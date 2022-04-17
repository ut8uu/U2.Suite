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
