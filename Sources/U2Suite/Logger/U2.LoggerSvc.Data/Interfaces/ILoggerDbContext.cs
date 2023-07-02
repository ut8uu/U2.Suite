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
    Task<int> AddLogEntryAsync(LoggerEntry entry, CancellationToken cancellationToken);
    Task DeleteAllEntriesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Deletes an entry with given identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns <see langword="true"/> if operation was successful, or <see langword="false"/> otherwise.</returns>
    /// <exception cref="DbUpdateException"></exception>
    /// <exception cref="OperationCanceledException"></exception>
    Task<bool> DeleteLogEntryAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Updates given log entry.
    /// </summary>
    /// <param name="entry"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> UpdateLogEntryAsync(LoggerEntry entry, CancellationToken cancellationToken);
}
