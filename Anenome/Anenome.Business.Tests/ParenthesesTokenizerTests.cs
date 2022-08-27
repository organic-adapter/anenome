using Anenome.Business.Parenthesis;
using Anenome.Business.Tests.UseCases;

namespace Anenome.Business.Tests
{
	public class ParenthesesTokenizerTests
	{
		private IParenthesesTokenizer tokenizer;

		public ParenthesesTokenizerTests()
		{
			tokenizer = new ParenthesisToBlockTokenizer();
		}

		[Fact]
		public void Can_Tokenize_To_Blocks()
		{
			var source = UseCase.LoadFromFile("paren-source");
			var expected = UseCase.DefaultRootBlock();

			var blocks = tokenizer.Tokenize(source);
			Assert.Equal(expected, blocks);
		}
	}
}