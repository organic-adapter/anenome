namespace Anenome.Business
{
	//If we want to extend the concept of sorting further, just overload Convert methods with a
	//property sort delegate as a parameter.
	public enum PropertySort
	{
		Unknown = 0,
		Alphabetical = 1,
		UsingSource = 2,
		Custom = 3, //An example of overengineering. I don't need a custom version.
	}
}