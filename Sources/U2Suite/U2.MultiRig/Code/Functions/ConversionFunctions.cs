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
    /// <param name="inputString"></param>
    /// <returns></returns>
    /// <exception cref="MaskParseException"></exception>
    /// Flag1 =  (V..RF...........ST........AU..MD0...)|pmFM
    /// Flag1 =13.00.00.00.00.00.00.00|00.00.00.00.00.00.00.00|pmVfoAA
    /// Validation=FEFEE05EFBFD
    /// Validation=FFFFFFFF.FF.0000000000.FF|FEFEE05E.03.0000000000.FD
    public static BitMask StrToBitMask(string s)
    {
        var inputString = s.Trim();
        var result = new BitMask
        {
            Param = RigParameter.None,
            Mask = Array.Empty<byte>(),
            Flags = Array.Empty<byte>()
        };

        if (inputString == string.Empty)
        {
            return result;
        }

        var list = SplitString(inputString);
        result.Mask = ByteFunctions.StrToBytes(list[0]);

        switch (list.Count)
        {
            case 1:
                result.Flags = FlagsFromBitMask(result.Mask, list[0][1]);
                break;

            case 2:
                {
                    result.Param = StrToRigParameter(list[1], false);

                    if (result.Param != RigParameter.None)
                    {
                        result.Flags = FlagsFromBitMask(result.Mask, list[0][1]);
                    }
                    else
                    {
                        result.Flags = result.Mask;
                    }
                }
                break;

            case 3:
                {
                    result.Flags = ByteFunctions.StrToBytes(list[1]);
                    result.Param = StrToRigParameter(list[2]);
                }
                break;

            default:
                throw new MaskParseException(inputString);
        }

        return result;
    }

    internal static ValueFormat StrToValueFormat(string s)
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
    internal static RigParameter StrToRigParameter(string s, bool showInLog = true)
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

    internal static List<string> SplitString(string s)
    {
        return s.Split(Delimiter).ToList();
    }

    internal static byte[] FlagsFromBitMask(byte[] mask, char char1)
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
}