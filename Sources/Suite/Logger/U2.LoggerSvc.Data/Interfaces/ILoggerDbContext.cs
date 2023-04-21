using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace U2.LoggerSvc.Data;

public interface ILoggerDbContext
{
    DbSet<LoggerEntry> LogEntries { get; set; }

    Task<IEnumerable<LoggerEntry>> GetLogEntriesAsync(CancellationToken cancellationToken);
    Task AddLogEntryAsync(LoggerEntry entry, CancellationToken cancellationToken);
    Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
    Task DeleteLogEntryAsync(int id, CancellationToken cancellationToken);
}
