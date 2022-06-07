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

using ColorTextBlock.Avalonia;
using log4net;
using MonoSerialPort;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using U2.Core;
using U2.MultiRig.Code;

namespace U2.MultiRig;

#nullable disable
public sealed class HostRig : Rig
{
    private static readonly object LockStart = new();
    private static readonly object StopLockObject = new();
    private static readonly object TimerTickLockObject = new();
    private static readonly object CheckQueueLockObject = new();

    private readonly List<RigParameter> _changedParams = new();
    private static readonly object MessageReceivedLockObject = new();
    private readonly List<byte> _receiveQueue = new();
    private readonly CommandQueue _queue = new();
    private readonly RigSettings _rigSettings;
    private readonly RigCommands _rigCommands;
    private readonly Timer _connectivityTimer;
    private readonly Timer _timeoutTimer;
    private readonly ILog _logger = LogManager.GetLogger(typeof(HostRig));
    private readonly IRigSerialPort _rigSerialPort;
    private MessageDisplayModes _messageDisplayModes;

    public HostRig(int rigNumber, ushort applicationId, 
        RigSettings rigSettings, RigCommands rigCommands)
        : base(RigControlType.Host, rigNumber, applicationId)
    {
        _rigSettings = rigSettings;
        _rigCommands = rigCommands;
        _connectivityTimer = new Timer(ConnectivityTimerCallbackFunc);
        DisableConnectivityTimer();
        _timeoutTimer = new Timer(TimeoutTimerCallbackFunc);
        DisableTimeoutTimer();

        _rigSerialPort = MultiRigApplicationContext.Instance.Container.Resolve<IRigSerialPort>();
        Debug.Assert(_rigSerialPort != null, "A RigSerialPort not resolved.");
        _rigSerialPort.RigSettings = _rigSettings;
        _rigSerialPort.SerialPortMessageReceived += RigSerialPortOnSerialPortMessageReceived;
    }

