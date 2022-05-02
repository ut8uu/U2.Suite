﻿using System;
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

public class Rig : CustomRig
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(Rig));
    protected readonly List<RigParameter> _changedParams = new List<RigParameter>();

    private byte[] FormatValue(int inputValue, ParameterValue info)
    {
        var value = Convert.ToInt32(Math.Round(Convert.ToDouble(inputValue * info.Mult + info.Add), MidpointRounding.AwayFromZero));
        var formatValueResult = new byte[info.Len];
        Array.Resize(ref formatValueResult, info.Len);

        if (new[] { ValueFormat.BcdLU, ValueFormat.BcdBU }.Contains(info.Format)
            && value < 0)
        {
            //MainForm.Log("RIG{0}: {!}user passed invalid value: {1}", new string[] { RigNumber, Convert.ToString(AValue) });
            return formatValueResult;
        }

        switch (info.Format)
        {
            case ValueFormat.Text:
                ToText(formatValueResult, value);
                break;

            case ValueFormat.BinL:
                ToBinL(formatValueResult, value);
                break;

            case ValueFormat.BinB:
                ToBinB(formatValueResult, value);
                break;

            case ValueFormat.BcdLU:
                ToBcdLU(formatValueResult, value);
                break;

            case ValueFormat.BcdLS:
                ToBcdLS(formatValueResult, value);
                break;

            case ValueFormat.BcdBU:
                ToBcdBU(formatValueResult, value);
                break;

            case ValueFormat.BcdBS:
                ToBcdBS(formatValueResult, value);
                break;

            case ValueFormat.Yaesu:
                ToYaesu(formatValueResult, value);
                break;

            case ValueFormat.DPIcom:
                ToDPIcom(formatValueResult, value);
                break;

            case ValueFormat.TextUD:
                ToTextUD(formatValueResult, value);
                break;

            case ValueFormat.Float:
                ToFloat(formatValueResult, value);
                break;
            case ValueFormat.None:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return formatValueResult;
    }

    public Rig(int rigNumber, RigSettings settings, RigCommands rigCommands) 
        : base(rigNumber, settings, rigCommands)
    {

    }

    //ASCII codes of digits
    private static void ToText(byte[] arr, int value)
    {
        var len = arr.Length;

        if (value < 0)
        {
            len--;
        }

        var s = value.ToString().PadLeft(len, '0');
        var bytes = Encoding.UTF8.GetBytes(s);
        bytes.CopyTo(arr, 0);
    }

    //BCD big endian signed
    // ReSharper disable once InconsistentNaming
    private static void ToBcdBS(byte[] arr, int value)
    {
        ToBcdBU(arr, Math.Abs(value));

        if (value < 0)
        {
            arr[0] = 0xFF;
        }
    }

    //BCD big endian unsigned
    // ReSharper disable once InconsistentNaming
    private static void ToBcdBU(byte[] arr, int value)
    {
        var chars = new byte[arr.Length];
        ToText(chars, value);

        for (var i = 0; i <= arr.Length - 1; i++)
        {
            var char1 = (byte)((chars[i * 2] - 0x30) << 4);
            var char2 = (byte)(chars[i * 2 + 1] - 0x30);
            arr[i] = (byte)(char1 | char2);
        }
    }

    //BCD little endian signed; sign in high byte (00 or FF)
    // ReSharper disable once InconsistentNaming
    private static void ToBcdLS(byte[] arr, int value)
    {
        ToBcdLU(arr, Math.Abs(value));

        if (value < 0)
        {
            arr[^1] = 0xFF;
        }
    }

    //BCD little endian unsigned
    // ReSharper disable once InconsistentNaming
    private static void ToBcdLU(byte[] arr, int value)
    {
        ToBcdBU(arr, value);
        Array.Reverse(arr);
    }

    //integer, big endian
    private static void ToBinB(byte[] arr, int value)
    {
        ToBinL(arr, value);
        Array.Reverse(arr);
    }

    //integer, little endian
    private static void ToBinL(byte[] arr, int value)
    {
        var bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        bytes.CopyTo(arr, 0);
    }

    private static void ToDPIcom(byte[] arr, int value)
    {
        var f = value / 1000000;
        var s = Convert.ToString(f).PadLeft(arr.Length, '0');
        var bytes = Encoding.UTF8.GetBytes(s);
        bytes.CopyTo(arr, 0);
    }

    //16 bits. high bit of the 1-st byte is sign,
    //the rest is integer, absolute value, big endian (not complementary!)
    private static void ToYaesu(byte[] arr, int value)
    {
        ToBinB(arr, Math.Abs(value));

        if (value < 0)
        {
            arr[0] = (byte)(arr[0] | 0x80);
        }
    }
    //bytes to value

    ////////////////////////////////////////////////////////////////////////////////
    //                                unformat
    ////////////////////////////////////////////////////////////////////////////////
    private int UnformatValue(byte[] sourceData, ParameterValue info)
    {
        if (sourceData.Length < info.Start + info.Len)
        {
            _logger.Error($"RIG{RigNumber}: reply too short");
            throw new AbortException();
        }

        var data = new byte[info.Len];
        sourceData.CopyTo(data, info.Start);

        return info.Format switch
        {
            ValueFormat.Text => FromText(data),
            ValueFormat.BinL => FromBinL(data),
            ValueFormat.BinB => FromBinB(data),
            ValueFormat.BcdLU => FromBcdLU(data),
            ValueFormat.BcdLS => FromBcdLS(data),
            ValueFormat.BcdBU => FromBcdBU(data),
            ValueFormat.BcdBS => FromBcdBS(data),
            ValueFormat.DPIcom => FromDPIcom(data),
            ValueFormat.Float => FromFloat(data),
            ValueFormat.Yaesu => FromYaesu(data),
            ValueFormat.None => 0,
            ValueFormat.TextUD => 0,
            _ => throw new ArgumentOutOfRangeException($"Format {info.Format} not recognized.")
        };
    }

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
                return true;
            }
        }

        _logger.Error($"RIG{RigNumber} reply validation failed.");
        return false;
    }

    // ReSharper disable once InconsistentNaming
    private static void ToTextUD(byte[] arr, int value)
    {
        var prefix = (value >= 0) ? "U" : "D";
        var s = prefix + Convert.ToString(Math.Abs(value))
            .PadLeft(arr.Length - 1, '0');

        var bytes = Encoding.UTF8.GetBytes(s);
        bytes.CopyTo(arr, 0);
    }
    
    private static void ToFloat(byte[] arr, int value)
    {
        var s = value.ToString("F", CultureInfo.InvariantCulture).PadLeft(arr.Length, ' ');
        var bytes = Encoding.UTF8.GetBytes(s);
        bytes.CopyTo(arr, 0);
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
                StoreParam(cmd.Values[index].Param, UnformatValue(data, cmd.Values[index]));
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
        _changedParams.Clear();
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
                var fmtValue = FormatValue(value, cmd.Value);

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

    private int FromBcdBS(byte[] AData)
    {
        int sign = 0;

        if (AData[0] == 0)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }

        AData[0] = 0;
        return sign * FromBcdBU(AData);
    }
    
    private int FromBcdBU(byte[] data)
    {
        var s = "".PadLeft(data.Length*2, ' ');

        for (var i = 0; i <= data.Length - 1; i++)
        {
            s = s.Remove(i * 2, 1).Insert(i * 2, ((byte)'0' + ((data[i] >> 4) & 0x0F)).ToString());
            s = s.Remove(i * 2 + 1, 1).Insert(i * 2 + 1, ((byte)'0' + (data[i] & 0x0F)).ToString());
        }

        try
        {
            return Convert.ToInt32(s);
        }
        catch (Exception)
        {
            _logger.ErrorFormat("RIG{0}: invalid BCD value: {1}", RigNumber, data);
            throw;
        }
    }

    private int FromBcdLS(byte[] data)
    {
        Array.Reverse(data);
        return FromBcdBS(data);
    }

    private int FromBcdLU(byte[] data)
    {
        Array.Reverse(data);
        return FromBcdBU(data);
    }

    private int FromBinB(byte[] data)
    {
        Array.Reverse(data);
        return FromBinL(data);
    }
    
    private int FromBinL(byte[] data)
    {
        return Convert.ToInt32(data);
    }

    private int FromText(byte[] data)
    {
        try
        {
            var s = Encoding.UTF8.GetString(data);
            return Convert.ToInt32(s);
        }
        catch (Exception)
        {
            _logger.ErrorFormat("RIG{0}: invalid reply", RigNumber);
            throw;
        }
    }

    private int FromDPIcom(byte[] data)
    {
        try
        {
            var s = Encoding.UTF8.GetString(data);
            s = RegularExpressionHelper.MatchAndGetFirst("([\\d+\\.*\\d*])", s);
            return Convert.ToInt32(Math.Round(Convert.ToDouble(1E6 * Convert.ToDouble(s.Trim())), MidpointRounding.AwayFromZero));
        }
        catch (Exception)
        {
            _logger.ErrorFormat("RIG{0}: invalid reply", RigNumber);
            throw;
        }
    }
    
    //16 bits. high bit of the 1-st byte is sign,
    //the rest is integer, absolute value, big endian (not complementary!)
    private int FromYaesu(byte[] data)
    {
        var sign = -1;

        if ((data[0] & 0x80) == 0)
        {
            sign = 1;
        }

        data[0] = (byte)(data[0] & 0x7F);
        return sign * FromBinB(data);
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
    
    private int FromFloat(byte[] data)
    {
        try
        {
            var s = Encoding.UTF8.GetString(data);
            var value = Convert.ToDouble(s.Trim(), CultureInfo.InvariantCulture);
            return Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
        }
        catch (Exception)
        {
            _logger.ErrorFormat("RIG{0}: invalid reply", RigNumber);
            throw;
        }
    }
}