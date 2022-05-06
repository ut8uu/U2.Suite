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
using System.Net.Sockets;
using System.Net;
using System.Text;
using SimpleUdp;
using log4net;

namespace U2.MultiRig;

public class UdpMessageType
{
    public const string Status = nameof(Status);
    public const string ParameterList = nameof(ParameterList);
    public const string Parameter = nameof(Parameter);
    public const string Custom = nameof(Custom);
    public const string RigType = nameof(RigType);
    public const string TxQueue = nameof(TxQueue);
}

public delegate void UdpMessageReceivedEventHandler(object sender, string message);

public enum UdpMessengerKind
{
    Client,
    Server,
}

public sealed class UdpClient : UdpMessenger
{
    public UdpClient() : base(UdpMessengerKind.Client){}
}

public sealed class UdpServer : UdpMessenger
{
    public UdpServer() : base(UdpMessengerKind.Server){}
}

public abstract class UdpMessenger : IDisposable
{
    public const int ClientPort = 11101;
    public const int ServerPort = 11102;
    
    private readonly UdpEndpoint _udp;
    private readonly ILog _logger = LogManager.GetLogger(typeof(UdpMessenger));
    private bool _started;

    protected UdpMessenger(UdpMessengerKind kind)
    {
        var port = kind == UdpMessengerKind.Server ? ServerPort : ClientPort;
        _udp = new UdpEndpoint(IPAddress.Loopback.ToString(), port);
        _udp.EndpointDetected += EndpointDetected;
        _udp.DatagramReceived += DatagramReceived;
        _udp.Events.Started += Started;
        _udp.Events.Stopped += Stopped;
    }

    private void Stopped(object? sender, EventArgs e)
    {
        _started = false;
        _logger.Debug("UdpMessenger stopped.");
    }

    private void Started(object? sender, EventArgs e)
    {
        _started = true;
        _logger.Debug("UdpMessenger started.");
    }

    public void Dispose()
    {
        _udp?.Stop();
        _udp?.Dispose();
    }

    public event UdpMessageReceivedEventHandler? MessageReceived;

    public void Start()
    {
        if (_started)
        {
            return;
        }
        _udp.Start();
        _started = true;
    }

    public void Stop()
    {
        if (!_started)
        {
            return;
        }
        _udp.Stop();
        _started = false;
    }

    private void DatagramReceived(object? sender, Datagram e)
    {
        _logger.Debug($"A datagram received at port {e.Port}: {e.Data}");
        var s = Encoding.UTF8.GetString(e.Data);
        if (string.IsNullOrEmpty(s) || !s.StartsWith("MR"))
        {
            return;
        }
        OnMessageReceived(s);
    }

    private void EndpointDetected(object? sender, EndpointMetadata e)
    {
        _logger.Debug($"Endpoint {e.Ip}:{e.Port} detected.");
    }

    private void SendUdpMessage(int rigNumber, string key, object param1, object param2)
    {
        var s = $"MR|{rigNumber}|{key}|{param1}|{param2}";
        _udp.Send(IPAddress.Loopback.ToString(), ClientPort, s);
    }

    public void ComNotifyStatus(int rigNumber)
    {
        SendUdpMessage(rigNumber, UdpMessageType.Status, 0, 0);
    }

    public void ComNotifyParams(int rigNumber, int parameters)
    {
        SendUdpMessage(rigNumber, UdpMessageType.ParameterList, parameters, 0);
    }

    public void ComNotifySingleParameter(int rigNumber, RigParameter parameter, object parameterValue = null)
    {
        SendUdpMessage(rigNumber, UdpMessageType.Parameter, (int)parameter, parameterValue);
    }

    public void ComNotifyCustom(int rigNumber, object Sender)
    {
        SendUdpMessage(rigNumber, UdpMessageType.Custom, Convert.ToInt32(Sender), 0);
    }

    public void TxQueue(int rigNumber)
    {
        SendUdpMessage(rigNumber, UdpMessageType.TxQueue, 0, 0);
    }

    public void ComNotifyRigType(int rigNumber)
    {
        throw new NotImplementedException();
    }

    private void OnMessageReceived(string message)
    {
        MessageReceived?.Invoke(this, message);
    }
}
