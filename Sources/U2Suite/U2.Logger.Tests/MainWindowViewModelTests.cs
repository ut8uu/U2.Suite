using System;
using System.IO;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.Templates;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Contracts;
using U2.Core;
using U2.Core.Models;
using U2.Logger.Models;
using U2.Resources;

namespace U2.Logger.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private static string GetLocalTempPath()
        {
            var localDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var tempDirectory = Path.Combine(localDirectory, "Temp", Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

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

            var tempPath = GetLocalTempPath();
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => tempPath;

            var logDirectory = FileSystemHelper.GetDatabaseFolderPath(ApplicationNames.LoggerLinux);
            var logFileName = $"{parameters.LogName}{CommonConstants.DatabaseExtension}";
            var expectedDatabaseFile = Path.Combine(logDirectory, logFileName);
            var logInfoFileName = string.Format(CommonConstants.LogInfoFileFmt, parameters.LogName);
            var expectedLogInfoFile = Path.Combine(logDirectory, logInfoFileName);

            var message = new ExecuteCommandMessage(CommandToExecute.CreateLog, parameters);
            Messenger.Default.Send(message);

            Assert.IsTrue(File.Exists(expectedDatabaseFile),
                $"Database file {expectedDatabaseFile} does not exist.");
            Assert.IsTrue(File.Exists(expectedLogInfoFile),
                $"LogInfo file {expectedLogInfoFile} does not exist.");

            Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.ShutDown));
        }

        [TestMethod]
        public void SwitchToNotExistingLog()
        {
            var tempPath = GetLocalTempPath();
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => tempPath;

            var logName = "SwitchToNotExistingLog";
            var logFileName = $"{logName}{CommonConstants.DatabaseExtension}";
            var logDirectory = FileSystemHelper.GetDatabaseFolderPath(ApplicationNames.LoggerLinux);
            var expectedDatabaseFile = Path.Combine(logDirectory, logFileName);

            AppSettings.Default.LogName = logName;

            var model = GetViewModel();
            var message = new ExecuteCommandMessage(CommandToExecute.SwitchLog, logName);
            Messenger.Default.Send(message);

            Assert.IsTrue(File.Exists(expectedDatabaseFile),
                $"Database file {expectedDatabaseFile} does not exist.");
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

            // settings should point to the current log
            Assert.AreEqual(parameters.LogName, AppSettings.Default.LogName);
        }
    }
}
