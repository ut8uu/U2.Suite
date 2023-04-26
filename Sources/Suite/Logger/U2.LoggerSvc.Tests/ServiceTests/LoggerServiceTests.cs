using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using U2.LoggerSvc.ApiTypes;
using U2.LoggerSvc.ApiTypes.v1;
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
        var parameters = new LoggerFilteringSearchingPaginationParameters();

        var entries = await service.GetContactsAsync(parameters, cancellationToken);
        Assert.NotEmpty(entries);
    }

    [Theory]
    [InlineData(false, "ZA1UU")]
    [InlineData(true, "UT2UU")]
    public async Task CanSortContactsByCall(bool ascending, string expectedCall)
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        _contacts.Add(GetContact(call: "ZA1UU"));
        _contacts.Add(GetContact(call: "UT8UU"));
        _contacts.Add(GetContact(call: "UT2UU"));
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);
        var parameters = new LoggerFilteringSearchingPaginationParameters
        {
            SortingParameters = new U2.Core.SortingParameters
            {
                Ascending = ascending,
                SortBy = (int)LoggerSortByField.Call,
            },
        };

        var entries = await service.GetContactsAsync(parameters, cancellationToken);
        Assert.Equal(3, entries.Count());
        var entry1 = entries.First();
        Assert.Equal(expectedCall, entry1.Call);
    }

    [Theory]
    [InlineData(0, 1, "UT2UU")]
    [InlineData(1, 1, "UT8UU")]
    [InlineData(1, 2, "ZA1UU")]
    public async Task CanPaginateContactsByCall(int pageIndex, int pageSize, string expectedCall)
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        _contacts.Add(GetContact(call: "ZA1UU"));
        _contacts.Add(GetContact(call: "UT8UU"));
        _contacts.Add(GetContact(call: "UT2UU"));
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);
        var parameters = new LoggerFilteringSearchingPaginationParameters
        {
            SortingParameters = new U2.Core.SortingParameters
            {
                Ascending = true,
                SortBy = (int)LoggerSortByField.Call,
            },
            PaginationParameters = new U2.Core.PaginationParameters
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
            },
        };

        var entries = await service.GetContactsAsync(parameters, cancellationToken);
        Assert.True(pageSize >= entries.Count());
        var entry1 = entries.First();
        Assert.Equal(expectedCall, entry1.Call);
    }

    [Fact]
    public async Task ServiceCanAddContact()
    {
        CancellationToken cancellationToken = new();
        _contacts.Clear();
        await SetupLoggerDbContext();

        var service = new LoggerService(_dbContext);
        var parameters = new LoggerFilteringSearchingPaginationParameters();

        var entries = await service.GetContactsAsync(parameters, cancellationToken);
        Assert.Empty(entries);

        var contact = GetContact();
        var id = await service.CreateContactAsync(contact, cancellationToken);
        Assert.Equal(1, id);
        entries = await service.GetContactsAsync(parameters, cancellationToken);

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
        var parameters = new LoggerFilteringSearchingPaginationParameters();

        var entries = await service.GetContactsAsync(parameters, cancellationToken);
        var contact = entries.Single();

        await service.DeleteContactAsync(contact.Id, cancellationToken);
        entries = await service.GetContactsAsync(parameters, cancellationToken);
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
        var parameters = new LoggerFilteringSearchingPaginationParameters();

        var entries = await service.GetContactsAsync(parameters, cancellationToken);
        var contact = entries.Single();
        contact.Call = "UT3UBR";

        await service.UpdateContactAsync(contact, cancellationToken);
        entries = await service.GetContactsAsync(parameters, cancellationToken);
        contact = entries.Single();
        Assert.Equal("UT3UBR", contact.Call);
    }
}
