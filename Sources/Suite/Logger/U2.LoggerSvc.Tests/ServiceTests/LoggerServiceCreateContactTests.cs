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
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);

        var entries = await service.GetContactsAsync(cancellationToken);
        Assert.Empty(entries);

        var contact = GetContact();
        await service.CreateContactAsync(contact, cancellationToken);

        entries = await service.GetContactsAsync(cancellationToken);
        Assert.NotEmpty(entries);
    }

    [Fact]
    public async Task ThrowsErrorOnNullContact()
    {
        _contacts.Clear();
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);

        await Assert.ThrowsAsync<ArgumentNullException>(async () 
            => await service.CreateContactAsync(null, new CancellationToken()));
    }

}
