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
    stNotConfigured, stDisabled, stPortBusy, stNotResponding, stOnLine
}

public abstract class CustomRig
{
    private readonly RigSettings _rigSettings;
    private readonly ILog _logger = LogManager.GetLogger(typeof(CustomRig));
    protected UdpMessenger _udpMessenger;
    protected readonly Timer _timer;
    protected bool _started = false;

    protected TCommandQueue FQueue;
    protected int FFreq = 0;
    protected int FFreqA = 0;
    protected int FFreqB = 0;
    protected int FRitOffset = 0;
    protected int FPitch = 0;
    protected RigParameter FVfo;
    protected RigParameter FSplit;
    protected RigParameter FRit;
    protected RigParameter FXit;
    protected RigParameter FTx;
    protected RigParameter FMode;

    internal bool _enabled = false;
    internal bool _online = false;
    internal RigCommands _rigCommands;
    internal DateTime FDeadLineTime;

    public int RigNumber { get; set; } = 0;
    public int PollMs { get; set; } = 0;
    public int TimeoutMs { get; set; } = 0;
    public SerialPortInput _serialPort;
    public RigParameter LastWrittenMode = RigParameter.None;

    public event SerialPortInput.ConnectionStatusChangedEventHandler ConnectionStatusChanged;

    protected CustomRig(int rigNumber, RigSettings rigSettings, RigCommands rigCommands)
    {
        _rigSettings = rigSettings;
        _rigCommands = rigCommands;
        RigNumber = rigNumber;
        FQueue = new TCommandQueue();

        _serialPort = CreateSerialPort(_rigSettings);
        _serialPort.ConnectionStatusChanged += SerialPort_ConnectionStatusChanged;
        _serialPort.MessageReceived += SerialPort_MessageReceived;

        _udpMessenger = new UdpMessenger();
        _timer = new Timer(TimerCallbackFunc, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(rigSettings.PollMs));
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

    public void Dispose()
    {
        _logger.Debug("Disposing");

        _udpMessenger?.Dispose();
        if (_serialPort.IsConnected)
        {
            _serialPort.Disconnect();
        }
    }

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

    private static Parity IntToParity(int parity)
    {
        return Parities[parity];
    }

    private void SerialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
    {
        lock (RecvEventLockObject)
        {
            var data = args.Data;

            //some COM ports do not send EV_TXEMPTY
            if (FQueue.Phase == TExchangePhase.phSending)
            {
                FQueue.Phase = TExchangePhase.phReceiving;
                _logger.Info($"RIG{RigNumber} {data.Length} bytes in TX buffer, accepting reply.");
            }

            if (FQueue.Phase == TExchangePhase.phReceiving)
            {
                _logger.DebugFormat("RIG{0} reply received: {1}", Convert.ToString(RigNumber), ByteFunctions.BytesToHex(data.ToArray()));
            }
            else
            {
                _logger.DebugFormat("RIG{0} unexpected data received: {1}", Convert.ToString(RigNumber), ByteFunctions.BytesToHex(data.ToArray()));
            }

            //are we in the right state?
            if (!_serialPort.IsConnected
                || FQueue.Phase != TExchangePhase.phReceiving
                || FQueue.Count == 0)
            {
                return;
            }

            //process data
            try
            {
                var currentCommand = FQueue.CurrentCmd;
                switch (currentCommand.Kind)
                {
                    case TCommandKind.ckInit:
                        ProcessInitReply(currentCommand.Number, data.ToArray());
                        break;

                    case TCommandKind.ckWrite:
                        ProcessWriteReply(currentCommand.Param, data.ToArray());
                        break;

                    case TCommandKind.ckStatus:
                        ProcessStatusReply(currentCommand.Number, data.ToArray());
                        break;

                    case TCommandKind.ckCustom:
                        ProcessCustomReply(currentCommand.CustSender, currentCommand.Code, data.ToArray());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("RIG{0} Processing reply: {1}", Convert.ToString(RigNumber), e.Message);
            }

            //we are receiving data, therefore we are online
            if (!_online)
            {
                _online = true;
                _udpMessenger.ComNotifyStatus(RigNumber);
            }

            //send next command if queue not empty
            FQueue.RemoveAt(0);
            FQueue.Phase = TExchangePhase.phIdle;
            FDeadLineTime = DateTime.MinValue;
            CheckQueue();
        }
    }

    private void SerialPort_ConnectionStatusChanged(object sender, ConnectionStatusChangedEventArgs args)
    {
        var state = args.Connected ? "Connected" : "Disconnected";
        _logger.Info($"Connection state changed to: {state}");

        OnConnectionStatusChanged(args);
    }

    ////////////////////////////////////////////////////////////////////////////////
    //                                 Comm port
    ////////////////////////////////////////////////////////////////////////////////
    private void SetEnabled(bool value)
    {
        if (_enabled == value)
        {
            return;
        }

        //check for valid RigCommands
        if (value && (RigCommands == null))
        {
            return;
        }

        if (value)
        {
            Start();
        }
        else
        {
            Stop();
        }

        _udpMessenger.ComNotifyStatus(RigNumber);
        LastWrittenMode = RigParameter.None;
    }

    private static readonly object GetStatusLockObject = new object();
    ////////////////////////////////////////////////////////////////////////////////
    //                                 status
    ////////////////////////////////////////////////////////////////////////////////
    private RigCtlStatus GetStatus()
    {
        lock (GetStatusLockObject)
        {
            if (RigCommands == null)
            {
                return RigCtlStatus.stNotConfigured;
            }
            else if (!_enabled)
            {
                return RigCtlStatus.stDisabled;
            }
            else if (!_serialPort.IsConnected)
            {
                return RigCtlStatus.stPortBusy;
            }
            else if (!_online)
            {
                return RigCtlStatus.stNotResponding;
            }
            else
            {
                return RigCtlStatus.stOnLine;
            }
        }
    }

    private static readonly object RecvEventLockObject = new object();

    private static object _sentEventLockObject = new object();

    private void SentEvent(object sender)
    {
        //_logger.InfoFormat("RIG{0} data sent, {1} bytes in TX buffer", RigNumber, ComPort.TxQueue);
        lock (_sentEventLockObject)
        {
            if (!_serialPort.IsConnected
                || FQueue.Phase != TExchangePhase.phSending
                || FQueue.Count == 0)
            {
                return;
            }

            if (FQueue.CurrentCmd.NeedsReply)
            {
                FQueue.Phase = TExchangePhase.phReceiving;
                FDeadLineTime = DateTime.Now.AddMilliseconds(TimeoutMs);
            }
            else
            {
                FQueue.RemoveAt(0);
                FQueue.Phase = TExchangePhase.phIdle;
                FDeadLineTime = DateTime.MaxValue;
                CheckQueue();
            }
        }
    }

    private void CtsDsrEvent(object sender)
    {
        string[] boolStr = { "OFF", "ON" };
        //_logger.Info($"RIG{RigNumber} ctrl bits: CTS={ComPort.CtsBit} DSR={ComPort.DsrBit} RLS={ComPort.RlsdBit}");
    }

    private void SetFreq(int value)
    {
        if (Enabled)
        {
            AddWriteCommand(RigParameter.Freq, value);
        }
    }

    private void SetFreqA(int value)
    {
        _logger.InfoFormat("Entered SetFreqA");

        if (Enabled && (value != FFreqA))
        {
            AddWriteCommand(RigParameter.FreqA, value);
        }

        _logger.InfoFormat("Exiting SetFreqA");
    }

    private void SetFreqB(int value)
    {
        if (Enabled && (value != FFreqB))
        {
            AddWriteCommand(RigParameter.FreqB, value);
        }
    }

    private void SetRitOffset(int value)
    {
        if (Enabled && (value != FRitOffset))
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
            FPitch = value;
        }
    }

    private void SetVfo(RigParameter value)
    {
        if (Enabled && (RigCommandUtilities.VfoParams.Contains(value)) && (value != FVfo))
        {
            AddWriteCommand(value);
        }
    }

    private void SetSplit(RigParameter value)
    {
        if (!(Enabled && (RigCommandUtilities.SplitParams.Contains(value))))
        {
            return;
        }

        if ((RigCommands.WriteableParams.Contains(value)) && (value != Split))
        {
            AddWriteCommand(value);
        }
        else if (value == RigParameter.SplitOn)
        {
            if (Vfo == RigParameter.VfoAA)
            {
                Vfo = RigParameter.VfoAB;
            }
            else if (Vfo == RigParameter.VfoBB)
            {
                Vfo = RigParameter.VfoBA;
            }
        }
        else if (Vfo == RigParameter.VfoAB)
        {
            Vfo = RigParameter.VfoAA;
        }
        else if (Vfo == RigParameter.VfoBA)
        {
            Vfo = RigParameter.VfoBB;
        }
    }

    private void SetRit(RigParameter value)
    {
        if (Enabled && (RigCommandUtilities.RitOnParams.Contains(value)) && (value != FRit))
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
        var getSplitResult = FSplit;

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

    protected abstract void AddCommands(IEnumerable<RigCommand> commands, TCommandKind kind);

    protected abstract void ProcessInitReply(int number, byte[] data);

    protected abstract void ProcessStatusReply(int number, byte[] data);

    protected abstract void ProcessWriteReply(RigParameter param, byte[] data);

    protected abstract void ProcessCustomReply(object sender, byte[] code, byte[] data);

    ////////////////////////////////////////////////////////////////////////////////
    //                                 system
    ////////////////////////////////////////////////////////////////////////////////

    private bool disposed = false;
    protected void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                Stop();
            }
        }

