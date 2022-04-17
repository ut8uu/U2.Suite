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
                Port = 1,
                RigType = 1,
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
}