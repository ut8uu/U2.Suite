using System;

namespace U2.MultiRig.Tests;

public class HostRigProcessStatusReplyTestDataObject
{
    public bool ExceptionIsExpected { get; set; }
    public Type ExceptionType { get; set; }
    public int CommandIndex { get; set; }
    public byte[] Data { get; set; }
}