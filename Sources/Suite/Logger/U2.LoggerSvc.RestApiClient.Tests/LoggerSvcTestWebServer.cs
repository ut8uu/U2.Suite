using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using U2.Core.Factories;
using U2.LoggerSvc.Core;

namespace U2.LoggerSvc.RestApiClient.Tests;

public sealed class LoggerSvcTestWebServer : ServerOptionsBase
{
	public LoggerSvcTestWebServer()
	{
	}

	public override void Setup(IWebHostBuilder builder)
	{
		builder.UseTestServer();
		builder.ConfigureServices(services =>
		{
		});

		if (MockServices != null)
		{
			builder.ConfigureServices(MockServices);
		}
	}

	public IEnumerable<IReadOnlyDictionary<string, string>> Configurations { get; init; }

	public Action<IServiceCollection> MockServices { get; init; }

	public override void BuildConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
	{
		foreach (var configuration in Configurations)
		{
			builder.AddInMemoryCollection(configuration);
		}
	}
}
