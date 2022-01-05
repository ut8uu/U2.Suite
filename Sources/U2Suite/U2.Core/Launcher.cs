using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace U2.Core
{
    public sealed class Launcher
    {
        public static void Launch(string path, string commandLineArgs)
        {
            Debug.Assert(File.Exists(path));
            var startInfo = new ProcessStartInfo(path)
            {
                UseShellExecute = true,
                WorkingDirectory = Path.GetDirectoryName(typeof(Launcher).Assembly.Location)
            };
            Process.Start(startInfo);
        }
    }
}
