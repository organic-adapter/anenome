// See https://aka.ms/new-console-template for more information
using Anenome.Business;
using Anenome.Business.Parenthesis;
using Anenome.Business.UlFormat;
using Anenome.CLI.Messages;
using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection();
service.AddTransient<IParenthesesTokenizer, ParenthesisToBlockTokenizer>();
service.AddTransient<IAnenomeFormatter, UlFormatter>();
service.AddTransient<IAnenomeMapper, PathOfLeastResistanceMapper>();

var provider = service.BuildServiceProvider();
var mapper = provider.GetService<IAnenomeMapper>();
if (mapper == null)
	throw new Exception("Could not find IAnenomeMapper");
Console.WindowHeight = 40;

Console.WriteLine("Core Use Case:");
Console.WriteLine(Message.LoadFromFile("core-use-case-message"));
Console.WriteLine(string.Empty);
Console.WriteLine("Doing magic...");

var useCase = Message.LoadFromFile("core-use-case");

Console.WriteLine(string.Empty);
Console.WriteLine("------------Source Sorted Output-----------");

var sourceSorted = mapper.Map(useCase, PropertySort.UsingSource);
Console.WriteLine(sourceSorted);

Console.WriteLine(string.Empty);
Console.WriteLine("------------Properties Alphabetized Output-----------");
var alphaSorted = mapper.Map(useCase, PropertySort.Alphabetical);
Console.WriteLine(alphaSorted);

Console.Write("For more magic, paste any other variation that follows the same pattern: ");
var line = Console.ReadLine();
Console.Clear();
Console.WriteLine(line);

Console.WriteLine(string.Empty);
Console.WriteLine("------------Source Sorted Output-----------");

sourceSorted = mapper.Map(line, PropertySort.UsingSource);
Console.WriteLine(sourceSorted);

Console.WriteLine(string.Empty);
Console.WriteLine("------------Properties Alphabetized Output-----------");
alphaSorted = mapper.Map(line, PropertySort.Alphabetical);
Console.WriteLine(alphaSorted);