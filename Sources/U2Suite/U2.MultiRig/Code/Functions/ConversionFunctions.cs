using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.MultiRig.Code;

namespace U2.MultiRig;

internal static class ConversionFunctions
{
    internal static readonly char[] Delimiter = { '|' };

    /// <summary>
    /// Reads mask from the string.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /// <exception cref="MaskParseException"></exception>
    /// Flag1 =  (V..RF...........ST........AU..MD0...)|pmFM
    /// Flag1 =13.00.00.00.00.00.00.00|00.00.00.00.00.00.00.00|pmVfoAA
    /// Validation=FEFEE05EFBFD
    /// Validation=FFFFFFFF.FF.0000000000.FF|FEFEE05E.03.0000000000.FD
    public static BitMask StrToMask(string s)
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

        var list = SplitString(s);
        strToMaskResult.Mask = ByteFunctions.StrToBytes(list[0]);

        switch (list.Count)
        {
            case 1:
                strToMaskResult.Flags = RigCmdsUnit.FlagsFromMask(strToMaskResult.Mask, list[0][1]);
                break;

            case 2:
                {
                    strToMaskResult.Param = StrToParam(list[1], false);

                    if (strToMaskResult.Param != RigParameter.None)
                    {
                        strToMaskResult.Flags = RigCmdsUnit.FlagsFromMask(strToMaskResult.Mask, list[0][1]);
                    }
                    else
                    {
                        strToMaskResult.Flags = ByteFunctions.StrToBytes(list[1]);
                    }
                }
                break;

            case 3:
                {
                    strToMaskResult.Flags = ByteFunctions.StrToBytes(list[1]);
                    strToMaskResult.Param = StrToParam(list[2]);
                }
                break;

            default:
                throw new MaskParseException(s);
        }

        return strToMaskResult;
    }

    internal static ValueFormat StrToFmt(string s)
    {
        if (!s.StartsWith("vf", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new FormatParseException(s);
        }
        var cutString = s.Replace("vf", string.Empty);
        if (Enum.TryParse<ValueFormat>(cutString, ignoreCase: true, out var result))
        {
            return result;
        }

        throw new FormatParseException(s);
    }

    /// <summary>
    /// Converts a string to a parameter
    /// </summary>
    /// <param name="s">A string to be converted</param>
    /// <param name="showInLog"></param>
    /// <returns></returns>
    /// <exception cref="ParameterParseException"></exception>
    internal static RigParameter StrToParam(string s, bool showInLog = true)
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

        throw new ParameterParseException(s);
    }

    public static List<string> SplitString(string s)
    {
        return s.Split(Delimiter).ToList();
    }
}