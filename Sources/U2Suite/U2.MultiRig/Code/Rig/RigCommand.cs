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
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig;

#nullable disable
public sealed class RigCommand
{
    public byte[] Code { get; set; }
    public ParameterValue Value { get; set; }
    public int ReplyLength { get; set; }
    public byte[] ReplyEnd { get; set; }

    public BitMask Validation { get; set; }

    public List<ParameterValue> Values { get; set; } = new();
    public List<BitMask> Flags { get; set; } = new();
}

public struct ParameterValue
{
    public int Start { get; set; }
    public int Len { get; set; }  //insert or extract bytes, Start is a 0-based index
    public ValueFormat Format { get; set; } //encode or decode according to this format
    public double Mult { get; set; }
    public double Add { get; set; }    //linear transformation before encoding or after decoding
    public RigParameter Param { get; set; }     //param to insert or to report
}

public enum ValueFormat
{
    None,
    Text,
    BinL,
    BinB,
    BcdLU,
    BcdLS,
    BcdBU,
    BcdBS,
    Yaesu,
    DPIcom,
    TextUD,
    Float,
}

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public struct BitMask
{
    public byte[] Mask { get; set; }   //do bitwise AND with this mask
    public byte[] Flags { get; set; }  //compare result to these bits
    public RigParameter Param { get; set; }   //report this param if bits match
    
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    string DebuggerDisplay => $"Mask: {ByteFunctions.BytesToHex(Mask)}\r\n Flags: {ByteFunctions.BytesToHex(Flags)}\r\nParam: {Param}";
}

public enum RigParameter
{
    None = 0,           // 0x00000000
    Freq = 1,           // 0x00000001
    FreqA = 2,          // 0x00000002
    FreqB = 4,          // 0x00000004
    Pitch = 8,          // 0x00000008
    RitOffset = 16,     // 0x00000010
    Rit0 = 32,          // 0x00000020
    VfoAA = 64,         // 0x00000040
    VfoAB = 128,        // 0x00000080
    VfoBA = 256,        // 0x00000100
    VfoBB = 512,        // 0x00000200
    VfoA = 1024,        // 0x00000400
    VfoB = 2048,        // 0x00000800
    VfoEqual = 4096,    // 0x00001000
    VfoSwap = 8192,     // 0x00002000
    SplitOn = 16384,    // 0x00004000
    SplitOff = 32768,   // 0x00008000
    RitOn = 65536,      // 0x00010000
    RitOff = 131072,    // 0x00020000
    XitOn = 262144,     // 0x00040000
    XitOff = 524288,    // 0x00080000
    Rx = 1048576,       // 0x00100000
    Tx = 2097152,       // 0x00200000
    CW_U = 4194304,     // 0x00400000
    CW_L = 8388608,     // 0x00800000
    SSB_U = 16777216,   // 0x01000000
    SSB_L = 33554432,   // 0x02000000
    DIG_U = 67108864,   // 0x04000000
    DIG_L = 134217728,  // 0x08000000
    AM = 268435456,     // 0x10000000
    FM = 536870912,     // 0x20000000
}

public enum Entry
{
    Command,
    ReplyLength,
    ReplyEnd,
    Validate,
    Value,
    Value1,
    Value2,
    Value3,
    Value4,
    Value5,
    Value6,
    Value7,
    Value8,
    Value9,
    Value10,
    Flag,
    Flag1,
    Flag2,
    Flag3,
    Flag4,
    Flag5,
    Flag6,
    Flag7,
    Flag8,
    Flag9,
    Flag10,
    Flag11,
    Flag12,
    Flag13,
    Flag14,
    Flag15,
    Flag16,
    Flag17,
    Flag18,
    Flag19,
    Flag20,
    Flag21,
    Flag22,
}
#nullable restore