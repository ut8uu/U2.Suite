using System.Threading;
using Microsoft.EntityFrameworkCore;
using U2.Core;

namespace U2.CIS.Data;

public class CisDbContext : DbContext, ICisDbContext
{
	public const string DefaultDatabaseName = "call_info_service.sqlite";

	private readonly string _dbName = DefaultDatabaseName;
	protected readonly string _dbPath;

	public CisDbContext(string dbPath = "", string dbName = DefaultDatabaseName)
	{
		if (dbPath.Length > 0 && Directory.Exists(dbPath))
		{
			_dbPath = dbPath;
		}
		else
		{
			_dbPath = FileSystemHelper.GetDatabaseFolderPath(applicationName: "CIS");
		}
		Directory.CreateDirectory(_dbPath);
		_dbName = dbName;
	}

	public string DbPath => Path.Combine(_dbPath, _dbName);

	public string DbName => _dbName;

	public DbSet<CallInfoEntry> Entries { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={DbPath}");

	public async Task<int> AddCallInfoEntryAsync(CallInfoEntry entry, CancellationToken cancellationToken)
	{
		var addedEntry = await Entries.AddAsync(entry, cancellationToken);
		await SaveChangesAsync(cancellationToken);
		return addedEntry.Entity.Id;
	}

	public async Task<bool> DeleteCallInfoEntryAsync(int id, CancellationToken cancellationToken)
	{
		var entry = await Entries.FindAsync(id, cancellationToken);

		if (entry == null)
		{
			return false;
		}

		Entries.Remove(entry);
		await SaveChangesAsync(cancellationToken);
		return true;
	}

	public Task<CallInfoEntry?> GetCallInfoEntryAsync(string call, CancellationToken cancellationToken)
	{
		return Entries.FirstOrDefaultAsync(x => x.Call == call, cancellationToken: cancellationToken);
	}

	public async Task<bool> UpdateCallInfoEntryAsync(CallInfoEntry entry, CancellationToken cancellationToken)
	{
		var existingEntry = await Entries.FindAsync(entry.Id, cancellationToken);

		if (existingEntry == null)
		{
			return false;
		}

		Entries.Entry(existingEntry).CurrentValues.SetValues(entry);
		await SaveChangesAsync(cancellationToken);
		return true;
	}

	public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
	{
		foreach (var entry in Entries)
		{
			Entries.Remove(entry);
		}

		await SaveChangesAsync(cancellationToken);
	}
}