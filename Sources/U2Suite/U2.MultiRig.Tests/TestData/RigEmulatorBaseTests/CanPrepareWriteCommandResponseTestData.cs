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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace U2.MultiRig.Tests;

public class CanPrepareWriteCommandResponseTestData
: IEnumerable<object[]>
{
    private readonly RigCommands _rigCommands;

    public CanPrepareWriteCommandResponseTestData()
    {
        var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var iniFilePath = Path.Combine(currentDirectory,
            "TestData", "RigCommand", "INI", "IC-705.ini");
        Assert.True(File.Exists(iniFilePath));
        _rigCommands = RigCommandUtilities.LoadRigCommands(iniFilePath);
        Assert.NotEmpty(_rigCommands.InitCmd);
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new List<object>();
        testData.AddRange(_rigCommands.WriteCmd.Keys.Select(PrepareResponse));

        var inconsistentParameter = PrepareResponse((int)RigParameter.FreqA);
        inconsistentParameter.RigParameter = RigParameter.FreqB;
        inconsistentParameter.ExpectedResult = false;
        testData.Add(inconsistentParameter);

        return testData.Select(td => new[] { td })
            .GetEnumerator();
    }

    private WriteCommandResponseTestData PrepareResponse(int parameter)
    {
        var command = _rigCommands.WriteCmd[parameter];
        return new WriteCommandResponseTestData
        {
            RigParameter = (RigParameter) parameter,
            RigCommand = command,
            ExpectedResponse = command.Validation.Flags,
            ExpectedResult = true,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class WriteCommandResponseTestData
{
    public RigParameter RigParameter { get; set; }
    public RigCommand RigCommand { get; set; }
    public byte[] ExpectedResponse { get; set; }
    public bool ExpectedResult { get; set; }
}
