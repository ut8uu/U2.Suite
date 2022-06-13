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
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using U2.MultiRig.Code;
using Xunit;

namespace U2.MultiRig.Tests;

public class IC705SerialPortEmulatorTests : RigTestsBase
{
    private IRigSerialPort GetSerialPort()
    {
        return MultiRigApplicationContext.Instance.Container.Resolve<IRigSerialPort>();
    }

    [Theory]
    [ClassData(typeof(Ic705SerialPortEmulatorInitCommandTestData))]
    public void CanSendInitCommand(Ic705SerialPortEmulatorInitCommandTestDataObject testData)
    {
        var serialPort = GetSerialPort();
        Assert.NotNull(serialPort);

        var commands = LoadIC705Ini();
        var init1 = commands.InitCmd.First();

        var responseReceived = false;

        serialPort.SerialPortMessageReceived += (sender, args) =>
        {
            HostRig.ValidateReply(args.Data, testData.RigCommand.Validation);
            responseReceived = true;
        };

        serialPort.SendMessage(testData.RigCommand.Code);

        while (!responseReceived)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        }
    }
}
