using System.Diagnostics;
using System.IO;

namespace U2.Core;


public static class Launcher
{
    public static void Launch(string path, string commandLineArgs = "")
    {
        Debug.Assert(File.Exists(path));
        var startInfo = new ProcessStartInfo(path)
        {
            UseShellExecute = true,
            WorkingDirectory = Path.GetDirectoryName(typeof(Launcher).Assembly.Location),
            Arguments = commandLineArgs
        };
        Process.Start(startInfo);
    }
}
