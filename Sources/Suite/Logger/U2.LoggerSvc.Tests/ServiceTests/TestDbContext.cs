using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Core;
using U2.LoggerSvc.Data;

namespace U2.LoggerSvc.Tests;

public sealed class TestDbContext : LoggerDbContext
{
    public TestDbContext() : base(TestDatabasedirectory, $"{Guid.NewGuid()}.sqlite") { }

    private static string TestDatabasedirectory
    {
        get
        {
            var localDir = FileSystemHelper.GetLocalFolder();
            var dir = Path.Combine(localDir, "TestDir", "Logger");
            Directory.CreateDirectory(dir);
            return dir;
        }
    }
}
