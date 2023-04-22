using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Moq;
using Newtonsoft.Json.Linq;
using U2.LoggerSvc.Api.Controllers.v1;
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

        await controller.Create(testData, new CancellationToken());
        var entries = await _loggerService.GetContactsAsync(new CancellationToken());
        Assert.Single(entries);
    }

    [Fact]
    public async Task CanDeleteExistingContact()
    {
        _contacts.Clear();
        _contacts.Add(GetContact());
        var controller = await CreateControllerAsync();

        var token = new CancellationToken();
        var entries = await _loggerService.GetContactsAsync(token);
        var entry = entries.Single();

        await controller.Delete(entry.Id, token);
        entries = await _loggerService.GetContactsAsync(token);
        Assert.Empty(entries);
    }

    [Fact]
    public async Task ShouldFailOnNonExistingId()
    {
        _contacts.Clear();
        var controller = await CreateControllerAsync();

        var token = new CancellationToken();
        var response = await controller.Delete(NonExistentId, token);
        Assert.IsType<NotFoundObjectResult>(response);
    }

}