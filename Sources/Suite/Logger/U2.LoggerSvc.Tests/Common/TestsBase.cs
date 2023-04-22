using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Contracts;
using U2.Core;
using U2.LoggerSvc.Core;

namespace U2.LoggerSvc.Tests;

public abstract class TestsBase
{
    protected static Contact GetContact(
        string call = "UT8UU",
        RadioBand? band = null,
        string country = "Ukraine",
        int cqZone = 16,
        DateTime? dateTimeOn = null,
        DateTime? dateTimeOff = null,
        int dxcc = 1,
        decimal frequency = 10.15M,
        decimal frequencyRx = 10.155M,
        string gridSquare = "KO50",
        decimal lat = 50.3M,
        decimal lon = -30.5M,
        RadioMode? mode = null,
        string name = "Alex",
        string myName = "Sergey",
        string operatorName = "Sergey Usmanov")
    {
        var contact = new Contact
        {
            Call = call,
            Band = band ?? new Band10M(),
            BandRx = band ?? new Band10M(),
            Continent = Continent.Europe,
            Country = country,
            Cqz = cqZone,
            DateTimeOff = dateTimeOff ?? DateTime.UtcNow,
            DateTimeOn = dateTimeOn ?? DateTime.UtcNow,
            Dxcc = dxcc,
            Frequency = frequency,
            FrequencyRx = frequencyRx,
            Gridsquare = gridSquare,
            Iota = "EU-001",
            IotaIslandId = "GB",
            IsRunQso = true,
            Ituz = 29,
            Lat = lat,
            Lon = lon,
            Mode = mode ?? new RadioModeCW(),
            MyCity = "Kyiv",
            MyCountry = "Ukraine",
            MyCqZone = 16,
            MyGridsquare = "KK50",
            MyItuZone = 33,
            MyLat = 51.23M,
            MyLon = -20.23M,
            MyName = myName,
            Name = name,
            Operator = operatorName,
            Propagation = "MS",
            QrzId = "a1s2d3",
            RstRcvd = "599",
            RstSent = "579",
            SatMode = "UV",
            SatName = "SO-50",
            UniqueId = Guid.NewGuid(),
        };
        return contact;
    }
}
