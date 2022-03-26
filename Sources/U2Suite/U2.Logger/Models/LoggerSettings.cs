using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using U2.Logger.Models.Database;

namespace U2.Logger
{
    public sealed class LoggerSettings
    {
        private const string ShowLogWindowField = nameof(ShowLogWindowField);

        public static LoggerSettings Instance { get; }

        static LoggerSettings()
        {
            Instance = new LoggerSettings();
        }

        private LoggerSettings()
        {
        }

        private string GetSettingValue(string settingId, [CanBeNull] string defaultValue = null)
        {
            var setting = LoggerDbContext.Instance.Settings.Find(settingId);
            if (setting == null)
            {
                setting = new SettingsDbo
                {
                    SettingId = settingId,
                    Value = defaultValue,
                };
                LoggerDbContext.Instance.Settings.Add(setting);
                LoggerDbContext.Instance.SaveChanges(acceptAllChangesOnSuccess: true);
            }

            return setting.Value;
        }

        private void SetSettingValue(string settingId, string value)
        {
            var setting = LoggerDbContext.Instance.Settings.Find(settingId);
            if (setting == null)
            {
                setting = new SettingsDbo
                {
                    SettingId = settingId,
                    Value = value,
                };
                LoggerDbContext.Instance.Settings.Add(setting);
            }
            else
            {
                setting.Value = value;
                LoggerDbContext.Instance.Update(setting);
            }

            LoggerDbContext.Instance.SaveChanges(acceptAllChangesOnSuccess: true);
        }

        public bool ShowLogWindow
        {
            get => bool.Parse(GetSettingValue(ShowLogWindowField));
            set => SetSettingValue(ShowLogWindowField, value.ToString());
        }
    }
}
