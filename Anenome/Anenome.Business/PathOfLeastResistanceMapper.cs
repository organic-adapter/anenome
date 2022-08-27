using Anenome.Business.Parenthesis;

namespace Anenome.Business
{
	/// <summary>
	/// VOLATILITY: Unfamiliar input and output types.
	/// 
	/// If we find more research we should be able to swap this out fairly quickly
	/// with one that uses known maps from the input.
	/// </summary>
	public class PathOfLeastResistanceMapper : IAnenomeMapper
	{
		private readonly IAnenomeFormatter anenomeFormatter;
		private readonly IParenthesesTokenizer parenthesesTokenizer;

		public PathOfLeastResistanceMapper(IParenthesesTokenizer parenthesesTokenizer, IAnenomeFormatter anenomeConverter)
		{
			this.parenthesesTokenizer = parenthesesTokenizer;
			this.anenomeFormatter = anenomeConverter;
		}

		public string Map(string source, PropertySort sort)
		{
			var rootBlock = parenthesesTokenizer.Tokenize(source);
			return anenomeFormatter.Format(rootBlock, sort, string.Empty);
		}
	}
}