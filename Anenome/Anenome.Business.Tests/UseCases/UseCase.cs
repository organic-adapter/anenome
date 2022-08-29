using Anenome.Business.Blocks;

namespace Anenome.Business.Tests.UseCases
{
	internal static class UseCase
	{
		internal static Block DefaultCustomFieldsBlock()
		{
			var returnMe = new Block();

			returnMe.Properties.Add("c1", Block.Blank);
			returnMe.Properties.Add("c2", Block.Blank);
			returnMe.Properties.Add("c3", Block.Blank);

			return returnMe;
		}
		internal static Block NestWith(this Block block, string name)
		{
			var nestMe = new Block();
			block.Properties.Add(name, nestMe);
			return nestMe;
		}
		internal static Block With(this Block block, string name)
		{
			block.Properties.Add(name, Block.Blank);
			return block;
		}
		internal static Block LastNodeNestedBlock()
		{
			var returnMe = new Block();

			returnMe
				.NestWith("a")
					.NestWith("b")
						.NestWith("c")
							.With("d");

			return returnMe;
		}

		internal static Block DefaultRootBlock()
		{
			var returnMe = new Block();
			returnMe.Properties.Add("id", Block.Blank);
			returnMe.Properties.Add("name", Block.Blank);
			returnMe.Properties.Add("email", Block.Blank);
			returnMe.Properties.Add("type", DefaultTypeBlock());
			returnMe.Properties.Add("externalId", Block.Blank);
			return returnMe;
		}

		internal static Block DefaultTypeBlock()
		{
			var returnMe = new Block();

			returnMe.Properties.Add("id", Block.Blank);
			returnMe.Properties.Add("name", Block.Blank);
			returnMe.Properties.Add("customFields", DefaultCustomFieldsBlock());

			return returnMe;
		}

		internal static string LoadFromFile(string useCaseName)
		{
			var rootPath = AppDomain.CurrentDomain.BaseDirectory;
			var filePath = Path.Combine(rootPath, $"UseCases/{useCaseName}.txt");
			return File.ReadAllText(filePath);
		}
	}
}