using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData;
using log4net;
using SoftCircuits.IniFileParser;
using static System.Collections.Specialized.BitVector32;
using U2.MultiRig;
using U2.MultiRig.Code;

namespace U2.MultiRig;

public partial class RigCommands
{

    private void LoadInitCmd()
    {
        ValidateEntryNames(new[] { "COMMAND", "REPLYLENGTH", "REPLYEND", "VALIDATE" });

        if (FList.Count == 0)
        {
            return;
        }

        var cmd = LoadCommon();
        FEntry = "Value";

        if (cmd.Value.Format != TValueFormat.vfNone)
        {
            Log("value is not allowed in INIT");
            return;
        }

        if (WasError)
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

        if (FList.Count == 0)
        {
            return;
        }

        //common fields
        var cmd = LoadCommon();
        FEntry = string.Empty;

        if (cmd.ReplyLength == 0 && cmd.ReplyEnd.Length == 0)
        {
            Log("ReplyLength or ReplyEnd must be specified");
        }

        cmd.Validation.Mask = Array.Empty<byte>();
        cmd.Values.Clear();
        cmd.Flags.Clear();

        var settings = FIni.GetSectionSettings(FSection);

        foreach (var iniSetting in settings)
        {
            if (string.IsNullOrEmpty(iniSetting.Name))
            {
                continue;
            }

            if (iniSetting.Name.StartsWith("value", StringComparison.CurrentCultureIgnoreCase))
            {
                FEntry = iniSetting.Name;
                var value = LoadValue();
                ValidateValue(value, Math.Max(cmd.ReplyLength, cmd.Validation.Mask.Length));

                if (value.Param == TRigParam.pmNone)
                {
                    Log("parameter name is missing");
                }
                else if (!(RigCmdsUnit.NumericParams.Contains(value.Param)))
                {
                    Log("parameter must be of numeric type");
                }

                cmd.Values.Add(value);
            }
            else if (iniSetting.Name.StartsWith("flag", StringComparison.CurrentCultureIgnoreCase))
            {
                FEntry = $"{iniSetting.Name}={iniSetting.Value}";
                var flag = StrToMask(ReadStringFromIni(string.Empty));
                ValidateMask(flag, cmd.ReplyLength, cmd.ReplyEnd);
                cmd.Flags.Add(flag);
            }
        }

        if (!cmd.Values.Any() && !cmd.Flags.Any())
        {
            Log("at least one ValueNN or FlagNN must be defined");
        }

        if (WasError)
        {
            return;
        }

        StatusCmd.Add(cmd);
    }

