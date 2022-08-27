using Anenome.Contracts;

namespace Anenome.WebAPI.Models
{
	/// <summary>
	/// Arbitrary sort: by developer whim though typical for SQL databases.
	/// </summary>
	public class ContactBeta : Contact
	{
		/// <summary>
		/// String for type safety (though it is probably an int)
		/// </summary>
		public override string Id { get; set; } = string.Empty;
		public override string Name { get; set; } = string.Empty;
		public override string Email { get; set; } = string.Empty;
	}
}
