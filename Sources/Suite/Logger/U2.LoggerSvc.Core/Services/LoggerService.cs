using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.LoggerSvc.Data;
using U2.LoggerSvc.Core;
using Microsoft.EntityFrameworkCore;

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

    public Task CreateContactAsync(Contact contact, CancellationToken cancellationToken)
    {
        var entry = contact.ToLogEntry();
        return _loggerDbContext.AddLogEntryAsync(entry, cancellationToken);
    }

    public async Task<bool> DeleteContactAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            return await _loggerDbContext.DeleteLogEntryAsync(id, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            // it's not an exception in this case
            return false;
        }
        catch (DbUpdateException ex)
        {
            throw new ContactRemovingFailedException(id, ex);
        }
    }

    public async Task<bool> UpdateContactAsync(Contact contact, CancellationToken cancellationToken)
    {
        try
        {
            var entry = contact.ToLogEntry();
            return await _loggerDbContext.UpdateLogEntryAsync(entry, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            return false;
        }
        catch (DbUpdateException ex)
        {
            throw new ContactUpdateFailedException(contact.Id, ex);
        }
    }
}
