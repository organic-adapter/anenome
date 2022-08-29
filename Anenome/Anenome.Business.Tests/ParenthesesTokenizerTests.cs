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
		[Fact]
		public void Can_Tokenize_Single_Property_Blocks()
		{
			var source = UseCase.LoadFromFile("edge-case-last-node-nested");
			var expected = UseCase.LastNodeNestedBlock();

			var blocks = tokenizer.Tokenize(source);
			Assert.Equal(expected, blocks);
		}
		[Fact]
		public void Can_Tokenize_Multiple_Properties_With_Blocks()
		{
			var source = UseCase.LoadFromFile("single-property-blocks");
			var expected = UseCase.SinglePropertyBlocks();

			var blocks = tokenizer.Tokenize(source);
			Assert.Equal(expected, blocks);
		}
	}
}