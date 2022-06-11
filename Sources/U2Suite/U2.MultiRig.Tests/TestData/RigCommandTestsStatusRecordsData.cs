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

using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace U2.MultiRig.Tests;

public class RigCommandTestsStatusRecordsData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new[]
        {
            GetStatus1(),
            GetIC705Status4(),
        };

        return testData.Select(td => new[] { td }).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #region Test data

    private StatusTestData GetStatus1()
    {
        return new StatusTestData
        {
            Text =
                "[STATUS1]\r\n; Read VFO A\r\nCommand = FEFEA4E0.2500.FD\r\nReplyLength = 19\r\nValidate = FEFEA4E02500FD.FEFEE0A4.2500.0000000000.FD\r\nValue1 = 13|5|vfBcdLU|1|0|pmFreqA",
            Command = new byte[] { 0xFE, 0xFE, 0xA4, 0xE0, 0x25, 0x00, 0xFD },
            ReplyLength = 19,
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x25, 0x00, 0xFD, 0xFE, 0xFE, 0xE0,
                0xA4, 0x25, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                // 13|5|vfBcdLU|1|0|pmFreqA
                Start = 13,
                Len = 5,
                Param = RigParameter.FreqA,
                Format = ValueFormat.BcdLU,
                Mult = 1,
                Add = 0,
            }
        };
    }

    private StatusTestData GetIC705Status4()
    {
        return new StatusTestData
        {
            Text =
                "[STATUS4]\r\n; Read CW pitch setting\r\nCommand=FEFEA4E0.1409.FD\r\nReplyLength=16\r\nValidate=FEFEA4E01409FD.FEFEE0A4.1409.0000.FD\r\n; 1=300 Hz, 254=900 Hz\r\nValue1=13|2|vfBcdBU|2.3715|297.6285|pmPitch",
            Command = new byte[] { 0xFE, 0xFE, 0xA4, 0xE0, 0x14, 0x09, 0xFD },
            ReplyLength = 19,
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x14, 0x09, 0xFD, 0xFE,
                0xFE, 0xE0, 0xA4, 0x14, 0x09, 0x00, 0x00, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                // 13|2|vfBcdBU|2.3715|297.6285|pmPitch
                Start = 13,
                Len = 2,
                Param = RigParameter.Pitch,
                Format = ValueFormat.BcdBU,
                Mult = 2.3715,
                Add = 297.6285,
            }
        };
    }

    private StatusTestData GetIC705Status5()
    {
        return new StatusTestData
        {
            Text = "[STATUS5]\r\n; Read transmit status\r\nCommand=FEFEA4E0.1C00.FD\r\n" +
                   "ReplyLength=15\r\n" +
                   "Validate=FEFEA4E01C00FD.FEFEE0A4.1C00.00.FD\r\n" +
                   "Flag1=00000000000000.00000000.0000.01.00|pmTx\r\n" +
                   "Flag2=00000000000000.00000000.0000.0F.00|00000000000000.00000000.0000.00.00|pmRx\r\n",
            Command = new byte[] {0xFE, 0xFE, 0xA4, 0xE0, 0x1C, 0x00, 0xFD},
            ReplyLength = 15,
            Validate = new byte[]
            {
                0xFE, 0xFE, 0xA4, 0xE0, 0x1C, 0x00, 0xFD,
                0xFE, 0xFE, 0xE0, 0xA4, 0x1C, 0x00, 0x00, 0xFD,
            },
            ParameterValue = new ParameterValue
            {
                // 13|2|vfBcdBU|2.3715|297.6285|pmPitch
                Start = 13,
                Len = 2,
                Param = RigParameter.Pitch,
                Format = ValueFormat.BcdBU,
                Mult = 2.3715,
                Add = 297.6285,
            },
            Flags = new BitMask[]
            {
                new()
                {
                    // 00000000000000.00000000.0000.01.00|pmTx
                    Flags = new byte[]
                    {
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00,
                    },
                    Mask = new byte[]
                    {
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00,
                    },
                    Param = RigParameter.Tx,
                },
                new()
                {
                    // 00000000000000.00000000.0000.0F.00|pmRx
                    Flags = new byte[]
                    {
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00,
                    },
                    Mask = new byte[]
                    {
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00,
                    },
                    Param = RigParameter.Rx,
                },
            },
        };
    }

    #endregion
}

public class StatusTestData
{
    #nullable disable
    public string Text { get; init; }
    public byte[] Command { get; init; }
    public int ReplyLength { get; init; }
    public byte[] Validate { get; init; }
    public BitMask[] Flags { get; init; }
    public ParameterValue ParameterValue { get; init; }
    #nullable restore
}
