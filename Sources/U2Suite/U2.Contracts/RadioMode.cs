using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Contracts
{
    public enum RadioModeType
    {
        CW,
        SSB,
        DIGI,
        RTTY,
        FM,
        DIGIVOICE,
    }

    public abstract class RadioMode
    {
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
        public RadioModeFM() : base(RadioModeType.FM, "FM") { }
    }

    public sealed class RadioModeCW : RadioMode
    {
        public RadioModeCW() : base(RadioModeType.CW, "CW") { }
    }

    public sealed class RadioModeSSB : RadioMode
    {
        public RadioModeSSB() : base(RadioModeType.SSB, "SSB") { }
    }

    public sealed class RadioModeDigivoice : RadioMode
    {
        public RadioModeDigivoice() : base(RadioModeType.DIGIVOICE, "DIGIVOICE") { }
    }

    public sealed class RadioModeRtty : RadioMode
    {
        public RadioModeRtty() : base(RadioModeType.RTTY, "RTTY") { }
    }
}
