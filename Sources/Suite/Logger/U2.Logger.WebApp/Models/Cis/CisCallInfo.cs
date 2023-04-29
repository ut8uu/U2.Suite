namespace U2.Logger.WebApp;

#nullable disable

public class CisCallInfo
{
	public int Id { get; set; }
	public string Call { get; set; }
	public string Aliases { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int? YearOfBirth { get; set; }
	public string EMail { get; set; }
	public string AddressLine1 { get; set; }
	public string AddressLine2 { get; set; }
	public string State { get; set; }
	public string DxccCountry { get; set; }
	public string Country { get; set; }
	public string ZIP { get; set; }
	public string GridLocator { get; set; }
	public decimal? Latitude { get; set; }
	public decimal? Longitude { get; set; }
	public int? CqZone { get; set; }
	public int? ItuZone { get; set; }
	public string QslManager { get; set; }

	public bool? AcceptsEqsl { get; set; }
	public bool? AcceptsLotw { get; set; }
	public bool? UsesPaperQsl { get; set; }

	public IEnumerable<CallInfoSection> GetCallInfoRows()
	{
		var result = new List<CallInfoSection>
		{
			new CallInfoSection("General Info")
			{
				new CallInfoRow("Call", Call),
				new CallInfoRow("Aliases", Aliases),
				new CallInfoRow("First Name", FirstName),
				new CallInfoRow("Last Name", LastName),
			},
			new CallInfoSection("Communications")
			{
				new CallInfoRow("e-mail", EMail),
			},
			new CallInfoSection("Address")
			{
				new CallInfoRow("Address Line 1", AddressLine1),
				new CallInfoRow("Address Line 2", AddressLine2),
				new CallInfoRow("State", State),
				new CallInfoRow("DXCC Country", DxccCountry),
				new CallInfoRow("Country", Country),
				new CallInfoRow("ZIP", ZIP),
			},
			new CallInfoSection("Location")
			{
				new CallInfoRow("Grid Locator", GridLocator),
				new CallInfoRow("Latitude", Latitude.HasValue ? Latitude.ToString() : string.Empty),
				new CallInfoRow("Longitude", Longitude.HasValue ? Longitude.ToString() : string.Empty),
				new CallInfoRow("CQ Zone", CqZone.HasValue ? CqZone.ToString() : string.Empty),
				new CallInfoRow("ITU Zone", ItuZone.HasValue ? ItuZone.ToString() : string.Empty),
			},
			new CallInfoSection("QSL")
			{
				new CallInfoRow("Accespts eQSL", BoolToYesNo(AcceptsEqsl)),
				new CallInfoRow("Accepts LoTW", BoolToYesNo(AcceptsLotw)),
				new CallInfoRow("Use Paper QSL", BoolToYesNo(UsesPaperQsl)),
			},
			new CallInfoSection("Other")
			{
				new CallInfoRow("QSL Manager", QslManager),
			},
		};

		return result;
	}

	private string BoolToYesNo(bool? value)
	{
		if (!value.HasValue)
		{
			return string.Empty;
		}

		return value.GetValueOrDefault(defaultValue: false) ? "Yes" : "No";
	}
}