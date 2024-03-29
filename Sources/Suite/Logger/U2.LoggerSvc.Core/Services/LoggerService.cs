﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.LoggerSvc.Data;
using U2.LoggerSvc.Core;
using Microsoft.EntityFrameworkCore;
using U2.Core;
using Microsoft.AspNetCore.Components;

namespace U2.LoggerSvc.Core;

public sealed class LoggerService : ILoggerService
{
    private readonly ILoggerDbContext _loggerDbContext;

    public LoggerService(ILoggerDbContext loggerDbContext)
    {
        _loggerDbContext = loggerDbContext;
    }

    public async Task<IEnumerable<Contact>> GetContactsAsync(
        ApiTypes.LoggerFilteringSearchingPaginationParameters parameters, 
        CancellationToken cancellationToken)
    {
        var entries = await _loggerDbContext.GetLogEntriesAsync(cancellationToken);
        if (parameters.SearchParameters != null)
        {
            entries = Filter(entries, parameters.SearchParameters);
        }
        if (parameters.SortingParameters != null)
        {
            entries = Sort(entries, parameters.SortingParameters);
        }
        if (parameters.PaginationParameters != null)
        {
            entries = Paginate(entries, parameters.PaginationParameters);
        }
        var result = entries.Select(_ => _.ToContact());
        return result;
    }

    private IEnumerable<LoggerEntry> Filter(IEnumerable<LoggerEntry> entries, SearchParameters searchParameters)
    {
        var result = entries.Where(x => x.Mode.Equals(searchParameters.Search, StringComparison.InvariantCultureIgnoreCase)
        || x.Band.Equals(searchParameters.Search, StringComparison.InvariantCultureIgnoreCase)
        || x.Call.Contains(searchParameters.Search, StringComparison.InvariantCultureIgnoreCase));
        
        return result;
    }

    private IEnumerable<LoggerEntry> Paginate(IEnumerable<LoggerEntry> entries, PaginationParameters paginationParameters)
    {
        if (paginationParameters == null)
        {
            return entries;
        }

        if (paginationParameters.PageIndex < 0)
        {
            throw new ArgumentException($"Wrong page index: {paginationParameters.PageIndex}");
        }
        if (paginationParameters.PageSize < 0)
        {
            throw new ArgumentException($"Wrong page size: {paginationParameters.PageSize}");
        }

        var skip = paginationParameters.PageIndex * paginationParameters.PageSize;
        return entries.Skip(skip).Take(paginationParameters.PageSize);
    }

    public static IEnumerable<LoggerEntry> Sort(IEnumerable<LoggerEntry> entries, SortingParameters sortingParameters)
    {
        if (sortingParameters == null)
        {
            return entries;
        }

        var sortBy = (LoggerSortByField)sortingParameters.SortBy;
        if (sortingParameters.Ascending)
        {
            return sortBy switch
            {
                LoggerSortByField.Call => entries.OrderBy(x => x.Call),
                LoggerSortByField.DateTimeOn => entries.OrderBy(x => x.DateTimeOn),
                LoggerSortByField.DateTimeOff => entries.OrderBy(x => x.DateTimeOff),
                LoggerSortByField.Band => entries.OrderBy(x => x.Band),
                LoggerSortByField.Mode => entries.OrderBy(x => x.Mode),
                _ => entries,
            };
        }
        else
        {
            return sortBy switch
            {
                LoggerSortByField.Call => entries.OrderByDescending(x => x.Call),
                LoggerSortByField.DateTimeOn => entries.OrderByDescending(x => x.DateTimeOn),
                LoggerSortByField.DateTimeOff => entries.OrderByDescending(x => x.DateTimeOff),
                LoggerSortByField.Band => entries.OrderByDescending(x => x.Band),
                LoggerSortByField.Mode => entries.OrderByDescending(x => x.Mode),
                _ => entries,
            };
        }
    }

    public Task<int> CreateContactAsync(Contact contact, CancellationToken cancellationToken)
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
