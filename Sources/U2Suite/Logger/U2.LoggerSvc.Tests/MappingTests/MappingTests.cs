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

namespace U2.LoggerSvc.Tests;

public class MappingTests : TestsBase
{
    [Fact]
    public void CanMapContactToLogEntry()
    {
        var contact = GetContact();
        var entry = contact.ToLogEntry();
        var contact2 = entry.ToContact();
        contact.ShouldDeepEqual(contact2);
    }

    [Fact]
    public void CanMapContactToContactDto()
    {
        var contact = GetContact();
        var contactDto = contact.ToContactDto();
        var contact2 = contactDto.ToContact();
        contact.WithDeepEqual(contact2)
            .IgnoreProperty<Contact>(x => x.IsRunQso)
            .Assert();
    }
}
