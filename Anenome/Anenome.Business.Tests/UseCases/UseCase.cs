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