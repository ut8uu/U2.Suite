using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Core.Models;
using U2.Core;
using U2.Tests.Common;

namespace U2.Logger.Tests
{
    [TestClass]
    public class LogInfoWindowViewModelTests
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
        public void CreateWindow_CreateLog_SetTitle()
        {
            var model = new LogInfoWindowViewModel(CommandToExecute.CreateLog);
            Assert.AreEqual("Create new log", model.WindowTitle);
        }

        [TestMethod]
        public void CreateWindow_UpdateLog_SetTitle()
        {
            var logInfo = LogInfoTestHelper.GetLogInfo();
            AppSettings.Default.LogName = logInfo.LogName;
            LogInfoHelper.SaveLogInfo(logInfo);

            var model = new LogInfoWindowViewModel(CommandToExecute.UpdateLog);
            Assert.AreEqual("Update existing log", model.WindowTitle);
        }

        [TestMethod]
        public void CreateWindow_UnexpectedParameter()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new LogInfoWindowViewModel(CommandToExecute.InitQso));
        }

        [TestMethod]
        public void FieldValidation()
        {
            var model = new LogInfoWindowViewModel(CommandToExecute.CreateLog);
            model.SetLogInfo(LogInfoTestHelper.GetLogInfo());

            Assert.ThrowsException<Avalonia.Data.DataValidationException>(
                () => {
                    model.StationCallsign = string.Empty;
                    model.CanExecute(throwException: true, out var _);
                });
            model.StationCallsign = nameof(model.StationCallsign);
            Assert.ThrowsException<Avalonia.Data.DataValidationException>(
                () =>
                {
                    model.LogName = string.Empty;
                    model.CanExecute(throwException: true, out var _);
                });
        }
    }
}
