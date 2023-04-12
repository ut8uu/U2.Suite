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
using Microsoft.OpenApi.Models;
using U2.Core.Factories;
using U2.LoggerSvc.ApiTypes.v1;

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
                services.AddAutoMapper(typeof(LoggerSvcMappingProfile));
                services.AddControllers();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LoggerSvcTestServer", Version = "v1" });
                });
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
