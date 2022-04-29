using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimpleUdp;
using log4net;

namespace U2.MultiRig;

public class UdpMessageType
{
    public const string Status = nameof(Status);
    public const string Params = nameof(Params);
    public const string Custom = nameof(Custom);
    public const string Visibility = nameof(Visibility);
}

public delegate void ApplicationVisibilityEventHandler();
public delegate void RigStatusEventHandler(int rigNumber);
public delegate void RigTypeChangedEventHandler(int rigNumber, string newRigType);
public delegate void RigParametersEventHandler(int rigNumber, int parameters);
public delegate void RigCustomCommandEventHandler(int rigNumber, byte[] customCommand);

internal sealed class UdpMessenger
{
    private const int TxPort = 11101;
    private const int RxPort = 11102;

    private readonly UdpEndpoint _udp;
    private readonly ILog _logger = LogManager.GetLogger(typeof(UdpMessenger));

    public UdpMessenger()
    {
        _udp = new UdpEndpoint(IPAddress.Loopback.ToString(), RxPort);
        _udp.EndpointDetected += EndpointDetected;
        _udp.DatagramReceived += DatagramReceived;
        _udp.Start();
    }

    public void Dispose()
    {
        _udp?.Stop();
    }

    public event ApplicationVisibilityEventHandler? ShowApplication = null;
    public event RigStatusEventHandler? RigStatus = null;
    public event RigParametersEventHandler? RigParameters = null;
    public event RigCustomCommandEventHandler? RigCustomCommand = null;
    public event RigTypeChangedEventHandler? RigTypeChanged = null;

    private void DatagramReceived(object? sender, Datagram e)
    {
        _logger.Debug($"A datagram received at port {e.Port}: {e.Data}");
    }

    private void EndpointDetected(object? sender, EndpointMetadata e)
    {
        throw new NotImplementedException();
    }

    private void SendUdpMessage(string key, object param1, object param2)
    {
        var s = $"{key}|{param1}|{param2}";
        _udp.Send(IPAddress.Loopback.ToString(), TxPort, s);
    }

    public void ComNotifyStatus(int rigNumber)
    {
        SendUdpMessage(UdpMessageType.Status, rigNumber, 0);
    }

    public void ComNotifyParams(int rigNumber, int parameters)
    {
        SendUdpMessage(UdpMessageType.Params, rigNumber, parameters);
    }

    public void ComNotifyCustom(int rigNumber, object Sender)
    {
        SendUdpMessage(UdpMessageType.Custom, rigNumber, Convert.ToInt32(Sender));
    }

    private void OnShowApplication()
    {
        ShowApplication?.Invoke();
    }

    private void OnRigStatus(int rigNumber)
    {
        RigStatus?.Invoke(rigNumber);
    }

    private void OnRigParameters(int rigNumber, int parameters)
    {
        RigParameters?.Invoke(rigNumber, parameters);
    }

    private void OnRigCustomCommand(int rigNumber, byte[] customCommand)
    {
        RigCustomCommand?.Invoke(rigNumber, customCommand);
    }

    private void OnRigTypeChanged(int rigNumber, string newRigType)
    {
        RigTypeChanged?.Invoke(rigNumber, newRigType);
    }
}
