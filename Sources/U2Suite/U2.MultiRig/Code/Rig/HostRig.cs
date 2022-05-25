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
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig;

#nullable disable
public sealed class HostRig : Rig
{
    private readonly List<RigParameter> _changedParams = new();

    public HostRig(int rigNumber, ushort applicationId, RigSettings settings, RigCommands rigCommands)
        : base(RigControlType.Host, rigNumber, applicationId, settings, rigCommands)
    {
    }

    public event RigParameterChangedEventHandler RigParameterChanged;

    ////////////////////////////////////////////////////////////////////////////////
    //                           interpret reply
    ////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Validates a reply using the given Flags
    /// </summary>
    /// <param name="inputData"></param>
    /// <param name="mask"></param>
    /// <exception cref="ValueValidationException"></exception>
    internal void ValidateReply(byte[] inputData, BitMask mask)
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

    ////////////////////////////////////////////////////////////////////////////////
    //                          add command to queue
    ////////////////////////////////////////////////////////////////////////////////
    internal override void AddCommands(IEnumerable<RigCommand> commands, CommandKind kind)
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initCommandIndex"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <exception cref="ValueValidationException">Is thrown when input data do not match the validation Flags</exception>
    internal override void ProcessInitReply(int initCommandIndex, byte[] data)
    {
        ValidateReply(data, RigCommands.InitCmd[initCommandIndex].Validation);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="statusCommandIndex"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <exception cref="ValueValidationException">Is thrown when input data do not match the validation Flags</exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    internal override bool ProcessStatusReply(int statusCommandIndex, byte[] data)
    {
        //validate reply
        var cmd = RigCommands.StatusCmd[statusCommandIndex];

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

    internal override void ProcessWriteReply(RigParameter param, byte[] data)
    {
        ValidateReply(data, RigCommands.WriteCmd[(int)param].Validation);
    }

    internal override void AddWriteCommand(RigParameter param, int value = 0)
    {
        Logger.DebugFormat("RIG{0} Generating Write command for {1}", RigNumber, param);

        //is cmd supported?
        if (RigCommands == null)
        {
            return;
        }

        var cmd = RigCommands.WriteCmd[(int)param];

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

    private static FieldInfo GetFieldInfo(string name)
    {
        var result = typeof(Rig).GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
        Debug.Assert(result != null, $"Field {name} not found in Rig.");
        return result;
    }

    ////////////////////////////////////////////////////////////////////////////////
    //                         store extracted param
    ////////////////////////////////////////////////////////////////////////////////
    private bool StoreParam(RigParameter parameter)
    {
        FieldInfo field;
        if (RigCommandUtilities.VfoParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(Vfo));
        }
        else if (RigCommandUtilities.SplitParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(Split));
        }
        else if (RigCommandUtilities.RitOnParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(Rit));
        }
        else if (RigCommandUtilities.XitOnParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(Xit));
        }
        else if (RigCommandUtilities.TxParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(Tx));
        }
        else if (RigCommandUtilities.ModeParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(Mode));
        }
        else
        {
            return false;
        }

        var fieldValue = field.GetValue(this);
        if (fieldValue == null || parameter == (RigParameter)fieldValue)
        {
            return false;
        }

        field.SetValue(this, parameter);

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
        FieldInfo field;

        switch (parameter)
        {
            case RigParameter.FreqA:
                field = GetFieldInfo(nameof(FreqA));
                break;

            case RigParameter.FreqB:
                field = GetFieldInfo(nameof(FreqB));
                break;

            case RigParameter.Freq:
                field = GetFieldInfo(nameof(Freq));
                break;

            case RigParameter.Pitch:
                field = GetFieldInfo(nameof(Pitch));
                break;

            case RigParameter.RitOffset:
                field = GetFieldInfo(nameof(RitOffset));
                break;

            default:
                throw new ArgumentOutOfRangeException($"Parameter {parameter} not supported.");
        }

        var fieldValue = field.GetValue(this);
        if (fieldValue == null || parameterValue == (int)fieldValue)
        {
            return;
        }

        field.SetValue(this, parameterValue);
        _changedParams.Add(parameter);
        Logger.DebugFormat("RIG{0} status changed: {1} = {2}", RigNumber, parameter.ToString(), Convert.ToString(parameterValue));
        var packet = UdpPacketFactory.CreateSingleParameterReportingPacket(RigNumber,
            senderId: ApplicationId, receiverId: KnownIdentifiers.MultiCast,
            parameter, parameterValue);
        UdpMessenger.SendMultiCastMessage(packet);
    }

    private void OnRigParameterChanged(int rigNumber, RigParameter parameter, object value)
    {
        RigParameterChanged?.Invoke(this, rigNumber, parameter, value);
    }

    #region Setter overloads

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

        base.SetFreq(value);
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
        if (!RigCommands.ReadableParams.Contains(RigParameter.Pitch))
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

        base.SetRit(value);
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

    #endregion
}
#nullable restore