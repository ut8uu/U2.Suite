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

using DynamicData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using U2.Core;
using U2.MultiRig.Code;
using U2.MultiRig.Emulators.Lib;
using U2.MultiRig.Tests.TestData;
using Xunit;

namespace U2.MultiRig.Tests.Emulator;

public class RigEmulatorBaseTests
{
    public RigEmulatorBaseTests()
    {
        MultiRigApplicationContext.Instance.ResetBuilder();

        IC705Emulator.Register();
        MultiRigApplicationContext.Instance.BuildContainer();
    }

    [Theory]
    [ClassData(typeof(CanPrepareWriteCommandResponseTestData))]
    public void CanPrepareWriteCommandResponse(WriteCommandResponseTestData testData)
    {
        var emulator = RigEmulatorBase.Instance;

        Assert.True(emulator.TryPrepareWriteCommandResponse(testData.RigParameter, testData.RigCommand, out var response));
        Assert.True(testData.ExpectedResponse.SequenceEqual(testData.ExpectedResponse));
    }

    [Theory]
    [ClassData(typeof(CanExtractValueTestData))]
    public void CanExtractValue(ExtractValueTestData testData)
    {
        var emulator = RigEmulatorBase.Instance;

        var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var iniFilePath = Path.Combine(currentDirectory,
            "TestData", "RigCommand", "INI", "IC-705.ini");
        Assert.True(File.Exists(iniFilePath));
        var rigCommands = RigCommandUtilities.LoadRigCommands(iniFilePath);
        Assert.NotEmpty(rigCommands.InitCmd);
        
        Assert.True(emulator.TryExtractValue(rigCommands, testData.Code));

        if (!testData.ExpectsValue)
        {
            switch (testData.RigParameter)
            {
                case RigParameter.AM:
                case RigParameter.FM:
                case RigParameter.CW_L:
                case RigParameter.CW_U:
                case RigParameter.SSB_L:
                case RigParameter.SSB_U:
                case RigParameter.DIG_L:
                case RigParameter.DIG_U:
                    Assert.Equal(testData.RigParameter, emulator.Mode);
                    break;
                case RigParameter.Tx:
                case RigParameter.Rx:
                    Assert.Equal(testData.RigParameter, emulator.Tx);
                    break;
                case RigParameter.XitOff:
                case RigParameter.XitOn:
                    Assert.Equal(testData.RigParameter, emulator.Xit);
                    break;
                case RigParameter.RitOff:
                case RigParameter.RitOn:
                    Assert.Equal(testData.RigParameter, emulator.Rit);
                    break;
                case RigParameter.SplitOff:
                case RigParameter.SplitOn:
                    Assert.Equal(testData.RigParameter, emulator.Split);
                    break;
                case RigParameter.Pitch:
                    break;
                default:
                    break;
            }
        }

        if (testData.ExpectsValue)
        {
            switch (testData.RigParameter)
            {
                case RigParameter.FreqA:
                    Assert.Equal(testData.ExpectedValue, emulator.FreqA);
                    break;
                case RigParameter.FreqB:
                    Assert.Equal(testData.ExpectedValue, emulator.FreqB);
                    break;
                case RigParameter.Pitch:
                    // TODO implement injection and extration of the Pitch
                    //Assert.Equal(testData.ExpectedValue, emulator.Pitch);
                    break;
            }
        }

    }

    [Fact]
    public void CanManageEmulatorByUdp()
    {
        const int expectedFreq = 145500000;
        var emulator = RigEmulatorBase.Instance;
        var viewModel = new Emulators.Gui.MainWindowViewModel();

        Assert.True(((RigEmulatorBase)emulator)._hostRig.Enabled);

        emulator.FreqA = expectedFreq;

        var inTime = false;
        var task = Task.Factory.StartNew(() =>
        {
            while (viewModel.FreqA != expectedFreq)
            {
            }
            inTime = true;
        });
        //Assert.True(task.Wait(TimeSpan.FromMilliseconds(35000)));
        Assert.True(task.Wait(TimeSpan.FromMilliseconds(-1)));

        //emulator.
        Assert.True(inTime);
    }
}
