using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace U2.CIS.Data;

public interface ICisDbContext
{
	DbSet<CallInfoEntry> Entries { get; set; }

	Task<CallInfoEntry> GetCallInfoEntryAsync(string call, CancellationToken cancellationToken);

	/// <summary>
	/// Adds given call entry in the database.
	/// </summary>
	/// <param name="entry"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>Returns an identifier of the added entry.</returns>
	Task<int> AddCallInfoEntryAsync(CallInfoEntry entry, CancellationToken cancellationToken);

	/// <summary>
	/// Deletes an entry with given identifier.
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>Returns <see langword="true"/> if operation was successful, or <see langword="false"/> otherwise.</returns>
	/// <exception cref="DbUpdateException"></exception>
	/// <exception cref="OperationCanceledException"></exception>
	Task<bool> DeleteCallInfoEntryAsync(int id, CancellationToken cancellationToken);

	/// <summary>
	/// Updates given log entry.
	/// </summary>
	/// <param name="entry"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> UpdateCallInfoEntryAsync(CallInfoEntry entry, CancellationToken cancellationToken);
}
