﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
//using U2.Core.Factories;
using U2.Tests.Common.IO;

namespace U2.LoggerSvc.Tests;

public partial class ApiIntegrationContext : IAsyncDisposable
{
    private readonly IHost _host = null;
    private readonly TemporaryDirectory _testDirectory = TemporaryDirectory.Create();
    public HttpClient HttpClient { get; }


    public JsonMediaTypeFormatter DefaultJsonFormatter => new JsonMediaTypeFormatter
    {
        SerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        }
    };

    public ApiIntegrationContext() :
        this(null!, null!)
    {
    }

    public ApiIntegrationContext(
        Action<IServiceCollection> mockServices) :
        this(mockServices, null!)
    {
    }

    public ApiIntegrationContext(
        IDictionary<string, string> configurationValues) :
        this(null!, configurationValues)
    {
    }

    public ApiIntegrationContext(
        Action<IServiceCollection> mockServices,
        IDictionary<string, string> configurationValues)
    {
        var configuration = new Dictionary<string, string>
        {
        };

        var serverOptions = new TestServerOptions(
            new[] { configuration, (IReadOnlyDictionary<string, string>)configurationValues })
        {
            MockServices = mockServices
        };

        //_host = HostFactory.Create(new CreateHostOptions(), serverOptions);
        //var svc = _host.Services.GetRequiredService<IMapper>();
        //svc.ConfigurationProvider.AssertConfigurationIsValid();
        //_host.Start();

        //HttpClient = _host.GetTestServer().CreateClient();
    }

    public async ValueTask DisposeAsync()
    {
        await _host.StopAsync();
        await _host.WaitForShutdownAsync();
        _host.Dispose();

        _testDirectory.Dispose();
    }

    public IServiceProvider Services => _host.GetTestServer().Services;
}
