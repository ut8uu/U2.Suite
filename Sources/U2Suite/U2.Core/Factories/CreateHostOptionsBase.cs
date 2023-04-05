using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http.Abstractions;
using Microsoft.AspNetCore.Internal;

namespace U2.Core.Factories;

public abstract class CreateHostOptionsBase
{
    //
    // Summary:
    //     Add necessary services to support MVC Controllers
    public virtual bool UseMvcControllers => true;

    //
    // Summary:
    //     Adds a CORS middleware to your web application pipeline to allow cross domain
    //     requests.
    public virtual bool UseCors => false;

    //
    // Summary:
    //     Configure middlewares and filters for ASP net core app.
    public virtual void ConfigureMiddlewares(WebHostBuilderContext context, IApplicationBuilder app)
    {
        ConfigureSwagger(context, app);
        app.UseStaticFiles();
        app.UseRouting();
        if (UseCors)
        {
            app.UseCors();
        }

        app.UseEndpoint(delegate (IEndpointRouteBuilder endpoints)
        {
            if (UseMvcControllers)
            {
                endpoints.MapControllers();
            }

            ConfigureEndpoints(context, endpoints);
        });
    }

    //
    // Summary:
    //     Configure NSwag or Swashbuckle (or neither). And do not forget add AddOpenApiDocument
    //     in ConfigureServices for NSwag.
    public abstract void ConfigureSwagger(WebHostBuilderContext context, IApplicationBuilder app);

    //
    // Summary:
    //     Configure endpoint for microservice.
    public virtual void ConfigureEndpoints(WebHostBuilderContext context, IEndpointRouteBuilder endpoints)
    {
    }

    //
    // Summary:
    //     Configure services.
    public abstract void ConfigureServices(WebHostBuilderContext context, IServiceCollection services);

    //
    // Summary:
    //     Configure MVC. Will be called if MvcControllers are enabled.
    public virtual void ConfigureMvc(IMvcBuilder mvcBuilder)
    {
    }

    //
    // Summary:
    //     Possibility to additionally configure Host Builder.
    public virtual void ConfigureHostBuilder(IHostBuilder hostBuilder)
    {
    }
}
