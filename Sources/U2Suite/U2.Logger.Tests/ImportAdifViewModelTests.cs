using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Logger.Tests
{
    [TestClass]
    public class ImportAdifViewModelTests
    {
        private ImportAdifFromFileViewModel GetViewModel()
        {
            return new ImportAdifFromFileViewModel();
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
    }
}
