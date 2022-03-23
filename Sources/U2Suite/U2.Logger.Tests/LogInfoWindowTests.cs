using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Logger.Tests
{
    [TestClass]
    public class LogInfoWindowTests
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
        [DataRow(CommandToExecute.CreateLog)]
        [DataRow(CommandToExecute.UpdateLog)]
        public void CreateWindow_SetTitle(CommandToExecute commandToExecute)
        {
            var window = new LogInfoWindow(commandToExecute);
            Assert.AreEqual(Resources.CreateNewLog, window.Title);
        }

        [TestMethod]
        public void CreateWindow_UnexpectedParameter()
        {
            Assert.ThrowsException<Avalonia.Data.DataValidationException>(() =>
                new LogInfoWindow(CommandToExecute.InitQso));
        }
    }
}
