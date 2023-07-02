using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Moq;
using Newtonsoft.Json.Linq;
using U2.LoggerSvc.Api.Controllers.v1;
using U2.LoggerSvc.ApiTypes;
using U2.LoggerSvc.ApiTypes.v1;
using U2.LoggerSvc.Core;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.LoggerSvc.Tests.LoggerSvc.v1.Controllers;

public class LoggerControllerTests : LoggerTestsBase
{
    private const int NonExistentId = 1000;
    private LoggerService _loggerService;

    private async Task<LoggerController> CreateControllerAsync()
    {
        await SetupLoggerDbContext();
        _loggerService = new LoggerService(_dbContext);
        var controller = new LoggerController(_loggerService);
        return controller;
    }

    [Fact]
    public async Task CanCreateNewContact()
    {
        var controller = await CreateControllerAsync();
        var testData = GetContact();
        var parameters = new LoggerFilteringSearchingPaginationParameters();

        await controller.Create(testData, new CancellationToken());
        var entries = await _loggerService.GetContactsAsync(parameters, new CancellationToken());
        Assert.Single(entries);
    }

    [Fact]
    public async Task CanDeleteExistingContact()
    {
        _contacts.Clear();
        _contacts.Add(GetContact());
        var controller = await CreateControllerAsync();
        var parameters = new LoggerFilteringSearchingPaginationParameters();

        var token = new CancellationToken();
        var entries = await _loggerService.GetContactsAsync(parameters, token);
        var entry = entries.Single();

        await controller.Delete(entry.Id, token);
        entries = await _loggerService.GetContactsAsync(parameters, token);
        Assert.Empty(entries);
    }

    [Fact]
    public async Task ShouldFailDeletionOnNonExistingId()
    {
        _contacts.Clear();
        var controller = await CreateControllerAsync();

        var token = new CancellationToken();
        var response = await controller.Delete(NonExistentId, token);
        Assert.IsType<NotFoundObjectResult>(response);
    }

    [Fact]
    public async Task CanUpdateContact()
    {
        var newCall = "UT3UBR";

        _contacts.Clear();
        _contacts.Add(GetContact());
        var controller = await CreateControllerAsync();
        var parameters = new LoggerFilteringSearchingPaginationParameters();

        var token = new CancellationToken();
        var entries = await _loggerService.GetContactsAsync(parameters, token);
        var entry = entries.Single();
        entry.Call = newCall;

        var result = await controller.Update(entry.Id, entry.ToContactDto(), token);
        Assert.IsType<OkResult>(result);

        entries = await _loggerService.GetContactsAsync(parameters, token);
        entry = entries.Single();
        Assert.Equal(newCall, entry.Call);
    }

    [Fact]
    public async Task ShouldFailUpdateOnNonExistingId()
    {
        _contacts.Clear();
        _contacts.Add(GetContact());
        var controller = await CreateControllerAsync();

        var token = new CancellationToken();
        var contactDto = GetContact().ToContactDto();
        var result = await controller.Update(NonExistentId, contactDto, token);
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task CanListContacts()
    {
        _contacts.Clear();
        _contacts.Add(GetContact());
        var controller = await CreateControllerAsync();
        var parameters = new LoggerFilteringSearchingPaginationParameters();

        var token = new CancellationToken();
        var entries = await controller.List(
            parameters.SearchParameters, 
            parameters.LoggerFilteringParameters, 
            parameters.PaginationParameters,
            parameters.SortingParameters,
            token);
        Assert.IsType<OkObjectResult>(entries.Result);
        var value = (OkObjectResult)entries.Result;
        Assert.NotNull(value);
        Assert.NotNull(value.Value);
        var values = (IEnumerable<ContactDto>)value.Value;
        Assert.Single(values);
    }
}