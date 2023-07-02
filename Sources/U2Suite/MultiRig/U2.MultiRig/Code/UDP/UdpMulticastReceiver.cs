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
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace U2.MultiRig;

public delegate void MulticastDataReceivedEventHandler(object sender, UdpMulticastDataEventArgs eventArgs);

public sealed class UdpMulticastReceiver : IDisposable
{
    private readonly UdpClient _client;
    private readonly IPAddress _multicastAddress;
    private readonly CancellationToken _token;
    private readonly ILog _logger = LogManager.GetLogger(typeof(UdpMulticastReceiver));
    private readonly IPEndPoint _localEndPoint;
    private bool _disposed;

    public UdpMulticastReceiver(IPAddress multicastAddress, int port, CancellationToken token)
    {
        _token = token;
        _multicastAddress = multicastAddress;

        _client = new UdpClient();
        _localEndPoint = new IPEndPoint(IPAddress.Any, port);
        _client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        _client.Client.Bind(_localEndPoint);

        try
        {
            _client.JoinMulticastGroup(_multicastAddress);
        }
        catch (Exception e)
        {
            _logger.Error(e.ToString());
        }

        var state = new UdpState
        {
            Client = _client,
            EndPoint = _localEndPoint,
        };
        _client.BeginReceive(DataReceived, state);

        _logger.Info("UdpMulticastReceiver is running ...");
    }

    public void Dispose()
    {
        _client.DropMulticastGroup(_multicastAddress);
        _client.Dispose();
        _disposed = true;
    }

    public event MulticastDataReceivedEventHandler MulticastDataReceived;

    private void DataReceived(IAsyncResult ar)
    {
        if (_disposed || _token.IsCancellationRequested)
        {
            return;
        }
        Debug.Assert(ar.AsyncState != null);
        var state = (UdpState)ar.AsyncState;
        var client = state.Client;
        var endPoint = state.EndPoint;

        Debug.Assert(client != null);
        Debug.Assert(endPoint != null);

        var receivedBytes = client.EndReceive(ar, ref endPoint);
        Debug.Assert(endPoint != null);

        var eventArgs = new UdpMulticastDataEventArgs(receivedBytes, endPoint);
        OnMulticastDataReceived(eventArgs);

        state = new UdpState
        {
            Client = _client,
            EndPoint = _localEndPoint,
        };
        _client.BeginReceive(DataReceived, state);
    }

    private void OnMulticastDataReceived(UdpMulticastDataEventArgs eventArgs)
    {
        MulticastDataReceived?.Invoke(this, eventArgs);
    }

    struct UdpState
    {
        public UdpClient Client;
        public IPEndPoint EndPoint;
    }
}
