using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using CommandLineParser.Arguments;
using U2.MultiRig.Code;
using U2.MultiRig.Emulators;
using Xunit;

namespace U2.MultiRig.Tests;

public sealed class EmulatorTests : IDisposable
{
    private readonly IC705Emulator _emulator = new();
    private readonly RigCommands _rigCommands;

    public EmulatorTests()
    {
        MultiRigApplicationContext.Instance.BuildContainer();

        var stream = new MemoryStream(Encoding.ASCII.GetBytes(Resources.IC_705));
        _rigCommands = RigCommandUtilities.LoadRigCommands(stream, "IC-705");
    }

    private IRigSerialPort GetSerialPort()
    {
        return MultiRigApplicationContext.Instance.Container
            .Resolve<IRigSerialPort>();
    }

    public void Dispose()
    {
    }

    [Fact]
    public void CanSetFreqA()
    {
        var responseReceived = false;
        byte[] lastReceivedMessage = null;
        var serialPort = GetSerialPort();
        var statusCommand = _rigCommands.StatusCmd[0];
        Assert.NotNull(statusCommand);

        int actualValue = 0;

        serialPort.SerialPortMessageReceived += (sender, args) =>
        {
            HostRig.ValidateReply(args.Data, statusCommand.Validation);
            actualValue = ConversionFunctions.UnformatValue(args.Data, statusCommand.Values[0]);
            responseReceived = true;
            lastReceivedMessage = args.Data;
        };

        _emulator.FreqA = 14101500;

        serialPort.SendMessage(statusCommand.Code);

        var timeSpan = TimeSpan.FromMilliseconds(100);
        while (!responseReceived)
        {
            Thread.Sleep(timeSpan);
        }

        Assert.Equal(_emulator.FreqA, actualValue);
    }
}
