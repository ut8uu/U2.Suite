using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace U2.Core.Factories;

public sealed class CreateHostOptions : CreateHostOptionsBase
{
    public override bool UseCors => false;

    public override void ConfigureSwagger(WebHostBuilderContext context, IApplicationBuilder app)
    {
    }

    public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.RespectBrowserAcceptHeader = true;
        })
            // https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_NullValueHandling.htm
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
    }
}
