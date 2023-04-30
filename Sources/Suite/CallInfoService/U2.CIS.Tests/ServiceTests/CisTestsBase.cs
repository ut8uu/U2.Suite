using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using U2.CIS.Core;

namespace U2.CIS.Tests;

public abstract class CisTestsBase : TestsBase, IDisposable
{
    protected readonly List<CallInfo> _callInfos = new();
    protected readonly TestDbContext _dbContext;

    public CisTestsBase()
    {
        _dbContext = new TestDbContext();
        _dbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        var dbName = Path.Combine(_dbContext.DbPath, _dbContext.DbName);

        _dbContext.SaveChanges();
        _dbContext.Database.CloseConnection();
        _dbContext.Dispose();

        if (File.Exists(dbName))
        {
            File.Delete(dbName);
        }
    }

    protected async Task SetupLoggerDbContext()
    {
        await _dbContext.DeleteAllEntriesAsync(CancellationToken.None);

        foreach (var callInfo in _callInfos)
        {
            await _dbContext.AddCallInfoEntryAsync(callInfo.ToCallInfoEntry(), CancellationToken.None);
        }
    }
}
