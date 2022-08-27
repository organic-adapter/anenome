using Anenome.Business.Blocks;

namespace Anenome.Business.UlFormat
{
	/// <summary>
	/// VOLATILE:
	/// Handles unfamiliar format 
	/// - id
	/// - type
	///   - sub1
	///     -sub1ofsub1
	/// Swap out if we find a good converter/mapper/serializer.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class UlFormatter : IAnenomeFormatter
	{
		#region can be configured

		/*
		 * Items in this area can be extended or changed by injecting
		 * a configuration to tweak the details.
		*/

		private readonly char depthIndent = ' ';
		private readonly int depthIndentCount = 2;
		private readonly string propertyNotation = "- {0}\r\n";
		private readonly Dictionary<PropertySort, Func<Block, Dictionary<string, Block?>>> sortPropsBy = new();

		#endregion can be configured

		public UlFormatter()
		{
			sortPropsBy.Add(PropertySort.Unknown, Unhandled);
			sortPropsBy.Add(PropertySort.Custom, Unhandled);

			sortPropsBy.Add(PropertySort.Alphabetical, SortPropsAlphabetically);
			sortPropsBy.Add(PropertySort.UsingSource, MaintainPropOrder);
		}
		public string Format(Block block, PropertySort sort, string appendTo, int currentDepth = 0)
		{
			var props = sortPropsBy[sort](block);
			foreach (var prop in props)
			{
				appendTo += AddProp(currentDepth, prop.Key);
				if (prop.Value != null)
					appendTo = Format(prop.Value, sort, appendTo, currentDepth + 1);
			}
			return appendTo;
		}

		/// <summary>
		/// E.G.
		/// - type
		/// or
		///   - id
		/// </summary>
		/// <param name="depth"></param>
		/// <param name="propName"></param>
		/// <returns></returns>
		private string AddProp(int depth, string propName)
		{
			var depthIndentation = new string(depthIndent, depth * depthIndentCount);
			var property = string.Format(propertyNotation, propName);
			return $"{depthIndentation}{property}";
		}

		private Dictionary<string, Block?> MaintainPropOrder(Block block)
		{
			return block.Properties;
		}

		private Dictionary<string, Block?> SortPropsAlphabetically(Block block)
		{
			return block.Properties.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
		}

		private Dictionary<string, Block?> Unhandled(Block block)
		{
			throw new UnhandledPropertySort();
		}

		public class UnhandledPropertySort : Exception
		{
			public UnhandledPropertySort() : base("The PropertySort value used is unhandled.")
			{
			}
		}
	}
}