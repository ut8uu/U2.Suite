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

	public Task<int> AddCallInfoEntryAsync(CallInfoEntry entry, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<bool> DeleteCallInfoEntryAsync(int id, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<CallInfoEntry> GetCallInfoEntryAsync(string call, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<bool> UpdateCallInfoEntryAsync(CallInfoEntry entry, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAllEntriesAsync(CancellationToken none)
	{
		throw new NotImplementedException();
	}
}