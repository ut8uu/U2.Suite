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
        result.RigEmulator = RigEmulatorBase.Instance;
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
}
