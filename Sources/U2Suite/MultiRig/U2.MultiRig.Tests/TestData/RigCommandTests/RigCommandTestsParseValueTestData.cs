using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace U2.MultiRig.Tests;

public class RigCommandTestsParseValueTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new[]
        {
            InvalidStringIncorrectRigParameter(),
            InvalidStringIncorrectValueFormat(),
            InvalidStringFourElements(),
            ValidStringFiveElements(),
            ValidStringSixElements(),
        };

        return testData.Select(td => new[] { td })
            .GetEnumerator();
    }

    private RigCommandTestsParseValueTestDataObject InvalidStringIncorrectRigParameter()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueLoadException),
            Value = "1|2|vfText|1|pmFreqX",
            ExpectedParameterValue = new ParameterValue(),
        };
    }

    private RigCommandTestsParseValueTestDataObject InvalidStringIncorrectValueFormat()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(FormatParseException),
            Value = "1|2|vfTextus|1|pmFreqA",
            ExpectedParameterValue = new ParameterValue(),
        };
    }

    private RigCommandTestsParseValueTestDataObject InvalidStringFourElements()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueLoadException),
            Value = "1|2|vfText|1",
            ExpectedParameterValue = new ParameterValue(),
        };
    }

    private RigCommandTestsParseValueTestDataObject ValidStringFiveElements()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = false,
            ExceptionType = null,
            Value = "1|2|vfText|1|0",
            ExpectedParameterValue = new ParameterValue
            {
                Add = 0,
                Mult = 1,
                Format = ValueFormat.Text,
                Param = RigParameter.None,
                Start = 1,
                Len = 2,
            }
        };
    }

    private RigCommandTestsParseValueTestDataObject ValidStringSixElements()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = false,
            ExceptionType = null,
            Value = "1|2|vfText|1|0|pmFreqA",
            ExpectedParameterValue = new ParameterValue
            {
                Add = 0,
                Mult = 1,
                Format = ValueFormat.Text,
                Param = RigParameter.FreqA,
                Start = 1,
                Len = 2,
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}