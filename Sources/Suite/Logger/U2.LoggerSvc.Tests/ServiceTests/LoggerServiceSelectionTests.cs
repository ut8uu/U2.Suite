using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.LoggerSvc.Core;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.LoggerSvc.Tests;

public class LoggerServiceSelectionTests : LoggerServiceTestsBase
{
    [Fact]
    public async Task ServiceCanListContacts()
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        _contacts.Add(ut8uuContact);
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);

        var entries = await service.GetContactsAsync(cancellationToken);
        Assert.NotEmpty(entries);
    }
}
