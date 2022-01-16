using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using GalaSoft.MvvmLight.Messaging;
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
            var dbDirectory = FileSystemHelper.GetFullPath("Database", "Logger");
            Directory.CreateDirectory(dbDirectory);
            _databasePath = Path.Combine(dbDirectory, DataBaseName);

            Messenger.Default.Register<ExecuteCommandMessage>(this, AcceptExecuteCommandMessage);
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

        private void AcceptExecuteCommandMessage(ExecuteCommandMessage message)
        {
            if (message.CommandToExecute == CommandToExecute.SaveQso)
            {
                if (message.CommandParameters is ApplicationFormData formData)
                {
                    SaveQso(formData);
                }
            }
        }

        private void SaveQso(ApplicationFormData formData)
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
            record.DateTime = formData.DateTime;
            record.RstReceived = formData.RstRcvd;
            record.RstSent = formData.RstSent;
            record.Frequency = formData.FreqKhz;
            record.Operator = formData.Operator;

            if (newRecord)
            {
                Records.Add(record);
            }

            this.SaveChanges();
        }
    }
}
