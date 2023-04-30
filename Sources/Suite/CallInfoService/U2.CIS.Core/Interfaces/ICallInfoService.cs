using System;

namespace U2.CIS.Core;

public interface ICallInfoService
{
	/// <summary>
	/// Adds given call to the database.
	/// </summary>
	/// <param name="call"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="CallAddFailedException"></exception>
	Task AddCallAsync(string call, CancellationToken cancellationToken);

	/// <summary>
	/// Deletes given call from the database.
	/// </summary>
	/// <param name="call"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="CallDeleteFailedException"></exception>
	Task DeleteCallAsync(string call, CancellationToken cancellationToken);

	/// <summary>
	/// Deletes given call from the database.
	/// </summary>
	/// <param name="call"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="CallDeleteFailedException"></exception>
	Task UpdateCallAsync(string call, CallInfo callInfo, CancellationToken cancellationToken);
}
