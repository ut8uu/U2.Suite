using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Core.Models
{
    public sealed class TempDirectory : IDisposable
    {
        public TempDirectory()
        {
            TempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(TempPath);
        }

        public TempDirectory(string tempDirectory)
        {
            TempPath = tempDirectory;
            Directory.CreateDirectory(TempPath);
        }

        public string TempPath { get; }

        public void Dispose()
        {
            Directory.Delete(TempPath, true);
        }
    }
}
