using Microsoft.Extensions.Diagnostics.HealthChecks;
using U2.LoggerSvc.RestApiClient;
using U2.LoggerSvc.RestApiClient.Tests;
using Xunit;

namespace U2.LoggerSvc.RestApiClient.Tests.v1.Controllers;

[Collection(DatabaseCollection.Name)]
public sealed class HealthTests
{
	[Fact]
	public async Task GetHealthShouldBeOkay()
	{
		await using var context = new ApiIntegrationContext();
		var client = context.HttpClient;
		using var restClient = new U2LoggerSvcRestApiClient(client);
		var health = await restClient.GetHealthAsync(CancellationToken.None);
		Assert.Equal(HealthStatus.Healthy.ToString(), health.Status);
	}

}
