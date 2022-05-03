using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using log4net;
using MonoSerialPort;
using MonoSerialPort.Port;
using U2.MultiRig.Code;
using System.Reactive;

namespace U2.MultiRig;

public enum RigCtlStatus
{
    NotConfigured, Disabled, PortBusy, NotResponding, OnLine
}

public abstract class CustomRig : IDisposable
{
    private readonly RigSettings _rigSettings;
    private readonly ILog _logger = LogManager.GetLogger(typeof(CustomRig));
    protected UdpMessenger _udpMessenger;
    protected readonly Timer _connectivityTimer;
    protected readonly Timer _timeoutTimer;

    protected CommandQueue _queue;
    protected int _freq = 0;
    protected int _freqA = 0;
    protected int _freqB = 0;
    protected int _ritOffset = 0;
    protected int _pitch = 0;
    protected RigParameter _vfo;
    protected RigParameter _split;
    protected RigParameter _rit;
    protected RigParameter _xit;
    protected RigParameter _tx;
    protected RigParameter _mode;

    protected bool _online = false;
    protected RigCommands _rigCommands;
    protected SerialPortInput _serialPort;
    protected RigParameter LastWrittenMode = RigParameter.None;

    public int RigNumber { get; set; } = 0;

    public event SerialPortInput.ConnectionStatusChangedEventHandler? ConnectionStatusChanged;

    protected CustomRig(int rigNumber, RigSettings rigSettings, RigCommands rigCommands)
    {
        _rigSettings = rigSettings;
        _rigCommands = rigCommands;
        RigNumber = rigNumber;
        _queue = new CommandQueue();

        _serialPort = CreateSerialPort(_rigSettings);
        _serialPort.ConnectionStatusChanged += SerialPort_ConnectionStatusChanged;
        _serialPort.MessageReceived += SerialPort_MessageReceived;

        _udpMessenger = new UdpMessenger();
        var interval = TimeSpan.FromMilliseconds(rigSettings.PollMs);
        _connectivityTimer = new Timer(ConnectivityTimerCallbackFunc);
        DisableConnectivityTimer();
        _timeoutTimer = new Timer(TimeoutTimerCallbackFunc);
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        _logger.Debug("Disposing");

        Stop();

        _udpMessenger?.Dispose();
    }

    #region Properties

    public RigCommands RigCommands => _rigCommands;
    public bool Enabled => _rigSettings.Enabled;

    public RigCtlStatus Status => GetStatus();
    public int Freq => _freq;
    public int FreqA => _freqA;
    public int FreqB => _freqB;
    public int Pitch => _pitch;
    public int RitOffset => _ritOffset;
    public RigParameter Vfo => _vfo;
    public RigParameter Split => GetSplit();
    public RigParameter Rit => _rit;
    public RigParameter Xit => _xit;
    public RigParameter Tx => _tx;
    public RigParameter Mode => _mode;

    private static readonly StopBits[] StopBits =
    {
        MonoSerialPort.Port.StopBits.One,
        MonoSerialPort.Port.StopBits.OnePointFive,
        MonoSerialPort.Port.StopBits.Two
    };
    private static readonly Parity[] Parities =
    {
        Parity.None,
        Parity.Odd,
        Parity.Even,
        Parity.Mark,
        Parity.Space
    };
    private static Handshake[] _handshakes = {
        Handshake.None,
        Handshake.RequestToSend,
        Handshake.RequestToSendXOnXOff,
        Handshake.XOnXOff,
    };

    #endregion

    private void TimeoutTimerCallbackFunc(object? state)
    {
        _logger.Debug($"RIG{RigNumber}: A timeout occurred.");
        _queue.Phase = ExchangePhase.Idle;
    }

    private SerialPortInput CreateSerialPort(RigSettings rigSettings)
    {
        return new SerialPortInput(_rigSettings.Port,
            baudRate: rigSettings.BaudRate,
            parity: Parities[rigSettings.Parity],
            dataBits: rigSettings.DataBits,
            stopBits: StopBits[_rigSettings.StopBits],
            handshake: Handshake.None,
            isVirtualPort: false);
    }

    private static Parity IntToParity(int parity)
    {
        return Parities[parity];
    }

