/*
using Microsoft.AspNetCore.Hosting;

namespace U2.Core.Factories;

public sealed class KestrelServerOptions : ServerOptionsBase
{
    public override void Setup(IWebHostBuilder builder)
    {
        builder.UseKestrel(delegate (WebHostBuilderContext builderContext, Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions options)
        {
            options.Configure(builderContext.Configuration.GetSection("Kestrel"));
        });
    }
}
//*/