using System;

namespace U2.MultiRig.Tests;

public class RigCommandTestsParseValueTestDataObject
{
    public bool ExceptionIsExpected { get; set; }
    public Type ExceptionType { get; set; }
    public ParameterValue ExpectedParameterValue { get; set; }
    public string Value { get; set; }
}