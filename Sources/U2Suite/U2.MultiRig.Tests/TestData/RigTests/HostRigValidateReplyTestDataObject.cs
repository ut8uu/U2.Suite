using System;

namespace U2.MultiRig.Tests;

public class HostRigValidateReplyTestDataObject
{
    public byte[] Data { get; set; }
    public BitMask BitMask { get; set; }
    public bool ExceptionIsExpected { get; set; }
    public Type ExceptionType { get; set; }
}