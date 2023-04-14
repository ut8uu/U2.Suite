using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Logger.Data;
using U2.LoggerSvc.Core;

namespace U2.LoggerSvc.Core;

public sealed class LoggerService : ILoggerService
{
    private readonly ILoggerDbContext _loggerDbContext;

    public LoggerService(ILoggerDbContext loggerDbContext)
    {
        _loggerDbContext = loggerDbContext;
    }

    public async Task<IEnumerable<Contact>> GetContactsAsync(CancellationToken cancellationToken)
    {
        var entries = await _loggerDbContext.GetLogEntriesAsync(cancellationToken);
        var result = entries.Select(_ => _.ToContact());
        return result;
    }

    public Task CreateAsync(Contact contact, CancellationToken cancellationToken)
    {
        var entry = contact.ToLogEntry();
        return _loggerDbContext.AddLogEntryAsync(entry, cancellationToken);
    }
}
