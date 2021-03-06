/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace U2.MultiRig.Tests;

#nullable disable
public class RigCommandTestsWriteRecordsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new[]
        {
            GetFreqA(),
            GetFreqB(),
            GetRit0(),
            GetPitch(),
            GetSplitOn(),
            GetSplitOff(),
            GetVfoA(),
            GetVfoB(),
            GetVfoSwap(),
            GetVfoEqual(),
            GetVfoAA(),
            GetVfoAB(),
            GetVfoBA(),
            GetVfoBB(),
            GetRitOn(),
            GetRitOff(),
            GetXitOn(),
            GetXitOff(),
            GetRx(),
            GetTx(),
        };

        return testData.Select(td => new[] { td }).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private static WriteTestData GetFreqA()
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
                Param = RigParameter.FreqA, 
            },
        };
    }

    private static WriteTestData GetFreqB()
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
                Param = RigParameter.FreqB,
            },
        };
    }

    private static WriteTestData GetRit0()
    {
        return new WriteTestData
        {
            Text = @"[pmRit0]
Command=FEFEA4E0.21.00000000.FD
ReplyLength=16
Validate=FEFEA4E02100000000FD.FEFEE0A4FBFD",
            ReplyLength = 16,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x00, 0x00, 0x00, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x00, 0x00, 0x00, 0x00,
                0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.Rit0,
            },
        };
    }

    private static WriteTestData GetPitch()
    {
        return new WriteTestData
        {
            Text = @"[pmPitch]
; The 0.425|-127.5 parameters maps 300Hz->0, 900Hz->255
Command=FEFEA4E0.14.09.0000.FD
Value=6|2|vfBcdBU|0.425|-127.5
ReplyLength=15
Validate=FEFEA4E014090000FD.FEFEE0A4FBFD",
            ReplyLength = 15,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x14, 0x09, 0x00, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x14, 0x09, 0x00, 0x00,
                0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Start = 6,
                Len = 2,
                Format = ValueFormat.BcdBU,
                Mult = 0.425,
                Add = -127.5,
                Param = RigParameter.Pitch,
            },
        };
    }

    private static WriteTestData GetSplitOn()
    {
        return new WriteTestData
        {
            Text = @"[pmSplitOn]
Command=FEFEA4E0.0F01.FD
ReplyLength=13
Validate=FEFEA4E00F01FD.FEFEE0A4FBFD",
            ReplyLength = 13,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x01, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x01,
                0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.SplitOn,
            },
        };
    }

    private static WriteTestData GetSplitOff()
    {
        return new WriteTestData
        {
            Text = @"[pmSplitOff]
Command=FEFEA4E0.0F00.FD
ReplyLength=13
Validate=FEFEA4E00F00FD.FEFEE0A4FBFD",
            ReplyLength = 13,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x00,
                0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.SplitOff,
            },
        };
    }

    private static WriteTestData GetVfoA()
    {
        return new WriteTestData
        {
            Text = @"[pmVfoA]
Command=FEFEA4E0.0700.FD
ReplyLength=13
Validate=FEFEA4E00700FD.FEFEE0A4FBFD",
            ReplyLength = 13,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x00,
                0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.VfoA,
            },
        };
    }

    private static WriteTestData GetVfoB()
    {
        return new WriteTestData
        {
            Text = @"[pmVfoB]
Command=FEFEA4E0.0701.FD
ReplyLength=13
Validate=FEFEA4E00701FD.FEFEE0A4FBFD",
            ReplyLength = 13,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x01, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x01,
                0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.VfoB,
            },
        };
    }

    private static WriteTestData GetVfoEqual()
    {
        return new WriteTestData
        {
            Text = @"[pmVfoEqual]
Command=FEFEA4E0.07A0.FD
ReplyLength=13
Validate=FEFEA4E007A0FD.FEFEE0A4FBFD",
            ReplyLength = 13,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0xA0, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0xA0,
                0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.VfoEqual,
            },
        };
    }

    private static WriteTestData GetVfoSwap()
    {
        return new WriteTestData
        {
            Text = @"[pmVfoSwap]
Command=FEFEA4E0.07B0.FD
ReplyLength=13
Validate=FEFEA4E007B0FD.FEFEE0A4FBFD",
            ReplyLength = 13,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0xB0, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0xB0,
                0xFD, 0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.VfoSwap,
            },
        };
    }

    private static WriteTestData GetVfoAA()
    {
        return new WriteTestData
        {
            Text = @"[pmVfoAA]
Command=FEFEA4E0.0700.FD.FEFEA4E0.0F00.FD
ReplyLength=20
Validate=FEFEA4E00700FD.FEFEA4E00F00FD.FEFEE0A4FBFD",
            ReplyLength = 20,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x00, 0xFD, 
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x00, 0xFD,
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x00, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.VfoAA,
            },
        };
    }

    private static WriteTestData GetVfoAB()
    {
        return new WriteTestData
        {
            Text = @"[pmVfoAB]
Command=FEFEA4E0.0700.FD.FEFEA4E0.0F01.FD
ReplyLength=20
Validate=FEFEA4E00700FD.FEFEA4E00F01FD.FEFEE0A4FBFD",
            ReplyLength = 20,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x00, 0xFD, 
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x01, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x00, 0xFD,
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x01, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.VfoAB,
            },
        };
    }

    private static WriteTestData GetVfoBA()
    {
        return new WriteTestData
        {
            Text = @"[pmVfoBA]
Command=FEFEA4E0.0701.FD.FEFEA4E0.0F00.FD
ReplyLength=20
Validate=FEFEA4E00701FD.FEFEA4E00F00FD.FEFEE0A4FBFD",
            ReplyLength = 20,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x01, 0xFD, 
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x01, 0xFD,
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x00, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.VfoBA,
            },
        };
    }

    private static WriteTestData GetVfoBB()
    {
        return new WriteTestData
        {
            Text = @"[pmVfoBB]
Command=FEFEA4E0.0701.FD.FEFEA4E0.0F00.FD
ReplyLength=20
Validate=FEFEA4E00701FD.FEFEA4E00F00FD.FEFEE0A4FBFD",
            ReplyLength = 20,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x01, 0xFD, 
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x07, 0x01, 0xFD,
                0xFE, 0xFE, 0xA4, 0xE0, 0x0F, 0x00, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.VfoBB,
            },
        };
    }

    private static WriteTestData GetRitOn()
    {
        return new WriteTestData
        {
            Text = @"[pmRitOn]
Command=FEFEA4E0.21.0101.FD
ReplyLength=14
Validate=FEFEA4E0210101FD.FEFEE0A4FBFD",
            ReplyLength = 14,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x01, 0x01, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x01, 0x01, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.RitOn,
            },
        };
    }

    private static WriteTestData GetRitOff()
    {
        return new WriteTestData
        {
            Text = @"[pmRitOff]
Command=FEFEA4E0.21.0100.FD
ReplyLength=14
Validate=FEFEA4E0210100FD.FEFEE0A4FBFD",
            ReplyLength = 14,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x01, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x01, 0x00, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.RitOff,
            },
        };
    }

    private static WriteTestData GetXitOn()
    {
        return new WriteTestData
        {
            Text = @"[pmXitOn]
Command=FEFEA4E0.21.0201.FD
ReplyLength=14
Validate=FEFEA4E0210201FD.FEFEE0A4FBFD",
            ReplyLength = 14,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x02, 0x01, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x02, 0x01, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.XitOn,
            },
        };
    }

    private static WriteTestData GetXitOff()
    {
        return new WriteTestData
        {
            Text = @"[pmXitOff]
Command=FEFEA4E0.21.0200.FD
ReplyLength=14
Validate=FEFEA4E0210200FD.FEFEE0A4FBFD",
            ReplyLength = 14,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x02, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x21, 0x02, 0x00, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.XitOff,
            },
        };
    }

    private static WriteTestData GetRx()
    {
        return new WriteTestData
        {
            Text = @"[pmRx]
Command=FEFEA4E0.1C00.00.FD
ReplyLength=14
Validate=FEFEA4E01C0000FD.FEFEE0A4FBFD",
            ReplyLength = 14,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x1C, 0x00, 0x00, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x1C, 0x00, 0x00, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.Rx,
            },
        };
    }

    private static WriteTestData GetTx()
    {
        return new WriteTestData
        {
            Text = @"[pmTx]
Command=FEFEA4E0.1C00.01.FD
ReplyLength=14
Validate=FEFEA4E01C0001FD.FEFEE0A4FBFD",
            ReplyLength = 14,
            Command = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x1C, 0x00, 0x01, 0xFD,
            },
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x1C, 0x00, 0x01, 0xFD, 
                0xFE, 0xFE, 0xE0, 0xA4, 0xFB, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                Param = RigParameter.Tx,
            },
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

#nullable restore
