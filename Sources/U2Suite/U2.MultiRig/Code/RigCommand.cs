using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig;

public sealed class RigCommand
{
    public byte[] Code;

    public TParamValue Value;

    //what to wait for
    public int ReplyLength;
    public byte[] ReplyEnd;

    public TBitMask Validation;

    //what to extract
    public List<TParamValue> Values = new();
    public List<TBitMask> Flags = new();
}

public struct TParamValue
{
    public int Start;
    public int Len;  //insert or extract bytes, Start is a 0-based index
    public TValueFormat Format; //encode or decode according to this format
    public double Mult;
    public double Add;    //linear transformation before encoding or after decoding
    public RigParameter Param;     //param to insert or to report
}

public enum TValueFormat
{
    vfNone, vfText, vfBinL, vfBinB, vfBcdLU, vfBcdLS, vfBcdBU, vfBcdBS, vfYaesu, vfDPIcom,
    vfTextUD, vfFloat
}

public struct TBitMask
{
    public byte[] Mask;   //do bitwise AND with this mask
    public byte[] Flags;  //compare result to these bits
    public RigParameter Param;   //report this param if bits match
}

public enum RigParameter
{
    pmNone, pmFreq, pmFreqA, pmFreqB, pmPitch, pmRitOffset, pmRit0, pmVfoAA, pmVfoAB,
    pmVfoBA, pmVfoBB, pmVfoA, pmVfoB, pmVfoEqual, pmVfoSwap, pmSplitOn, pmSplitOff,
    pmRitOn, pmRitOff, pmXitOn, pmXitOff, pmRx, pmTx, pmCW_U, pmCW_L, pmSSB_U,
    pmSSB_L, pmDIG_U, pmDIG_L, pmAM, pmFM
}
