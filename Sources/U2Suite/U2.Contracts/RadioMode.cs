﻿using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace U2.Contracts
{
    public enum RadioModeType
    {
        CW,
        SSB,
        PSK,
        RTTY,
        FM,
        DIGITALVOICE,
    }

    public abstract class RadioMode
    {
        public const string CW = nameof(CW);
        public const string SSB = nameof(SSB);
        public const string RTTY = nameof(RTTY);
        public const string FM = nameof(FM);
        public const string DIGITALVOICE = nameof(DIGITALVOICE);
        public const string PSK = nameof(PSK);

        public RadioModeType Type { get; }
        public string Name { get; }

        public RadioMode(RadioModeType type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    public sealed class RadioModeFM : RadioMode
    {
        public RadioModeFM() : base(RadioModeType.FM, RadioMode.FM) { }
    }

    public sealed class RadioModeCW : RadioMode
    {
        public RadioModeCW() : base(RadioModeType.CW, RadioMode.CW) { }
    }

    public sealed class RadioModeSSB : RadioMode
    {
        public RadioModeSSB() : base(RadioModeType.SSB, RadioMode.SSB) { }
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
}