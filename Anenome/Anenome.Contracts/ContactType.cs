namespace Anenome.Contracts
{
	public class ContactType
	{
		public static ContactType Empty = new();

		/// <summary>
		/// object for Type Safety
		/// </summary>
		public Dictionary<string, object> CustomFields { get; set; } = new ();

		/// <summary>
		/// String for type safety (though it is probably an int)
		/// </summary>
		public virtual string Id { get; set; } = string.Empty;

		public virtual string Name { get; set; } = string.Empty;
	}
}