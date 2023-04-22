using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using U2.LoggerSvc.Core;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.LoggerSvc.Tests;

public class LoggerServiceTests : LoggerTestsBase
{
    [Fact]
    public async Task ServiceCanListContacts()
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        _contacts.Add(GetContact());
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);

        var entries = await service.GetContactsAsync(cancellationToken);
        Assert.NotEmpty(entries);
    }

    [Fact]
    public async Task ServiceCanAddContact()
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);

        var entries = await service.GetContactsAsync(cancellationToken);
        Assert.Empty(entries);

        var contact = GetContact();
        var id = await service.CreateContactAsync(contact, cancellationToken);
        Assert.Equal(1, id);
        entries = await service.GetContactsAsync(cancellationToken);

        var contact2 = entries.Single();
        contact.WithDeepEqual(contact2).IgnoreProperty<Contact>(x => x.Id).Assert();
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
    [Fact]
    public async Task ServiceCanDeleteContact()
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        _contacts.Add(GetContact());
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);

        var entries = await service.GetContactsAsync(cancellationToken);
        var contact = entries.Single();

        await service.DeleteContactAsync(contact.Id, cancellationToken);
        entries = await service.GetContactsAsync(cancellationToken);
        Assert.Empty(entries);
    }

    [Fact]
    public async Task ServiceCanUpdateContact()
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        _contacts.Add(GetContact());
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);

        var entries = await service.GetContactsAsync(cancellationToken);
        var contact = entries.Single();
        contact.Call = "UT3UBR";

        await service.UpdateContactAsync(contact, cancellationToken);
        entries = await service.GetContactsAsync(cancellationToken);
        contact = entries.Single();
        Assert.Equal("UT3UBR", contact.Call);
    }
}
