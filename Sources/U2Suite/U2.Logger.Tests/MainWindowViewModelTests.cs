using System;
using System.IO;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Contracts;
using U2.Core;
using U2.Logger.Models;
using U2.Resources;

namespace U2.Logger.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private static MainWindowViewModel GetViewModel()
        {
            var viewModel = new MainWindowViewModel();
            return viewModel;
        }

        private static LogInfo GetLogInfo()
        {
            return new LogInfo
            {
                Description = String.Empty,
                LogName = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss") + DateTime.UtcNow.Millisecond
            };
        }

        [TestMethod]
        public void CreateNewLogSuccess()
        {
            var model = GetViewModel();

            var parameters = GetLogInfo();

            var logDirectory = FileSystemHelper.GetDatabaseFolderPath(ApplicationNames.LoggerLinux);
            var logFileName = $"{parameters.LogName}{CommonConstants.DatabaseExtension}";
            var expectedFile = Path.Combine(logDirectory, logFileName);

            var message = new ExecuteCommandMessage(CommandToExecute.CreateLog, parameters);
            Messenger.Default.Send(message);

            Assert.IsTrue(File.Exists(expectedFile), $"File {expectedFile} does not exist.");
        }

        [TestMethod]
        public void CreateNewLog_AlreadyExists()
        {
            var model = GetViewModel();

            var expectedLogName = AppSettings.Default.LogName;

            var parameters = GetLogInfo();

            var logDirectory = FileSystemHelper.GetDatabaseFolderPath(ApplicationNames.LoggerLinux);
            var logFileName = $"{parameters.LogName}{CommonConstants.DatabaseExtension}";
            var expectedFile = Path.Combine(logDirectory, logFileName);
            var expectedFileContent = "test content";

            File.WriteAllText(expectedFile, expectedFileContent);
            Assert.IsTrue(File.Exists(expectedFile), $"File {expectedFile} does not exist.");

            var message = new ExecuteCommandMessage(CommandToExecute.CreateLog, parameters);
            Messenger.Default.Send(message);

            Assert.IsTrue(File.Exists(expectedFile), $"File {expectedFile} does not exist.");
            var fileInfo = new FileInfo(expectedFile);
            // file should not be overwritten
            Assert.AreEqual(expectedFileContent.Length, fileInfo.Length);

            // settings should point to the previous log
            Assert.AreEqual(expectedLogName, AppSettings.Default.LogName);
        }
    }
}
