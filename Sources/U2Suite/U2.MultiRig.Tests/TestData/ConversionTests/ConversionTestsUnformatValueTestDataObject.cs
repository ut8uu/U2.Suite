using System;

namespace U2.MultiRig.Tests;

public class ConversionTestsUnformatValueTestDataObject
{
    public bool ExceptionIsExpected { get; set; }
    public Type ExceptionType { get; set; }
    public ParameterValue ParameterValue { get; set; }
    public byte[] Data { get; set; }
    public int ExpectedValue { get; set; }
}