        disposed = true;
    }

    public abstract void AddWriteCommand(RigParameter param, int value = 0);

    public abstract void AddCustomCommand(object sender, byte[] code, int len, string end);

    private static object _lockStart = new object();
    public void Start()
    {
        if (RigCommands == null)
        {
            return;
        }

        _logger.Info($"Starting RIG{RigNumber}");
        lock (_lockStart)
        {
            if (_enabled)
            {
                return;
            }

            _enabled = true;
            FQueue.Clear();
            FQueue.Phase = TExchangePhase.phIdle;
            FDeadLineTime = DateTime.MaxValue;
            AddCommands(RigCommands.InitCmd, TCommandKind.ckInit);
            AddCommands(RigCommands.StatusCmd, TCommandKind.ckStatus);

            try
            {
                _serialPort.Connect();
            }
            catch (Exception ex1)
            {
                _logger.Error(ex1.Message);
            }
        }

        if (_serialPort.IsConnected)
        {
            CheckQueue();
        }
        else
        {
            _logger.DebugFormat("RIG{0} Unable to open port", RigNumber);
        }
    }

    private static object _stopLockObject = new object();
    public void Stop()
    {
        if (!_enabled)
        {
            return;
        }

        _logger.DebugFormat("Stopping RIG{0}", Convert.ToString(RigNumber));

        lock (_stopLockObject)
        {
            _enabled = false;
            _online = false;
            FQueue.Clear();
            FQueue.Phase = TExchangePhase.phIdle;
            _serialPort.Disconnect();
        }
    }

    private void DisableTimer()
    {
        _timer.Change(TimeSpan.MaxValue, TimeSpan.FromMilliseconds(_rigSettings.PollMs));
    }

    private bool _timerCallbackProcess = false;
    public static object _timerTickLockObject = new object();

    private void TimerCallbackFunc(object? state)
    {
        var hasLock = false;

        try
        {
            Monitor.TryEnter(_timerTickLockObject, ref hasLock);
            if (!hasLock)
            {
                return;
            }

            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            TimerTick();
        }
        finally
        {
            if (hasLock)
            {
                Monitor.Exit(_timerTickLockObject);
                var interval = TimeSpan.FromMilliseconds(_rigSettings.PollMs);
                _timer.Change(interval, interval);
            }
        }
    }

    private void TimerTick()
    {
        _logger.Debug("Timer ticked.");
        if (!_rigSettings.Enabled)
        {
            return;
        }

        if (_timerCallbackProcess)
        {
            return;
        }

        _timerCallbackProcess = true;

        try
        {
            var connected = false;
            if (!_serialPort.IsConnected)
            {
                _logger.Debug($"RIG{RigNumber} is not connected. (Re)Connecting.");
                connected = _serialPort.Connect();
            }

            if (!connected)
            {
                _logger.Error("Failed to connect to the RIG.");
                _timerCallbackProcess = false;
                return;
            }

            if (FQueue.HasStatusCommands)
            {
                _logger.InfoFormat("RIG{0} Status commands is already in the queue", RigNumber);
            }
            else
            {
                _logger.InfoFormat("RIG{0} Adding status commands to the queue", RigNumber);
                AddCommands(RigCommands.StatusCmd, TCommandKind.ckStatus);
            }

            if (FQueue.Phase != TExchangePhase.phIdle)
            {
                FQueue.Phase = TExchangePhase.phIdle;
            }

            CheckQueue();
        }
        finally
        {
            _timerCallbackProcess = false;
        }
    }

    private static object _checkQueueLockObject = new object();
    public void CheckQueue()
    {
        lock (_checkQueueLockObject)
        {
            if (_serialPort.IsConnected &&
                FQueue.Phase == TExchangePhase.phIdle
                && FQueue.Count > 0)
            {
                var s = FQueue[0].Kind switch
                {
                    TCommandKind.ckInit => "init",
                    TCommandKind.ckWrite => FQueue[0].Param.ToString(),
                    TCommandKind.ckStatus => "status",
                    TCommandKind.ckCustom => "custom",
                    _ => throw new ArgumentOutOfRangeException()
                };

                _logger.DebugFormat("RIG{0} sending {1} command: {2}",
                    Convert.ToString(RigNumber), s, ByteFunctions.BytesToHex(FQueue[0].Code));
                //send command
                FQueue.Phase = TExchangePhase.phSending;
                FDeadLineTime = DateTime.Now.AddMilliseconds(TimeoutMs);

                _logger.DebugFormat("RIG{0} ComPort.Send called. Bytes sent: {1}",
                    RigNumber, ByteFunctions.BytesToHex(FQueue[0].Code));
                _serialPort.SendMessage(FQueue[0].Code);
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
    public RigCommands RigCommands
    {
        get
        {
            return _rigCommands;
        }
        set
        {
            SeRigCommands(value);
        }
    }
    public bool Enabled
    {
        get
        {
            return _enabled;
        }
        set
        {
            SetEnabled(value);
        }
    }
    public RigCtlStatus Status
    {
        get
        {
            return GetStatus();
        }
    }
    public int Freq
    {
        get
        {
            return FFreq;
        }
        set
        {
            SetFreq(value);
        }
    }
    public int FreqA
    {
        get
        {
            return FFreqA;
        }
        set
        {
            SetFreqA(value);
        }
    }
    public int FreqB
    {
        get
        {
            return FFreqB;
        }
        set
        {
            SetFreqB(value);
        }
    }
    public int Pitch
    {
        get
        {
            return FPitch;
        }
        set
        {
            SetPitch(value);
        }
    }
    public int RitOffset
    {
        get
        {
            return FRitOffset;
        }
        set
        {
            SetRitOffset(value);
        }
    }
    public RigParameter Vfo
    {
        get
        {
            return FVfo;
        }
        set
        {
            SetVfo(value);
        }
    }
    public RigParameter Split
    {
        get
        {
            return GetSplit();
        }
        set
        {
            SetSplit(value);
        }
    }
    public RigParameter Rit
    {
        get
        {
            return FRit;
        }
        set
        {
            SetRit(value);
        }
    }
    public RigParameter Xit
    {
        get
        {
            return FXit;
        }
        set
        {
            SetXit(value);
        }
    }
    public RigParameter Tx
    {
        get
        {
            return FTx;
        }
        set
        {
            SetTx(value);
        }
    }
    public RigParameter Mode
    {
        get
        {
            return FMode;
        }
        set
        {
            SetMode(value);
        }
    }

    protected virtual void OnConnectionStatusChanged(ConnectionStatusChangedEventArgs args)
    {
        ConnectionStatusChanged?.Invoke(this, args);
    }

    public void Connect()
    {
        if (_started)
        {
            return;
        }

        _started = true;
        _timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(_rigSettings.PollMs));
    }
}