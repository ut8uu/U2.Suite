using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Logger.Tests
{
    [TestClass]
    public class LogInfoWindowViewModelTests
    {
        [TestInitialize]
        public void InitTest()
        {
        }

        [TestCleanup]
        public void CleanupTest()
        {
        }

        [TestMethod]
        [DataRow(CommandToExecute.CreateLog, "Create new log")]
        [DataRow(CommandToExecute.UpdateLog, "Update existing log")]
        public void CreateWindow_SetTitle(CommandToExecute commandToExecute, string title)
        {
            var model = new LogInfoWindowViewModel(commandToExecute);
            Assert.AreEqual(title, model.WindowTitle);
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
            var model = new LogInfoWindowViewModel(CommandToExecute.CreateLog)
            {
                StationCallsign = "1",
                LogName = "2",
            };
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
