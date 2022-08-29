using Anenome.Business.Blocks;

namespace Anenome.Business.Parenthesis
{
	public class ParenthesisToBlockTokenizer : IParenthesesTokenizer
	{
		private const char blockEndDelimiter = ')';
		private const char blockStartDelimiter = '(';
		private const int notFound = -1;
		private const char propertyDelimiter = ',';
		private readonly int blockPadding = "()".Length;

		public Dictionary<string, Block?> GetBlockProperties(string block)
		{
			var blockProperties = new Dictionary<string, Block?>();
			var endOfBlock = block.Length - 1;

			var propertyStart = notFound;
			//OPTIMIZATIONS: Cyclomatic complexity is high in this area. Difficult to read as well.
			for (var i = 0; i <= endOfBlock; i++)
			{
				var focus = block[i];
				if(!block.Contains(propertyDelimiter) && !block.Contains(blockStartDelimiter))
				{
					blockProperties.Add(block, Block.Blank);
				}
				else if (focus.Equals(blockStartDelimiter))
				{
					var propertyName = block.Substring(propertyStart, i - propertyStart).Trim();
					var nestedBlockStart = i;

					var rawBlock = FindChildBlock(block, nestedBlockStart);
					var nestedProperties = GetBlockProperties(rawBlock);

					blockProperties.Add(propertyName, new Block() { Properties = nestedProperties });
					i += rawBlock.Length + blockPadding;
					propertyStart = notFound;
				}
				else if (focus.Equals(propertyDelimiter))
				{
					var propertyName = block.Substring(propertyStart, i - propertyStart).Trim();
					blockProperties.Add(propertyName, Block.Blank);
					propertyStart = notFound;
				}
				else if (i == endOfBlock && propertyStart != notFound)
				{
					var propertyName = block.Substring(propertyStart, i - propertyStart + 1).Trim();
					blockProperties.Add(propertyName, Block.Blank);
				}
				else if (propertyStart == notFound)
				{
					propertyStart = i;
				}
			}

			return blockProperties;
		}

		public Block Tokenize(string value)
		{
			var rootBlock = new Block();

			var rawRoot = ExtractRoot(value);
			rootBlock.Properties = GetBlockProperties(rawRoot);

			return rootBlock;
		}

		private string ExtractRoot(string value)
		{
			return FindChildBlock(value);
		}

		/// <summary>
		/// This will only return the next block it finds in a string
		/// </summary>
		/// <param name="value"></param>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		private string FindChildBlock(string value, int startIndex = 0)
		{
			var blockStart = notFound;
			var blockEnd = notFound;
			var blockLevels = 0;
			for (var i = startIndex; i < value.Length; i++)
			{
				var focus = value[i];
				if(focus.Equals(blockStartDelimiter))
					blockLevels++;

				if (blockStart == notFound && focus.Equals(blockStartDelimiter))				
					blockStart = i;				
				else if (focus.Equals(blockEndDelimiter))
				{
					blockEnd = i;
					blockLevels--;
					if (blockLevels == 0)
						break;
				}
			}
			if (blockStart == blockEnd)
				return string.Empty;

			return value.Substring(blockStart + 1, blockEnd - blockStart - 1);
		}
	}
}