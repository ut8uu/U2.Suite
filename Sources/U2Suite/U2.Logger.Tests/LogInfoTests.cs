using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Core;
using U2.Core.Models;
using U2.Tests.Common;

namespace U2.Logger.Tests
{
    [TestClass]
    public sealed class LogInfoTests
    {
        [TestMethod]
        public void LoadFromGoodFile()
        {
            using var tempDirectory = new TempDirectory();
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => tempDirectory.TempPath;

            var logInfo = new LogInfo
            {
                ActivatedReference = "1",
                Description = "2",
                LogName = "3",
                MaxDate = DateTime.MaxValue,
                MinDate = DateTime.MinValue,
                NumberOfRecords = 1,
                OperatorCallsign = "4",
                StationCallsign = "5",
            };
            var logInfoFile = $"1.json";
            var logInfoPath = Path.Combine(tempDirectory.TempPath, logInfoFile);
            using (var stream = new FileStream(logInfoPath, FileMode.Create, FileAccess.Write, FileShare.Delete))
            {
                JsonSerializer.Serialize(stream, logInfo);
            }

            var loadedObject = LogInfoHelper.LoadLogInfo("1");

            var compareLogic = new CompareLogic();
            var comparisonResult = compareLogic.Compare(logInfo, loadedObject);
            Assert.IsTrue(comparisonResult.AreEqual, comparisonResult.DifferencesString);
        }

        [TestMethod]
        public void LoadFromBadFile()
        {
            using var tempDirectory = new TempDirectory();
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => tempDirectory.TempPath;

            var logInfoFile = $"1.json";
            var logInfoPath = Path.Combine(tempDirectory.TempPath, logInfoFile);
            File.WriteAllText(logInfoPath, "123");

            Assert.ThrowsException<BadLogInfoException>(() => LogInfoHelper.LoadLogInfo("1"));
        }

        [TestMethod]
        public void LoadFromNotExistingFile()
        {
            using var tempDirectory = new TempDirectory();
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => tempDirectory.TempPath;

            Assert.ThrowsException<LogInfoNotFoundException>(() => LogInfoHelper.LoadLogInfo("NotExistingFile"));
        }

    }
}
