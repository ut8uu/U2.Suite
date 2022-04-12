using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Core;
using U2.Tests.Common;

namespace U2.Logger.Tests
{
    [TestClass]
    public class ImportAdifViewModelTests
    {
        private string _tempDirectory = TestHelpers.GetLocalTempPath();
        private ImportAdifFromFileViewModel GetViewModel()
        {
            return new ImportAdifFromFileViewModel();
        }

        [TestInitialize]
        public void InitTest()
        {
            FileSystemHelper.GetDatabaseFolderFunc = (applicationName) => _tempDirectory;

            LoggerDbContext.Instance.Database.EnsureDeleted();

            Directory.Delete(_tempDirectory, true);
            Directory.CreateDirectory(_tempDirectory);

            var dbDirectory = FileSystemHelper.GetDatabaseFolderPath(U2.Resources.ApplicationNames.LoggerOsx);

            var dbName = "ImportAdifViewModelTests";
            AppSettings.Default.LogName = dbName;
            var databasePath = Path.Combine(dbDirectory, dbName);
            File.WriteAllText(databasePath, dbName);

            LoggerDbContext.Reset();
            LoggerDbContext.Instance.Database.Migrate();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            LoggerDbContext.Instance.Database.EnsureDeleted();
            Directory.Delete(_tempDirectory, recursive: true);
        }

        [TestMethod]
        public void DuplicateOptionRadioButtonTest()
        {
            var model = GetViewModel();

            model.ExecuteAddSelectedAction();
            Assert.AreEqual(DuplicateRecordSaveOption.Add, model._duplicateRecordSaveOption);

            model.ExecuteOverwriteSelectedAction();
            Assert.AreEqual(DuplicateRecordSaveOption.Overwrite, model._duplicateRecordSaveOption);

            model.ExecuteIgnoreSelectedAction();
            Assert.AreEqual(DuplicateRecordSaveOption.Ignore, model._duplicateRecordSaveOption);
        }

        [TestMethod]
        public async Task CanProcessGoodFile()
        {
            var model = GetViewModel();

            var testData = TestData.GetLogRecords();
            var adifFilePath = Path.Combine(_tempDirectory, "CanProcessGoodFile.adi");
            await AdifHelper.ExportAsync(adifFilePath, LogInfoTestHelper.GetLogInfo(), testData);

            var duplicate = testData.First();
            LoggerDbContext.Instance.Records.Add(duplicate);
            LoggerDbContext.Instance.SaveChanges();

            Assert.AreEqual(1, LoggerDbContext.Instance.Records.Count());

            await model.ProcessAdifFileAsync(adifFilePath, CancellationToken.None);
            Assert.AreEqual(testData.Count(), model.AdifFileRecords);
            Assert.AreEqual(1, model.AdifFileDuplicates);
        }

        private async Task CanImportRecords_Prepare(
            ImportAdifFromFileViewModel model,
            Guid duplicateId)
        {
            // add one record to simulate a duplicate record
            var duplicate = TestData.GetLogRecords().First();
            duplicate.RecordId = duplicateId;
            LoggerDbContext.Instance.Records.Add(duplicate);
            LoggerDbContext.Instance.SaveChanges();

            model._loadedRecords.Clear();
            model._loadedRecords.AddRange(TestData.GetLogRecords());

            model._duplicates.Clear();
            model._duplicates.Add(duplicate);
        }

        [TestMethod]
        public async Task CanImportRecords_OverwriteDuplicates()
        {
            var duplicateId = Guid.NewGuid();
            var model = GetViewModel();
            await CanImportRecords_Prepare(model, duplicateId);

            // duplicate record should be overwritten
            model._duplicateRecordSaveOption = DuplicateRecordSaveOption.Overwrite;
            model.ExecuteImportAction();

            Assert.IsFalse(LoggerDbContext.Instance.Records.Any(r => r.RecordId == duplicateId));
            Assert.AreEqual(TestData.GetLogRecords().Count(), LoggerDbContext.Instance.Records.Count());
        }

        [TestMethod]
        public async Task CanImportRecords_IgnoreDuplicates()
        {
            var duplicateId = Guid.NewGuid();
            var model = GetViewModel();
            await CanImportRecords_Prepare(model, duplicateId);

            // duplicate record should be overwritten
            model._duplicateRecordSaveOption = DuplicateRecordSaveOption.Ignore;
            model.ExecuteImportAction();

            Assert.IsTrue(LoggerDbContext.Instance.Records.Any(r => r.RecordId == duplicateId));
            Assert.AreEqual(TestData.GetLogRecords().Count(), LoggerDbContext.Instance.Records.Count());
        }

        [TestMethod]
        public async Task CanImportRecords_AddDuplicates()
        {
            var expectedCount = TestData.GetLogRecords().Count() + 1;

            var duplicateId = Guid.NewGuid();
            var model = GetViewModel();
            await CanImportRecords_Prepare(model, duplicateId);

            // duplicate record should be overwritten
            model._duplicateRecordSaveOption = DuplicateRecordSaveOption.Add;
            model.ExecuteImportAction();

            Assert.IsTrue(LoggerDbContext.Instance.Records.Any(r => r.RecordId == duplicateId));
            Assert.AreEqual(expectedCount, LoggerDbContext.Instance.Records.Count());
        }
    }
}
