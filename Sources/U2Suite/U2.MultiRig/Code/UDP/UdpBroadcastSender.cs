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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace U2.MultiRig.Code.UDP
{
    public sealed class UdpBroadcastSender : IDisposable
    {
        private readonly UdpClient _client;
        private readonly CancellationToken _token;
        private readonly string _multicastAddress;
        private readonly int _port;
        private readonly IPEndPoint _remoteEndpoint;
        private readonly ILog _logger = LogManager.GetLogger(typeof(UdpBroadcastSender));

        public UdpBroadcastSender(string multicastAddress, int port, CancellationToken token)
        {
            _multicastAddress = multicastAddress;
            _port = port;
            _token = token;

            _client = new UdpClient();
            var multicastIPAddress = IPAddress.Parse(_multicastAddress);

            try
            {
                // Join group
                _client.JoinMulticastGroup(multicastIPAddress);
            }
            catch (Exception e) when (e is SocketException)
            {
                _logger.Error(e.ToString());
            }

            _remoteEndpoint = new IPEndPoint(multicastIPAddress, _port);
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<int> SendAsync(byte[] data)
        {
            try
            {
                var result = await _client.SendAsync(data, _remoteEndpoint, _token);
                return result;
            }
            catch (Exception ex) when (ex is SocketException)
            {
                _logger.Error(ex);
            }

            return 0;
        }
    }
}
