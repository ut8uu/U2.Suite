using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using U2.LoggerSvc.Data;
using U2.LoggerSvc.Core;

namespace U2.LoggerSvc.Tests;

public abstract class LoggerServiceTestsBase
{
    protected readonly Contact ut8uuContact = new Contact
    {
        Call = "UT8UU",
        DateTimeOn = DateTime.UtcNow.AddYears(-1),
        DateTimeOff = DateTime.UtcNow.AddYears(-1),
        UniqueId = Guid.NewGuid(),
    };

    protected readonly List<Contact> _contacts = new();
    protected readonly Mock<ILoggerDbContext> _dbContext;

    public LoggerServiceTestsBase()
    {
        _dbContext = new Mock<ILoggerDbContext>();
    }

    protected void SetupLoggerDbContext()
    {
        _dbContext.Setup(_ => _.AddLogEntryAsync(It.IsAny<LogEntry>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var entries = _contacts.Select(_ => _.ToLogEntry());
        _dbContext.Setup(_ => _.GetLogEntriesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(entries));
    }
}
