using System;

namespace U2.MultiRig.Tests;

public class Ic705SerialPortEmulatorInitCommandTestDataObject
{
    public bool ExceptionIsExpected { get; set; }
    public Type ExceptionType { get; set; }
    public RigCommand RigCommand { get; set; }
}