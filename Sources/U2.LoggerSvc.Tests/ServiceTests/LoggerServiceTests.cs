﻿using System;
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
    private readonly Contact ut8uuContact = new();

    private readonly List<Contact> _contacts = new();
    private readonly Mock<ILoggerDbContext> _dbContext;

    public LoggerServiceTests()
    {
        _dbContext = new Mock<ILoggerDbContext>();
    }

    private void SetupLoggerDbContext()
    {
        _dbContext.Setup(_ => _.AddLogEntryAsync(It.IsAny<LogEntry>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var entries = _contacts.Select(_ => _.ToLogEntry());
        _dbContext.Setup(_ => _.GetLogEntriesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(entries));
    }

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
        await service.CreateAsync(contact, new CancellationToken());

        // re-setup the mocked object
        _contacts.Add(ut8uuContact);
        SetupLoggerDbContext();

        entries = await service.GetContactsAsync(cancellationToken);
        Assert.NotEmpty(entries);
    }

}
