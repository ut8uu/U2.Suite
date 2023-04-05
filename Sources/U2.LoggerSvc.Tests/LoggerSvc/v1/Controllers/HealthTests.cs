using Microsoft.Extensions.Diagnostics.HealthChecks;
using U2.LoggerSvc.RestApiClient;

namespace U2.LoggerSvc.Tests.LoggerSvc.v1.Controllers;

[TestClass]
public class HealthTests
{
    [TestMethod]
    public async Task HealthShouldBeOkay()
    {
        await using var context = new ApiIntegrationContext();
        var client = context.HttpClient;
        using var restClient = new U2LoggerSvcRestApiClient(client);
        var health = await restClient.GetHealthAsync(CancellationToken.None);
        Assert.Equals(HealthStatus.Healthy.ToString(), health.Status);
    }

}