using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig;

public sealed class RigCommand
{
    public byte[] Code;

    public ParameterValue Value;

    //what to wait for
    public int ReplyLength;
    public byte[] ReplyEnd;

    public BitMask Validation;

    //what to extract
    public List<ParameterValue> Values = new();
    public List<BitMask> Flags = new();
}

public struct ParameterValue
{
    public int Start;
    public int Len;  //insert or extract bytes, Start is a 0-based index
    public ValueFormat Format; //encode or decode according to this format
    public double Mult;
    public double Add;    //linear transformation before encoding or after decoding
    public RigParameter Param;     //param to insert or to report
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

public struct BitMask
{
    public byte[] Mask;   //do bitwise AND with this mask
    public byte[] Flags;  //compare result to these bits
    public RigParameter Param;   //report this param if bits match
}

[Flags]
public enum RigParameter
{
    None = 0,
    Freq = 1,
    FreqA = 2,
    FreqB = 4,
    Pitch = 8,
    RitOffset = 16,
    Rit0 = 32,
    VfoAA = 64,
    VfoAB = 128,
    VfoBA = 256,
    VfoBB = 512,
    VfoA = 1024,
    VfoB = 2048,
    VfoEqual = 4096,
    VfoSwap = 8192,
    SplitOn = 16384,
    SplitOff = 32768,
    RitOn = 65536,
    RitOff = 131072,
    XitOn = 262144,
    XitOff = XitOn * 2,
    Rx = XitOff * 2,
    Tx = Rx * 2,
    CW_U = Tx * 2,
    CW_L = CW_U * 2,
    SSB_U = CW_L * 2,
    SSB_L = SSB_U * 2,
    DIG_U = SSB_L * 2,
    DIG_L = DIG_U * 2,
    AM = DIG_L * 2,
    FM = AM * 2,
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
