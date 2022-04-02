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
        private string _tempDirectory = TestHelpers.GetLocalTempPath();

        [TestInitialize]
        public void InitTest()
        {
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => _tempDirectory;

            Directory.Delete(_tempDirectory, true);
            Directory.CreateDirectory(_tempDirectory);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Directory.Delete(_tempDirectory, recursive: true);
        }

        [TestMethod]
        public void SaveLoadLogInfo()
        {
            var expectedLogInfo = new LogInfo
            {
                ActivatedReference = "1",
                Description = "2",
                LogName = "LogName",
                MaxDate = DateTime.MaxValue,
                MinDate = DateTime.MinValue,
                NumberOfRecords = 1,
                OperatorCallsign = "4",
                StationCallsign = "5",
            };

            LogInfoHelper.SaveLogInfo(expectedLogInfo);
            var currentLogInfo = LogInfoHelper.LoadLogInfo(expectedLogInfo.LogName);

            TestHelpers.AssertAreEqual(expectedLogInfo, currentLogInfo);
        }

        [TestMethod]
        public void LoadFromBadFile()
        {
            var logName = "1";
            var logInfoFile = LogInfoHelper.FormatLogInfoFileName(logName);
            var logInfoPath = Path.Combine(_tempDirectory, logInfoFile);
            File.WriteAllText(logInfoPath, "123");

            Assert.ThrowsException<BadLogInfoException>(() => LogInfoHelper.LoadLogInfo(logName));
        }

        [TestMethod]
        public void LoadFromNotExistingFile()
        {
            Assert.ThrowsException<LogInfoNotFoundException>(() => LogInfoHelper.LoadLogInfo("NotExistingFile"));
        }
    }
}
