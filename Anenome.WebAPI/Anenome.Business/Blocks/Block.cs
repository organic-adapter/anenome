namespace Anenome.Business.Blocks
{
	public class Block
	{
		public static Block? Blank = null;
		public Dictionary<string, Block?> Properties = new();

		public override bool Equals(object? obj)
		{
			var block = obj as Block;

			if (block == null)
				return false;
			if (base.Equals(obj))
				return true;
			if (block.Properties.Count != Properties.Count)
				return false;

			return Properties.All(kvp =>
			{
				if (!block.Properties.ContainsKey(kvp.Key))
					return false;

				var blockValue = block.Properties[kvp.Key];
				if (blockValue == Blank && kvp.Value == Blank)
					return true;

				return blockValue?.Equals(kvp.Value) ?? false;
			});
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}