using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anenome.CLI.Messages
{
	internal static class Message
	{
		internal static string LoadFromFile(string messageName)
		{
			var rootPath = AppDomain.CurrentDomain.BaseDirectory;
			var filePath = Path.Combine(rootPath, $"Messages/{messageName}.txt");
			return File.ReadAllText(filePath);
		}
	}
}
