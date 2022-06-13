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
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace U2.MultiRig.Tests;

public sealed class CanExtractValueTestData
: RigEmulatorBaseTestData, IEnumerable<object[]>
{

    private static readonly IEnumerable<RigParameter> BinaryParameters =
        new[]
        {
            RigParameter.AM,
            RigParameter.FM,
            RigParameter.CW_L,
            RigParameter.CW_U,
            RigParameter.SSB_L,
            RigParameter.SSB_U,
            RigParameter.DIG_L,
            RigParameter.DIG_U,
            RigParameter.Tx,
            RigParameter.Rx,
            RigParameter.XitOff,
            RigParameter.XitOn,
            RigParameter.RitOff,
            RigParameter.RitOn,
            RigParameter.SplitOff,
            RigParameter.SplitOn,
            RigParameter.Pitch,
            RigParameter.VfoAA,
            RigParameter.VfoAB,
        };

    private static readonly IEnumerable<RigParameter> ValueParameters =
        new[]
        {
            RigParameter.FreqA,
            RigParameter.FreqB,
            RigParameter.Pitch,
        };

    public IEnumerator<object[]> GetEnumerator()
    {
        var testData = new List<ExtractValueTestData>();
        testData.AddRange(BinaryParameters.Select(PrepareBinaryTestData));
        testData.AddRange(ValueParameters.Select(p => PrepareValueTestData(p, 12345)));

        return testData.Select(td => new[] { td })
            .GetEnumerator();
    }

    private ExtractValueTestData ExtractAM()
    {
        return PrepareBinaryTestData(RigParameter.AM);
    }

    private ExtractValueTestData PrepareBinaryTestData(RigParameter parameter)
    {
        var command = _rigCommands.WriteCmd[(int)parameter];
        return new ExtractValueTestData
        {
            RigParameter = parameter,
            Code = command.Code,
            ExpectedValue = 0,
            ExpectsValue = false,
        };
    }

    private ExtractValueTestData PrepareValueTestData(RigParameter parameter, int value)
    {
        var command = _rigCommands.WriteCmd[(int)parameter];
        var code = command.Code;

        var info = command.Value;
        if (info.Param == RigParameter.None)
        {
            info = command.Values[0];
        }
        var bytes = ConversionFunctions.FormatValue(value, info);
        Assert.NotEmpty(bytes);
        Assert.Equal(info.Len, bytes.Length);
        Array.Copy(bytes, 0, code, info.Start, info.Len);

        return new ExtractValueTestData
        {
            RigParameter = parameter,
            Code = code,
            ExpectedValue = value,
            ExpectsValue = true,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public sealed class ExtractValueTestData
{
    public RigParameter RigParameter { get; set; }
    public byte[] Code { get; set; }
    public bool ExpectsValue { get; set; }
    public int ExpectedValue { get; set; }
}