using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Contracts;

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
