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
            //Dxcc = 
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
