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
