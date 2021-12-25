using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Contracts
{
    public sealed class LaunchInfo
    {
        public string WindowsApplicationPath { get; set; }
        public string OsxApplicationPath { get; set; }
        public string LinuxApplicationPath { get; set; }
    }
}
