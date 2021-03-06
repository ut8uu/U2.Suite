/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using U2.Core;
using U2.Core.Models;
using U2.Logger.Models.Database;

namespace U2.Logger;

public sealed class LoggerDbContext : DbContext
{
    private readonly string _dataBaseName = "logger.sqlite";
    private readonly string _databasePath;
    private static LoggerDbContext? _dbContext;
    private static bool _running = true;

    private LoggerDbContext() : base()
    {
        var dbDirectory = FileSystemHelper.GetDatabaseFolderPath(U2.Resources.ApplicationNames.LoggerOsx);
        Directory.CreateDirectory(dbDirectory);
        _dataBaseName = $"{LoggerAppSettings.Default.LogName}{CommonConstants.DatabaseExtension}";
        _databasePath = Path.Combine(dbDirectory, _dataBaseName);

        CheckIntegrity();
    }

    public static LoggerDbContext Instance
    {
        get
        {
            if (!_running)
            {
                return null;
            }

            if (_dbContext == null)
            {
                _dbContext = new LoggerDbContext();
            }
            return _dbContext;
        }
    }

    public DbSet<LogRecordDbo>? Records { get; set; }
    public DbSet<SettingsDbo>? Settings { get; set; }

    public static void Reset()
    {
        _dbContext = null;
    }

    public static void ShutDown()
    {
        _running = false;
        _dbContext?.Database.CloseConnection();
        _dbContext = null;
    }

    private string GetConnectionString()
    {
        return $"Filename={_databasePath};DataSource={_databasePath};";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    private void CheckIntegrity()
    {
        SQLiteConnection db = null;
        try
        {
            var connectionString = GetConnectionString();
            db = new SQLiteConnection(connectionString);
            db.Open();
            CheckTable(db, "Records");
            CheckTable(db, "Settings");
            db.Close();
        }
        catch (Exception ex)
        {
            db?.Close();
            Console.WriteLine(ex.Message);
            var message = new DatabaseCorruptedMessage(ex.Message);
            Messenger.Default.Send(message);
        }
    }

    private void CheckTable(SQLiteConnection connection, string tableName)
    {
        var cmd = new SQLiteCommand($"PRAGMA integrity_check({tableName});", connection);
        var result = cmd.ExecuteScalar().ToString();
        if (result != "ok")
        {
            var dbName = Path.GetFileNameWithoutExtension(_dataBaseName);
            var message = new DatabaseCorruptedMessage(dbName);
            Messenger.Default.Send(message);
        }
    }

    public void SaveQso(QsoData formData)
    {
        if (!_running)
        {
            return;
        }

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
        record.QsoEndTimestamp = formData.Timestamp;
        record.QsoBeginTimestamp = formData.Timestamp;
        record.RstReceived = formData.RstRcvd;
        record.RstSent = formData.RstSent;
        record.Operator = formData.Operator ?? string.Empty;
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
        if (!_running)
        {
            return;
        }

        var recordsToDelete = Records.Where(r => recordIds.Contains(r.RecordId)).ToList();
        Records.RemoveRange(recordsToDelete);
        this.SaveChanges();
    }
}
