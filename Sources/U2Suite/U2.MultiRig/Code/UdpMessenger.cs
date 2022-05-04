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
    public const string Params = nameof(Params);
    public const string Custom = nameof(Custom);
    public const string Visibility = nameof(Visibility);
    public const string TxQueue = nameof(TxQueue);
}

public delegate void ApplicationVisibilityEventHandler();
public delegate void RigStatusCheckEventHandler(int rigNumber);
public delegate void RigTypeChangedEventHandler(int rigNumber, string newRigType);
public delegate void RigParametersEventHandler(int rigNumber, int parameters);
public delegate void RigCustomCommandEventHandler(int rigNumber, byte[] customCommand);

public sealed class UdpMessenger : IDisposable
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
        _udp?.Dispose();
    }

    public event ApplicationVisibilityEventHandler? ShowApplication = null;
    public event RigStatusCheckEventHandler? RigStatusCheck = null;
    public event RigParametersEventHandler? RigParametersChanged = null;
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

    public void TxQueue(int rigNumber)
    {
        SendUdpMessage(UdpMessageType.TxQueue, rigNumber, 0);
    }

    private void OnShowApplication()
    {
        ShowApplication?.Invoke();
    }

    private void OnRigStatus(int rigNumber)
    {
        RigStatusCheck?.Invoke(rigNumber);
    }

    private void OnRigParameters(int rigNumber, int parameters)
    {
        RigParametersChanged?.Invoke(rigNumber, parameters);
    }

    private void OnRigCustomCommand(int rigNumber, byte[] customCommand)
    {
        RigCustomCommand?.Invoke(rigNumber, customCommand);
    }

    private void OnRigTypeChanged(int rigNumber, string newRigType)
    {
        RigTypeChanged?.Invoke(rigNumber, newRigType);
    }

    public void ComNotifyRigType(int rigNumber)
    {
        throw new NotImplementedException();
    }
}
