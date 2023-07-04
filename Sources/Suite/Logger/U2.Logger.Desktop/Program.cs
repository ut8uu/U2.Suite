using System;

using Avalonia;
using Avalonia.ReactiveUI;

namespace U2.Logger.Desktop;

class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		try
		{
			BuildAvaloniaApp()
				.StartWithClassicDesktopLifetime(args);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}

	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder
			.Configure<App>()
			.AfterSetup(_ =>
			{
				App.ConfigureDesktopServices();
			})
			.WithInterFont()
			.UsePlatformDetect()
			.LogToTrace();
}
