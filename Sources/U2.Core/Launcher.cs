using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using U2.Contracts;

namespace U2.Core
{
    public sealed class Launcher
    {
        public static void LaunchApplication(LaunchInfo launchInfo)
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                    // returned by SilverLight. .NET Core returns Unix for this OS
                    throw new NotImplementedException("This OS is not supported.");
                case PlatformID.Win32S:
                    // not used anymore
                    throw new NotImplementedException("This OS is not supported.");
                case PlatformID.Win32Windows:
                    throw new NotImplementedException("This OS is not supported.");
                case PlatformID.Win32NT:
                    Process.Start(launchInfo.WindowsApplicationPath);
                    break;
                case PlatformID.WinCE:
                    // not used anymore
                    throw new NotImplementedException("This OS is not supported.");
                case PlatformID.Unix:
                    // MacOS falls here
                    Process.Start(launchInfo.OsxApplicationPath);
                    break;
                case PlatformID.Xbox:
                    // not used anymore
                    throw new NotImplementedException("This OS is not supported.");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
