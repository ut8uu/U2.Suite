using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using U2.Logger.Models.Database;

namespace U2.Logger.Models
{
    public sealed class LoggerSettings
    {
        private const string ShowLogWindowField = nameof(ShowLogWindowField);

        private readonly LoggerDbContext _dbContext;

        public static LoggerSettings Instance { get; }

        static LoggerSettings()
        {
            Instance = new LoggerSettings();
        }

        private LoggerSettings()
        {
            _dbContext = new LoggerDbContext();
        }

        private string GetSettingValue(string settingId, [CanBeNull] string defaultValue = null)
        {
            var setting = _dbContext.Settings.Find(settingId);
            if (setting == null)
            {
                setting = new SettingsDbo
                {
                    SettingId = settingId,
                    Value = defaultValue,
                };
                _dbContext.Settings.Add(setting);
                _dbContext.SaveChanges(acceptAllChangesOnSuccess: true);
            }

            return setting.Value;
        }

        private void SetSettingValue(string settingId, string value)
        {
            var setting = _dbContext.Settings.Find(settingId);
            if (setting == null)
            {
                setting = new SettingsDbo
                {
                    SettingId = settingId,
                    Value = value,
                };
                _dbContext.Settings.Add(setting);
            }
            else
            {
                setting.Value = value;
                _dbContext.Update(setting);
            }

            _dbContext.SaveChanges(acceptAllChangesOnSuccess: true);
        }

        public bool ShowLogWindow
        {
            get => bool.Parse(GetSettingValue(ShowLogWindowField));
            set => SetSettingValue(ShowLogWindowField, value.ToString());
        }
    }
}
