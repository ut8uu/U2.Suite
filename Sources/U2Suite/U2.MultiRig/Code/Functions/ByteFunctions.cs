using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData;
using U2.Core;

namespace U2.MultiRig.Code;

public static class ByteFunctions
{
    public static bool ByteArraysEqual(byte[] arr1, byte[] arr2)
    {
        return arr1.SequenceEqual(arr2);
    }

    public static byte[] BytesAnd(byte[] arr1, byte[] arr2)
    {
        List<byte> result = new();

        var maxIndex = Math.Min(arr1.Length, arr2.Length);

        for (var i = 0; i <= maxIndex - 1; i++)
        {
            result.Add((byte)(arr1[i] & arr2[i]));
        }

        return result.ToArray();
    }

    public static void BytesReverse(byte[] arr)
    {
        Array.Reverse(arr);
    }

    public static string BytesToStr(byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }

    public static string BytesToHex(byte[] bytes)
    {
        var stringBuilder = new StringBuilder();
        foreach (var b in bytes)
        {
            stringBuilder.Append($"{b:X}");
        }
        return stringBuilder.ToString();
    }

    public static string StrToHex(string s)
    {
        return BytesToHex(StrToBytes(s));
    }

    private const string HexChars = "0123456789abcdef";
    private const char dot = '.';
    internal static byte[] StrToBytes(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return Array.Empty<byte>();
        }

        var trimmedString = s.Trim();

        if (s.StartsWith("("))
        {
            trimmedString = trimmedString.Trim("()".ToCharArray());
            var result = Encoding.UTF8.GetBytes(trimmedString);
            if (!trimmedString.Contains(dot))
            {
                return result;
            }

            for (var i = 1; i < result.Length; i++)
            {
                if (trimmedString[i] == dot)
                {
                    result[i] = 0x00;
                }
            }

            return result;
        }
        else if (HexChars.Contains(trimmedString[0]))
        {
            return HexStrToBytes(trimmedString);
        }

        return Array.Empty<byte>();
    }

    internal static byte[] HexStrToBytes(string s)
    {
        var preparedString = RegularExpressionHelper.ReplaceRegExpr("[^a-f0-9]", string.Empty, s);
        if (preparedString.Length % 2 != 0)
        {
            return Array.Empty<byte>();
        }

        return Enumerable.Range(0, preparedString.Length / 2)
            .Select(x => ToByte(preparedString, x))
            .ToArray();

        byte ToByte(string str, int position)
        {
            return Convert.ToByte(str.Substring(position * 2, 2), 16);
        }
    }
}
