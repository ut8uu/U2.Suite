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
using System.Net.NetworkInformation;

namespace U2.MultiRig.Code.UDP
{
    public delegate void BroadcastDataReceivedEventHandler(object sender, BroadcastDataEventArgs eventArgs);

    public sealed class UdpBroadcastReceiver : IDisposable
    {
        private readonly UdpClient _client;
        private readonly IPAddress _multicastAddress;
        private readonly int _port;
        private readonly CancellationToken _token;
        private readonly ILog _logger = LogManager.GetLogger(typeof(UdpBroadcastReceiver));
        private readonly IPEndPoint _localEndPoint;

        public UdpBroadcastReceiver(string multicastAddress, int port, CancellationToken token)
        {
            _port = port;
            _token = token;
            _multicastAddress = IPAddress.Parse(multicastAddress);

            _client = new UdpClient();

            // Create new IPEndPoint
            _localEndPoint = new IPEndPoint(IPAddress.Any, _port);

            // Set socket options
            _client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // Bind to IPEndPoint
            _client.Client.Bind(_localEndPoint);

            try
            {
                // Join group
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

            _logger.Info("UdpBroadcastReceiver is running ...");
        }

        private void DataReceived(IAsyncResult ar)
        {
            Debug.Assert(ar.AsyncState != null);
            var state = (UdpState)ar.AsyncState;
            var client = state.Client;
            var endPoint = state.EndPoint;

            var receivedBytes = client.EndReceive(ar, ref endPoint);

            var eventArgs = new BroadcastDataEventArgs(receivedBytes, endPoint);
            OnBroadcastDataReceived(eventArgs);

            state = new UdpState
            {
                Client = _client,
                EndPoint = _localEndPoint,
            };
            _client.BeginReceive(DataReceived, state);
        }

        public void Dispose()
        {
            _client.DropMulticastGroup(_multicastAddress);
            _client.Dispose();
        }

        public event BroadcastDataReceivedEventHandler BroadcastDataReceived;

        private void OnBroadcastDataReceived(BroadcastDataEventArgs eventargs)
        {
            BroadcastDataReceived?.Invoke(this, eventargs);
        }

        struct UdpState
        {
            public UdpClient Client;
            public IPEndPoint EndPoint;
        }
    }
}
