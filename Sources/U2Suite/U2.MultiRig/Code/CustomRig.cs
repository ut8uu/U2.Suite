using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using log4net;
using U2.MultiRig.Code;

namespace U2.MultiRig;

public enum TRigCtlStatus
{
    stNotConfigured, stDisabled, stPortBusy, stNotResponding, stOnLine
}

public abstract class CustomRig
{
    private ILog _logger = LogManager.GetLogger(typeof(CustomRig));
    protected UdpMessenger _udpMessenger;

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

    internal bool FEnabled = false;
    internal bool FOnline = false;
    internal IntPtr FCritSect = new IntPtr();
    internal RigCommands FRigCommands = new RigCommands();
    internal DateTime FNextStatusTime;
    internal DateTime FDeadLineTime;

    public int RigNumber { get; set; } = 0;
    public int PollMs { get; set; } = 0;
    public int TimeoutMs { get; set; } = 0;
    public TAlCommPort ComPort = new TAlCommPort();
    public RigParameter LastWrittenMode = RigParameter.None;

    protected CustomRig()
    {
        FCritSect = new IntPtr();
        FQueue = new TCommandQueue();
        ComPort = new TAlCommPort
        {
            //OnReceived = RecvEvent(),
            //OnSent = SentEvent(),
            //OnCtsDsr = CtsDsrEvent()
        };

        _udpMessenger = new UdpMessenger();
    }

    public void Dispose()
    {
        _udpMessenger?.Dispose();
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
        LastWrittenMode = RigParameter.None;
    }

