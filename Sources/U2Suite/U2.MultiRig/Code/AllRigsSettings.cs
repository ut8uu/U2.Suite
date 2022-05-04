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
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using U2.Core;

namespace U2.MultiRig
{
    public static class AllRigsSettings
    {
        private const string SettingsFileName = "RigSettings.json";
        private static readonly List<RigSettings> _defaultRigSettings = new()
        {
            new RigSettings
            {
                RigId = "RIG1",
            }
        };

        internal static readonly string _pathToSettings = Path.Combine(
            FileSystemHelper.GetAppDataFolderPath(nameof(AllRigsSettings)), SettingsFileName);
        private static readonly JsonSerializerOptions _serializationOptions =
            new()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };


        public static List<RigSettings> AllRigs { get; } = new();

        internal static void LoadSettings()
        {
            AllRigs.Clear();

            if (!File.Exists(_pathToSettings))
            {
                AllRigs.AddRange(_defaultRigSettings);
                return;
            }

            using var fs = File.OpenRead(_pathToSettings);
            List<RigSettings> settings;
            try
            {
                settings = JsonSerializer.Deserialize<List<RigSettings>>(fs);
                if (settings == null || !settings.Any())
                {
                    AllRigs.AddRange(_defaultRigSettings);
                    return;
                }
            }
            catch (JsonException)
            {
                settings = _defaultRigSettings;
            }

            AllRigs.AddRange(settings);
        }

        public static void SaveSettings()
        {
            if (File.Exists(_pathToSettings))
            {
                var backupFilePath = $"{_pathToSettings}.bak";
                if (File.Exists(_pathToSettings))
                {
                    File.Move(_pathToSettings, backupFilePath,
                        overwrite: true);
                }
            }

            using (var fs = File.OpenWrite(_pathToSettings))
            {
                JsonSerializer.Serialize(fs, AllRigs, _serializationOptions);
            }
        }
    }
}
