using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using U2.MultiRig.Code;
using U2.MultiRig.Utils;
using Xunit;

namespace U2.MultiRig.Tests;
public class IoCTests
{
    [Fact]
    public void TestRegistration()
    {
        var builder = new ContainerBuilder();
        builder.Register(c => new IcomIC705SerialPortEmulator())
            .As<IRigSerialPort>();

        var container = builder.Build();

        var serialPort = container.Resolve<IRigSerialPort>();
        Assert.NotNull(serialPort);
        Assert.Equal(typeof(IcomIC705SerialPortEmulator), serialPort.GetType());
    }
}
