using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace U2.MultiRig.Tests;

public class HostRigProcessInitReplyTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new[]
        {
            DataArrayIsEmpty(),
            DataTooShort(),
            DataTooLong(),
            InvalidData(),
            ValidData(),
            InvalidIndex(),
        };

        return testData.Select(td => new[] { td })
            .GetEnumerator();
    }

    private HostRigProcessInitReplyTestDataObject InvalidIndex()
    {
        return new HostRigProcessInitReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ArgumentOutOfRangeException),
            Data = Array.Empty<byte>(),
            CommandIndex = -1,
        };
    }

    private HostRigProcessInitReplyTestDataObject ValidData()
    {
        return new HostRigProcessInitReplyTestDataObject
        {
            ExceptionIsExpected = false,
            ExceptionType = null,
            Data = ByteFunctions.HexStrToBytes("FEFEA4E01A05013201FDFEFEE0A4FBFD"),
            CommandIndex = 0,
        };
    }

    private HostRigProcessInitReplyTestDataObject InvalidData()
    {
        return new HostRigProcessInitReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = ByteFunctions.HexStrToBytes("00FEA4E01A05013201FDFEFEE0A4FBFD"),
            CommandIndex = 0,
        };
    }

    private HostRigProcessInitReplyTestDataObject DataTooLong()
    {
        var result = new HostRigProcessInitReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = new byte[1000], 
            CommandIndex = 0,
        };
        var b = (byte) 0x00;
        Array.Fill(result.Data, b);
        return result;
    }

    private HostRigProcessInitReplyTestDataObject DataTooShort()
    {
        return new HostRigProcessInitReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = new byte[] { 0x00 },
            CommandIndex = 0,
        };
    }

    private HostRigProcessInitReplyTestDataObject DataArrayIsEmpty()
    {
        return new HostRigProcessInitReplyTestDataObject
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueValidationException),
            Data = Array.Empty<byte>(),
            CommandIndex = 0,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}