namespace Anenome.Contracts
{
	/// <summary>
	/// Forces the developer to always have the same properties despite annotating them differently in inherited classes.
	/// Reduces mapping errors.
	/// This can be done in a couple ways. I prefer explicit contracts that will fail during compile time.
	/// 
	/// </summary>
	public class Contact
	{
		public virtual string Email { get; set; } = string.Empty;

		/// <summary>
		/// String for type safety (though it is probably an int)
		/// </summary>
		public virtual string Id { get; set; } = string.Empty;

		public virtual string Name { get; set; } = string.Empty;
		public virtual ContactType Type { get; set; } = ContactType.Empty;
	}
}