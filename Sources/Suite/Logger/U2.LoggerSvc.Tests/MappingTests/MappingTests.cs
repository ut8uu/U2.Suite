using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using U2.Contracts;
using U2.Core;
using U2.LoggerSvc.Core;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.LoggerSvc.Tests.MappingTests;

public class MappingTests
{
    private static Contact GetSampleContact()
    {
        var contact = new Contact
        {
            Call = "UT8UU",
            Band = new Band10M(),
            BandRx = new Band10M(),
            Continent = Continent.Europe,
            Country = "Ukraine",
            Cqz = 16,
            DateTimeOff = DateTime.UtcNow,
            DateTimeOn = DateTime.UtcNow,
            Dxcc = 1,
            Frequency = 10.150M,
            FrequencyRx = 10.155M,
            Gridsquare = "KO50",
            Iota = "EU-001",
            IotaIslandId = "GB",
            IsRunQso = false,
            Ituz = 29,
            Lat = 50.3M,
            Lon = -30.5M,
            Mode = new RadioModeCW(),
            MyCity = "Kyiv",
            MyCountry = "Ukraine",
            MyCqZone = 16,
            MyGridsquare = "KK50",
            MyItuZone = 33,
            MyLat = 51.23M,
            MyLon = -20.23M,
            MyName = "Sergey",
            Name = "Alex",
            Operator = "Sergey Usmanov",
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

    [Fact]
    public void CanMapContactToLogEntry()
    {
        var contact = GetSampleContact();
        var entry = contact.ToLogEntry();
        var contact2 = entry.ToContact();
        contact.ShouldDeepEqual(contact2);
    }

    [Fact]
    public void CanMapContactToContactDto()
    {
        var contact = GetSampleContact();
        var contactDto = contact.ToContactDto();
        var contact2 = contactDto.ToContact();
        contact.ShouldDeepEqual(contact2);
    }
}
