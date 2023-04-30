using System;

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
	/// <param name="call"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="CallDeleteFailedException"></exception>
	Task UpdateCallAsync(string call, CallInfo callInfo, CancellationToken cancellationToken);
}
