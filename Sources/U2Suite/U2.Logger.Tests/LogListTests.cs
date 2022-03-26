using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Core.Models;

namespace U2.Logger.Tests;

[TestClass]
public sealed class LogListTests
{
    private static LogInfo GetRandomLogInfo()
    {
        var logInfo = new LogInfo
        {
            LogName = Path.GetRandomFileName(),
            Description = "description",
        };
        return logInfo;
    }

    private static void SerialzeToFile(string fileName, LogInfo logInfo)
    {
        using var stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write, FileShare.Delete);
        JsonSerializer.Serialize(stream, logInfo);
    }

    [TestMethod]
    public void LoadListOfDatabases()
    {
        using var tempDirectory = new TempDirectory();
        SerialzeToFile(Path.Combine(tempDirectory.TempPath, "001.json"), GetRandomLogInfo());
        SerialzeToFile(Path.Combine(tempDirectory.TempPath, "002.json"), GetRandomLogInfo());
        SerialzeToFile(Path.Combine(tempDirectory.TempPath, "003.json"), GetRandomLogInfo());

        Assert.AreEqual(3, Directory.EnumerateFiles(tempDirectory.TempPath).Count());

        var model = new LogListViewModel(tempDirectory.TempPath);
        Assert.AreEqual(3, model.List.Count);
    }
}
