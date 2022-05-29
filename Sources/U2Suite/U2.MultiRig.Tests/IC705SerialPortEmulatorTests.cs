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

        serialPort.Start();

        serialPort.SendMessage(testData.RigCommand.Code);

        while (!responseReceived)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        }
    }
}
