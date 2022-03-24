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
            var window = new LogInfoWindowViewModel(commandToExecute);
            Assert.AreEqual(title, window.WindowTitle);
        }

        [TestMethod]
        public void CreateWindow_UnexpectedParameter()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new LogInfoWindowViewModel(CommandToExecute.InitQso));
        }
    }
}
