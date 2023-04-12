using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace U2.Core.Factories;

public abstract class ServerOptionsBase
{
    public abstract void Setup(IWebHostBuilder builder);

    public virtual void BuildConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
    {
    }
}
