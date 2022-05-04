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

namespace U2.MultiRig;

public static class AllRigsSettings
{
    private const string SettingsFileName = "RigSettings.json";
    private static readonly List<RigSettings> DefaultRigSettings = new()
    {
        new RigSettings
        {
            RigId = "RIG1",
        }
    };

    internal static readonly string PathToSettings = Path.Combine(
        FileSystemHelper.GetAppDataFolderPath(nameof(AllRigsSettings)), SettingsFileName);
    private static readonly JsonSerializerOptions SerializationOptions =
        new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
        };


    public static List<RigSettings> AllRigs { get; } = new();

    public static void LoadSettings()
    {
        AllRigs.Clear();

        if (!File.Exists(PathToSettings))
        {
            AllRigs.AddRange(DefaultRigSettings);
            return;
        }

        using var fs = File.OpenRead(PathToSettings);
        try
        {
            var settings = JsonSerializer.Deserialize<List<RigSettings>>(fs) ?? DefaultRigSettings;
            AllRigs.AddRange(settings);
        }
        catch (JsonException)
        {
            AllRigs.AddRange(DefaultRigSettings);
        }
    }

    public static void SaveSettings()
    {
        if (File.Exists(PathToSettings))
        {
            var backupFilePath = $"{PathToSettings}.bak";
            File.Move(PathToSettings, backupFilePath, overwrite: true);
        }

        using (var fs = File.OpenWrite(PathToSettings))
        {
            JsonSerializer.Serialize(fs, AllRigs, SerializationOptions);
        }
    }
}
