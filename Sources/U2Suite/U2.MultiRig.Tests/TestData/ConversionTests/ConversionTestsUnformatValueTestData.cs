using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace U2.MultiRig.Tests;

public class ConversionTestsUnformatValueTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new[]
        {
            FromTextNotIntegerValue(),
            FromTextSuccess(),
        };

        return testData.Select(td => new[] { td })
            .GetEnumerator();
    }

    private ConversionTestsUnformatValueTestDataObject FromTextNotIntegerValue()
    {
        return new ConversionTestsUnformatValueTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueConversionException),
            Data = new byte[] { 0x40, 0x41, 0x42 },
            ExpectedValue = 0,
            ParameterValue = RigCommandUtilities.ParseParameterValue("1|2|vfText|1|0|pmFreqA"),
        };
    }

    private ConversionTestsUnformatValueTestDataObject FromTextSuccess()
    {
        return new ConversionTestsUnformatValueTestDataObject
        {
            ExceptionIsExpected = false,
            ExceptionType = null,
            Data = new byte[] { 0x30, 0x31, 0x32 },
            ExpectedValue = 12,
            ParameterValue = RigCommandUtilities.ParseParameterValue("1|2|vfText|1|0|pmFreqA"),
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}