using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace U2.MultiRig.Tests;

public class UdpSenderReceiverTests
{
    [Fact]
    public async Task CanSendAndReceiveData()
    {
        var bytes = Encoding.ASCII.GetBytes("mama");
        var port = 10110;
        var cancellationToken = CancellationToken.None;
        var multiCastAddress = IPAddress.Parse("224.5.11.71");
        using var sender = new UdpMulticastSender(multiCastAddress, port, cancellationToken);
        using var receiver = new UdpMulticastReceiver(multiCastAddress, port, cancellationToken);

        var dataReceived = false;
        receiver.MulticastDataReceived += (o, args) => dataReceived = true;

        var numberOfSentBytes = sender.Send(bytes);
        Assert.Equal(bytes.Length, numberOfSentBytes);

        var task = Task.Factory.StartNew(() =>
        {
            while (!dataReceived) { }
        }, CancellationToken.None);

        var finishedInTime = task.Wait(TimeSpan.FromMilliseconds(5000));
        Assert.True(dataReceived);
        Assert.True(finishedInTime);
    }
}
