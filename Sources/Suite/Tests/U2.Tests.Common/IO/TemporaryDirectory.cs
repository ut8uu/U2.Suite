using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Tests.Common.IO;

public class TemporaryDirectory : IDisposable
{
    //
    // Summary:
    //     This location is safe for parallel test execution by different build on
    //     the same server. Also, it will be cleaned up automatically 
    //     before next test run.
    public static string DefaultDirectory { get; } = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(TemporaryDirectory).Assembly.Location), "_TMP");


    public string Path { get; }

    private TemporaryDirectory()
    {
        Path = System.IO.Path.Combine(DefaultDirectory, System.IO.Path.GetRandomFileName());
        Directory.CreateDirectory(Path);
    }

    public TemporaryDirectory(string path)
    {
        Path = path;
    }

    public static TemporaryDirectory Create()
    {
        return new TemporaryDirectory();
    }

    public void Dispose()
    {
        if (Directory.Exists(Path))
        {
            try
            {
                Directory.Delete(Path, recursive: true);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
            }
        }
    }

    public static implicit operator string(TemporaryDirectory that)
    {
        return that.Path;
    }
}
