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
using JetBrains.Annotations;
using log4net;

namespace U2.MultiRig.Code.UDP
{
    public sealed class RigUdpMessenger : IDisposable
    {
        public readonly IPAddress MultiCastAddress = IPAddress.Parse("224.100.0.1");
        public const int MessengerRxPort = 11501;
        public const int MessengerTxPort = 11502;
        public const int ServerBufferSize = 8192;

        private readonly CancellationToken _cancellationToken;
        private readonly ILog _log = LogManager.GetLogger(typeof(RigUdpMessenger));
        private readonly UdpServer _server;
        private readonly UdpClient _client;
        private bool _disposed;

        public RigUdpMessenger(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            
            _server = new UdpServer(MessengerRxPort, _cancellationToken, ServerBufferSize);
            _server.NewDataArrived += ServerOnNewDataArrived;

            _client = new UdpClient(AddressFamily.InterNetwork)
            {
                ExclusiveAddressUse = false,
            };
            _client.JoinMulticastGroup(MultiCastAddress);
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _server.Dispose();
            _disposed = true;
        }

        private void ServerOnNewDataArrived(object sender, UdpDataReceivedEventArgs eventArgs)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                return;
            }

            try
            {
                var packet = RigUdpMessengerPacket.FromUdpPacket(eventArgs.Data);
            }
            catch (UdpPacketException ex)
            {
                _log.Error(ex.Message);
            }
        }

        private void SendMultiCastMessage(byte[] data)
        {
            var ipEndPoint = new IPEndPoint(MultiCastAddress, MessengerTxPort);
            _client.Send(data, data.Length, ipEndPoint);
            _client.Close();
        }
    }
}
