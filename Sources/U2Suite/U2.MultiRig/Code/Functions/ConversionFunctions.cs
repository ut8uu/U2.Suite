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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using U2.Core;
using U2.MultiRig.Code;

namespace U2.MultiRig;

internal static class ConversionFunctions
{
    internal static readonly char[] Delimiter = { '|' };

    private static ILog ClassLog => LogManager.GetLogger(typeof(ConversionFunctions));

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

    public static int FromBcdBS(byte[] data)
    {
        int sign = 0;

        if (data[0] == 0)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }

        data[0] = 0;
        return sign * FromBcdBU(data);
    }

    public static int FromBcdBU(byte[] data)
    {
        var sb = new StringBuilder();
        for (var i = 0; i <= data.Length - 1; i++)
        {
            sb.Append((char)('0' + data[i] / 16));
            sb.Append((char)('0' + data[i] % 16));
        }

        try
        {
            return Convert.ToInt32(sb.ToString());
        }
        catch (Exception ex)
        {
            ClassLog.ErrorFormat("invalid BCD value: {0}. {1}", 
                ByteFunctions.BytesToHex(data), ex.Message);
            throw;
        }
    }

    public static int FromBcdLS(byte[] data)
    {
        Array.Reverse(data);
        return FromBcdBS(data);
    }

    public static int FromBcdLU(byte[] data)
    {
        Array.Reverse(data);
        return FromBcdBU(data);
    }

    public static int FromBinB(byte[] data)
    {
        Array.Reverse(data);
        return FromBinL(data);
    }

    public static int FromBinL(byte[] data)
    {
        return Convert.ToInt32(data);
    }

    public static int FromText(byte[] data)
    {
        try
        {
            var s = Encoding.UTF8.GetString(data);
            return Convert.ToInt32(s);
        }
        catch (Exception)
        {
            ClassLog.ErrorFormat("Invalid reply: {0}", ByteFunctions.BytesToHex(data));
            throw;
        }
    }

    public static int FromDPIcom(byte[] data)
    {
        try
        {
            var s = Encoding.UTF8.GetString(data);
            s = RegularExpressionHelper.MatchAndGetFirst("([\\d+\\.*\\d*])", s);
            return Convert.ToInt32(Math.Round(Convert.ToDouble(1E6 * Convert.ToDouble(s.Trim())), MidpointRounding.AwayFromZero));
        }
        catch (Exception)
        {
            ClassLog.ErrorFormat("Invalid DPIcom reply: {0}", ByteFunctions.BytesToHex(data));
            throw;
        }
    }

    //16 bits. high bit of the 1-st byte is sign,
    //the rest is integer, absolute value, big endian (not complementary!)
    public static int FromYaesu(byte[] data)
    {
        var sign = -1;

        if ((data[0] & 0x80) == 0)
        {
            sign = 1;
        }

        data[0] = (byte)(data[0] & 0x7F);
        return sign * FromBinB(data);
    }

    public static int FromFloat(byte[] data)
    {
        try
        {
            var s = Encoding.UTF8.GetString(data);
            var value = Convert.ToDouble(s.Trim(), CultureInfo.InvariantCulture);
            return Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
        }
        catch (Exception)
        {
            ClassLog.ErrorFormat("Invalid reply: {0}", ByteFunctions.BytesToHex(data));
            throw;
        }
    }

    //bytes to value

    ////////////////////////////////////////////////////////////////////////////////
    //                                unformat
    ////////////////////////////////////////////////////////////////////////////////
    public static int UnformatValue(byte[] sourceData, ParameterValue info)
    {
        if (sourceData.Length < info.Start + info.Len)
        {
            ClassLog.Error($"Reply too short.");
            throw new AbortException();
        }

        var data = sourceData.Skip(info.Start).Take(info.Len).ToArray();

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

    public static byte[] FormatValue(int inputValue, ParameterValue info)
    {
        var value = Convert.ToInt32(Math.Round(Convert.ToDouble(inputValue * info.Mult + info.Add), MidpointRounding.AwayFromZero));

        if (info.Format is ValueFormat.BcdLU or ValueFormat.BcdBU
            && value < 0)
        {
            ClassLog.ErrorFormat($"Passed invalid value: {inputValue}. Expected to be a BCD kind.");
            return Array.Empty<byte>();
        }

        return info.Format switch
        {
            ValueFormat.Text => ToText(value, info.Len),
            ValueFormat.BinL => ToBinL(value, info.Len),
            ValueFormat.BinB => ToBinB(value, info.Len),
            ValueFormat.BcdLU => ToBcdLU(value, info.Len),
            ValueFormat.BcdLS => ToBcdLS(value, info.Len),
            ValueFormat.BcdBU => ToBcdBU(value, info.Len),
            ValueFormat.BcdBS => ToBcdBS(value, info.Len),
            ValueFormat.Yaesu => ToYaesu(value, info.Len),
            ValueFormat.DPIcom => ToDPIcom(value, info.Len),
            ValueFormat.TextUD => ToTextUD(value, info.Len),
            ValueFormat.Float => ToFloat(value, info.Len),
            ValueFormat.None => Array.Empty<byte>(),
            _ => throw new ArgumentOutOfRangeException($"{info.Format} not recognized.")
        };
    }

    //ASCII codes of digits

    public static byte[] ToText(int value, int len)
    {
        var s = value.ToString().PadLeft(len, '0');
        return Encoding.UTF8.GetBytes(s);
    }

    //BCD big endian signed
    // ReSharper disable once InconsistentNaming

    public static byte[] ToBcdBS(int value, int len)
    {
        var result = ToBcdBU(Math.Abs(value), len);

        if (value < 0)
        {
            result[0] = 0xFF;
        }

        return result;
    }

    //BCD big endian unsigned
    // ReSharper disable once InconsistentNaming

    public static byte[] ToBcdBU(int value, int len)
    {
        var chars = ToText(value, len*2);
        var result = new byte[len];

        for (var i = 0; i < len; i++)
        {
            var char1 = (byte)((chars[i * 2] - 0x30) << 4);
            var char2 = (byte)(chars[i * 2 + 1] - 0x30);
            result[i] = (byte)(char1 | char2);
        }

        return result;
    }

    //BCD little endian signed; sign in high byte (00 or FF)
    // ReSharper disable once InconsistentNaming

    public static byte[] ToBcdLS(int value, int len)
    {
        var arr = ToBcdLU(Math.Abs(value), len);

        if (value < 0)
        {
            arr[^1] = 0xFF;
        }

        return arr;
    }

    //BCD little endian unsigned
    // ReSharper disable once InconsistentNaming

    public static byte[] ToBcdLU(int value, int len)
    {
        var arr = ToBcdBU(value, len);
        Array.Reverse(arr);
        return arr;
    }

    //integer, big endian

    public static byte[] ToBinB(int value, int len)
    {
        var arr = ToBinL(value, len);
        Array.Reverse(arr);
        return arr;
    }

    //integer, little endian

    public static byte[] ToBinL(int value, int len)
    {
        var bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return bytes;
    }

    public static byte[] ToDPIcom(int value, int len)
    {
        var f = value / 1000000;
        var s = Convert.ToString(f).PadLeft(len, '0');
        return Encoding.UTF8.GetBytes(s);
    }

    //16 bits. high bit of the 1-st byte is sign,
    //the rest is integer, absolute value, big endian (not complementary!)

    public static byte[] ToYaesu(int value, int len)
    {
        var arr = ToBinB(Math.Abs(value), len);

        if (value < 0)
        {
            arr[0] = (byte)(arr[0] | 0x80);
        }

        return arr;
    }

    // ReSharper disable once InconsistentNaming
    public static byte[] ToTextUD(int value, int len)
    {
        var prefix = (value >= 0) ? "U" : "D";
        var s = prefix + Convert.ToString(Math.Abs(value))
            .PadLeft(len - 1, '0');

        return Encoding.UTF8.GetBytes(s);
    }

    public static byte[] ToFloat(int value, int len)
    {
        var s = value.ToString("F", CultureInfo.InvariantCulture).PadLeft(len, ' ');
        return Encoding.UTF8.GetBytes(s);
    }
}