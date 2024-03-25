using System.Collections.Concurrent;
using Newtonsoft.Json;
using SocketIO.Core;
using SocketIOClient;
using SocketIOClient.Transport;
using U2.Suite.Brandmeister.Contracts;
using U2.Suite.Helpers;

namespace U2.Suite.Brandmeister.Core;

public delegate void ConnectedEventHandler(object sender);
public delegate void DisconnectedEventHandler(object sender);
public delegate void ConnectErrorEventHandler(object sender, string error);
public delegate void ReconnectAttemptEventHandler(object sender, int attemptNumber);
public delegate void ReconnectFailedEventHandler(object sender);
public delegate void MessageThrownEventHandler(object sender, string message);
public delegate void SessionDataReceivedEventHandler(object sender, SessionData data);

public sealed class BrandmeisterListener : IDisposable
{
    const string bmApiUrl = "https://api.brandmeister.network";
    const int oneThousandMs = 1000;

    readonly Timer _mqttTimer;
    readonly Timer _watchdogTimer;
    readonly ConcurrentQueue<string> _mqttData = new ConcurrentQueue<string>();
    SocketIOClient.SocketIO _socket;
    bool _started = false;
    bool _connected = false;
    private bool disposedValue;

    public event ConnectedEventHandler? Connected;
    public event DisconnectedEventHandler? Disconnected;
    public event ConnectErrorEventHandler? ConnectError;
    public event ReconnectAttemptEventHandler? ReconnectAttempt;
    public event ReconnectFailedEventHandler? ReconnectFailed;
    public event MessageThrownEventHandler? MessageThrown;
    public event SessionDataReceivedEventHandler? SessionDataReceived;

    public BrandmeisterListener()
    {
        _socket = new SocketIOClient.SocketIO(bmApiUrl, new SocketIOOptions
        {
            Path = "/lh/socket.io",
            Reconnection = true,
            EIO = EngineIO.V4,
            Transport = TransportProtocol.WebSocket,
            ExtraHeaders = new Dictionary<string, string> { },
        });

        _socket.OnConnected += _socket_OnConnected;
        _socket.OnDisconnected += _socket_OnDisconnected;
        _socket.OnError += _socket_OnError;
        _socket.OnReconnectAttempt += _socket_OnReconnectAttempt;
        _socket.OnReconnectFailed += _socket_OnReconnectFailed;
        _socket.OnAny((x, data) =>
        {
            var json = data.ToString();
            _mqttData.Enqueue(json);
            Console.Write(".");
        });
        _mqttTimer = new Timer(state => { OnMqttTimerTick(); }, null, dueTime: Timeout.Infinite, period: Timeout.Infinite);
        _watchdogTimer = new Timer(state => { OnWatchdogTimerTick(); }, null, dueTime: Timeout.Infinite, period: Timeout.Infinite);
    }

    void OnSessionDataReceived(SessionData data)
    {
        SessionDataReceived?.Invoke(this, data);
    }

    public void OnMessageThrown(string message)
    {
        MessageThrown?.Invoke(this, message);
    }

    private void _socket_OnReconnectFailed(object? sender, EventArgs e)
    {
        ReconnectFailed?.Invoke(this);
    }

    private void _socket_OnReconnectAttempt(object? sender, int attemptNumber)
    {
        ReconnectAttempt?.Invoke(this, attemptNumber);
    }

    private void _socket_OnError(object? sender, string errorMessage)
    {
        ConnectError?.Invoke(this, errorMessage);
    }

    private void _socket_OnDisconnected(object? sender, string e)
    {
        Disconnected?.Invoke(this);
    }

    private void _socket_OnConnected(object? sender, EventArgs e)
    {
        Connected?.Invoke(this);
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Stop();
                _socket?.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    void OnWatchdogTimerTick()
    {
        if (_connected || !_started)
        {
            return;
        }

        //_watchdogTimer.Change(dueTime: Timeout.Infinite, period: Timeout.Infinite);
        try
        {
            _socket.ConnectAsync().GetAwaiter();
        }
        catch { }
        //_watchdogTimer.Change(dueTime: oneThousandMs, period: oneThousandMs);
    }

    bool _processingMqtt = false;
    void OnMqttTimerTick()
    {
        if (!_started || !_mqttData.Any())
        {
            return;
        }

        if (_processingMqtt)
        {
            return;
        }

        _processingMqtt = true;

        //_mqttTimer?.Change(Timeout.Infinite, Timeout.Infinite);

        Console.WriteLine("MQTT timer tick.");

        while (_mqttData.Any())
        {
            // TODO process received MQTT data
            if (_mqttData.TryDequeue(out var data))
            {
                try
                {
                    data = data.Trim("[]".ToCharArray());
                    var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
                    if (dictionary == null)
                    {
                        continue;
                    }
                    var payload = JsonConvert.DeserializeObject<SessionData>(dictionary["payload"]);
                    if (payload == null)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(payload.SourceCall))
                    {
                        continue;
                    }

                    var dxcc = DxccHelper.Call2Dxcc(payload.SourceCall, DateTime.UtcNow);
                    if (int.TryParse(dxcc.Adif, out var id))
                    {
                        payload.Dxcc = id;
                        payload.CountryName = dxcc.Details;
                    }
                    OnSessionDataReceived(payload);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        // start timer again
        //_mqttTimer?.Change(dueTime: oneThousandMs, period: oneThousandMs);

        _processingMqtt = false;
    }

    public void Start()
    {
        if (_started)
        {
            return;
        }

        _started = true;
        _mqttTimer.Change(dueTime: oneThousandMs, period: oneThousandMs);
        _socket.ConnectAsync();
    }

    public void Stop()
    {
        if (!_started)
        {
            return;
        }

        try
        {
            if (_socket?.Connected ?? false)
            {
                _socket.DisconnectAsync();
            }
        }
        catch { }
        _mqttTimer?.Change(Timeout.Infinite, Timeout.Infinite);
        _started = false;
    }

}
