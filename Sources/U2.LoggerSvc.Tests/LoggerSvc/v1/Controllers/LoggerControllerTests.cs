using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Moq;
using U2.Logger.Api.Controllers.v1;
using U2.LoggerSvc.Core;
using Xunit;
using Assert = Xunit.Assert;

namespace U2.LoggerSvc.Tests.LoggerSvc.v1.Controllers;

public class LoggerControllerTests
{
    private static Mock<ILoggerService> CreateLoggerServiceMock()
    {
        var service = new Mock<ILoggerService>();
        service.Setup(_ => _.CreateAsync(It.IsAny<Contact>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(Guid.NewGuid()));
        return service;
    }

    private static LoggerController CreateController(ILoggerService service)
    {
        var controller = new LoggerController(service);
        return controller;
    }

    [Fact]
    public async Task CanCreateNewContact()
    {
        var service = CreateLoggerServiceMock();
        var controller = CreateController(service.Object);
        var testData = new Contact();

        await controller.Create(testData, new CancellationToken());
    }

}