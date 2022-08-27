namespace Anenome.Contracts
{
	public class ParenthesisMessage
	{
		public ParenthesisMessage(string value)
		{
			Value = value;
		}

		public string Value { get; set; } = string.Empty;
	}
}