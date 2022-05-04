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
using System.IO;
using System.Linq;
using System.Text.Json;
using DeepEqual.Syntax;
using Xunit;

namespace U2.MultiRig.Tests;

public sealed class RigSettingsTests : IDisposable
{
    public RigSettingsTests()
    {
        PrepareDirectory();
    }

    private static void PrepareDirectory()
    {
        var pathToFile = AllRigsSettings._pathToSettings;
        var directory = Path.GetDirectoryName(pathToFile);
        Assert.NotNull(directory);
        if (Directory.Exists(directory))
        {
            Directory.Delete(directory, recursive: true);
        }
        Directory.CreateDirectory(directory);
    }

    private static List<RigSettings> PrepareRigSettings()
    {
        return new List<RigSettings>
        {
            new()
            {
                RigId = "RIG1",
                BaudRate = 1,
                DataBits = 1,
                DtrMode = 1,
                Parity = 1,
                PollMs = 1,
                Port = "NONE",
                RigType = string.Empty,
                RtsMode = 1,
                StopBits = 1,
                TimeoutMs = 1,
            },
            new() {RigId = "RIG2"},
            new() {RigId = "RIG3"},
        };
    }

    public void Dispose()
    {
        PrepareDirectory();
    }

    [Fact]
    public void LoadAllSettings()
    {
        var allSettings = PrepareRigSettings();
        var pathToFile = AllRigsSettings._pathToSettings;
        using (var fs = File.OpenWrite(pathToFile))
        {
            // file should not be locked
            JsonSerializer.Serialize(fs, allSettings);
        }

        AllRigsSettings.LoadSettings();
        Assert.Equal(allSettings.Count, AllRigsSettings.AllRigs.Count);
        Assert.Contains("RIG1", AllRigsSettings.AllRigs.Select(rs => rs.RigId));
        Assert.Contains("RIG2", AllRigsSettings.AllRigs.Select(rs => rs.RigId));
        Assert.Contains("RIG3", AllRigsSettings.AllRigs.Select(rs => rs.RigId));
    }

    [Fact]
    public void SaveAllSettings()
    {
        var settings = PrepareRigSettings();

        AllRigsSettings.AllRigs.Clear();
        AllRigsSettings.AllRigs.AddRange(settings);
        AllRigsSettings.SaveSettings();

        Assert.True(File.Exists(AllRigsSettings._pathToSettings));
        using (var fs = File.OpenRead(AllRigsSettings._pathToSettings))
        {
            var savedSettings = JsonSerializer.Deserialize<List<RigSettings>>(fs);
            savedSettings.ShouldDeepEqual(settings);
        }
    }

    [Fact]
    public void LoadEmptySettings_ShouldCreateOneDefaultSetting()
    {
        var pathToFile = AllRigsSettings._pathToSettings;
        File.WriteAllText(pathToFile, string.Empty);
        AllRigsSettings.LoadSettings();
        Assert.Single(AllRigsSettings.AllRigs);
    }

    [Fact]
    public void LoadFromNonExistentFile_ShouldCreateOneDefaultSetting()
    {
        var pathToFile = AllRigsSettings._pathToSettings;
        AllRigsSettings.LoadSettings();
        Assert.Single(AllRigsSettings.AllRigs);
    }

    [Fact]
    public void ShouldDeleteExistingSettings()
    {
        const string oldName = nameof(oldName);
        var pathToFile = AllRigsSettings._pathToSettings;
        AllRigsSettings.AllRigs.Add(new()
        {
            RigId = oldName,
        });
        AllRigsSettings.LoadSettings();
        Assert.DoesNotContain(AllRigsSettings.AllRigs, r => r.RigId == oldName);
    }
}