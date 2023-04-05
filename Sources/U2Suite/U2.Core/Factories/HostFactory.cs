using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace U2.Core.Factories;

public static class HostFactory
{
    //
    // Summary:
    //     Creates the host.
    //
    // Parameters:
    //   options:
    //     Options used to configure Microsoft.Extensions.Hosting.IHostBuilder and Microsoft.AspNetCore.Hosting.IWebHostBuilder.
    //
    //   serverOptions:
    //     Options used to configure Microsoft.AspNetCore.Hosting.IWebHostBuilder.
    public static IHost Create(CreateHostOptionsBase options, ServerOptionsBase serverOptions)
    {
        return Create(Array.Empty<string>(), options, serverOptions);
    }

    //
    // Summary:
    //     Creates the host.
    //
    // Parameters:
    //   args:
    //     Pass '--service' argument to run as a Windows service.
    //
    //   options:
    //     Options used to configure Microsoft.Extensions.Hosting.IHostBuilder and Microsoft.AspNetCore.Hosting.IWebHostBuilder.
    //
    //   serverOptions:
    //     Options used to configure Microsoft.AspNetCore.Hosting.IWebHostBuilder.
    public static IHost Create(string[] args, CreateHostOptionsBase options, ServerOptionsBase serverOptions)
    {
        string[] valuesAfter;
        bool num = TryRemoveValue("--service", args, out valuesAfter);
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder(valuesAfter);
        if (num)
        {
            hostBuilder = hostBuilder.UseWindowsService();
        }

        options.ConfigureHostBuilder(hostBuilder);
        hostBuilder.ConfigureHostOptions(delegate (HostBuilderContext context, HostOptions options)
        {
            
        });
        hostBuilder.ConfigureHostConfiguration(delegate (IConfigurationBuilder builder)
        {
            
        });
        hostBuilder.ConfigureWebHost(delegate (IWebHostBuilder webBuilder)
        {
            webBuilder.ConfigureAppConfiguration(new Action<WebHostBuilderContext, IConfigurationBuilder>(serverOptions.BuildConfiguration));
            webBuilder.Configure(new Action<WebHostBuilderContext, IApplicationBuilder>(options.ConfigureMiddlewares));
            if (options.UseMvcControllers)
            {
                Assembly assembly = options.GetType().Assembly;
                webBuilder.ConfigureServices(delegate (IServiceCollection services)
                {
                    IMvcBuilder mvcBuilder = services.AddControllers().AddApplicationPart(assembly);
                    options.ConfigureMvc(mvcBuilder);
                });
            }

            webBuilder.ConfigureServices(new Action<WebHostBuilderContext, IServiceCollection>(options.ConfigureServices));
            serverOptions.Setup(webBuilder);
        });
        return hostBuilder.Build();
    }

    private static bool TryRemoveValue(string valueToRemove, string[] values, out string[] valuesAfter)
    {
        bool result = values.Contains(valueToRemove);
        valuesAfter = values.Where((string value) => value != valueToRemove).ToArray();
        return result;
    }
}
