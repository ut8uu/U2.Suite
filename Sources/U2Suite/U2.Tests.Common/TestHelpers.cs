using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Tests.Common
{
    public static class TestHelpers
    {
        public static string GetLocalTempPath()
        {
            var localDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var tempDirectory = Path.Combine(localDirectory, "Temp", Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        public static void AssertAreEqual<T>(T expectedObject, T actualObject)
        {
            var compareLogic = new CompareLogic();
            var comparisonResult = compareLogic.Compare(expectedObject, actualObject);
            Assert.IsTrue(comparisonResult.AreEqual, comparisonResult.DifferencesString);
        }
    }
}
