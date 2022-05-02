using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace U2.MultiRig.Tests;

public class RigCommandTestsWriteRecordsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new[]
        {
            GetFreqA(),
            GetFreqB(),
        };

        return testData.Select(td => new[] { td }).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private WriteTestData GetFreqA()
    {
        return new WriteTestData
        {
            Text = @"[pmFreqA]
Command=FEFEA4E0.25.00.0000000000.FD
Value=6|5|vfBcdLU|1|0
ReplyLength=18
Validate=FEFEA4E025000000000000FD.FEFEE0A4FBFD",
            ReplyLength = 18,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x25, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x25, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Start = 6,
                Len = 5,
                Format = ValueFormat.BcdLU,
                Mult = 1,
                Add = 0,
                Param = RigParameter.None, // by default
            }
        };
    }

    private WriteTestData GetFreqB()
    {
        return new WriteTestData
        {
            Text = @"[pmFreqB]
Command=FEFEA4E0.25.01.0000000000.FD
Value=6|5|vfBcdLU|1|0
ReplyLength=18
Validate=FEFEA4E025010000000000FD.FEFEE0A4FBFD",
            ReplyLength = 18,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x25, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x25, 0x01, 0x00, 0x00, 0x00,
                0x00, 0x00, 0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Start = 6,
                Len = 5,
                Format = ValueFormat.BcdLU,
                Mult = 1,
                Add = 0,
                Param = RigParameter.None, // by default
            }
        };
    }
}

public class WriteTestData
{
    public string Text { get; init; }
    public byte[] Command { get; init; }
    public byte[] Validate { get; init; }
    public ParameterValue ParameterValue { get; init; }
    public int ReplyLength { get; init; }
}