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
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using DynamicData;
using U2.Core;

namespace U2.MultiRig;

[DebuggerStepThrough]
public static class ByteFunctions
{
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

    public static string BytesToStr(byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }

    [DebuggerStepThrough]
    public static string BytesToHex(byte[] bytes)
    {
        var stringBuilder = new StringBuilder();
        foreach (var b in bytes)
        {
            stringBuilder.Append($"{b:X2}");
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
        else if (HexChars.Contains(trimmedString[0], StringComparison.InvariantCultureIgnoreCase))
        {
            return HexStrToBytes(trimmedString);
        }

        return Array.Empty<byte>();
    }

    public static byte[] HexStrToBytes(string s)
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

    public static byte[] RigParameterToBytes(RigParameter parameter)
    {
        return UlongToBytes((ulong)parameter);
    }

    public static byte[] TimestampToBytes(DateTime timestamp)
    {
        return BitConverter.GetBytes(timestamp.ToBinary());
    }

    public static DateTime BytesToTimestamp(byte[] data)
    {
        var res = DateTime.FromBinary(BitConverter.ToInt64(data));
        return res;
    }

    public static byte[] UshortToBytes(ushort input)
    {
        var data = BitConverter.GetBytes(input);
        Array.Reverse(data); // big endian is expected
        return data;
    }

    public static byte[] IntToBytes(int input)
    {
        var data = BitConverter.GetBytes(input);
        Array.Reverse(data); // big endian is expected
        return data;
    }

    private static byte[] ULongToBytes(ulong input)
    {
        var data = BitConverter.GetBytes(input);
        Array.Reverse(data); // big endian is expected
        return data;
    }

    private static ushort BytesToUshort(byte[] data)
    {
        var arr = data.ToArray();
        Array.Reverse(arr); // big endian is expected
        return BitConverter.ToUInt16(arr);
    }

    private static ulong BytesToUlong(byte[] data)
    {
        var arr = data.ToArray();
        Array.Reverse(arr); // big endian is expected
        return BitConverter.ToUInt64(arr);
    }

    private static short BytesToShort(byte[] data)
    {
        var arr = data.ToArray();
        Array.Reverse(arr); // big endian is expected
        return BitConverter.ToInt16(arr);
    }

    private static int BytesToInt(byte[] data)
    {
        var arr = data.ToArray();
        Array.Reverse(arr); // big endian is expected
        return BitConverter.ToInt32(arr);
    }

    private static long BytesToLong(byte[] data)
    {
        var arr = data.ToArray();
        Array.Reverse(arr); // big endian is expected
        return BitConverter.ToInt64(arr);
    }

    public static byte[] MessageIdToBytes(byte messageId)
    {
        return new[] { messageId };
    }

    public static byte BytesToMessageId(byte[] data)
    {
        return data.First();
    }

    public static ushort BytesToSenderId(byte[] data)
    {
        return BytesToUshort(data);
    }

    public static byte[] SenderIdToBytes(ushort senderId)
    {
        return UshortToBytes(senderId);
    }

    public static ushort BytesToReceiverId(byte[] data)
    {
        return BytesToUshort(data);
    }

    public static byte[] ReceiverIdToBytes(ushort receiverId)
    {
        return UshortToBytes(receiverId);
    }

    public static ushort BytesToCommandId(byte[] data)
    {
        return BytesToUshort(data);
    }

    public static byte[] CommandIdToBytes(ushort commandId)
    {
        return UshortToBytes(commandId);
    }

    public static ushort BytesToDataLength(byte[] data)
    {
        return BytesToUshort(data);
    }

    public static byte[] DataLengthToBytes(ushort commandId)
    {
        return UshortToBytes(commandId);
    }

    public static byte[] UlongToBytes(ulong input)
    {
        var data = BitConverter.GetBytes(input);
        Array.Reverse(data); // big endian is expected
        return data;
    }

    public static byte[] LongToBytes(long input)
    {
        var data = BitConverter.GetBytes(input);
        Array.Reverse(data); // big endian is expected
        return data;
    }

    public static RigParameter BytesToRigParameter(byte[] data)
    {
        Debug.Assert(data.Length == 8); // 64-bit value
        return (RigParameter)BytesToUlong(data);
    }

    public static (RigParameter, long) BytesToRigParameterValue(byte[] data)
    {
        if (data.Length == 0)
        {
            return (RigParameter.None, 0);
        }
 
        var parameter = (RigParameter)BytesToLong(data.Take(8).ToArray());
        long value = 0;

        var valueBytes = data.Skip(8).ToArray();
        if (valueBytes.Length == 2)
        {
            value = Convert.ToInt64(BytesToShort(valueBytes));
        }
        else if (valueBytes.Length == 4)
        {
            value = Convert.ToInt64(BytesToInt(valueBytes));
        }
        else if (valueBytes.Length == 8)
        {
            value = BytesToLong(valueBytes);
        }
        return (parameter, value);
    }
}
