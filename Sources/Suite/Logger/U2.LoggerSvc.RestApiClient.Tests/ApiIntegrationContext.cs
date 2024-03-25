using System.Net.Http.Formatting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using U2.Tests.Common.IO;

namespace U2.LoggerSvc.RestApiClient.Tests;

internal class ApiIntegrationContext : IAsyncDisposable
{
	private sealed class DelegatedDefaultValueProvider : DefaultValueProvider
	{
		private readonly Func<object> _provider;

		public DelegatedDefaultValueProvider(Func<object> provider) => _provider = provider;

		protected override object GetDefaultValue(Type type, Mock mock) => _provider();
	}

	private readonly IHost _host;
	private readonly TemporaryDirectory _temporaryDirectory = TemporaryDirectory.Create();

	public ApiIntegrationContext() : this(_ => { })
	{
	}

	public ApiIntegrationContext(Action<IServiceCollection> mockServices)
		: this(mockServices, configurations: Enumerable.Empty<IReadOnlyDictionary<string, string>>())
	{
	}

	public ApiIntegrationContext(
		Action<IServiceCollection> mockServices,
		IEnumerable<IReadOnlyDictionary<string, string>> configurations)
	{
		var server = new LoggerSvcTestWebServer
		{
			Configurations = new[] { defaultConfiguration }.Concat(configurations),
			MockServices = (services) =>
			{
				var bpHubClientFactoryMock = new Mock<IBPHubSvcClientFactory>(MockBehavior.Strict);
				bpHubClientFactoryMock.Setup(_ => _.Create())
					.Returns(BPHubClientMock.Object);
				services.AddTransient(_ => bpHubClientFactoryMock.Object);

				var processorClientFactoryMock = new Mock<IProcessorSvcClientFactory>(MockBehavior.Strict);
				processorClientFactoryMock.Setup(_ => _.Create())
					.Returns(ProcessorClientMock.Object);
				services.AddTransient(_ => processorClientFactoryMock.Object);

				mockServices?.Invoke(services);
			},
		};

		_host = HostFactory.Create(new CreateHostOptions(), server);
		_host.Start();

		HttpClient = _host.GetTestServer().CreateClient();
	}

	public async ValueTask DisposeAsync()
	{
		await _host.StopAsync();
		await _host.WaitForShutdownAsync();
		_host.Dispose();

		_temporaryDirectory.Dispose();
	}

	public JsonMediaTypeFormatter DefaultJsonFormatter { get; } =
		new JsonMediaTypeFormatter
		{
			SerializerSettings = new JsonSerializerSettings
			{
				ContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new CamelCaseNamingStrategy()
				},
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore,
			}
		};

	public HttpClient HttpClient { get; }

	public IServiceProvider Services => _host.Services;

}
