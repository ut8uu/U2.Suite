using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using log4net;
using MonoSerialPort;
using MonoSerialPort.Port;
using U2.MultiRig.Code;

namespace U2.MultiRig;

public enum TRigCtlStatus
{
    stNotConfigured, stDisabled, stPortBusy, stNotResponding, stOnLine
}

public abstract class CustomRig
{
    private readonly RigSettings _rigSettings;
    private ILog _logger = LogManager.GetLogger(typeof(CustomRig));
    protected UdpMessenger _udpMessenger;

    protected TCommandQueue FQueue;
    protected int FFreq = 0;
    protected int FFreqA = 0;
    protected int FFreqB = 0;
    protected int FRitOffset = 0;
    protected int FPitch = 0;
    protected TRigParam FVfo;
    protected TRigParam FSplit;
    protected TRigParam FRit;
    protected TRigParam FXit;
    protected TRigParam FTx;
    protected TRigParam FMode;

    internal bool FEnabled = false;
    internal bool FOnline = false;
    internal RigCommands FRigCommands;
    internal DateTime FNextStatusTime;
    internal DateTime FDeadLineTime;

    public int RigNumber { get; set; } = 0;
    public int PollMs { get; set; } = 0;
    public int TimeoutMs { get; set; } = 0;
    public SerialPortInput _serialPort;
    public TRigParam LastWrittenMode = TRigParam.None;

    public event SerialPortInput.ConnectionStatusChangedEventHandler ConnectionStatusChanged;

    protected CustomRig(int rigNumber, RigSettings rigSettings)
    {
        _rigSettings = rigSettings;
        RigNumber = rigNumber;
        FQueue = new TCommandQueue();

        _serialPort = new SerialPortInput(_rigSettings.Port,
            baudRate: rigSettings.BaudRate,
            parity: _parities[rigSettings.Parity],
            dataBits:rigSettings.DataBits,
            stopBits: _stopBits[_rigSettings.StopBits],
            handshake: Handshake.None,
            isVirtualPort:false);
        _serialPort.SetPort(_rigSettings.Port, rigSettings.BaudRate);
        _serialPort.ConnectionStatusChanged += SerialPort_ConnectionStatusChanged;
        _serialPort.MessageReceived += SerialPort_MessageReceived;

        _udpMessenger = new UdpMessenger();
    }

