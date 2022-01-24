using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using U2.Core;
using U2.Logger.Models.Database;

namespace U2.Logger
{
    public sealed class LoggerDbContext : DbContext
    {
        private const string DataBaseName = "logger.sqlite";
        private readonly string _databasePath;

        public LoggerDbContext()
        {
            var dbDirectory = FileSystemHelper.GetFullPath("Database", "Logger");
            Directory.CreateDirectory(dbDirectory);
            _databasePath = Path.Combine(dbDirectory, DataBaseName);
        }

        public DbSet<LogRecordDbo> Records { get; set; }
        public DbSet<SettingsDbo> Settings { get; set; }

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

        public void SaveQso(QsoData formData)
        {
            var record = Records.Find(formData.RecordId);
            var newRecord = record == null;

            if (newRecord)
            {
                record = new LogRecordDbo();
            }

            Debug.Assert(record != null);

            record.RecordId = formData.RecordId;
            record.Callsign = formData.Callsign;
            record.Comments = formData.Comments ?? string.Empty;
            record.Timestamp = formData.Timestamp;
            record.RstReceived = formData.RstRcvd;
            record.RstSent = formData.RstSent;
            record.Operator = formData.Operator;
            record.Mode = formData.Mode;
            record.Band = formData.Band;
            record.Frequency = formData.FreqMhz.GetValueOrDefault(-1);
            if (record.Frequency<0)
            {
                record.Frequency = ConversionHelper.BandNameAndModeToFrequency(formData.Band, formData.Mode);
            }

            if (newRecord)
            {
                Records.Add(record);
            }

            this.SaveChanges();
        }

        /// <summary>
        /// Deletes a given collection of QSO.
        /// </summary>
        /// <param name="recordIds"></param>
        public void DeleteQso(Guid[] recordIds)
        {
            var recordsToDelete = Records.Where(r => recordIds.Contains(r.RecordId)).ToList();
            Records.RemoveRange(recordsToDelete);
            this.SaveChanges();
        }
    }
}
