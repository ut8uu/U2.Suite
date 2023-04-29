namespace U2.Logger.WebApp;

#nullable disable

public class CisCallInfo
{
	public int Id { get; set; }
	public string Call { get; set; }
	public string Aliases { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public IEnumerable<CallInfoRow> GetCallInfoRows()
	{
		return new List<CallInfoRow>
		{
			new CallInfoRow("General Info", string.Empty, isCaption: true),
			new CallInfoRow("Call", Call),
			new CallInfoRow("Aliases", Aliases),
			new CallInfoRow("First Name", FirstName),
			new CallInfoRow("Last Name", LastName),
		};
	}
}