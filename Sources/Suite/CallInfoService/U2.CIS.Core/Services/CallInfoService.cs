using System.Diagnostics;
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

	public async Task<bool> DeleteCallAsync(string call, CancellationToken cancellationToken)
	{
		var entry = await _dbContext.GetCallInfoEntryAsync(call, cancellationToken);
		if (entry == null) 
		{
			return false;
		}
		return await _dbContext.DeleteCallInfoEntryAsync(entry.Id, cancellationToken);
	}

	public async Task<CallInfo> GetCallInfoAsync(string call, CancellationToken cancellationToken)
	{
		var entry = await _dbContext.GetCallInfoEntryAsync(call, cancellationToken);
		if (entry == null)
		{
			var newEntry = new CallInfoEntry { Call = call };
			var id = await _dbContext.AddCallInfoEntryAsync(newEntry, cancellationToken);
			entry = await _dbContext.GetCallInfoEntryAsync(call, cancellationToken);
			entry ??= newEntry;
		}
		return entry.ToCallInfo();
	}

	public int GetCallInfoCount()
	{
		return _dbContext.Entries.Count();
	}

	public Task<bool> UpdateCallAsync(int id, CallInfo callInfo, CancellationToken cancellationToken)
	{
		var callInfoEntry = callInfo.ToCallInfoEntry();
		callInfoEntry.Id = id;
		return _dbContext.UpdateCallInfoEntryAsync(callInfoEntry, cancellationToken);
	}

	private string GetDebuggerDisplay()
	{
		return ToString();
	}
}