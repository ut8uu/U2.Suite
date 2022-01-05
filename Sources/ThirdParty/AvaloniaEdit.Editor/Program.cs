using Avalonia;
using CommandLine.Text;
using CommandLine;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AvaloniaEdit.Editor
{
    public class EditorOptions
    {
        [Option("inputFile", Required = true, HelpText = "A full path to the input file.")]
        public string InputFile { get; set; }
    }

    class Program
    {
        public static string InputFile { get; set; }

        // This method is needed for IDE previewer infrastructure
        public static AppBuilder BuildAvaloniaApp()
          => AppBuilder.Configure<App>().UsePlatformDetect();

        // The entry point. Things aren't ready yet
        public static int Main(string[] args)
        {
            Debugger.Launch();

            Parser.Default.ParseArguments<EditorOptions>(args)
            .WithParsed<EditorOptions>(eo =>
            {
                InputFile = eo.InputFile;
            });

            return BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
    }
}
