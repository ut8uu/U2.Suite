using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace U2.Logger.Data;

public class LoggerDbContext : IdentityDbContext, ILoggerDbContext
{
    public LoggerDbContext(DbContextOptions<LoggerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LogEntry> LogEntries { get; set; }

    // <snippet1>
    public async virtual Task<List<LogEntry>> GetLogEntriesAsync(CancellationToken cancellationToken)
    {
        return await LogEntries
            .OrderByDescending(x => x.DateTimeOff)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    // </snippet1>

    // <snippet2>
    public async virtual Task AddLogEntryAsync(LogEntry entry, CancellationToken cancellationToken)
    {
        await LogEntries.AddAsync(entry, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }
    // </snippet2>

    // <snippet3>
    public async virtual Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
    {
        foreach (LogEntry entry in LogEntries)
        {
            LogEntries.Remove(entry);
        }

        await SaveChangesAsync(cancellationToken);
    }
    // </snippet3>

    // <snippet4>
    public async virtual Task DeleteLogEntryAsync(int id, CancellationToken cancellationToken)
    {
        var entry = await LogEntries.FindAsync(id, cancellationToken);

        if (entry != null)
        {
            LogEntries.Remove(entry);
            await SaveChangesAsync(cancellationToken);
        }
    }
    // </snippet4>

    public void Initialize()
    {
        LogEntries.AddRange(GetSeedingLogEntries());
        SaveChanges();
    }

    public static List<LogEntry> GetSeedingLogEntries()
    {
        return new List<LogEntry>()
        {
            new LogEntry()
            {
                Id = Guid.NewGuid(),
                DateTimeOn = DateTime.UtcNow,
            },
        };
    }
}
