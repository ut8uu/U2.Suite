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
using CommandLineParser.Arguments;
using SimpleUdp;
using log4net;
using System.Reflection.Metadata;
using System.ServiceModel.Channels;

namespace U2.MultiRig;

public class UdpMessageType
{
    public const string Status = "ST";
    public const string ParameterList = "PL";
    public const string Parameter = "P1";
    public const string Custom = "CU";
    public const string RigType = "RT";
}

public delegate void UdpMessageReceivedEventHandler(object sender, string message);

public enum UdpMessengerKind
{
    Client,
    Server,
}

public sealed class UdpMessage
{
    public int RigNumber { get; init; }
    public string MessageType { get; init; }
    public int Parameter { get; init; }
    public object Value { get; set; }
}

public sealed class UdpClient : UdpMessenger
{
    public UdpClient(CancellationToken cancellationToken)
        : base(UdpMessengerKind.Client, cancellationToken) { }
}

public sealed class UdpServer : UdpMessenger
{
    public UdpServer(CancellationToken cancellationToken)
        : base(UdpMessengerKind.Server, cancellationToken) { }
}

public abstract class UdpMessenger : IDisposable
{
    public const int ClientPort = 11101;
    public const int ServerPort = 11102;

    private readonly UdpEndpoint _udp;
    private readonly ILog _logger = LogManager.GetLogger(typeof(UdpMessenger));
    private bool _started;
    private readonly Timer _sendTimer;
    private readonly List<UdpMessage> _queue = new();
    private CancellationToken _cancellationToken;
    private readonly TimeSpan _sendTimeSpan = TimeSpan.FromMilliseconds(500);

    protected UdpMessenger(UdpMessengerKind kind, CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
        var port = kind == UdpMessengerKind.Server ? ServerPort : ClientPort;
        _udp = new UdpEndpoint(IPAddress.Loopback.ToString(), port);
        _udp.EndpointDetected += EndpointDetected;
        _udp.DatagramReceived += DatagramReceived;
        _udp.Events.Started += Started;
        _udp.Events.Stopped += Stopped;

        _sendTimer = new Timer(Flush);
    }

    private void EnableTimer()
    {
        _sendTimer.Change(_sendTimeSpan, _sendTimeSpan);
    }

    private void DisableTimer()
    {
        _sendTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
    }

    private void Flush(object? state)
    {
        if (!_started || _queue.Count == 0)
        {
            return;
        }
        DisableTimer();
        try
        {
            var sb = new StringBuilder();
            var list = _queue.ToList();
            _queue.Clear();
            foreach (var msg in list)
            {
                var message = $"MR|{msg.RigNumber}|{msg.MessageType}|{msg.Parameter}|{msg.Value}";
                sb.AppendLine(message);
            }
            _udp.Send(IPAddress.Loopback.ToString(), ClientPort, sb.ToString());
        }
        finally
        {
            if (!_cancellationToken.IsCancellationRequested)
            {
                EnableTimer();
            }
        }
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
        Start(CancellationToken.None);
    }

    public void Start(CancellationToken cancellationToken)
    {
        if (_started)
        {
            return;
        }

        if (cancellationToken != CancellationToken.None)
        {
            _cancellationToken = cancellationToken;
        }
        EnableTimer();
        _udp.Start();
        _started = true;
    }

    public void Stop()
    {
        if (!_started)
        {
            return;
        }
        DisableTimer();
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

    private void EnqueueMessage(int rigNumber, string key, int parameter, object value)
    {
        var existingMessage = _queue.FirstOrDefault(x => x.RigNumber == rigNumber
                                                         && x.MessageType == key
                                                         && x.Parameter == parameter);
        if (existingMessage != null)
        {
            existingMessage.Value = value;
        }
        else
        {
            _queue.Add(new()
            {
                RigNumber = rigNumber,
                MessageType = key,
                Parameter = parameter,
                Value = value,
            });
        }
    }

    public void ComNotifyStatus(int rigNumber)
    {
        EnqueueMessage(rigNumber, UdpMessageType.Status, 0, 0);
    }

    public void ComNotifyParams(int rigNumber, int parameters)
    {
        EnqueueMessage(rigNumber, UdpMessageType.ParameterList, parameters, 0);
    }

    public void ComNotifySingleParameter(int rigNumber, RigParameter parameter, object parameterValue = null)
    {
        EnqueueMessage(rigNumber, UdpMessageType.Parameter, (int)parameter, parameterValue);
    }

    public void ComNotifyCustom(int rigNumber, object Sender)
    {
        EnqueueMessage(rigNumber, UdpMessageType.Custom, Convert.ToInt32(Sender), 0);
    }

    public void TxQueue(int rigNumber)
    {
        EnqueueMessage(rigNumber, UdpMessageType.TxQueue, 0, 0);
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
