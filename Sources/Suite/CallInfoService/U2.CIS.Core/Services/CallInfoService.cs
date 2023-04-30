﻿using System.Diagnostics;
using U2.CIS.Data;

namespace U2.CIS.Core;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed class CallInfoService : ICallInfoService
{
	private readonly ICisDbContext _dbContext;

	public CallInfoService(ICisDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<int> AddCallAsync(string call, CancellationToken cancellationToken)
	{
		var newEntry = new CallInfoEntry
		{
			Call = call,
		};
		return _dbContext.AddCallInfoEntryAsync(newEntry, cancellationToken);
	}

	public Task DeleteCallAsync(string call, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public int GetCallInfoCount()
	{
		return _dbContext.Entries.Count();
	}

	public Task UpdateCallAsync(string call, CallInfo callInfo, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	private string GetDebuggerDisplay()
	{
		return ToString();
	}
}