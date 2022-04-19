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

public enum RigParameter
{
    None,
    Freq,
    FreqA,
    FreqB,
    Pitch,
    RitOffset,
    Rit0,
    VfoAA,
    VfoAB,
    VfoBA,
    VfoBB,
    VfoA,
    VfoB,
    VfoEqual,
    VfoSwap,
    SplitOn,
    SplitOff,
    RitOn,
    RitOff,
    XitOn,
    XitOff,
    Rx,
    Tx,
    CW_U,
    CW_L,
    SSB_U,
    SSB_L,
    DIG_U,
    DIG_L,
    AM,
    FM,
}