    private static StopBits[] _stopBits = {StopBits.One, StopBits.OnePointFive, StopBits.Two};
    private static Parity[] _parities = {Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space};
    private static Handshake[] _handshakes = {
        Handshake.None, 
        Handshake.RequestToSend, 
        Handshake.RequestToSendXOnXOff, 
        Handshake.XOnXOff,
    };
    private static Parity IntToParity(int parity)
    {
        return _parities[parity];
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
            if (!FOnline)
            {
                FOnline = true;
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
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _udpMessenger?.Dispose();
        if (_serialPort.IsConnected)
        {
            _serialPort.Disconnect();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////
    //                                 Comm port
    ////////////////////////////////////////////////////////////////////////////////
    private void SetEnabled(bool value)
    {
        if (FEnabled == value)
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
        LastWrittenMode = TRigParam.None;
    }

    private static readonly object GetStatusLockObject = new object();
    ////////////////////////////////////////////////////////////////////////////////
    //                                 status
    ////////////////////////////////////////////////////////////////////////////////
    private TRigCtlStatus GetStatus()
    {
        lock (GetStatusLockObject)
        {
            if (RigCommands == null)
            {
                return TRigCtlStatus.stNotConfigured;
            }
            else if (!FEnabled)
            {
                return TRigCtlStatus.stDisabled;
            }
            else if (!_serialPort.IsConnected)
            {
                return TRigCtlStatus.stPortBusy;
            }
            else if (!FOnline)
            {
                return TRigCtlStatus.stNotResponding;
            }
            else
            {
                return TRigCtlStatus.stOnLine;
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
            AddWriteCommand(TRigParam.Freq, value);
        }
    }

    private void SetFreqA(int value)
    {
        _logger.InfoFormat("Entered SetFreqA");

        if (Enabled && (value != FFreqA))
        {
            AddWriteCommand(TRigParam.FreqA, value);
        }

        _logger.InfoFormat("Exiting SetFreqA");
    }

    private void SetFreqB(int value)
    {
        if (Enabled && (value != FFreqB))
        {
            AddWriteCommand(TRigParam.FreqB, value);
        }
    }

    private void SetRitOffset(int value)
    {
        if (Enabled && (value != FRitOffset))
        {
            AddWriteCommand(TRigParam.RitOffset, value);
        }
    }

    private void SetPitch(int value)
    {
        if (!Enabled)
        {
            return;
        }

        AddWriteCommand(TRigParam.Pitch, value);

        //remember the pitch that we set if we cannot read it back from the rig
        if (!(RigCommands.ReadableParams.Contains(TRigParam.Pitch)))
        {
            FPitch = value;
        }
    }

    private void SetVfo(TRigParam value)
    {
        if (Enabled && (RigCommandUtilities.VfoParams.Contains(value)) && (value != FVfo))
        {
            AddWriteCommand(value);
        }
    }

    private void SetSplit(TRigParam value)
    {
        if (!(Enabled && (RigCommandUtilities.SplitParams.Contains(value))))
        {
            return;
        }

        if ((RigCommands.WriteableParams.Contains(value)) && (value != Split))
        {
            AddWriteCommand(value);
        }
        else if (value == TRigParam.SplitOn)
        {
            if (Vfo == TRigParam.VfoAA)
            {
                Vfo = TRigParam.VfoAB;
            }
            else if (Vfo == TRigParam.VfoBB)
            {
                Vfo = TRigParam.VfoBA;
            }
        }
        else if (Vfo == TRigParam.VfoAB)
        {
            Vfo = TRigParam.VfoAA;
        }
        else if (Vfo == TRigParam.VfoBA)
        {
            Vfo = TRigParam.VfoBB;
        }
    }

    private void SetRit(TRigParam value)
    {
        if (Enabled && (RigCommandUtilities.RitOnParams.Contains(value)) && (value != FRit))
        {
            AddWriteCommand(value);
        }
    }

    private void SetXit(TRigParam value)
    {
        if (Enabled && (RigCommandUtilities.XitOnParams.Contains(value)) && (value != Xit))
        {
            AddWriteCommand(value);
        }
    }

    private void SetTx(TRigParam value)
    {
        if (Enabled && (RigCommandUtilities.TxParams.Contains(value)))
        {
            AddWriteCommand(value);
        }
    }

    private void SetMode(TRigParam value)
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
        FRigCommands = value;
        _udpMessenger.ComNotifyRigType(RigNumber);
    }

    private TRigParam GetSplit()
    {
        var getSplitResult = FSplit;

        if (getSplitResult != TRigParam.None)
        {
            return getSplitResult;
        }
        if (new[] { TRigParam.VfoAA, TRigParam.VfoBB }.Contains(Vfo))
        {
            getSplitResult = TRigParam.SplitOff;
        }
        else if (new[] { TRigParam.VfoAB, TRigParam.VfoBA }.Contains(Vfo))
        {
            getSplitResult = TRigParam.SplitOn;
        }
        return getSplitResult;
    }

    //these commands are implemented in the descendant class,
    //just to keep them in a separate file

    protected abstract void AddCommands(IEnumerable<RigCommand> commands, TCommandKind kind);

    protected abstract void ProcessInitReply(int number, byte[] data);

    protected abstract void ProcessStatusReply(int number, byte[] data);

    protected abstract void ProcessWriteReply(TRigParam param, byte[] data);

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

    public abstract void AddWriteCommand(TRigParam param, int value = 0);

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
            if (FEnabled)
            {
                return;
            }

            FEnabled = true;
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
        if (!FEnabled)
        {
            return;
        }

        _logger.DebugFormat("Stopping RIG{0}", Convert.ToString(RigNumber));

        lock (_stopLockObject)
        {
            FEnabled = false;
            FOnline = false;
            FQueue.Clear();
            FQueue.Phase = TExchangePhase.phIdle;
            _serialPort.Disconnect();
        }
    }

    public static object _timerTickLockObject = new object();
    public void TimerTick()
    {
        lock (_timerTickLockObject)
        {
            if (!FEnabled)
            {
                return;
            }

            //try to open port
            if (!_serialPort.IsConnected)
            {
                _serialPort.Connect();
            }

            //refresh params
            if (_serialPort.IsConnected && DateTime.Now > FNextStatusTime)
            {
                if (FQueue.HasStatusCommands)
                {
                    _logger.InfoFormat("RIG{0} Status commands already in queue", RigNumber);
                }
                else
                {
                    _logger.InfoFormat("RIG{0} Adding status commands to queue", RigNumber);
                    AddCommands(RigCommands.StatusCmd, TCommandKind.ckStatus);
                }

                FNextStatusTime = DateTime.Now.AddMilliseconds(PollMs);
            }

            //on-line timeout occurred
            if (DateTime.Now > FDeadLineTime)
            {
                //switch off-line
                if (FOnline)
                {
                    FOnline = false;
                    _udpMessenger.ComNotifyStatus(RigNumber);
                    LastWrittenMode = TRigParam.None;
                }

                //cancel pending operation
                switch (FQueue.Phase)
                {
                    case TExchangePhase.phSending:
                        {
                            _logger.DebugFormat("RIG{0} send timeout", RigNumber);
                            //do not send the remaining part
                            //ComPort.PurgeTx();
                            //send the same cmd again
                            FQueue.Phase = TExchangePhase.phIdle;
                            FDeadLineTime = DateTime.MaxValue;
                        }
                        break;

                    case TExchangePhase.phReceiving:
                        {
                            _logger.DebugFormat("RIG{0} recv timeout.", RigNumber);
                            //consider current cmd unreplied
                            FQueue.RemoveAt(0);
                            //allow next cmd
                            FQueue.Phase = TExchangePhase.phIdle;
                            FDeadLineTime = DateTime.MaxValue;
                        }
                        break;
                }
            }
        }

        CheckQueue();
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

    public void ForceVfo(TRigParam Value)
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
            return FRigCommands;
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
            return FEnabled;
        }
        set
        {
            SetEnabled(value);
        }
    }
    public TRigCtlStatus Status
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
    public TRigParam Vfo
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
    public TRigParam Split
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
    public TRigParam Rit
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
    public TRigParam Xit
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
    public TRigParam Tx
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
    public TRigParam Mode
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
}
public partial class CustRigUnit
{
    public static readonly int MAX_TIMEOUT = 6;
    public static readonly int WM_TXQUEUE = 0x0400 + 1;
    public static readonly int WM_COMSTATUS = 0x0400 + 2;
    public static readonly int WM_COMPARAMS = 0x0400 + 3;
    public static readonly int WM_COMCUSTOM = 0x0400 + 4;
    public static readonly int NEVER = 999999;
    public static readonly double DinMS = 1 / 86400000;
}
