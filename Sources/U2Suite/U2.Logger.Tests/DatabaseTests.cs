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

namespace U2.Logger.Tests
{
    [TestClass]
    public sealed class DatabaseTests
    {
        [TestMethod]
        public void TestBrokenDatabase()
        {
            bool messageReceived = false;
            Messenger.Default.Register<DatabaseCorruptedMessage>(this,
                (message) => messageReceived = true);

            const string badDatabase = nameof(badDatabase);

            var dbDirectory = FileSystemHelper.GetDatabaseFolderPath(U2.Resources.ApplicationNames.LoggerOsx);

            using var tempDirectory = new TempDirectory(dbDirectory);
            AppSettings.Default.LogName = badDatabase;
            var badDatabasePath = Path.Combine(dbDirectory, badDatabase);
            File.WriteAllText(badDatabasePath, badDatabase);

            var db = LoggerDbContext.Instance;

            Assert.IsTrue(messageReceived);
        }
    }
}
