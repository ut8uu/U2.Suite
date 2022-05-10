using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NetTools;
using Tmds.DBus;

namespace U2.MultiRig;

public delegate void UdpDataArrivedEventHandler(object sender, UdpDataReceivedEventArgs eventArgs);

public class UdpMessenger : IDisposable
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(UdpMessenger));
    private readonly IPAddress _ipAddress;
    private readonly byte[] _buffer;
    private Socket? _socket;
    private bool _isDisposed;

    public UdpMessenger(string ipAddressToBind, int portToBind, int bufferSize = 1024)
    {
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
                        _log.Error(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        _log.Error(ex.Message);
                    }
                }
            }
            BeginReceive();
            _log.DebugFormat($"UDP Server initialization successful: Listening to {Address}:{Port}");
        }
        catch (Exception ex)
        {
            _log.Error($"UDP Server initialization failed: {ex.Message}");
            throw;
        }
    }

    private void BeginReceive()
    {
        if (_socket == null)
        {
            return;
        }
        var remoteEndPoint = (EndPoint)new IPEndPoint(_ipAddress, 0);
        _socket.BeginReceiveFrom(_buffer, 0, _buffer.Length,
            SocketFlags.None, ref remoteEndPoint, OnDataReceived, remoteEndPoint);
    }

    private UdpDataReceivedEventArgs EndReceive(IAsyncResult asyncResult)
    {
        var endpoint = (EndPoint)new IPEndPoint(_ipAddress, 0);
        if (_socket == null)
        {
            return new UdpDataReceivedEventArgs {Data = Array.Empty<byte>(), EndPoint = endpoint};
        }

        var len = _socket.EndReceiveFrom(asyncResult, ref endpoint);
        var arr = new byte[len];
        Array.Copy(_buffer, arr, len);
        return new UdpDataReceivedEventArgs {Data = arr, EndPoint = endpoint};
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
                _log.Error($"Error during dispose: {ex.Message}");
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
            OnNewDataArrived(EndReceive(asyncResult));
        }
        catch (Exception ex)
        {
            _log.Error($"Error processing received data: {ex.Message}");
        }
        finally
        {
            BeginReceive();
        }
    }
}
