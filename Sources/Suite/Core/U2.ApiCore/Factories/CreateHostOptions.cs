/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NSwag;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors.Security;
using U2.Core.Middleware;

namespace U2.ApiCore.Factories;

public sealed class CreateHostOptions : CreateHostOptionsBase
{
    public override bool UseCors => false;

    public override void ConfigureSwagger(WebHostBuilderContext context, IApplicationBuilder app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi3();
    }

    public override void ConfigureMiddlewares(WebHostBuilderContext context, IApplicationBuilder app)
    {
        ConfigureSwagger(context, app);

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiAutoMapperDemo v1"));
        }

        app.UseHealth();
        app.UseStaticFiles();

        app.UseRouting();
        if (UseCors)
        { 
            app.UseCors(); 
        }

        app.UseEndpoints(endpoints =>
        {
            if (UseMvcControllers)
            {
                endpoints.MapControllers();
            }
        });
    }

    public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
    {
        services.AddHealthChecks();
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
//*/