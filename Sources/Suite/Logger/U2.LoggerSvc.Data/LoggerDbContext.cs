using System.Threading;
using Microsoft.EntityFrameworkCore;
using U2.Core;

namespace U2.LoggerSvc.Data;

public class LoggerDbContext : DbContext, ILoggerDbContext
{
    public const string DefaultDatabaseName = "logger.sqlite";

    private readonly string _dbName = DefaultDatabaseName;
    protected readonly string _dbPath;

    public LoggerDbContext(string dbPath = "", string dbName = DefaultDatabaseName)
    {
        if (dbPath.Length > 0 && Directory.Exists(dbPath))
        {
            _dbPath = dbPath;
        }
        else
        {
            _dbPath = FileSystemHelper.GetDatabaseFolderPath(applicationName: "Logger");
        }
        Directory.CreateDirectory(_dbPath);
        _dbName = dbName;
    }

    public DbSet<LoggerEntry> LogEntries { get; set; }

    public string DbPath => Path.Combine(_dbPath, _dbName);

    public string DbName => _dbName;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public async virtual Task<IEnumerable<LoggerEntry>> GetLogEntriesAsync(CancellationToken cancellationToken)
    {
        return await LogEntries
            .OrderByDescending(x => x.DateTimeOff)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async virtual Task AddLogEntryAsync(LoggerEntry entry, CancellationToken cancellationToken)
    {
        await LogEntries.AddAsync(entry, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }

    public async virtual Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
    {
        foreach (LoggerEntry entry in LogEntries)
        {
            LogEntries.Remove(entry);
        }

        await SaveChangesAsync(cancellationToken);
    }

    public async virtual Task<bool> DeleteLogEntryAsync(int id, CancellationToken cancellationToken)
    {
        var entry = await LogEntries.FindAsync(id, cancellationToken);

        if (entry == null)
        {
            return false;
        }

        LogEntries.Remove(entry);
        await SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateLogEntryAsync(LoggerEntry entry, CancellationToken cancellationToken)
    {
        var existingEntry = await LogEntries.FindAsync(entry.Id, cancellationToken);

        if (existingEntry == null)
        {
            return false;
        }

        LogEntries.Entry(existingEntry).CurrentValues.SetValues(entry);
        await SaveChangesAsync(cancellationToken);
        return true;
    }
}
