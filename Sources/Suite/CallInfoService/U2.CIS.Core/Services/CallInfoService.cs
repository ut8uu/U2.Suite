using System.Diagnostics;

namespace U2.CIS.Core;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed class CallInfoService : ICallInfoService
{
	public CallInfoService()
	{
	}

	public Task AddCallAsync(string call, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task DeleteCallAsync(string call, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
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