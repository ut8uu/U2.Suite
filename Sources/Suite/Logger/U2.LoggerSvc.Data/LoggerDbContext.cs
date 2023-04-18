using System.Threading;
using Microsoft.EntityFrameworkCore;
using U2.Core;

namespace U2.LoggerSvc.Data;

public class LoggerDbContext : DbContext, ILoggerDbContext
{
    public const string DefaultDatabaseName = "logger.sqlite";
    public DbSet<LogEntry> LogEntries { get; set; }

    public string DbPath { get; }

    public LoggerDbContext(string dbName = DefaultDatabaseName)
    {
        var path = FileSystemHelper.GetDatabaseFolderPath(applicationName: "Logger");
        DbPath = Path.Join(path, dbName);
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public async virtual Task<IEnumerable<LogEntry>> GetLogEntriesAsync(CancellationToken cancellationToken)
    {
        return await LogEntries
            .OrderByDescending(x => x.DateTimeOff)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async virtual Task AddLogEntryAsync(LogEntry entry, CancellationToken cancellationToken)
    {
        await LogEntries.AddAsync(entry, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }

    public async virtual Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
    {
        foreach (LogEntry entry in LogEntries)
        {
            LogEntries.Remove(entry);
        }

        await SaveChangesAsync(cancellationToken);
    }

    public async virtual Task DeleteLogEntryAsync(int id, CancellationToken cancellationToken)
    {
        var entry = await LogEntries.FindAsync(id, cancellationToken);

        if (entry != null)
        {
            LogEntries.Remove(entry);
            await SaveChangesAsync(cancellationToken);
        }
    }
}
