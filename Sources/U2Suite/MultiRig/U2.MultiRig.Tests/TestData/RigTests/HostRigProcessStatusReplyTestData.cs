using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace U2.MultiRig.Tests;

public class HostRigProcessStatusReplyTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new[]
        {
            InvalidIndex(),
            DataTooShort(),
            DataTooLong(),
        };

        return testData.Select(td => new[] { td })
            .GetEnumerator();
    }

    private HostRigProcessStatusReplyTestDataObject DataTooLong()
    {
        return new HostRigProcessStatusReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = new byte[1000],
            CommandIndex = 0,
        };
    }

    private HostRigProcessStatusReplyTestDataObject DataTooShort()
    {
        return new HostRigProcessStatusReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = new byte[]{ 0x00 },
            CommandIndex = 0,
        };
    }

    private HostRigProcessStatusReplyTestDataObject InvalidIndex()
    {
        return new HostRigProcessStatusReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ArgumentOutOfRangeException),
            Data = Array.Empty<byte>(),
            CommandIndex = -1,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}