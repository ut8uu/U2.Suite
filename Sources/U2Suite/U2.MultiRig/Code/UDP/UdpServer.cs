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
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using log4net;
using NetTools;

namespace U2.MultiRig;

public delegate void UdpDataArrivedEventHandler(object sender, UdpDataReceivedEventArgs eventArgs);

public class UdpServer : IDisposable
{
    private static readonly ILog Log = LogManager.GetLogger(typeof(UdpServer));
    private readonly IPAddress _ipAddress;
    private readonly byte[] _buffer;
    private Socket? _socket;
    private bool _isDisposed;

    private readonly TimeSpan _sendTimeSpan = TimeSpan.FromMilliseconds(500);
    private readonly CancellationToken _cancellationToken;
    private readonly Timer _sendTimer;
    private readonly List<UdpMessage> _queue = new();

    public UdpServer(int portToBind, CancellationToken cancellationToken, int bufferSize = 1024)
        : this(ipAddressToBind: null, portToBind, cancellationToken, bufferSize)
    { }

    public UdpServer(string? ipAddressToBind, int portToBind, 
        CancellationToken cancellationToken, int bufferSize = 1024)
    {
        _cancellationToken = cancellationToken;
        _ipAddress = IPAddress.Any;
        _buffer = new byte[bufferSize];
        try
        {
            var udpClient = new UdpClient();
            _socket = udpClient.Client;
            _socket.ReceiveBufferSize = bufferSize;
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.IpTimeToLive, true);
            _socket.ExclusiveAddressUse = false;
            _socket.Bind(new IPEndPoint(_ipAddress, portToBind));

            var endpoint = _socket.LocalEndPoint as IPEndPoint;
            Debug.Assert(endpoint is not null, "endpoint is null");
            Port = endpoint.Port;
            Address = endpoint.Address;
            if (!string.IsNullOrEmpty(ipAddressToBind))
            {
                if (IsMultiCastAddress(ipAddressToBind))
                {
                    try
                    {
                        var ipAddressToJoin = IPAddress.Parse(ipAddressToBind);
                        udpClient.JoinMulticastGroup(ipAddressToJoin, _ipAddress);
                    }
                    catch (SocketException ex)
                    {
                        Log.Error(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Log.Error(ex.Message);
                    }
                }
            }
            BeginReceive();
            _sendTimer = new Timer(Flush);
            Log.DebugFormat($"UdpMessenger initialization successful: Listening to {Address}:{Port}");
        }
        catch (Exception ex)
        {
            Log.Error($"UdpMessenger initialization failed: {ex.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize((object)this);
    }

    private void Dispose(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }
        if (disposing)
        {
            try
            {
                _socket.Shutdown(SocketShutdown.Both);
            }
            catch (SocketException)
            {
            }
            catch (Exception ex)
            {
                Log.Error($"Error during dispose: {ex.Message}");
            }
            finally
            {
                _socket.Close();
            }
        }
        _socket = null;
        _isDisposed = true;
    }

    public event UdpDataArrivedEventHandler? NewDataArrived;

    public int Port { get; }

    public IPAddress Address { get; }

    public static bool IsMultiCastAddress(string ip)
    {
        var address = IPAddress.Parse(ip);
        return (IPAddressRange.Parse("224.0.0.1 - 224.0.0.255").Contains(address))
            || (IPAddressRange.Parse("239.0.0.0 - 239.255.255.255").Contains(address));
    }

    #region Receive

    private void BeginReceive()
    {
        if (_socket == null || _cancellationToken.IsCancellationRequested)
        {
            return;
        }
        var remoteEndPoint = (EndPoint)new IPEndPoint(_ipAddress, 0);
        _socket.BeginReceiveFrom(_buffer, 0, _buffer.Length,
            SocketFlags.None, ref remoteEndPoint, OnDataReceived, remoteEndPoint);
    }

    private (byte[] data, EndPoint endpoint) EndReceive(IAsyncResult asyncResult)
    {
        var endpoint = (EndPoint)new IPEndPoint(_ipAddress, 0);
        if (_socket == null || _cancellationToken.IsCancellationRequested)
        {
            return (Array.Empty<byte>(), endpoint);
        }

        var len = _socket.EndReceiveFrom(asyncResult, ref endpoint);
        var arr = new byte[len];
        Array.Copy(_buffer, arr, len);
        return (arr, endpoint);
    }

    private void OnNewDataArrived(UdpDataReceivedEventArgs e)
    {
        NewDataArrived?.Invoke((object)this, e);
    }

    private void OnDataReceived(IAsyncResult asyncResult)
    {
        if (_socket == null)
        {
            return;
        }

        try
        {
            var (data, endpoint) = EndReceive(asyncResult);
            OnNewDataArrived(new UdpDataReceivedEventArgs(data, endpoint));
        }
        catch (Exception ex)
        {
            Log.Error($"Error processing received data: {ex.Message}");
        }
        finally
        {
            BeginReceive();
        }
    }


    #endregion

    #region Send

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
        if (_queue.Count == 0)
        {
            return;
        }
        DisableTimer();
        try
        {
            // actual send is being performed here
        }
        finally
        {
            if (!_cancellationToken.IsCancellationRequested)
            {
                EnableTimer();
            }
        }
    }

    public void EnqueueMessage(UdpMessage message)
    {
        _queue.Add(message);
    }

    #endregion
}

public sealed class UdpMessage
{
    public IPAddress Address { get; set; }
    public byte[] Data { get; set; }
}
