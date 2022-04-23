using System;
using System.Globalization;
using System.Text;
using SoftCircuits.IniFileParser;
using U2.MultiRig.Code;

namespace U2.MultiRig;

public partial class RigCommands
{

    private void LoadInitCmd()
    {
        ValidateEntryNames(new[] { "COMMAND", "REPLYLENGTH", "REPLYEND", "VALIDATE" });

        if (_fList.Count == 0)
        {
            return;
        }

        var cmd = LoadCommon();
        _entry = "Value";

        if (cmd.Value.Format != ValueFormat.None)
        {
            Log("value is not allowed in INIT");
            return;
        }

        if (_wasError)
        {
            return;
        }

        InitCmd.Add(cmd);
    }

    private void LoadStatusCmd()
    {
        ValidateEntryNames(new[]
        {
            "COMMAND", "REPLYLENGTH", "REPLYEND", "VALIDATE",
            "VALUE1", "VALUE2", "VALUE3", "VALUE4", "VALUE5", "VALUE6",
            "FLAG1", "FLAG2", "FLAG3", "FLAG4", "FLAG5", "FLAG6",
        });

        if (_fList.Count == 0)
        {
            return;
        }

        //common fields
        var cmd = LoadCommon();
        _entry = string.Empty;

        if (cmd.ReplyLength == 0 && cmd.ReplyEnd.Length == 0)
        {
            Log("ReplyLength or ReplyEnd must be specified");
        }

        cmd.Validation.Mask = Array.Empty<byte>();
        cmd.Values.Clear();
        cmd.Flags.Clear();

        var settings = _iniFile.GetSectionSettings(_section);

        foreach (var iniSetting in settings.Where(s => !string.IsNullOrEmpty(s.Name)))
        {
            if (CanReadStatusEntryValue(cmd, iniSetting, out var value))
            {
                cmd.Values.Add(value.Value);
            }
            else if (CanReadStatusEntryFlag(cmd, iniSetting, out var flag))
            {
                cmd.Flags.Add(flag.Value);
            }
        }

        if (!cmd.Values.Any() && !cmd.Flags.Any())
        {
            Log("at least one ValueNN or FlagNN must be defined");
        }

        if (_wasError)
        {
            return;
        }

        StatusCmd.Add(cmd);
    }

    private bool CanReadStatusEntryFlag(RigCommand cmd, IniSetting iniSetting,
        out BitMask? mask)
    {
        mask = null;
        if (!iniSetting.Name.StartsWith("flag", StringComparison.CurrentCultureIgnoreCase))
        {
            return false;
        }

        _entry = $"{iniSetting.Name}={iniSetting.Value}";
        var flag = StrToMask(ReadStringFromIni(string.Empty));
        ValidateMask(flag, cmd.ReplyLength, cmd.ReplyEnd);

        return !_wasError;
    }

    private bool CanReadStatusEntryValue(RigCommand cmd, IniSetting iniSetting, out ParameterValue? result)
    {
        result = null;
        if (!iniSetting.Name.StartsWith("value", StringComparison.CurrentCultureIgnoreCase))
        {
            return false;
        }

        _entry = iniSetting.Name;
        var value = LoadValue();
        ValidateValue(value, Math.Max(cmd.ReplyLength, cmd.Validation.Mask.Length));

        if (value.Param == RigParameter.None)
        {
            Log("parameter name is missing");
        }
        else if (!(RigCmdsUnit.NumericParameters.Contains(value.Param)))
        {
            Log("parameter must be of numeric type");
        }

        result = value;

        return !_wasError;
    }

    private void LoadWriteCmd()
    {
        try
        {
            _entry = string.Empty;
            var param = StrToParam(_section);

            if (_wasError)
            {
                return;
            }

            ValidateEntryNames(new string[] { "COMMAND", "REPLYLENGTH", "REPLYEND", "VALIDATE", "VALUE" });

            if (_fList.Count == 0 || _fList.All(string.IsNullOrEmpty))
            {
                return;
            }

            var cmd = LoadCommon();
            _entry = "Value";
            cmd.Value = LoadValue();
            ValidateValue(cmd.Value, cmd.Code.Length);

            if (cmd.Value.Param != RigParameter.None)
            {
                Log("parameter name is not allowed");
            }

            if (RigCmdsUnit.NumericParameters.Contains(param) && cmd.Value.Len == 0)
            {
                Log("Value is missing");
            }

            if (!RigCmdsUnit.NumericParameters.Contains(param) && cmd.Value.Len > 0)
            {
                Log("parameter does not require a value", false);
            }

            if (!_wasError)
            {
                WriteCmd.Add(cmd);
            }
        }
        catch (Exception ex)
        {
            Log(ex.Message, false);
            throw;
        }
    }

