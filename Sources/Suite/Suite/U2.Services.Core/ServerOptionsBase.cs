using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace U2.Services.Core;

/// <summary>
/// Implement to provide HTTP server.
/// </summary>
public abstract class ServerOptionsBase
{
	/// <summary>
	/// Add server implementation (UseKestrel, UseServer, etc..)
	/// </summary>
	public abstract void Setup(IWebHostBuilder builder);

	/// <summary>
	/// If necessary, tune web app configuration.
	/// </summary>
	public virtual void BuildConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
	{
	}
}