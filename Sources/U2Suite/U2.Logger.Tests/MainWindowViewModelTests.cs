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
using U2.Tests.Common;

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

        [TestInitialize]
        public void InitTest()
        {
            var tempPath = TestHelpers.GetLocalTempPath();
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => tempPath;

            Directory.Delete(tempPath, true);
            Directory.CreateDirectory(tempPath);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var tempPath = TestHelpers.GetLocalTempPath();
            Directory.Delete(tempPath, recursive: true);
        }

        [TestMethod]
        public void CreateNewLogSuccess()
        {
            var model = GetViewModel();
            var parameters = LogInfoTestHelper.GetLogInfo();

            var tempPath = TestHelpers.GetLocalTempPath();
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

            Assert.IsTrue(model.WindowTitle.Contains(parameters.LogName));

            Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.ShutDown));
        }

        [TestMethod]
        public void SwitchToNotExistingLog()
        {
            var logName = "SwitchToNotExistingLog";
            var logFileName = $"{logName}{CommonConstants.DatabaseExtension}";
            var logDirectory = FileSystemHelper.GetDatabaseFolderPath(ApplicationNames.LoggerLinux);
            var expectedDatabaseFile = Path.Combine(logDirectory, logFileName);

            LoggerAppSettings.Default.LogName = logName;

            var model = GetViewModel();
            var message = new ExecuteCommandMessage(CommandToExecute.SwitchLog, logName);
            Messenger.Default.Send(message);

            Assert.IsTrue(File.Exists(expectedDatabaseFile),
                $"Database file {expectedDatabaseFile} does not exist.");
        }

        [TestMethod]
        public void CreateNewLog_AlreadyExists()
        {
            var tempPath = TestHelpers.GetLocalTempPath();
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => tempPath;

            var parameters = LogInfoTestHelper.GetLogInfo();

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
            Assert.AreEqual(parameters.LogName, LoggerAppSettings.Default.LogName);
        }

        [TestMethod]
        public void UpdateLog()
        {
            var model = GetViewModel();
            var expectedLogInfo = LogInfoTestHelper.GetLogInfo();
            LogInfoHelper.SaveLogInfo(expectedLogInfo);

            expectedLogInfo.OperatorCallsign = "UT3UBR";
            expectedLogInfo.StationCallsign = "UT3UBR/P";
            expectedLogInfo.ActivatedReference = "URFF-0001";
            expectedLogInfo.Description = "updated description";

            var message = new ExecuteCommandMessage(CommandToExecute.UpdateLog, expectedLogInfo);
            Messenger.Default.Send(message);

            var currentLogInfo = LogInfoHelper.LoadLogInfo(LoggerAppSettings.Default.LogName);
            TestHelpers.AssertAreEqual(expectedLogInfo, currentLogInfo);
        }
    }
}
