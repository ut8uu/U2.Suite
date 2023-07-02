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
