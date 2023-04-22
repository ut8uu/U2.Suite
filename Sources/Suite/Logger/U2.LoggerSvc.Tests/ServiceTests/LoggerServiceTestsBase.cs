using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.LoggerSvc.Core;
using Microsoft.EntityFrameworkCore;

namespace U2.LoggerSvc.Tests;

public abstract class LoggerServiceTestsBase : TestsBase, IDisposable
{
    protected readonly List<Contact> _contacts = new();
    protected readonly TestDbContext _dbContext;

    public LoggerServiceTestsBase()
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

        foreach (var contact in _contacts)
        {
            await _dbContext.AddLogEntryAsync(contact.ToLogEntry(), CancellationToken.None);
        }
    }
}
