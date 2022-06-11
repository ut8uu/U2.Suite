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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.MultiRig.Code;
using U2.MultiRig.Emulators.Lib;
using U2.MultiRig.Tests.TestData;
using Xunit;

namespace U2.MultiRig.Tests.Emulator;

public class RigEmulatorBaseTests
{
    [Theory]
    [ClassData(typeof(CanPrepareWriteCommandResponseTestData))]
    public void CanPrepareWriteCommandResponse(WriteCommandResponseTestData testData)
    {
        IC705Emulator.Register();
        MultiRigApplicationContext.Instance.BuildContainer();
        var emulator = RigEmulatorBase.Instance;

        Assert.True(emulator.TryPrepareWriteCommandResponse(testData.RigParameter, testData.RigCommand, out var response));
        Assert.True(testData.ExpectedResponse.SequenceEqual(testData.ExpectedResponse));
    }
}
