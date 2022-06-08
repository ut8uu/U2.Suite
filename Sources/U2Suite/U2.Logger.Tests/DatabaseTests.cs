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
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Core;
using U2.Core.Models;
using U2.Tests.Common;

namespace U2.Logger.Tests
{
    [TestClass]
    public sealed class DatabaseTests
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
        public void TestBrokenDatabase()
        {
            bool messageReceived = false;
            Messenger.Default.Register<DatabaseCorruptedMessage>(this,
                (message) => messageReceived = true);

            const string badDatabase = nameof(badDatabase);

            var dbDirectory = FileSystemHelper.GetDatabaseFolderPath(U2.Resources.ApplicationNames.LoggerOsx);

            LoggerAppSettings.Default.LogName = badDatabase;
            var badDatabasePath = Path.Combine(dbDirectory, badDatabase);
            File.WriteAllText(badDatabasePath, badDatabase);

            var db = LoggerDbContext.Instance;

            Assert.IsTrue(messageReceived);
        }
    }
}
