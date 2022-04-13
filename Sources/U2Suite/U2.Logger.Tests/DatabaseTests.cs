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

            AppSettings.Default.LogName = badDatabase;
            var badDatabasePath = Path.Combine(dbDirectory, badDatabase);
            File.WriteAllText(badDatabasePath, badDatabase);

            var db = LoggerDbContext.Instance;

            Assert.IsTrue(messageReceived);
        }
    }
}
