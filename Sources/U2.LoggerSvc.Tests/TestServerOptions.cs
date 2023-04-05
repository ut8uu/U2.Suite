using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using U2.Tests.Common.Common;

namespace U2.LoggerSvc.Tests;

public sealed partial class ApiIntegrationContext
{
    internal sealed class TestServerOptions : ServerOptionsBase
    {
        private readonly IEnumerable<IReadOnlyDictionary<string, string>> _configurations;

        public Action<IServiceCollection> MockServices { get; set; } = null!;

        public TestServerOptions(
            IEnumerable<IReadOnlyDictionary<string, string>> configurations)
        {
            _configurations = configurations;
        }

        public override void Setup(IWebHostBuilder builder)
        {
            builder.UseTestServer();
            builder.ConfigureLogging(loggingBuilder => loggingBuilder.ClearProviders());

            builder.ConfigureServices(services =>
            {
            });

            if (MockServices != null)
            {
            }
        }

        public override void BuildConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            foreach (var configuration in _configurations)
            {
                builder.AddInMemoryCollection(configuration);
            }
        }
    }
}