    private void LoadWriteCmd()
    {
        try
        {
            FEntry = string.Empty;
            var param = StrToParam(FSection);

            if (WasError)
            {
                return;
            }

            ValidateEntryNames(new string[] { "COMMAND", "REPLYLENGTH", "REPLYEND", "VALIDATE", "VALUE" });

            if (FList.Count == 0 || FList.All(string.IsNullOrEmpty))
            {
                return;
            }

            var cmd = LoadCommon();
            FEntry = "Value";
            cmd.Value = LoadValue();
            ValidateValue(cmd.Value, cmd.Code.Length);

            if (cmd.Value.Param != TRigParam.pmNone)
            {
                Log("parameter name is not allowed");
            }

            if (RigCmdsUnit.NumericParams.Contains(param) && cmd.Value.Len == 0)
            {
                Log("Value is missing");
            }

            if (!RigCmdsUnit.NumericParams.Contains(param) && cmd.Value.Len > 0)
            {
                Log("parameter does not require a value", false);
            }

            if (!WasError)
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
        var iniValues = FIni.GetSectionSettings(FSection);
        FList = iniValues.Select(v => $"{v.Name}={v.Value}").ToList();

        var iniNames = iniValues.Select(v => v.Name).Distinct();
        if (iniNames.Any(n => !entryNames.Contains(n, StringComparer.CurrentCultureIgnoreCase)))
        {
            Log("invalid entry name", false);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////
    //                             validation
    ////////////////////////////////////////////////////////////////////////////////
    private void ValidateMask(TBitMask mask, int len, byte[] end)
    {
        if (mask.Mask.Length == 0 
            && mask.Flags.Length == 0 
            && (mask.Param == TRigParam.pmNone))
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
        else if (FEntry.ToUpper() == "VALIDATE")
        {
            if (mask.Param != TRigParam.pmNone)
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
            if (mask.Param == TRigParam.pmNone)
            {
                Log("parameter name is missing");
            }

            if (mask.Mask.Length == 0)
            {
                Log("mask is blank");
            }
        }
    }

    private void ValidateValue(TParamValue value, int len)
    {
        try
        {
            if (value.Param == TRigParam.pmNone)
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

        if (showValue && !string.IsNullOrEmpty(FEntry))
        {
            var iniSetting = FIni.GetSectionSettings(FSection)
                .FirstOrDefault(s => s.Name.Equals(FEntry, StringComparison.CurrentCultureIgnoreCase));
            if (iniSetting != null)
            {
                value = $"in '{iniSetting.Value}'";
            }
        }

        FLog.Add($"[{FSection}].{FEntry}:  {message} {value}");
        WasError = true;
    }

    private RigCommand LoadCommon()
    {
        try
        {
            var loadCommonResult = new RigCommand();
            Clear(loadCommonResult);

            try
            {
                FEntry = "Command";
                loadCommonResult.Code = StrToBytes(ReadStringFromIni(string.Empty));
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
                FEntry = "ReplyLength";
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
                FEntry = "ReplyEnd";
                loadCommonResult.ReplyEnd = Encoding.UTF8.GetBytes(ReadStringFromIni(string.Empty));
            }
            catch (Exception)
            {
                Log("invalid byte string");
            }

            try
            {
                FEntry = "Validate";
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
        ReadableParams = new List<TRigParam>();
        WriteableParams = new List<TRigParam>();

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

        for (var p = (TRigParam)Enum.GetValues(typeof(TRigParam)).GetLowerBound(0); p <= (TRigParam)Enum.GetValues(typeof(TRigParam)).GetUpperBound(0); p++)
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
        var iniSetting = FIni.GetSectionSettings(FSection)
            .FirstOrDefault(s => s.Name == FEntry);
        if (iniSetting != null)
        {
            return iniSetting.Value ?? defaultValue;
        }

        return defaultValue;
    }

    private int ReadIntFromIni(int defaultValue = 0)
    {
        var iniSetting = FIni.GetSectionSettings(FSection)
            .FirstOrDefault(s => s.Name == FEntry);
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
    private TParamValue LoadValue()
    {
        try
        {
            var loadValueResult = new TParamValue();
            var value = ReadStringFromIni(string.Empty);
            if (string.IsNullOrEmpty(value))
            {
                return loadValueResult;
            }
            FList = value.Split(FDelimiter).ToList();

            switch (FList.Count)
            {
                case 0:
                    return loadValueResult;

                case 5:
                    break;

                case 6:
                    loadValueResult.Param = StrToParam(FList[5]);
                    break;

                default:
                    Log("invalid syntax");
                    break;
            }

            try
            {
                loadValueResult.Start = Convert.ToInt32(FList[0]);
            }
            catch (Exception)
            {
                Log("invalid Start value");
            }

            try
            {
                loadValueResult.Len = Convert.ToInt32(FList[1]);
            }
            catch (Exception)
            {
                Log("invalid Length value");
            }

            loadValueResult.Format = StrToFmt(FList[2]);

            try
            {
                loadValueResult.Mult = Convert.ToDouble(FList[3], CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Log("invalid Multiplier value");
            }

            try
            {
                loadValueResult.Add = Convert.ToDouble(FList[4]);
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

    private TValueFormat StrToFmt(string s)
    {
        if (Enum.TryParse<TValueFormat>(s, ignoreCase: true, out var result))
        {
            return result;
        }
        else
        {
            Log("invalid format name");
        }

        return TValueFormat.vfNone;
    }

    private TRigParam StrToParam(string S, bool showInLog = true)
    {
        if (Enum.TryParse<TRigParam>(S, ignoreCase: true, out var result))
        {
            return result;
        }
        else
        {
            Log("invalid format name");
        }

        return TRigParam.pmNone;
    }

    private byte[] StrToBytes(string s)
    {
        return Encoding.UTF8.GetBytes(s);
    }

    private List<string> SplitString(string s)
    {
        return s.Split(FDelimiter).ToList();
    }

    private TBitMask StrToMask(string s)
    {
        var strToMaskResult = new TBitMask
        {
            Param = TRigParam.pmNone,
            Mask = Array.Empty<byte>(),
            Flags = Array.Empty<byte>()
        };

        if (s == string.Empty)
        {
            return strToMaskResult;
        }

        //extract mask
        FList = SplitString(s);
        strToMaskResult.Mask = StrToBytes(FList[0]);

        if (strToMaskResult.Mask == null)
        {
            throw new Exception();
        }

        switch (FList.Count)
        {
            case 1:
                strToMaskResult.Flags = RigCmdsUnit.FlagsFromMask(strToMaskResult.Mask, FList[0][1]);
                break;

            case 2:
                {
                    strToMaskResult.Param = StrToParam(FList[1], false);

                    if (strToMaskResult.Param != TRigParam.pmNone)
                    {
                        strToMaskResult.Flags = RigCmdsUnit.FlagsFromMask(strToMaskResult.Mask, FList[0][1]);
                    }
                    else
                    {
                        strToMaskResult.Flags = StrToBytes(FList[1]);
                    }
                }
                break;

            case 3:
                {
                    strToMaskResult.Flags = StrToBytes(FList[1]);
                    strToMaskResult.Param = StrToParam(FList[2]);
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
        rec.Value = new TParamValue();
        rec.ReplyLength = 0;
        rec.ReplyEnd = Array.Empty<byte>();
        Clear(rec.Validation);
        rec.Values.Clear();
        rec.Flags.Clear();
    }

    private void Clear(TBitMask Rec)
    {
        Rec.Mask = Array.Empty<byte>();
        Rec.Flags = Array.Empty<byte>();
        Rec.Param = TRigParam.pmNone;
    }

}

public static class RigCmdsUnit
{
    public static readonly TRigParam[] NumericParams =
    {
        TRigParam.pmFreq,
        TRigParam.pmFreqA,
        TRigParam.pmFreqB,
        TRigParam.pmPitch,
        TRigParam.pmRitOffset
    };

    public static readonly TRigParam[] VfoParams =
    {
        TRigParam.pmVfoAA, TRigParam.pmVfoAB, TRigParam.pmVfoBA,
        TRigParam.pmVfoBB, TRigParam.pmVfoA, TRigParam.pmVfoB,
        TRigParam.pmVfoEqual, TRigParam.pmVfoSwap
    };
    public static readonly TRigParam[] SplitParams = { TRigParam.pmSplitOn, TRigParam.pmSplitOff };
    public static readonly TRigParam[] RitOnParams = { TRigParam.pmRitOn, TRigParam.pmRitOff };
    public static readonly TRigParam[] XitOnParams = { TRigParam.pmXitOn, TRigParam.pmXitOff };
    public static readonly TRigParam[] TxParams = { TRigParam.pmRx, TRigParam.pmTx };

    public static readonly TRigParam[] ModeParams =
    {
        TRigParam.pmCW_U, TRigParam.pmCW_L, TRigParam.pmSSB_U, TRigParam.pmSSB_L,
        TRigParam.pmDIG_U, TRigParam.pmDIG_L, TRigParam.pmAM, TRigParam.pmFM
    };
    /* TRigCommands */

    ////////////////////////////////////////////////////////////////////////////////
    //                              system
    ////////////////////////////////////////////////////////////////////////////////

    public static byte[] FlagsFromMask(byte[] mask, char Char1)
    {
        var flagsFromMaskResult = mask.ToArray();

        if (Char1 == '(')
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

    public static int ParamsToInt(List<TRigParam> Params)
    {
        int paramsToInt_result = 0;
        Params = new List<TRigParam>();
        TRigParam Par = new TRigParam();
        paramsToInt_result = 0;

        for (Par = (TRigParam)Enum.GetValues(typeof(TRigParam)).GetLowerBound(0); Par <= (TRigParam)Enum.GetValues(typeof(TRigParam)).GetUpperBound(0); Par++)
        {
            if (Params.Contains(Par))
            {
                paramsToInt_result = paramsToInt_result | (1 << Convert.ToInt32(Par));
            }
        }

        return paramsToInt_result;
    }

    public static int ParamToInt(TRigParam Param)
    {
        int paramToInt_result = 0;
        paramToInt_result = 1 << Convert.ToInt32(Param);
        return paramToInt_result;
    }

    public static TRigParam IntToParam(int Int)
    {
        TRigParam intToParam_result = new TRigParam();

        for (intToParam_result = (TRigParam)Enum.GetValues(typeof(TRigParam)).GetLowerBound(0); intToParam_result <= (TRigParam)Enum.GetValues(typeof(TRigParam)).GetUpperBound(0); intToParam_result++)
        {
            if ((1 << Convert.ToInt32(intToParam_result)) == Int)
            {
                return intToParam_result;
            }
        }

        intToParam_result = TRigParam.pmNone;
        return intToParam_result;
    }
}
