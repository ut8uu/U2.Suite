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
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace U2.Contracts;

public enum RadioModeType
{
    CW,
    SSB,
    PSK,
    RTTY,
    FM,
    DIGITALVOICE,
    AM,
    SATELLITES
}

public abstract class RadioMode
{
    public const string CW = nameof(CW);
    public const string SSB = nameof(SSB);
    public const string RTTY = nameof(RTTY);
    public const string AM = nameof(AM);
    public const string FM = nameof(FM);
    public const string DIGITALVOICE = nameof(DIGITALVOICE);
    public const string PSK = nameof(PSK);
    public const string SATELLITES = nameof(SATELLITES);

    public RadioModeType Type { get; }
    public string Name { get; }

    protected RadioMode(RadioModeType type, string name)
    {
        Type = type;
        Name = name;
    }

    public static RadioModeType[] AllModes =>
        new[]
        {
                RadioModeType.CW,
                RadioModeType.PSK,
                RadioModeType.RTTY,
                RadioModeType.DIGITALVOICE,
                RadioModeType.SSB,
                RadioModeType.FM,
                RadioModeType.AM,
                RadioModeType.SATELLITES,
        };

    public static RadioModeType[] CwModes =>
        new[]
        {
                RadioModeType.CW,
        };

    public static RadioModeType[] CwSsbModes =>
        new[]
        {
                RadioModeType.CW,
                RadioModeType.SSB,
        };

    public static RadioModeType[] NarrowBandModes =>
        new[]
        {
                RadioModeType.CW,
                RadioModeType.PSK,
                RadioModeType.RTTY,
        };

    public static RadioModeType[] NarrowBandDigitalModes =>
        new[]
        {
                RadioModeType.PSK,
                RadioModeType.RTTY,
        };

    public static RadioModeType[] VoiceModes =>
        new[]
        {
                RadioModeType.DIGITALVOICE,
                RadioModeType.SSB,
                RadioModeType.FM,
                RadioModeType.AM,
        };

    public static RadioModeType[] FmDigitalModes =>
        new[]
        {
                RadioModeType.FM,
                RadioModeType.PSK,
                RadioModeType.RTTY,
                RadioModeType.DIGITALVOICE,
        };

    public static RadioModeType[] AmFmModes =>
        new[]
        {
                RadioModeType.FM,
                RadioModeType.AM,
        };

    public static RadioModeType[] SatelliteModes =>
        new[]
        {
                RadioModeType.SATELLITES,
        };
}

public sealed class RadioModeFM : RadioMode
{
    public RadioModeFM() : base(RadioModeType.FM, RadioMode.FM) { }
}

public sealed class RadioModeCW : RadioMode
{
    public RadioModeCW() : base(RadioModeType.CW, RadioMode.CW) { }
}

public sealed class RadioModeAM : RadioMode
{
    public RadioModeAM() : base(RadioModeType.AM, RadioMode.AM) { }
}

public sealed class RadioModeSsb : RadioMode
{
    public RadioModeSsb() : base(RadioModeType.SSB, RadioMode.SSB) { }
}

public sealed class RadioModeDigitalVoice : RadioMode
{
    public RadioModeDigitalVoice() : base(RadioModeType.DIGITALVOICE, RadioMode.DIGITALVOICE) { }
}

public sealed class RadioModeRtty : RadioMode
{
    public RadioModeRtty() : base(RadioModeType.RTTY, RadioMode.RTTY) { }
}

public sealed class RadioModePsk : RadioMode
{
    public RadioModePsk() : base(RadioModeType.PSK, RadioMode.PSK) { }
}
