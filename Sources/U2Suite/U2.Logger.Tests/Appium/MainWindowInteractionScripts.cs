using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using TechTalk.SpecFlow;
using System.Linq;
using Avalonia.Input;

namespace U2.Logger.Tests.Appium
{
    [Binding]
    public class MainWindowInteraction : U2LoggerSession
    {
        private readonly ScenarioContext _scenarioContext;

        public MainWindowInteraction(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region TestClass stuff

        [BeforeFeature]
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Create session to launch a U2.Logger window
            Setup(context);
        }

        [AfterFeature]
        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

        [BeforeScenario]
        [TestInitialize]
        public void Clear()
        {
            ClickButton(_wipeButton);
        }

        #endregion

        #region Given

        [Given("Application is started")]
        public void GivenApplicationIsStarted()
        {
        }


        [Given("log is empty")]
        public void GivenLogIsEmpty()
        {
            using var dbContext = new LoggerDbContext();
            var records = dbContext.Records.ToList();
            if (records.Any())
            {
                foreach (var rec in records)
                {
                    dbContext.Records.Remove(rec);
                }

                dbContext.SaveChanges();
            }
        }

        #endregion

        #region When

        [When("user enters '(.*)' in Callsign")]
        public void WhenUserEntersInCallsign(string value)
        {
            RaiseTextEvent(_callsignField, value);
        }

        [When("user clicks the Save button")]
        public void WhenUserClicksTheSaveButton()
        {
            ClickButton(_saveButton);
        }

        #endregion

        #region Then

        [Then("log contains (.*) record")]
        public void ThenLogContainsRecord(int numberOfRecords)
        {
            using var dbContext = new LoggerDbContext();
            Assert.AreEqual(numberOfRecords, dbContext.Records.Count());
        }

        #endregion
    }
}
