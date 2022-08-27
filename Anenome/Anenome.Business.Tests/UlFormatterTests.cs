using Anenome.Business.Tests.UseCases;
using Anenome.Business.UlFormat;

namespace Anenome.Business.Tests
{
	public class UlFormatterTests
	{
		private readonly IAnenomeFormatter formatter;

		public UlFormatterTests()
		{
			formatter = new UlFormatter();
		}

		[Fact]
		public void Can_Convert_From_Blocks_Sorted_Alphabetical()
		{
			var root = UseCase.DefaultRootBlock();
			var expected = UseCase.LoadFromFile("ul-expected-alpha-sorted");

			var converted = formatter.Format(root, PropertySort.Alphabetical, string.Empty);
			Assert.Equal(expected, converted);
		}

		[Fact]
		public void Can_Convert_From_Blocks_Using_Source_Sorting()
		{
			var root = UseCase.DefaultRootBlock();
			var expected = UseCase.LoadFromFile("ul-expected-source-sorted");

			var converted = formatter.Format(root, PropertySort.UsingSource, string.Empty);
			Assert.Equal(expected, converted);
		}
	}
}