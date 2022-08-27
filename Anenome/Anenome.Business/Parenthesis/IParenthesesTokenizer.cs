using Anenome.Business.Blocks;

namespace Anenome.Business.Parenthesis
{
	/// <summary>
	/// VOLATILE:
	/// Handles unfamiliar format (id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)
	/// Swap out when we find an existing serializer.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IParenthesesTokenizer
	{
		public Block Tokenize(string value);
	}
}