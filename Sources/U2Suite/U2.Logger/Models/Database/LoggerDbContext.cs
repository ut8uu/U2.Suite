using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using U2.Core;

namespace U2.Logger
{
    public sealed class LoggerDbContext : DbContext
    {
        private const string DataBaseName = "logger.sqlite";
        private readonly string _databasePath;

        public LoggerDbContext()
        {
            _databasePath = FileSystemHelper.GetFullPath("Logger", DataBaseName);
        }

        public DbSet<LogRecordDbo> Records { get; set; }

        private string GetConnectionString()
        {
            return $"Filename={_databasePath};";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
