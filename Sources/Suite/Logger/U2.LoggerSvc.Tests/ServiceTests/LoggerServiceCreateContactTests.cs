using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using U2.LoggerSvc.Data;
using U2.LoggerSvc.Core;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.LoggerSvc.Tests.ServiceTests;

public class LoggerServiceCreateContactTests : LoggerServiceTestsBase
{
    [Fact]
    public async Task CanCreateContact()
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        SetupLoggerDbContext();

        var service = new LoggerService(_dbContext.Object);

        var entries = await service.GetContactsAsync(cancellationToken);
        Assert.Empty(entries);

        var contact = new Contact();
        await service.CreateAsync(contact, cancellationToken);

        // re-setup the mocked object
        _contacts.Add(ut8uuContact);
        SetupLoggerDbContext();

        entries = await service.GetContactsAsync(cancellationToken);
        Assert.NotEmpty(entries);
    }

    [Fact]
    public async Task ThrowsErrorOnNullContact()
    {
        _contacts.Clear();
        SetupLoggerDbContext();

        var service = new LoggerService(_dbContext.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () 
            => await service.CreateAsync(null, new CancellationToken()));
    }

}
