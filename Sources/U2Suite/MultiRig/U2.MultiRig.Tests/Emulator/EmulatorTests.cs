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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using CommandLineParser.Arguments;
using Newtonsoft.Json.Linq;
using U2.MultiRig.Code;
using U2.MultiRig.Emulators.Lib;
using Xunit;

namespace U2.MultiRig.Tests;

public sealed class EmulatorTests : IDisposable
{
    private readonly IRigEmulator _emulator;
    private readonly RigCommands _rigCommands;

    public EmulatorTests()
    {
        IC705Emulator.Register();
        MultiRigApplicationContext.Instance.BuildContainer();
        _emulator = RigEmulatorBase.Instance;

        var stream = new MemoryStream(Encoding.ASCII.GetBytes(Resources.IC_705));
        _rigCommands = RigCommandUtilities.LoadRigCommands(stream, "IC-705");
    }

    private IRigSerialPort GetSerialPort()
    {
        var serialPort = MultiRigApplicationContext.Instance.Container
            .Resolve<IRigSerialPort>();
        Assert.NotNull(serialPort);

        var result = (RigSerialPortEmulatorBase) serialPort;
        return result;
    }

    public void Dispose()
    {
    }

    [Theory]
    [InlineData(RigParameter.FreqA, 14101500)]
    [InlineData(RigParameter.FreqB, 14101500)]
    public void CanSetRigParameter(RigParameter parameter, int value)
    {
        var responseReceived = false;
        byte[] lastReceivedMessage = null;
        var serialPort = GetSerialPort();
        var statusCommand = _rigCommands.StatusCmd.
            FirstOrDefault(c => c.Values.Any(x => x.Param == parameter));
        Assert.NotNull(statusCommand);

        int actualValue = 0;

        serialPort.SerialPortMessageReceived += (sender, args) =>
        {
            HostRig.ValidateReply(args.Data, statusCommand.Validation);
            actualValue = ConversionFunctions.UnformatValue(args.Data, statusCommand.Values[0]);
            responseReceived = true;
            lastReceivedMessage = args.Data;
        };

        switch (parameter)
        {
            case RigParameter.FreqA:
                _emulator.FreqA = value;
                break;
            case RigParameter.FreqB:
                _emulator.FreqB = value;
                break;
            default:
                throw new ArgumentOutOfRangeException($"Parameter {parameter} is out of range.");
        }

        serialPort.SendMessage(statusCommand.Code);

        var timeSpan = TimeSpan.FromMilliseconds(100);
        while (!responseReceived)
        {
            Thread.Sleep(timeSpan);
        }

        Assert.Equal(value, actualValue);
    }

    [Theory]
    [InlineData(RigParameter.AM)]
    [InlineData(RigParameter.FM)]
    [InlineData(RigParameter.SSB_U)]
    [InlineData(RigParameter.SSB_L)]
    [InlineData(RigParameter.CW_L)]
    [InlineData(RigParameter.CW_U)]
    [InlineData(RigParameter.DIG_L)]
    [InlineData(RigParameter.DIG_U)]
    [InlineData(RigParameter.Rx)]
    [InlineData(RigParameter.Tx)]
    [InlineData(RigParameter.RitOff)]
    [InlineData(RigParameter.RitOn)]
    [InlineData(RigParameter.XitOff)]
    [InlineData(RigParameter.XitOn)]
    public void CanSwitchParameter(RigParameter expectedParameter)
    {
        var responseReceived = false;
        byte[] lastReceivedMessage = null;
        var serialPort = GetSerialPort();
        var statusCommand = _rigCommands.StatusCmd.
            FirstOrDefault(c => c.Flags.Any(x => x.Param == expectedParameter));
        Assert.NotNull(statusCommand);

        RigParameter actualParameter = RigParameter.None;

        serialPort.SerialPortMessageReceived += (sender, args) =>
        {
            HostRig.ValidateReply(args.Data, statusCommand.Validation);
            for (var i = 0; i < statusCommand.Flags.Count; i++)
            {
                if (!statusCommand.Flags[i].Flags.SequenceEqual(
                        ByteFunctions.BytesAnd(args.Data, statusCommand.Flags[i].Mask)))
                {
                    continue;
                }
                actualParameter = statusCommand.Flags[i].Param;
                break;
            }
            responseReceived = true;
            lastReceivedMessage = args.Data;
        };

        switch (expectedParameter)
        {
            case RigParameter.AM:
            case RigParameter.FM:
            case RigParameter.CW_L:
            case RigParameter.CW_U:
            case RigParameter.SSB_L:
            case RigParameter.SSB_U:
            case RigParameter.DIG_L:
            case RigParameter.DIG_U:
                _emulator.Mode = expectedParameter;
                break;
            case RigParameter.Tx:
            case RigParameter.Rx:
                _emulator.Tx = expectedParameter;
                break;
            case RigParameter.XitOff:
            case RigParameter.XitOn:
                _emulator.Xit = expectedParameter;
                break;
            case RigParameter.RitOff:
            case RigParameter.RitOn:
                _emulator.Rit = expectedParameter;
                break;
            case RigParameter.SplitOff:
            case RigParameter.SplitOn:
                _emulator.Split = expectedParameter;
                break;
            default:
                throw new ArgumentOutOfRangeException($"Parameter {expectedParameter} not supported.");
        }

        serialPort.SendMessage(statusCommand.Code);

        var timeSpan = TimeSpan.FromMilliseconds(100);
        while (!responseReceived)
        {
            Thread.Sleep(timeSpan);
        }

        Assert.Equal(expectedParameter, actualParameter);
    }
}
