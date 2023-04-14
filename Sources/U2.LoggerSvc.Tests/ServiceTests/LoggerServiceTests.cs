using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using U2.Logger.Data;
using U2.LoggerSvc.Core;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.LoggerSvc.Tests.ServiceTests;

public class LoggerServiceTests
{
    private Contact ut8uuContact = new Contact();

    private static Mock<ILoggerDbContext> MockLoggerDbContext()
    {
        var context = new Mock<ILoggerDbContext>();
        context.Setup(_ => _.AddLogEntryAsync(It.IsAny<LogEntry>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        return context;
    }

    [Fact]
    public async Task CanCreateContact()
    {
        CancellationToken cancellationToken = new();
        var dbContextMock = MockLoggerDbContext();

        // this is to simulate empty database
        dbContextMock.Setup(_ => _.GetLogEntriesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new List<LogEntry>()));

        var service = new LoggerService(dbContextMock.Object);

        var entries = await service.GetContactsAsync(cancellationToken);
        Assert.Empty(entries);

        // this is to simulate empty database
        dbContextMock.Setup(_ => _.GetLogEntriesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new List<LogEntry>
            {
                ut8uuContact.ToLogEntry(),
            }));

        var contact = new Contact();
        await service.CreateAsync(contact, new CancellationToken());
        entries = await service.GetContactsAsync(cancellationToken);
        Assert.NotEmpty(entries);
    }
}