    private void RigSerialPortOnSerialPortMessageReceived(object sender, SerialPortMessageReceivedEventArgs eventargs)
    {
        lock (MessageReceivedLockObject)
        {
            var receivedData = eventargs.Data;
            _receiveQueue.AddRange(receivedData);

            //some COM ports do not send EV_TXEMPTY
            if (_queue.Phase == ExchangePhase.Sending)
            {
                _queue.Phase = ExchangePhase.Receiving;
                _logger.Error("RIG: Data received from radio while receiving is not expected. Switched to receiving.");
            }

            if (_queue.Phase != ExchangePhase.Receiving)
            {
                _logger.ErrorFormat("RIG: received data when not in the receiving state: {0} ({1} bytes)",
                    ByteFunctions.BytesToHex(receivedData), receivedData.Length);
                return;
            }

            //are we in the right state?
            if (_queue.Count == 0)
            {
                _logger.Error("RIG: Data received, but the queue is empty.");
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

    public event RigParameterChangedEventHandler RigParameterChanged;

    /// <summary>
    /// Validates a reply using the given Flags
    /// </summary>
    /// <param name="inputData"></param>
    /// <param name="mask"></param>
    /// <exception cref="ValueValidationException"></exception>
    internal static void ValidateReply(byte[] inputData, BitMask mask)
    {
        if (inputData.Length != mask.Flags.Length)
        {
            throw new ValueValidationException($"Incorrect input data length. Expected {mask.Flags.Length}, actual {inputData.Length}.");
        }

        var data = ByteFunctions.BytesAnd(inputData, mask.Mask);
        if (data.SequenceEqual(mask.Flags))
        {
            return;
        }

        var expectedString = ByteFunctions.BytesToHex(mask.Flags);
        var actualString = ByteFunctions.BytesToHex(inputData);
        throw new ValueValidationException($"Invalid input data. Expected {expectedString}, actual {actualString}.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initCommandIndex"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <exception cref="ValueValidationException">Is thrown when input data do not match the validation Flags</exception>
    internal void ProcessInitReply(int initCommandIndex, byte[] data)
    {
        DisplayMessage(MessageDisplayModes.Diagnostics3, $"Processing the Init reply: {ByteFunctions.BytesToHex(data)}");
        ValidateReply(data, _rigCommands.InitCmd[initCommandIndex].Validation);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="statusCommandIndex"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <exception cref="ValueValidationException">Is thrown when input data do not match the validation Flags</exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    internal bool ProcessStatusReply(int statusCommandIndex, byte[] data)
    {
        //validate reply
        var cmd = _rigCommands.StatusCmd[statusCommandIndex];

        DisplayMessage(MessageDisplayModes.Diagnostics3,
            $"Processing the Status ({cmd.Value.Param}) reply: {ByteFunctions.BytesToHex(data)}");

        ValidateReply(data, cmd.Validation);

        //extract numeric values
        for (var index = 0; index <= cmd.Values.Count - 1; index++)
        {
            try
            {
                var value = ConversionFunctions.UnformatValue(data, cmd.Values[index]);
                StoreParam(cmd.Values[index].Param, value);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        //extract bit flags
        for (var index = 0; index <= cmd.Flags.Count - 1; index++)
        {
            if (data.Length != cmd.Flags[index].Mask.Length
                || data.Length != cmd.Flags[index].Flags.Length)
            {
                Logger.ErrorFormat("RIG{0}: incorrect reply length", RigNumber);
            }
            else if (cmd.Flags[index].Flags.SequenceEqual(ByteFunctions.BytesAnd(data, cmd.Flags[index].Mask)))
            {
                var parameter = cmd.Flags[index].Param;
                if (StoreParam(parameter))
                {
                    DisplayMessage(MessageDisplayModes.Diagnostics2, $"Found changed parameter: {parameter}");
                    _changedParams.Add(parameter);
                }
            }
        }
        ReportChangedParameters(_changedParams);
        _changedParams.Clear();

        //tell clients
        if (_changedParams.Any())
        {
            var packet = UdpPacketFactory.CreateMultipleParametersReportingPacket(RigNumber,
                senderId: ApplicationId, receiverId: KnownIdentifiers.MultiCast, _changedParams);
            UdpMessenger.SendMultiCastMessage(packet);
            Logger.Debug($"Multiple parameters changed. A multicast message sent: {ByteFunctions.BytesToHex(packet.GetBytes())}");
        }
        ReportChangedParameters(_changedParams);
        _changedParams.Clear();

        return true;
    }

    private void ReportChangedParameters(IEnumerable<RigParameter> parameters)
    {
        foreach (var parameter in parameters)
        {
            object parameterValue = parameter switch
            {
                RigParameter.FreqA => FreqA,
                RigParameter.None => 0,
                RigParameter.Freq => Freq,
                RigParameter.FreqB => FreqB,
                RigParameter.Pitch => Pitch,
                RigParameter.RitOffset => RitOffset,
                RigParameter.Rit0 => Rit,
                RigParameter.VfoAA => 0,
                RigParameter.VfoAB => 0,
                RigParameter.VfoBA => 0,
                RigParameter.VfoBB => 0,
                RigParameter.VfoA => 0,
                RigParameter.VfoB => 0,
                RigParameter.VfoEqual => 0,
                RigParameter.VfoSwap => 0,
                RigParameter.SplitOn => 1,
                RigParameter.SplitOff => 0,
                RigParameter.RitOn => 1,
                RigParameter.RitOff => 0,
                RigParameter.XitOn => 1,
                RigParameter.XitOff => 0,
                RigParameter.Rx => "RX",
                RigParameter.Tx => "TX",
                RigParameter.CW_U => "CW",
                RigParameter.CW_L => "CW",
                RigParameter.SSB_U => "USB",
                RigParameter.SSB_L => "LSB",
                RigParameter.DIG_U => "DIGI-U",
                RigParameter.DIG_L => "DIGI-L",
                RigParameter.AM => "AM",
                RigParameter.FM => "FM",
                _ => 0
            };

            OnRigParameterChanged(RigNumber, parameter, parameterValue);
        }
    }

    internal void ProcessWriteReply(RigParameter param, byte[] data)
    {
        DisplayMessage(MessageDisplayModes.Diagnostics3, $"Processing the Write reply: {ByteFunctions.BytesToHex(data)}");
        ValidateReply(data, _rigCommands.WriteCmd[(int)param].Validation);
    }

    internal void AddWriteCommand(RigParameter param, int value = 0)
    {
        Logger.DebugFormat("RIG{0} Generating Write command for {1}", RigNumber, param);

        //is cmd supported?
        if (_rigCommands == null)
        {
            return;
        }

        if (!_rigCommands.WriteCmd.ContainsKey((int)param))
        {
            throw new ArgumentException($"A parameter {param} does not support writing to the RIG.", nameof(param));
        }

        var cmd = _rigCommands.WriteCmd[(int)param];
        if (cmd.Code == null)
        {
            Logger.ErrorFormat("RIG{0} Write command not supported for {1}", RigNumber, param);
            return;
        }

        //generate cmd
        var newCode = cmd.Code;

        if (cmd.Value.Format != ValueFormat.None)
        {
            try
            {
                var fmtValue = ConversionFunctions.FormatValue(value, cmd.Value);

                if (cmd.Value.Start + cmd.Value.Len > newCode.Length)
                {
                    Logger.ErrorFormat($"Value {cmd.Code} exceeds expected length of {newCode.Length} bytes.");
                    throw new ValueValidationException($"Value {ByteFunctions.BytesToHex(cmd.Code)} too long");
                }
                Array.Copy(fmtValue, 0, newCode, cmd.Value.Start, cmd.Value.Len);
            }
            catch (Exception e) when (e is not ValueValidationException)
            {
                Logger.ErrorFormat("RIG{0}: Generating command: {1}", RigNumber, e.Message);
            }
        }

        //add to queue
        var queueItem = new QueueItem
        {
            Code = newCode,
            Param = param,
            Kind = CommandKind.Write,
            ReplyLength = cmd.ReplyLength,
            ReplyEnd = ByteFunctions.BytesToStr(cmd.ReplyEnd),
        };
        AddBeforeStatus(queueItem);

        CheckQueue();
    }

    private static PropertyInfo GetPropertyInfo(string name)
    {
        var property = typeof(CustomRig).GetProperty(name);
        Debug.Assert(property != null, $"Property {name} not found in Rig");
        return property;
    }

    /// <summary>
    /// Stores given parameter to a variable.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns>Returns <see langword="true"/> if new value was applied, otherwise <see langword="false"/>.</returns>
    private bool StoreParam(RigParameter parameter)
    {
        if (RigCommandUtilities.VfoParams.Contains(parameter))
        {
            if (Vfo == parameter)
            {
                return false;
            }
            Vfo = parameter;
        }
        else if (RigCommandUtilities.SplitParams.Contains(parameter))
        {
            if (Split == parameter)
            {
                return false;
            }
            Split = parameter;
        }
        else if (RigCommandUtilities.RitOnParams.Contains(parameter))
        {
            if (Rit == parameter)
            {
                return false;
            }
            Rit = parameter;
        }
        else if (RigCommandUtilities.XitOnParams.Contains(parameter))
        {
            if (Xit == parameter)
            {
                return false;
            }
            Xit = parameter;
            return false;
        }
        else if (RigCommandUtilities.TxParams.Contains(parameter))
        {
            if (Tx == parameter)
            {
                return false;
            }
            Tx = parameter;
        }
        else if (RigCommandUtilities.ModeParams.Contains(parameter))
        {
            if (Mode == parameter)
            {
                return false;
            }
            Mode = parameter;
        }
        else
        {
            return false;
        }

        ReportChangedParameters(new[] { parameter });

        //unsolved problem:
        //there is no command to read the mode of the other VFO,
        //its change goes undetected.
        if (RigCommandUtilities.ModeParams.Contains(parameter)
            && parameter != LastWrittenMode)
        {
            LastWrittenMode = RigParameter.None;
        }

        Logger.DebugFormat("RIG{0} status changed: {1} enabled", RigNumber, parameter);

        return true;
    }

    /// <summary>
    /// Stores given value into specified parameter.
    /// </summary>
    /// <param name="parameter">A parameter to store to</param>
    /// <param name="parameterValue">A parameter value</param>
    /// <exception cref="ArgumentOutOfRangeException">Is thrown when passed not supported parameter.</exception>
    internal void StoreParam(RigParameter parameter, int parameterValue)
    {
        PropertyInfo property;

        switch (parameter)
        {
            case RigParameter.FreqA:
                property = GetPropertyInfo(nameof(FreqA));
                break;

            case RigParameter.FreqB:
                property = GetPropertyInfo(nameof(FreqB));
                break;

            case RigParameter.Freq:
                property = GetPropertyInfo(nameof(Freq));
                break;

            case RigParameter.Pitch:
                property = GetPropertyInfo(nameof(Pitch));
                break;

            case RigParameter.RitOffset:
                property = GetPropertyInfo(nameof(RitOffset));
                break;

            default:
                throw new ArgumentOutOfRangeException($"Parameter {parameter} not supported.");
        }

        var fieldValue = property.GetValue(this);
        if (fieldValue == null || parameterValue == (int)fieldValue)
        {
            return;
        }

        property.SetValue(this, parameterValue);
        _changedParams.Add(parameter);
        DisplayMessage(MessageDisplayModes.Debug,
            $"RIG{RigNumber} status changed: {parameter.ToString()} = {Convert.ToString(parameterValue)}");
        var packet = UdpPacketFactory.CreateSingleParameterReportingPacket(RigNumber,
            senderId: ApplicationId, receiverId: KnownIdentifiers.MultiCast,
            parameter, parameterValue);
        UdpMessenger.SendMultiCastMessage(packet);
    }

    private void OnRigParameterChanged(int rigNumber, RigParameter parameter, object value)
    {
        DisplayMessage(MessageDisplayModes.Diagnostics2, $"Found changed parameter: {parameter}. New value: {value}");
        RigParameterChanged?.Invoke(this, rigNumber, parameter, value);
    }

    #region Setter overloads

    public override MessageDisplayModes MessageDisplayModes
    {
        get => _messageDisplayModes;
        set
        {
            _messageDisplayModes = value;
            _rigSerialPort.MessageDisplayModes = value;
        }
    }

    public override void SetFreq(int value)
    {
        if (!Enabled || Freq == value)
        {
            return;
        }

        base.SetFreq(value);
        AddWriteCommand(RigParameter.Freq, value);
    }

    public override void SetFreqA(int value)
    {
        if (!Enabled || value == FreqA)
        {
            return;
        }

        base.SetFreqA(value);
        AddWriteCommand(RigParameter.FreqA, value);
    }

    public override void SetFreqB(int value)
    {
        if (!Enabled || (value == FreqB))
        {
            return;
        }

        base.SetFreqB(value);
        AddWriteCommand(RigParameter.FreqB, value);
    }

    public override void SetPitch(int value)
    {
        if (!Enabled || Pitch == value)
        {
            return;
        }

        //remember the pitch that we set if we cannot read it back from the rig
        if (!_rigCommands.ReadableParams.Contains(RigParameter.Pitch))
        {
            base.SetPitch(value);
        }
        AddWriteCommand(RigParameter.Pitch, value);
    }

    public override void SetRitOffset(int value)
    {
        if (!Enabled || RitOffset == value)
        {
            return;
        }

        base.SetRitOffset(value);
        AddWriteCommand(RigParameter.RitOffset, value);
    }

    public override void SetVfo(RigParameter value)
    {
        if (!Enabled || Vfo == value ||
            !RigCommandUtilities.VfoParams.Contains(value))
        {
            return;
        }

        base.SetVfo(value);
        AddWriteCommand(value);
    }

    public override void SetRit(RigParameter value)
    {
        if (!Enabled || value == Rit ||
            !RigCommandUtilities.RitOnParams.Contains(value))
        {
            return;
        }

        base.SetRit(value);
        AddWriteCommand(value);
    }

    public override void SetXit(RigParameter value)
    {
        if (!Enabled || !RigCommandUtilities.XitOnParams.Contains(value) || value == Xit)
        {
            return;
        }

        base.SetXit(value);
        AddWriteCommand(value);
    }

    public override void SetTx(RigParameter value)
    {
        if (!Enabled || (!RigCommandUtilities.TxParams.Contains(value)))
        {
            return;
        }

        base.SetTx(value);
        AddWriteCommand(value);
    }

    public override void SetMode(RigParameter value)
    {
        if (!Enabled || !RigCommandUtilities.ModeParams.Contains(value))
        {
            return;
        }

        base.SetMode(value);
        AddWriteCommand(value);
    }

    public override void SetSplit(RigParameter value)
    {
        if (!Enabled && !RigCommandUtilities.SplitParams.Contains(value))
        {
            return;
        }

        if (_rigCommands.WriteableParams.Contains(value) && value != Split)
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

        base.SetSplit(value);
    }

    #endregion

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

    private void ConnectivityTimerCallbackFunc(object state)
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
        if (!Enabled)
        {
            return;
        }

        var connected = _rigSerialPort.IsConnected;
        if (!connected)
        {
            _logger.Debug("RIG is not connected. (Re)Connecting.");
            connected = _rigSerialPort.Connect();
        }

        if (!connected)
        {
            _logger.Error("Failed to connect to the RIG.");
            return;
        }

        if (!_queue.HasStatusCommands)
        {
            AddCommands(_rigCommands.StatusCmd, CommandKind.Status);
        }

        CheckQueue();
    }

    private void TimeoutTimerCallbackFunc(object state)
    {
        _logger.Debug("RIG: A timeout occurred.");
        _queue.Phase = ExchangePhase.Idle;
    }

    #endregion

    #region Commands

    internal void AddBeforeStatus(QueueItem commandQueueItem)
    {
        _queue.AddBeforeStatusCommands(commandQueueItem);
    }

    public void AddCommands(IEnumerable<RigCommand> commands, CommandKind kind)
    {
        var index = 0;
        foreach (var command in commands)
        {
            AddCommand(new QueueItem
            {
                Code = command.Code,
                Number = index++,
                ReplyLength = command.ReplyLength,
                ReplyEnd = ByteFunctions.BytesToStr(command.ReplyEnd),
                Kind = kind,
            });
        }
    }

    internal void AddCommand(QueueItem commandQueueItem)
    {
        _queue.Add(commandQueueItem);
    }

    public void CheckQueue()
    {
        lock (CheckQueueLockObject)
        {
            if (!Enabled
                            || !_rigSerialPort.IsConnected
                            || _queue.Phase != ExchangePhase.Idle
                            || _queue.Count == 0)
            {
                return;
            }

            //send command
            _rigSerialPort.SendMessage(_queue.CurrentCmd.Code);

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

    #endregion

    #region Start/stop

    public override void Start()
    {
        if (_rigCommands == null)
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

            AddCommands(_rigCommands.InitCmd, CommandKind.Init);
            AddCommands(_rigCommands.StatusCmd, CommandKind.Status);
        }

        EnableConnectivityTimer();
    }

    public override void Stop()
    {
        _logger.Debug($"Stopping RIG{RigNumber}");

        lock (StopLockObject)
        {
            _cancellationTokenSource.Cancel();
            _online = false;
            _rigSerialPort.Disconnect();
        }
    }

    #endregion

    protected override ILog GetLogger()
    {
        return LogManager.GetLogger("HostRig");
    }

    protected override bool IsConnected()
    {
        return _rigSerialPort?.IsConnected ?? false;
    }
}
#nullable restore