    private static readonly object GetStatusLockObject = new object();
    ////////////////////////////////////////////////////////////////////////////////
    //                                 status
    ////////////////////////////////////////////////////////////////////////////////
    private TRigCtlStatus GetStatus()
    {
        lock(GetStatusLockObject)
        {
            if (RigCommands == null)
            {
                return TRigCtlStatus.stNotConfigured;
            }
            else if (!FEnabled)
            {
                return TRigCtlStatus.stDisabled;
            }
            else if (!ComPort.Open)
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
    private void RecvEvent(object sender)
    {
        lock (RecvEventLockObject)
        {
            var data = new List<byte>();
            if (ComPort.RxBuffer != string.Empty)
            {
                data = ByteFunctions.StrToBytes(ComPort.RxBuffer).ToList();
            }

            ComPort.PurgeRx();

            //some COM ports do not send EV_TXEMPTY

            if (FQueue.Phase == TExchangePhase.phSending)
            {
                FQueue.Phase = TExchangePhase.phReceiving;
                //_logger.InfoFormat($"RIG{RigNumber} {ComPort.TxQueue} bytes in TX buffer, accepting reply", new string[] { Convert.ToString(RigNumber), ComPort.TxQueue });
            }

            if (FQueue.Phase == TExchangePhase.phReceiving)
            {
                _logger.InfoFormat("RIG{0} reply received: {1}", Convert.ToString(RigNumber), ByteFunctions.BytesToHex(data.ToArray()));
            }
            else
            {
                _logger.InfoFormat("RIG{0} unexpected data received: {1}", Convert.ToString(RigNumber), ByteFunctions.BytesToHex(data.ToArray()));
            }

            //are we in the right state?
            if (!ComPort.Open
                || FQueue.Phase != TExchangePhase.phReceiving
                || FQueue.Count == 0)
            {
                return;
            }

            //process data
            try
            {
                var currentCommand = FQueue.CurrentCmd();
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

    private static object _sentEventLockObject = new object();

    private void SentEvent(object sender)
    {
        //_logger.InfoFormat("RIG{0} data sent, {1} bytes in TX buffer", RigNumber, ComPort.TxQueue);

        if (ComPort.TxQueue > 0)
        {
            return;
        }

        lock (_sentEventLockObject)
        {
            if ((!ComPort.Open) || (FQueue.Phase != TExchangePhase.phSending) || (FQueue.Count == 0))
            {
                return;
            }

            if (FQueue.CurrentCmd().NeedsReply())
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
        _logger.Info($"RIG{RigNumber} ctrl bits: CTS={ComPort.CtsBit} DSR={ComPort.DsrBit} RLS={ComPort.RlsdBit}");
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
        FRigCommands = value;
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

    protected abstract void AddCommands(List<RigCommand> commands, TCommandKind kind);

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
                ComPort.Open = true;
            }
            catch (Exception ex1)
            {
                _logger.Error(ex1.Message);
            }
        }

        if (ComPort.Open)
        {
            CheckQueue();
        }
        else
        {
            _logger.InfoFormat("RIG{0} Unable to open port", RigNumber);
        }
    }

    private static object _stopLockObject = new object();
    public void Stop()
    {
        if (!FEnabled)
        {
            return;
        }

        _logger.InfoFormat("Stopping RIG{0}", Convert.ToString(RigNumber));

        lock (_stopLockObject)
        {
            FEnabled = false;
            FOnline = false;
            FQueue.Clear();
            FQueue.Phase = TExchangePhase.phIdle;
            ComPort.Open = false;
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
            if (!ComPort.Open)
            {
                try
                {
                    ComPort.Open = true;
                }
                catch (Exception ex1)
                {
                }
            }

            //refresh params
            if (ComPort.Open && (DateTime.Now > FNextStatusTime))
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
                    LastWrittenMode = RigParameter.None;
                }

                //cancel pending operation
                switch (FQueue.Phase)
                {
                    case TExchangePhase.phSending:
                        {
                            _logger.InfoFormat("RIG{0} send timeout, {1} bytes still in TX buffer", RigNumber, ComPort.TxQueue);
                            //do not send the remaining part
                            ComPort.PurgeTx();
                            //send the same cmd again
                            FQueue.Phase = TExchangePhase.phIdle;
                            FDeadLineTime = DateTime.MaxValue;
                        }
                        break;

                    case TExchangePhase.phReceiving:
                        {
                            _logger.InfoFormat("RIG{0} recv timeout. RX Buffer: \"{1}\"", RigNumber, ByteFunctions.StrToHex(ComPort.RxBuffer));
                            //waste partial reply
                            ComPort.PurgeRx();
                            ComPort.RxBlockMode = TRxBlockMode.rbChar;
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
            string s = string.Empty;
            if (ComPort.Open && (FQueue.Phase == TExchangePhase.phIdle) && (FQueue.Count > 0))
            {
                if (ComPort.RxBuffer != string.Empty)
                {
                    _logger.InfoFormat("RIG{0} unexpected bytes in RX buffer: {1}",
                        RigNumber, ByteFunctions.StrToHex(ComPort.RxBuffer));
                    ComPort.PurgeRx();
                }

                {
                    ComPort.RxBlockSize = FQueue[0].ReplyLength;
                    ComPort.RxBlockTerminator = FQueue[0].ReplyEnd;

                    if (FQueue[0].ReplyEnd != string.Empty)
                    {
                        ComPort.RxBlockMode = TRxBlockMode.rbTerminator;
                    }
                    else if (FQueue[0].ReplyLength > 0)
                    {
                        ComPort.RxBlockMode = TRxBlockMode.rbBlockSize;
                    }
                    else
                    {
                        ComPort.RxBlockMode = TRxBlockMode.rbChar;
                    }
                }

                //log
                s = FQueue[0].Kind switch
                {
                    TCommandKind.ckInit => "init",
                    TCommandKind.ckWrite => FQueue[0].Param.ToString(),
                    TCommandKind.ckStatus => "status",
                    TCommandKind.ckCustom => "custom",
                    _ => throw new ArgumentOutOfRangeException()
                };

                _logger.InfoFormat("RIG{0} sending {1} command: {2}",
                    Convert.ToString(RigNumber), s, ByteFunctions.BytesToHex(FQueue[0].Code));
                //send command
                FQueue.Phase = TExchangePhase.phSending;
                FDeadLineTime = DateTime.Now.AddMilliseconds(TimeoutMs);

                ComPort.Send(ByteFunctions.BytesToStr(FQueue[0].Code));
                _logger.InfoFormat("RIG{0} ComPort.Send called, {1} bytes in TX buffer",
                    RigNumber, ComPort.TxQueue);
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
