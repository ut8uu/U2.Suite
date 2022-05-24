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
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using log4net;
using MonoSerialPort;
using MonoSerialPort.Port;
using U2.MultiRig.Code;
using U2.MultiRig.Code.UDP;

namespace U2.MultiRig;

public enum RigCtlStatus
{
    NotConfigured, Disabled, PortBusy, NotResponding, OnLine
}

#nullable disable
public abstract class CustomRig : IDisposable
{
    private static readonly object LockStart = new();
    private static readonly object StopLockObject = new();
    private static readonly object TimerTickLockObject = new();
    private static readonly object CheckQueueLockObject = new();

    protected readonly ushort ApplicationId;
    private readonly RigSettings _rigSettings;
    private readonly ILog _logger = LogManager.GetLogger(typeof(CustomRig));
    protected RigUdpMessenger UdpMessenger;
    private readonly Timer _connectivityTimer;
    private readonly Timer _timeoutTimer;
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private readonly RigCommands _rigCommands;
    private readonly SerialPortInput _serialPort;

    protected CommandQueue _queue;

    protected bool _online = false;
    protected RigParameter LastWrittenMode = RigParameter.None;

    private static readonly object GetStatusLockObject = new();
    private static readonly object MessageReceivedLockObject = new();

    public int RigNumber { get; set; } = 0;

    public event SerialPortInput.ConnectionStatusChangedEventHandler? ConnectionStatusChanged;

    protected CustomRig(RigControlType rigControlType, int rigNumber, ushort applicationId, 
        RigSettings rigSettings, RigCommands rigCommands)
    {
        RigNumber = rigNumber;
        ApplicationId = applicationId;
        _rigSettings = rigSettings;
        _rigCommands = rigCommands;
        _queue = new CommandQueue();

        if (rigControlType == RigControlType.Host)
        {
            _serialPort = CreateSerialPort(_rigSettings);
            _serialPort.ConnectionStatusChanged += SerialPort_ConnectionStatusChanged;
            _serialPort.MessageReceived += SerialPort_MessageReceived;

            _connectivityTimer = new Timer(ConnectivityTimerCallbackFunc);
            DisableConnectivityTimer();
            _timeoutTimer = new Timer(TimeoutTimerCallbackFunc);
            DisableTimeoutTimer();
        }

        UdpMessenger = new RigUdpMessenger(rigControlType, _cancellationTokenSource.Token);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        _logger.Debug("Disposing");

        Stop();

        UdpMessenger.Dispose();
    }

    #region Properties

    public RigCommands RigCommands => _rigCommands;
    public bool Enabled => _rigSettings.Enabled;

    public RigCtlStatus Status => GetStatus();
    public int Freq { get; set; }
    public int FreqA { get; set; }
    public int FreqB { get; set; }
    public int Pitch { get; set; }
    public int RitOffset { get; set; }
    public RigParameter Vfo { get; set; }
    public RigParameter Split => GetSplit();
    public RigParameter Rit { get; set; }
    public RigParameter Xit { get; set; }
    public RigParameter Tx { get; set; }
    public RigParameter Mode { get; set; }

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

    #endregion

    private void TimeoutTimerCallbackFunc(object? state)
    {
        _logger.Debug($"RIG{RigNumber}: A timeout occurred.");
        _queue.Phase = ExchangePhase.Idle;
    }

    private SerialPortInput CreateSerialPort(RigSettings rigSettings)
    {
        return new SerialPortInput(_rigSettings.Port,
            baudRate: ComPortStuff.BaudRates[rigSettings.BaudRate],
            parity: Parities[rigSettings.Parity],
            dataBits: ComPortStuff.DataBits[rigSettings.DataBits],
            stopBits: StopBits[_rigSettings.StopBits],
            handshake: Handshake.None,
            isVirtualPort: false);
    }

