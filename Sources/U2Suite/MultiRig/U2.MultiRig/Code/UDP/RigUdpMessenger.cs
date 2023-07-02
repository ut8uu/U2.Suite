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
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace U2.MultiRig;

public sealed class RigUdpMessenger : IDisposable
{
    public readonly IPAddress MultiCastAddress = IPAddress.Parse("224.5.11.71");
    public const int MessengerRxPort = 11501;
    public const int MessengerTxPort = 11502;

    private readonly CancellationToken _cancellationToken;
    private readonly ILog _log = LogManager.GetLogger(typeof(RigUdpMessenger));
    private readonly UdpMulticastSender _sender;
    private readonly UdpMulticastReceiver _receiver;
    private bool _disposed;

    public event UdpPacketReceivedEventHandler UdpPacketReceived;

    public RigUdpMessenger(RigControlType rigControlType, CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;

        var isHost = rigControlType == RigControlType.Guest;
        var rxPort = isHost ? MessengerRxPort : MessengerTxPort;
        var txPort = isHost ? MessengerTxPort : MessengerRxPort;
        _sender = new UdpMulticastSender(MultiCastAddress, txPort, _cancellationToken);
        _receiver = new UdpMulticastReceiver(MultiCastAddress, rxPort, _cancellationToken);
        _receiver.MulticastDataReceived += ReceiverOnMulticastDataReceived;
    }

    private void ReceiverOnMulticastDataReceived(object sender, UdpMulticastDataEventArgs eventArgs)
    {
        if (_cancellationToken.IsCancellationRequested)
        {
            return;
        }

        try
        {
            var packet = RigUdpMessengerPacket.FromUdpPacket(eventArgs.Data);
            if (!packet.IsValid)
            {
                return;
            }

            var args = new RigUdpMessengerPacketEventArgs
            {
                Packet = packet,
                RemoteEndpoint = eventArgs.SenderEndPoint,
            };
            OnUdpPacketReceived(args);
        }
        catch (UdpPacketException ex)
        {
            _log.Error(ex.Message);
        }
    }

    private void OnUdpPacketReceived(RigUdpMessengerPacketEventArgs eventArgs)
    {
        UdpPacketReceived?.Invoke(this, eventArgs);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }
        _receiver.Dispose();
        _sender.Dispose();
        _disposed = true;
    }

    public void SendMultiCastMessage(RigUdpMessengerPacket packet)
    {
        var data = packet.GetBytes();
        var sentBytes = _sender.Send(data);
        if (sentBytes != data.Length)
        {
            _log.Error($"Incorrect datagram sent. Expected to be {data.Length} bytes, only {sentBytes} sent.");
        }
    }
}
