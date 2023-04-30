using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.CIS.Core;

namespace U2.CIS.Tests;

public abstract class TestsBase
{
    public static CallInfo GetCallInfo(
        string addressLine1 = "line1",
		string addressLine2 = "line2",
		string aliases = "aliases",
		string call = "call",
		string country = "country",
		int? cqZone = 16,
		string dxccCountry = "Ukraine",
		string email = "email@gmail.com",
		string firstName = "Sergey",
		string gridLocator = "KO50",
		int id = 1,
		int? ituZone = 29,
		string lastName = "Usmanov",
		decimal? latitude = 50.2M,
		decimal? longitude = 30.3M,
		string qslManager = "none",
		string state = "KV",
		bool? usePaperQsl = true,
		bool? acceptsEqsl = true,
		bool? acceptsLotw = true,
		int? yearOfBirth = 1971,
		string zip = "01014")
	{
		var result = new CallInfo
        {
            AcceptsEqsl = acceptsEqsl,
            AcceptsLotw = acceptsLotw,
            AddressLine1 = addressLine1,
            AddressLine2 = addressLine2,
            Aliases = aliases,
            Call = call,
            Country = country,
            CqZone = cqZone,
            DxccCountry = dxccCountry,
            EMail = email,
            FirstName = firstName,
            GridLocator = gridLocator,
            Id = id,
            ItuZone = ituZone,
            LastName = lastName,
            Latitude = latitude,
            Longitude = longitude,
            QslManager = qslManager,
            State = state,
            UsesPaperQsl = usePaperQsl,
            YearOfBirth = yearOfBirth,
            ZIP = zip
        };
        return result;
    }
}
