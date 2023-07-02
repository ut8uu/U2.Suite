using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.CIS.Data;
using U2.Core;

namespace U2.CIS.Tests;

public sealed class TestDbContext : CisDbContext
{
    public TestDbContext() : base(TestDatabasedirectory, $"{Guid.NewGuid()}.sqlite") { }

    private static string TestDatabasedirectory
    {
        get
        {
            var localDir = FileSystemHelper.GetLocalFolder();
            var dir = Path.Combine(localDir, "TestDir", "CIS");
            Directory.CreateDirectory(dir);
            return dir;
        }
    }
}
