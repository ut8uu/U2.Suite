using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Contracts;
using U2.Core;
using U2.LoggerSvc.Core;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.LoggerSvc.Tests.MappingTests;

public class ContactToLogEntryMappingTests
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
            //Dxcc = 
        };
        return contact;
    }

    [Fact]
    public void CanMapEmptyContact()
    {
        var contact = GetSampleContact();
        var entry = contact.ToLogEntry();

        Assert.NotNull(entry);
    }
}
