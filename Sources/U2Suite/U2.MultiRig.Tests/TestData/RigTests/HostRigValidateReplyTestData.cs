using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace U2.MultiRig.Tests;

public class HostRigValidateReplyTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new[]
        {
            DataTooShort(),
            DataTooLong(),
            InvalidData(),
            ValidData(),
        };

        return testData.Select(td => new[] { td })
            .GetEnumerator();
    }

    private HostRigValidateReplyTestDataObject ValidData()
    {
        return new HostRigValidateReplyTestDataObject
        {
            ExceptionIsExpected = false,
            ExceptionType = null,
            Data = new byte[] { 0x04, 0x01, },
            BitMask = new BitMask
            {
                Flags = new byte[] { 0x04, 0x00, },
                Mask = new byte[] { 0xFF, 0x00, },
                Param = RigParameter.FreqA,
            },
        };
    }

    private HostRigValidateReplyTestDataObject InvalidData()
    {
        return new HostRigValidateReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = new byte[] { 0x03, 0x01, },
            BitMask = new BitMask
            {
                Flags = new byte[] { 0x04, 0x00, },
                Mask = new byte[] { 0xFF, 0x00, },
                Param = RigParameter.FreqA,
            },
        };
    }

    private HostRigValidateReplyTestDataObject DataTooLong()
    {
        return new HostRigValidateReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = new byte[] { 0x00, 0x00, 0x00, },
            BitMask = new BitMask
            {
                Flags = new byte[] { 0x00, 0x00, },
                Mask = new byte[] { 0x00, 0x00, },
                Param = RigParameter.FreqA,
            },
        };
    }

    private HostRigValidateReplyTestDataObject DataTooShort()
    {
        return new HostRigValidateReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = new byte[] {0x00},
            BitMask = new BitMask
            {
                Flags = new byte[] {0x00, 0x00,},
                Mask = new byte[] {0x00, 0x00,},
                Param = RigParameter.FreqA,
            },
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}