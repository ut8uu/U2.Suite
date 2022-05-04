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
using System.Globalization;
using System.Runtime.InteropServices;
using System.Linq;
using System.Reflection;
using System.Text;
using U2.MultiRig.Code;
using log4net;
using U2.Core;

namespace U2.MultiRig;

public delegate void RigParameterChangedEventHandler(object sender, int rigNumber,
    RigParameter parameter, object value);

public class Rig : CustomRig
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(Rig));
    protected readonly List<RigParameter> _changedParams = new List<RigParameter>();

    public Rig(int rigNumber, RigSettings settings, RigCommands rigCommands) 
        : base(rigNumber, settings, rigCommands)
    {
    }

    public event RigParameterChangedEventHandler RigParameterChanged;

    ////////////////////////////////////////////////////////////////////////////////
    //                           interpret reply
    ////////////////////////////////////////////////////////////////////////////////
    private bool ValidateReply(byte[] inputData, BitMask mask)
    {
        if (inputData.Length == mask.Mask.Length
            && inputData.Length == mask.Flags.Length)
        {
            var data = ByteFunctions.BytesAnd(inputData, mask.Mask);
            if (data.SequenceEqual(mask.Flags))
            {
                _logger.Debug($"RIG{RigNumber}: Validation successful.");
                return true;
            }
        }

        _logger.Error($"RIG{RigNumber} reply validation failed.");
        return false;
    }

    ////////////////////////////////////////////////////////////////////////////////
    //                          add command to queue
    ////////////////////////////////////////////////////////////////////////////////
    protected override void AddCommands(IEnumerable<RigCommand> commands, CommandKind kind)
    {
        var index = 0;
        foreach (var command in commands)
        {
            _queue.Add(new QueueItem
            {
                Code = command.Code,
                Number = index++,
                ReplyLength = command.ReplyLength,
                ReplyEnd = ByteFunctions.BytesToStr(command.ReplyEnd),
                Kind = kind,
            });
        }
    }

    protected override void ProcessInitReply(int number, byte[] data)
    {
        ValidateReply(data, RigCommands.InitCmd[number].Validation);
    }
    
    protected override void ProcessStatusReply(int number, byte[] data)
    {
        //validate reply
        var cmd = RigCommands.StatusCmd[number];

        if (!ValidateReply(data, cmd.Validation))
        {
            return;
        }

        //extract numeric values
        for (var index = 0; index <= cmd.Values.Count - 1; index++)
        {
            try
            {
                StoreParam(cmd.Values[index].Param, ConversionFunctions.UnformatValue(data, cmd.Values[index]));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        //extract bit flags
        for (var index = 0; index <= cmd.Flags.Count - 1; index++)
        {
            if (data.Length != cmd.Flags[index].Mask.Length 
                || data.Length != cmd.Flags[index].Flags.Length)
            {
                _logger.ErrorFormat("RIG{0}: incorrect reply length", RigNumber);
            }
            else if (cmd.Flags[index].Flags.SequenceEqual(ByteFunctions.BytesAnd(data, cmd.Flags[index].Mask)))
            {
                StoreParam(cmd.Flags[index].Param);
            }
        }

        //tell clients
        if (_changedParams.Any())
        {
            _udpMessenger.ComNotifyParams(RigNumber, RigCommandUtilities.ParamsToInt(_changedParams));
        }
        ReportChangedParameters(_changedParams);
        _changedParams.Clear();
    }

    private void ReportChangedParameters(IEnumerable<RigParameter> parameters)
    {
        foreach (var parameter in parameters)
        {
            object parameterValue = parameter switch
            {
                RigParameter.FreqA => _freqA,
                RigParameter.None => 0,
                RigParameter.Freq => _freq,
                RigParameter.FreqB => _freqB,
                RigParameter.Pitch => _pitch,
                RigParameter.RitOffset => _ritOffset,
                RigParameter.Rit0 => _rit,
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
                RigParameter.Rx => 1,
                RigParameter.Tx => 1,
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
    
    protected override void ProcessWriteReply(RigParameter param, byte[] data)
    {
        ValidateReply(data, RigCommands.WriteCmd[(int)param].Validation);
    }


    private static readonly object ProcessCustomReplyLockObject = new();
    protected override void ProcessCustomReply(object sender, byte[] code, byte[] data)
    {
        lock (ProcessCustomReplyLockObject)
        {
            //MissedLogic.TOmniRigX(ASender).CustCommand = ACode;
            //MissedLogic.TOmniRigX(ASender).CustReply = AData;
        }
        
        _udpMessenger.ComNotifyCustom(RigNumber, sender);
    }
    //add command to the queue
    
    public override void AddWriteCommand(RigParameter param, int value = 0)
    {
        byte[] NewCode;
        _logger.DebugFormat("RIG{0} Generating Write command for {1}", RigNumber, param);

        //is cmd supported?
        if (RigCommands == null)
        {
            return;
        }

        var cmd = RigCommands.WriteCmd[(int)param];

        if (cmd.Code == null)
        {
            _logger.ErrorFormat("RIG{0} Write command not supported for {1}", RigNumber, param);
            return;
        }

        //generate cmd
        NewCode = cmd.Code;

        if (cmd.Value.Format != ValueFormat.None)
        {
            try
            {
                var fmtValue = ConversionFunctions.FormatValue(value, cmd.Value);

                if (cmd.Value.Start + cmd.Value.Len > NewCode.Length)
                {
                    _logger.ErrorFormat($"Value {cmd.Code} exceeds expected length of {NewCode.Length} bytes.");
                    throw new Exception("Value too long");
                }
                Array.Copy(fmtValue, 0, NewCode, cmd.Value.Start, cmd.Value.Len);
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("RIG{0}: Generating command: {1}", RigNumber, e.Message);
            }
        }

        //add to queue
        var queueItem = new QueueItem
        {
            Code = NewCode,
            Param = param,
            Kind = CommandKind.Write,
            ReplyLength = cmd.ReplyLength,
            ReplyEnd = ByteFunctions.BytesToStr(cmd.ReplyEnd),
        };
        _queue.AddBeforeStatusCommands(queueItem);

        //reminder to check queue
        _udpMessenger.TxQueue(RigNumber);
        CheckQueue();
    }
    
    public override void AddCustomCommand(object sender, byte[] code, int len, string end)
    {
        if (code == null)
        {
            return;
        }

        var item = new QueueItem
        {
            Code = code,
            Kind = CommandKind.Custom,
            CustSender = sender,
            ReplyLength = len,
            ReplyEnd = end
        };

        _queue.Add(item);
        _udpMessenger.TxQueue(RigNumber);
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
    private void StoreParam(RigParameter parameter)
    {
        FieldInfo field;
        if (RigCommandUtilities.VfoParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(_vfo));
        }
        else if (RigCommandUtilities.SplitParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(_split));
        }
        else if (RigCommandUtilities.RitOnParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(_rit));
        }
        else if (RigCommandUtilities.XitOnParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(_xit));
        }
        else if (RigCommandUtilities.TxParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(_tx));
        }
        else if (RigCommandUtilities.ModeParams.Contains(parameter))
        {
            field = GetFieldInfo(nameof(_mode));
        }
        else
        {
            return;
        }

        var fieldValue = field.GetValue(this);
        if (fieldValue == null || parameter == (RigParameter)fieldValue)
        {
            return;
        }

        field.SetValue(this, parameter);

        _changedParams.Add(parameter);

        //unsolved problem:
        //there is no command to read the mode of the other VFO,
        //its change goes undetected.
        if ((RigCommandUtilities.ModeParams.Contains(parameter)) 
            && (parameter != LastWrittenMode))
        {
            LastWrittenMode = RigParameter.None;
        }

        _logger.DebugFormat("RIG{0} status changed: {1} enabled", RigNumber, parameter);
    }
    
    private void StoreParam(RigParameter param, int value)
    {
        FieldInfo field;

        switch (param)
        {
            case RigParameter.FreqA:
                field = GetFieldInfo(nameof(_freqA));
                break;

            case RigParameter.FreqB:
                field = GetFieldInfo(nameof(_freqB));
                break;

            case RigParameter.Freq:
                field = GetFieldInfo(nameof(_freq));
                break;

            case RigParameter.Pitch:
                field = GetFieldInfo(nameof(_pitch));
                break;

            case RigParameter.RitOffset:
                field = GetFieldInfo(nameof(_ritOffset));
                break;

            default:
                return;
        }

        var fieldValue = field.GetValue(this);
        if (fieldValue == null || value == (int)fieldValue)
        {
            return;
        }

        field.SetValue(this, value);
        _changedParams.Add(param);
        _logger.DebugFormat("RIG{0} status changed: {1} = {2}", RigNumber, param.ToString(), Convert.ToString(value));
    }

    protected virtual void OnRigParameterChanged(int rigNumber, RigParameter parameter, object value)
    {
        RigParameterChanged?.Invoke(this, rigNumber, parameter, value);
    }
}