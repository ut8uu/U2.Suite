/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U2.Tests.Common;

public static class TestHelpers
{
    public static string GetLocalTempPath()
    {
        var localDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Debug.Assert(!string.IsNullOrEmpty(localDirectory));
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
