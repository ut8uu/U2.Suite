using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.CIS.Core;

#nullable disable

/// <summary>
/// Represents a call information object.
/// </summary>
public sealed class CallInfo
{
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
}