    private readonly List<byte> _receiveQueue = new List<byte>();
    private void SerialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
    {
        lock (RecvEventLockObject)
        {
            var receivedData = args.Data;
            _receiveQueue.AddRange(receivedData);

            //some COM ports do not send EV_TXEMPTY
            if (_queue.Phase == ExchangePhase.Sending)
            {
                _queue.Phase = ExchangePhase.Receiving;
                _logger.Debug($"RIG{RigNumber}: Data received from radio while receivivng is not expected. Switched to receiving.");
            }

            if (_queue.Phase == ExchangePhase.Receiving)
            {
                _logger.DebugFormat("RIG{0}: reply received: {1} ({2} bytes)", 
                    RigNumber, ByteFunctions.BytesToHex(receivedData), receivedData.Length);
            }
            else
            {
                _logger.ErrorFormat("RIG{0}: received data when not in the receiving state: {1} ({2} bytes)", 
                    RigNumber, ByteFunctions.BytesToHex(receivedData), receivedData.Length);
                return;
            }

            //are we in the right state?
            if (_queue.Count == 0)
            {
                _logger.Error($"RIG{RigNumber}: Data received, but the queue is empty.");
                return;
            }

            if (_queue.CurrentCmd.NeedsReply
                && _queue.CurrentCmd.ReplyLength > _receiveQueue.Count)
            {
                _logger.Debug($"RIG{RigNumber}: Buffer has insufficient data. Waiting for the rest.");
                return;
            }

            //process data
            try
            {
                DisableTimeoutTimer();

                var data = _receiveQueue.Take(_queue.CurrentCmd.ReplyLength).ToArray();
                var theTail = _receiveQueue.Skip(_queue.CurrentCmd.ReplyLength);
                _receiveQueue.Clear();
                _receiveQueue.AddRange(theTail);
                var currentCommand = _queue.CurrentCmd;
                switch (currentCommand.Kind)
                {
                    case CommandKind.Init:
                        ProcessInitReply(currentCommand.Number, data);
                        break;

                    case CommandKind.Write:
                        ProcessWriteReply(currentCommand.Param, data);
                        break;

                    case CommandKind.Status:
                        ProcessStatusReply(currentCommand.Number, data);
                        break;

                    case CommandKind.Custom:
                        ProcessCustomReply(currentCommand.CustSender, currentCommand.Code, data);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("RIG{0}: Error during processing reply: {1}", RigNumber, e.Message);
            }

            //we are receiving data, therefore we are online
            if (!_online)
            {
                _online = true;
                _udpMessenger.ComNotifyStatus(RigNumber);
            }

            //send next command if queue not empty
            _queue.RemoveAt(0);
            _queue.Phase = ExchangePhase.Idle;
            if (_queue.Count > 0)
            {
                CheckQueue();
            }
        }
    }

    private void SerialPort_ConnectionStatusChanged(object sender, ConnectionStatusChangedEventArgs args)
    {
        var state = args.Connected ? "Connected" : "Disconnected";
        _logger.Info($"Connection state changed to: {state}");

        OnConnectionStatusChanged(args);
    }

    private static readonly object GetStatusLockObject = new();
    ////////////////////////////////////////////////////////////////////////////////
    //                                 status
    ////////////////////////////////////////////////////////////////////////////////
    private RigCtlStatus GetStatus()
    {
        lock (GetStatusLockObject)
        {
            if (RigCommands == null)
            {
                return RigCtlStatus.NotConfigured;
            }
            else if (!_rigSettings.Enabled)
            {
                return RigCtlStatus.Disabled;
            }
            else if (!_serialPort.IsConnected)
            {
                return RigCtlStatus.PortBusy;
            }
            else if (!_online)
            {
                return RigCtlStatus.NotResponding;
            }
            else
            {
                return RigCtlStatus.OnLine;
            }
        }
    }

    private static readonly object RecvEventLockObject = new();

    private static readonly object SentEventLockObject = new();

    private void SentEvent(object sender)
    {
        //_logger.InfoFormat("RIG{0} data sent, {1} bytes in TX buffer", RigNumber, ComPort.TxQueue);
        lock (SentEventLockObject)
        {
            if (!_serialPort.IsConnected
                || _queue.Phase != ExchangePhase.Sending
                || _queue.Count == 0)
            {
                return;
            }

            if (_queue.CurrentCmd.NeedsReply)
            {
                _queue.Phase = ExchangePhase.Receiving;
                EnableTimeoutTimer();
            }
            else
            {
                _queue.RemoveAt(0);
                _queue.Phase = ExchangePhase.Idle;
                CheckQueue();
            }
        }
    }

    private void CtsDsrEvent(object sender)
    {
        string[] boolStr = { "OFF", "ON" };
        //_logger.Info($"RIG{RigNumber} ctrl bits: CTS={ComPort.CtsBit} DSR={ComPort.DsrBit} RLS={ComPort.RlsdBit}");
    }

    public void SetFreq(int value)
    {
        if (Enabled)
        {
            AddWriteCommand(RigParameter.Freq, value);
        }
    }

    private void SetFreqA(int value)
    {
        _logger.InfoFormat("Entered SetFreqA");

        if (Enabled && (value != _freqA))
        {
            AddWriteCommand(RigParameter.FreqA, value);
        }

        _logger.InfoFormat("Exiting SetFreqA");
    }

    private void SetFreqB(int value)
    {
        if (Enabled && (value != _freqB))
        {
            AddWriteCommand(RigParameter.FreqB, value);
        }
    }

    private void SetRitOffset(int value)
    {
        if (Enabled && (value != _ritOffset))
        {
            AddWriteCommand(RigParameter.RitOffset, value);
        }
    }

    private void SetPitch(int value)
    {
        if (!Enabled)
        {
            return;
        }

        AddWriteCommand(RigParameter.Pitch, value);

        //remember the pitch that we set if we cannot read it back from the rig
        if (!(RigCommands.ReadableParams.Contains(RigParameter.Pitch)))
        {
            _pitch = value;
        }
    }

    private void SetVfo(RigParameter value)
    {
        if (Enabled && RigCommandUtilities.VfoParams.Contains(value) && value != _vfo)
        {
            AddWriteCommand(value);
        }
    }

    private void SetSplit(RigParameter value)
    {
        if (!(Enabled && RigCommandUtilities.SplitParams.Contains(value)))
        {
            return;
        }

        if (RigCommands.WriteableParams.Contains(value) && value != Split)
        {
            AddWriteCommand(value);
        }
        else if (value == RigParameter.SplitOn)
        {
            switch (Vfo)
            {
                case RigParameter.VfoAA:
                    SetVfo(RigParameter.VfoAB);
                    break;
                case RigParameter.VfoBB:
                    SetVfo(RigParameter.VfoBA);
                    break;
            }
        }
        else switch (Vfo)
            {
                case RigParameter.VfoAB:
                    SetVfo(RigParameter.VfoAA);
                    break;
                case RigParameter.VfoBA:
                    SetVfo(RigParameter.VfoBB);
                    break;
            }
    }

    private void SetRit(RigParameter value)
    {
        if (Enabled && (RigCommandUtilities.RitOnParams.Contains(value)) && (value != _rit))
        {
            AddWriteCommand(value);
        }
    }

    private void SetXit(RigParameter value)
    {
        if (Enabled && (RigCommandUtilities.XitOnParams.Contains(value)) && (value != Xit))
        {
            AddWriteCommand(value);
        }
    }

    private void SetTx(RigParameter value)
    {
        if (Enabled && (RigCommandUtilities.TxParams.Contains(value)))
        {
            AddWriteCommand(value);
        }
    }

    private void SetMode(RigParameter value)
    {
        if (Enabled && (RigCommandUtilities.ModeParams.Contains(value)))
        {
            AddWriteCommand(value);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////
    //                               set param
    ////////////////////////////////////////////////////////////////////////////////
    private void SeRigCommands(RigCommands value)
    {
        _rigCommands = value;
        _udpMessenger.ComNotifyRigType(RigNumber);
    }

    private RigParameter GetSplit()
    {
        var getSplitResult = _split;

        if (getSplitResult != RigParameter.None)
        {
            return getSplitResult;
        }
        if (new[] { RigParameter.VfoAA, RigParameter.VfoBB }.Contains(Vfo))
        {
            getSplitResult = RigParameter.SplitOff;
        }
        else if (new[] { RigParameter.VfoAB, RigParameter.VfoBA }.Contains(Vfo))
        {
            getSplitResult = RigParameter.SplitOn;
        }
        return getSplitResult;
    }

    //these commands are implemented in the descendant class,
    //just to keep them in a separate file

    protected abstract void AddCommands(IEnumerable<RigCommand> commands, CommandKind kind);

    protected abstract void ProcessInitReply(int number, byte[] data);

    protected abstract void ProcessStatusReply(int number, byte[] data);

    protected abstract void ProcessWriteReply(RigParameter param, byte[] data);

    protected abstract void ProcessCustomReply(object sender, byte[] code, byte[] data);

    public abstract void AddWriteCommand(RigParameter param, int value = 0);

    public abstract void AddCustomCommand(object sender, byte[] code, int len, string end);

    private static readonly object LockStart = new();
    public void Start()
    {
        if (RigCommands == null)
        {
            return;
        }

        _logger.Info($"Starting RIG{RigNumber}");
        lock (LockStart)
        {
            if (!_rigSettings.Enabled)
            {
                return;
            }

            _queue.Clear();
            _queue.Phase = ExchangePhase.Idle;
            AddCommands(RigCommands.InitCmd, CommandKind.Init);
            AddCommands(RigCommands.StatusCmd, CommandKind.Status);
        }

        EnableConnectivityTimer();
    }

    private static readonly object StopLockObject = new();
    public void Stop()
    {
        if (!_rigSettings.Enabled)
        {
            return;
        }

        DisableConnectivityTimer();

        _logger.Debug($"Stopping RIG{RigNumber}");

        lock (StopLockObject)
        {
            _online = false;
            _queue.Clear();
            _queue.Phase = ExchangePhase.Idle;
            _serialPort.Disconnect();
        }
    }

    private void EnableConnectivityTimer()
    {
        var interval = TimeSpan.FromMilliseconds(_rigSettings.PollMs);
        _connectivityTimer.Change(interval, interval);
    }

    private void DisableConnectivityTimer()
    {
        _connectivityTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    private static readonly object TimerTickLockObject = new();

    private void ConnectivityTimerCallbackFunc(object? state)
    {
        if (!_rigSettings.Enabled || _queue.Phase != ExchangePhase.Idle)
        {
            return;
        }

        var hasLock = false;

        try
        {
            Monitor.TryEnter(TimerTickLockObject, ref hasLock);
            if (!hasLock)
            {
                return;
            }

            DisableConnectivityTimer();

            ConnectivityTimerTick();
        }
        finally
        {
            if (hasLock)
            {
                Monitor.Exit(TimerTickLockObject);
                EnableConnectivityTimer();
            }
        }
    }

    private void EnableTimeoutTimer()
    {
        _timeoutTimer.Change(TimeSpan.FromMilliseconds(_rigSettings.TimeoutMs), Timeout.InfiniteTimeSpan);
    }

    private void DisableTimeoutTimer()
    {
        _timeoutTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
    }

    private void ConnectivityTimerTick()
    {
        _logger.Debug("Timer ticked.");

        var connected = _serialPort.IsConnected;
        if (!connected)
        {
            _logger.Debug($"RIG{RigNumber} is not connected. (Re)Connecting.");
            connected = _serialPort.Connect();
        }

        if (!connected)
        {
            _logger.Error("Failed to connect to the RIG.");
            return;
        }

        if (_queue.HasStatusCommands)
        {
            _logger.DebugFormat("RIG{0} Status commands is already in the queue", RigNumber);
        }
        else
        {
            _logger.DebugFormat("RIG{0} Adding status commands to the queue", RigNumber);
            AddCommands(RigCommands.StatusCmd, CommandKind.Status);
        }

        CheckQueue();
    }

    private static readonly object CheckQueueLockObject = new();
    public void CheckQueue()
    {
        lock (CheckQueueLockObject)
        {
            if (!Enabled 
                || !_serialPort.IsConnected 
                || _queue.Phase != ExchangePhase.Idle 
                || _queue.Count == 0)
            {
                return;
            }

            var s = _queue.CurrentCmd.Kind switch
            {
                CommandKind.Init => "init",
                CommandKind.Write => _queue.CurrentCmd.Param.ToString(),
                CommandKind.Status => "status",
                CommandKind.Custom => "custom",
                _ => throw new ArgumentOutOfRangeException()
            };

            _logger.DebugFormat("RIG{0}: Sending {1} command: {2}",
                RigNumber, s, ByteFunctions.BytesToHex(_queue.CurrentCmd.Code));
            //send command
            _serialPort.SendMessage(_queue.CurrentCmd.Code);

            if (_queue.CurrentCmd.NeedsReply)
            {
                _queue.Phase = ExchangePhase.Receiving;
                EnableTimeoutTimer();
                _logger.Debug($"RIG{RigNumber}: Waiting for reply from radio.");
            }
        }
    }

    public void ForceVfo(RigParameter Value)
    {
        if (Enabled)
        {
            AddWriteCommand(Value);
        }
    }

    public string GetStatusStr()
    {
        var getStatusStrResult = string.Empty;
        string[] statusStr = { "Rig is not configured", "Rig is disabled", "Port is not available", "Rig is not responding", "On-line" };
        return statusStr[(int)GetStatus()];
    }

    protected virtual void OnConnectionStatusChanged(ConnectionStatusChangedEventArgs args)
    {
        ConnectionStatusChanged?.Invoke(this, args);
    }
}