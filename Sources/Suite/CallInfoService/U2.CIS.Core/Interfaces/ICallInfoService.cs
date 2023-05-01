using System;
using U2.CIS.Data;

namespace U2.CIS.Core;

public interface ICallInfoService
{
	int GetCallInfoCount();

	/// <summary>
	/// Adds given call to the database.
	/// </summary>
	/// <param name="call"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="CallAddFailedException"></exception>
	Task<int> AddCallAsync(string call, CancellationToken cancellationToken);

	Task<CallInfo> GetCallInfoAsync(string call, CancellationToken cancellationToken);

	/// <summary>
	/// Deletes given call from the database.
	/// </summary>
	/// <param name="call"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="CallDeleteFailedException"></exception>
	Task<bool> DeleteCallAsync(string call, CancellationToken cancellationToken);

	/// <summary>
	/// Deletes given call from the database.
	/// </summary>
	/// <param name="id"></param>
	/// <param name="callInfo"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="CallDeleteFailedException"></exception>
	Task<bool> UpdateCallAsync(int id, CallInfo callInfo, CancellationToken cancellationToken);
}
