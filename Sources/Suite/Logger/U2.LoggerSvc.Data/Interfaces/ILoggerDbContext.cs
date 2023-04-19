using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace U2.LoggerSvc.Data;

public interface ILoggerDbContext
{
    DbSet<LogEntry> LogEntries { get; set; }

    Task<IEnumerable<LogEntry>> GetLogEntriesAsync(CancellationToken cancellationToken);
    Task AddLogEntryAsync(LogEntry entry, CancellationToken cancellationToken);
    Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
    Task DeleteLogEntryAsync(int id, CancellationToken cancellationToken);
}