    private readonly List<byte> _receiveQueue = new();
    private void SerialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
    {
        lock (MessageReceivedLockObject)
        {
            var receivedData = args.Data;
            _receiveQueue.AddRange(receivedData);

            //some COM ports do not send EV_TXEMPTY
            if (_queue.Phase == ExchangePhase.Sending)
            {
                _queue.Phase = ExchangePhase.Receiving;
                _logger.Error($"RIG{RigNumber}: Data received from radio while receiving is not expected. Switched to receiving.");
            }

            if (_queue.Phase != ExchangePhase.Receiving)
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

            var currentCommand = _queue.CurrentCmd;
            Debug.Assert(currentCommand != null);

            if (currentCommand.NeedsReply
                && currentCommand.ReplyLength > _receiveQueue.Count)
            {
                return;
            }

            //process data
            try
            {
                DisableTimeoutTimer();

                var data = _receiveQueue.Take(currentCommand.ReplyLength).ToArray();
                var theTail = _receiveQueue.Skip(currentCommand.ReplyLength);
                _receiveQueue.Clear();
                _receiveQueue.AddRange(theTail);
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
                        #warning TODO Check if Custom command is required
                        _logger.Error($"A custom command is not handled.");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"A command kind {currentCommand.Kind} not recognized.", nameof(currentCommand.Kind));
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
                UdpMessenger.SendMultiCastMessage(UdpPacketFactory.CreateHeartbeatPacket(RigNumber, ApplicationId));
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

    ////////////////////////////////////////////////////////////////////////////////
    //                                 status
    ////////////////////////////////////////////////////////////////////////////////
    private RigCtlStatus GetStatus()
    {
        lock (GetStatusLockObject)
        {
            if (!_rigSettings.Enabled)
            {
                return RigCtlStatus.Disabled;
            }
            if (_serialPort is {IsConnected: false})
            {
                return RigCtlStatus.PortBusy;
            }
            if (!_online)
            {
                return RigCtlStatus.NotResponding;
            }
            return RigCtlStatus.OnLine;
        }
    }

    public void SetFreq(int value)
    {
        if (Enabled)
        {
            Freq = value;
            AddWriteCommand(RigParameter.Freq, value);
        }
    }

    public void SetFreqA(int value)
    {
        if (Enabled && value != FreqA)
        {
            AddWriteCommand(RigParameter.FreqA, value);
        }
    }

    public void SetFreqB(int value)
    {
        if (Enabled && (value != FreqB))
        {
            AddWriteCommand(RigParameter.FreqB, value);
        }
    }

    public void SetRitOffset(int value)
    {
        if (Enabled && (value != RitOffset))
        {
            AddWriteCommand(RigParameter.RitOffset, value);
        }
    }

    public void SetPitch(int value)
    {
        if (!Enabled)
        {
            return;
        }

        AddWriteCommand(RigParameter.Pitch, value);

        //remember the pitch that we set if we cannot read it back from the rig
        if (!RigCommands.ReadableParams.Contains(RigParameter.Pitch))
        {
            Pitch = value;
        }
    }

    public void SetVfo(RigParameter value)
    {
        if (Enabled && RigCommandUtilities.VfoParams.Contains(value) && value != Vfo)
        {
            AddWriteCommand(value);
        }
    }

    public void SetSplit(RigParameter value)
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
        else
        {
            switch (Vfo)
            {
                case RigParameter.VfoAB:
                    SetVfo(RigParameter.VfoAA);
                    break;
                case RigParameter.VfoBA:
                    SetVfo(RigParameter.VfoBB);
                    break;
            }
        }
    }

    public void SetRit(RigParameter value)
    {
        if (Enabled && RigCommandUtilities.RitOnParams.Contains(value) 
                    && value != Rit)
        {
            AddWriteCommand(value);
        }
    }

    public void SetXit(RigParameter value)
    {
        if (Enabled && RigCommandUtilities.XitOnParams.Contains(value) 
                    && value != Xit)
        {
            AddWriteCommand(value);
        }
    }

    public void SetTx(RigParameter value)
    {
        if (Enabled && (RigCommandUtilities.TxParams.Contains(value)))
        {
            AddWriteCommand(value);
        }
    }

    public void SetMode(RigParameter value)
    {
        if (Enabled && (RigCommandUtilities.ModeParams.Contains(value)))
        {
            AddWriteCommand(value);
        }
    }

    private RigParameter GetSplit()
    {
        var getSplitResult = Split;

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

    public abstract void AddWriteCommand(RigParameter param, int value = 0);

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

            _cancellationTokenSource = new CancellationTokenSource();
            _queue.Clear();
            _queue.Phase = ExchangePhase.Idle;
            AddCommands(RigCommands.InitCmd, CommandKind.Init);
            AddCommands(RigCommands.StatusCmd, CommandKind.Status);
        }

        EnableConnectivityTimer();
    }

    public void Stop()
    {
        if (!_rigSettings.Enabled)
        {
            return;
        }

        _logger.Debug($"Stopping RIG{RigNumber}");

        lock (StopLockObject)
        {
            _cancellationTokenSource.Cancel();
            DisableConnectivityTimer();
            _online = false;
            _queue.Clear();
            _queue.Phase = ExchangePhase.Idle;
            _serialPort.Disconnect();
            UdpMessenger.Dispose();
        }
    }

    #region Timer related methods

    private void EnableConnectivityTimer()
    {
        var interval = TimeSpan.FromMilliseconds(_rigSettings.PollMs);
        _connectivityTimer.Change(interval, interval);
    }

    private void DisableConnectivityTimer()
    {
        _connectivityTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

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
        _timeoutTimer?.Change(TimeSpan.FromMilliseconds(_rigSettings.TimeoutMs), Timeout.InfiniteTimeSpan);
    }

    private void DisableTimeoutTimer()
    {
        _timeoutTimer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
    }

    private void ConnectivityTimerTick()
    {
        //_logger.Debug("Timer ticked.");

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

        if (!_queue.HasStatusCommands)
        {
            AddCommands(RigCommands.StatusCmd, CommandKind.Status);
        }

        CheckQueue();
    }

    #endregion

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

            //send command
            _serialPort.SendMessage(_queue.CurrentCmd.Code);

            if (_queue.CurrentCmd.NeedsReply)
            {
                _queue.Phase = ExchangePhase.Receiving;
                EnableTimeoutTimer();
            }
            else
            {
                _queue.RemoveAt(0);
            }
        }
    }

    protected virtual void OnConnectionStatusChanged(ConnectionStatusChangedEventArgs args)
    {
        ConnectionStatusChanged?.Invoke(this, args);
    }
}
#nullable restore