    private void ValidateEntryNames(string[] entryNames)
    {
        var iniValues = _iniFile.GetSectionSettings(_section);
        _fList = iniValues.Select(v => $"{v.Name}={v.Value}").ToList();

        var iniNames = iniValues.Select(v => v.Name).Distinct();
        if (iniNames.Any(n => !entryNames.Contains(n, StringComparer.CurrentCultureIgnoreCase)))
        {
            Log("invalid entry name", false);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////
    //                             validation
    ////////////////////////////////////////////////////////////////////////////////
    private void ValidateMask(BitMask mask, int len, byte[] end)
    {
        if (mask.Mask.Length == 0
            && mask.Flags.Length == 0
            && (mask.Param == RigParameter.None))
        {
            return;
        }

        if (mask.Mask.Length == 0 || mask.Flags.Length == 0)
        {
            Log("incorrect mask length");
        }
        else if (mask.Mask.Length != mask.Flags.Length)
        {
            Log("incorrect mask length");
        }
        else if (len > 0 && mask.Mask.Length != len)
        {
            Log("mask length <> ReplyLength");
        }
        else if (!ByteFunctions.ByteArraysEqual(ByteFunctions.BytesAnd(mask.Flags, mask.Flags), mask.Flags))
        {
            Log("mask hides valid bits");
        }
        else if (_entry.ToUpper() == "VALIDATE")
        {
            if (mask.Param != RigParameter.None)
            {
                Log("parameter name is not allowed");
            }

            var startIndex = mask.Flags.Length - end.Length - 1;
            var ending = mask.Flags[startIndex..];

            if (!ByteFunctions.ByteArraysEqual(ending, end))
            {
                Log("mask does not end with ReplyEnd");
            }
        }
        else
        {
            if (mask.Param == RigParameter.None)
            {
                Log("parameter name is missing");
            }

            if (mask.Mask.Length == 0)
            {
                Log("mask is blank");
            }
        }
    }

    private void ValidateValue(ParameterValue value, int len)
    {
        try
        {
            if (value.Param == RigParameter.None)
            {
                return;
            }

            if (len == 0)
            {
                len = int.MaxValue;
            }

            // ISPIRER
            //with AValue do
            {
                if ((value.Start < 0) || (value.Start >= len))
                {
                    Log("invalid Start value");
                }

                if (value.Len < 0 || value.Start + value.Len > len)
                {
                    Log("invalid Length value");
                }

                if (value.Mult <= 0)
                {
                    Log("invalid Multiplier value");
                }
            }
        }
        catch (Exception e)
        {
            Log(e.Message);
            throw;
        }
    }

    private void Log(string message, bool showValue = true)
    {
        var value = string.Empty;

        if (showValue && !string.IsNullOrEmpty(_entry))
        {
            var iniSetting = _iniFile.GetSectionSettings(_section)
                .FirstOrDefault(s => s.Name.Equals(_entry, StringComparison.CurrentCultureIgnoreCase));
            if (iniSetting != null)
            {
                value = $"in '{iniSetting.Value}'";
            }
        }

        _log.Add($"[{_section}].{_entry}:  {message} {value}");
        _wasError = true;
    }

    private RigCommand LoadCommon()
    {
        try
        {
            var loadCommonResult = new RigCommand();
            Clear(loadCommonResult);

            try
            {
                _entry = "Command";
                loadCommonResult.Code = ByteFunctions.StrToBytes(ReadStringFromIni(string.Empty));
            }
            catch (Exception)
            {
                Log("invalid byte string");
            }

            if (loadCommonResult.Code.Length == 0)
            {
                Log("command code is missing");
            }

            try
            {
                _entry = "ReplyLength";
                loadCommonResult.ReplyLength = ReadIntFromIni();

                if (loadCommonResult.ReplyLength < 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Log("invalid integer");
            }

            try
            {
                _entry = "ReplyEnd";
                loadCommonResult.ReplyEnd = ByteFunctions.StrToBytes(ReadStringFromIni(string.Empty));
            }
            catch (Exception)
            {
                Log("invalid byte string");
            }

            try
            {
                _entry = "Validate";
                loadCommonResult.Validation = StrToMask(ReadStringFromIni(string.Empty));
            }
            catch (Exception)
            {
                Log("invalid mask");
            }

            ValidateMask(loadCommonResult.Validation, loadCommonResult.ReplyLength, loadCommonResult.ReplyEnd);
            return loadCommonResult;
        }
        catch (Exception ex)
        {
            Log(ex.Message, false);
            throw;
        }
    }

    private void ListSupportedParams()
    {
        ReadableParams = new List<RigParameter>();
        WriteableParams = new List<RigParameter>();

        for (var i = 0; i <= StatusCmd.Count - 1; i++)
        {
            for (var j = 0; j <= StatusCmd[i].Values.Count - 1; j++)
            {
                ReadableParams.Add(StatusCmd[i].Values[j].Param);
            }

            for (var j = 0; j <= StatusCmd[i].Flags.Count - 1; j++)
            {
                ReadableParams.Add(StatusCmd[i].Flags[j].Param);
            }
        }

        for (var p = (RigParameter)Enum.GetValues(typeof(RigParameter)).GetLowerBound(0); p <= (RigParameter)Enum.GetValues(typeof(RigParameter)).GetUpperBound(0); p++)
        {
            if (WriteCmd.Count <= (int)p)
            {
                break;
            }

            if (WriteCmd[(int)p].Code.Length > 0)
            {
                WriteableParams.Add(p);
            }
        }
    }

    private string ReadStringFromIni(string defaultValue = "")
    {
        var iniSetting = _iniFile.GetSectionSettings(_section)
            .FirstOrDefault(s => s.Name == _entry);
        if (iniSetting != null)
        {
            return iniSetting.Value ?? defaultValue;
        }

        return defaultValue;
    }

    private int ReadIntFromIni(int defaultValue = 0)
    {
        var iniSetting = _iniFile.GetSectionSettings(_section)
            .FirstOrDefault(s => s.Name == _entry);
        if (iniSetting == null)
        {
            return defaultValue;
        }
        if (int.TryParse(iniSetting.Value ?? defaultValue.ToString(), out var result))
        {
            return result;
        }

        return defaultValue;
    }

    //Value=5|5|vfBcdL|1|0[|pmXXX]
    private ParameterValue LoadValue()
    {
        try
        {
            var loadValueResult = new ParameterValue();
            var value = ReadStringFromIni(string.Empty);
            if (string.IsNullOrEmpty(value))
            {
                return loadValueResult;
            }
            _fList = value.Split(_delimiter).ToList();

            switch (_fList.Count)
            {
                case 0:
                    return loadValueResult;

                case 5:
                    break;

                case 6:
                    loadValueResult.Param = StrToParam(_fList[5]);
                    break;

                default:
                    Log("invalid syntax");
                    break;
            }

            try
            {
                loadValueResult.Start = Convert.ToInt32(_fList[0]);
            }
            catch (Exception)
            {
                Log("invalid Start value");
            }

            try
            {
                loadValueResult.Len = Convert.ToInt32(_fList[1]);
            }
            catch (Exception)
            {
                Log("invalid Length value");
            }

            loadValueResult.Format = StrToFmt(_fList[2]);

            try
            {
                loadValueResult.Mult = Convert.ToDouble(_fList[3], CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Log("invalid Multiplier value");
            }

            try
            {
                loadValueResult.Add = Convert.ToDouble(_fList[4]);
            }
            catch (Exception)
            {
                Log("invalid Add value");
            }

            return loadValueResult;
        }
        catch (Exception ex)
        {
            Log(ex.Message, false);
            throw;
        }
    }

    private ValueFormat StrToFmt(string s)
    {
        if (Enum.TryParse<ValueFormat>(s, ignoreCase: true, out var result))
        {
            return result;
        }
        else
        {
            Log("invalid format name");
        }

        return ValueFormat.None;
    }

    private RigParameter StrToParam(string s, bool showInLog = true)
    {
        if (!s.StartsWith("pm", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ParameterParseException(s);
        }
        var cutString = s.Replace("pm", string.Empty);
        if (Enum.TryParse<RigParameter>(cutString, ignoreCase: true, out var result))
        {
            return result;
        }
        else
        {
            Log("invalid format name");
        }

        return RigParameter.None;
    }

    private List<string> SplitString(string s)
    {
        return s.Split(_delimiter).ToList();
    }

    private BitMask StrToMask(string s)
    {
        var strToMaskResult = new BitMask
        {
            Param = RigParameter.None,
            Mask = Array.Empty<byte>(),
            Flags = Array.Empty<byte>()
        };

        if (s == string.Empty)
        {
            return strToMaskResult;
        }

        //extract mask
        _fList = SplitString(s);
        strToMaskResult.Mask = ByteFunctions.StrToBytes(_fList[0]);

        if (strToMaskResult.Mask == null)
        {
            throw new Exception();
        }

        switch (_fList.Count)
        {
            case 1:
                strToMaskResult.Flags = RigCmdsUnit.FlagsFromMask(strToMaskResult.Mask, _fList[0][1]);
                break;

            case 2:
                {
                    strToMaskResult.Param = StrToParam(_fList[1], false);

                    if (strToMaskResult.Param != RigParameter.None)
                    {
                        strToMaskResult.Flags = RigCmdsUnit.FlagsFromMask(strToMaskResult.Mask, _fList[0][1]);
                    }
                    else
                    {
                        strToMaskResult.Flags = ByteFunctions.StrToBytes(_fList[1]);
                    }
                }
                break;

            case 3:
                {
                    strToMaskResult.Flags = ByteFunctions.StrToBytes(_fList[1]);
                    strToMaskResult.Param = StrToParam(_fList[2]);
                }
                break;

            default:
                throw new Exception();
        }

        return strToMaskResult;
    }

    ////////////////////////////////////////////////////////////////////////////////
    //                            clear record
    ////////////////////////////////////////////////////////////////////////////////
    private void Clear(RigCommand rec)
    {
        rec.Code = Array.Empty<byte>();
        rec.Value = new ParameterValue();
        rec.ReplyLength = 0;
        rec.ReplyEnd = Array.Empty<byte>();
        Clear(rec.Validation);
        rec.Values.Clear();
        rec.Flags.Clear();
    }

    private void Clear(BitMask Rec)
    {
        Rec.Mask = Array.Empty<byte>();
        Rec.Flags = Array.Empty<byte>();
        Rec.Param = RigParameter.None;
    }
}

public static class RigCmdsUnit
{
    public static readonly RigParameter[] NumericParameters =
    {
        RigParameter.Freq,
        RigParameter.FreqA,
        RigParameter.FreqB,
        RigParameter.Pitch,
        RigParameter.RitOffset,
    };

    public static readonly RigParameter[] VfoParams =
    {
        RigParameter.VfoAA, RigParameter.VfoAB, RigParameter.VfoBA,
        RigParameter.VfoBB, RigParameter.VfoA, RigParameter.VfoB,
        RigParameter.VfoEqual, RigParameter.VfoSwap,
    };
    public static readonly RigParameter[] SplitParams = { RigParameter.SplitOn, RigParameter.SplitOff, };
    public static readonly RigParameter[] RitOnParams = { RigParameter.RitOn, RigParameter.RitOff, };
    public static readonly RigParameter[] XitOnParams = { RigParameter.XitOn, RigParameter.XitOff, };
    public static readonly RigParameter[] TxParams = { RigParameter.Rx, RigParameter.Tx, };

    public static readonly RigParameter[] ModeParams =
    {
        RigParameter.CW_U, RigParameter.CW_L, RigParameter.SSB_U, RigParameter.SSB_L,
        RigParameter.DIG_U, RigParameter.DIG_L, RigParameter.AM, RigParameter.FM,
    };
    /* TRigCommands */

    ////////////////////////////////////////////////////////////////////////////////
    //                              system
    ////////////////////////////////////////////////////////////////////////////////

    public static byte[] FlagsFromMask(byte[] mask, char char1)
    {
        var flagsFromMaskResult = mask.ToArray();

        if (char1 == '(')
        {
            for (var i = 0; i <= mask.Length - 1; i++)
            {
                if (mask[i] == '.')
                {
                    mask[i] = 0;
                    flagsFromMaskResult[i] = 0;
                }
                else
                {
                    mask[i] = 0xFF;
                }
            }
        }
        else
        {
            for (var i = 0; i <= mask.Length - 1; i++)
            {
                if (mask[i] != 0)
                {
                    mask[i] = 0xFF;
                }
            }
        }

        return flagsFromMaskResult;
    }

    public static int ParamsToInt(List<RigParameter> parameters)
    {
        int paramsToInt_result = 0;
        parameters = new List<RigParameter>();
        RigParameter Par = new RigParameter();
        paramsToInt_result = 0;

        for (Par = (RigParameter)Enum.GetValues(typeof(RigParameter)).GetLowerBound(0); Par <= (RigParameter)Enum.GetValues(typeof(RigParameter)).GetUpperBound(0); Par++)
        {
            if (parameters.Contains(Par))
            {
                paramsToInt_result = paramsToInt_result | (1 << Convert.ToInt32(Par));
            }
        }

        return paramsToInt_result;
    }

    public static int ParamToInt(RigParameter parameter)
    {
        int paramToInt_result = 0;
        paramToInt_result = 1 << Convert.ToInt32(parameter);
        return paramToInt_result;
    }

    public static RigParameter IntToParam(int value)
    {
        RigParameter intToParam_result = new RigParameter();

        for (intToParam_result = (RigParameter)Enum.GetValues(typeof(RigParameter)).GetLowerBound(0); intToParam_result <= (RigParameter)Enum.GetValues(typeof(RigParameter)).GetUpperBound(0); intToParam_result++)
        {
            if ((1 << Convert.ToInt32(intToParam_result)) == value)
            {
                return intToParam_result;
            }
        }

        intToParam_result = RigParameter.None;
        return intToParam_result;
    }
}
