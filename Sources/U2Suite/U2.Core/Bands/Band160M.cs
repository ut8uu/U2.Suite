using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band160M : RadioBand
    {
        public Band160M()
        {
            Name = RadioBandName.B160m;
            BeginMhz = 1.810;
            EndMhz = 2.000;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B160m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 1.8100,
                    EndMhz = 1.8380,
                    Modes = new[] {RadioModeType.CW}
                },
                new SubBand
                {
                    BeginMhz = 1.8380,
                    EndMhz = 1.840,
                    Modes = new[] {RadioModeType.CW, RadioModeType.PSK, RadioModeType.RTTY,}
                },
                new SubBand
                {
                    BeginMhz = 1.840,
                    EndMhz = 2.000,
                    Modes = new[]
                    {
                        RadioModeType.CW, RadioModeType.PSK, RadioModeType.DIGITALVOICE, 
                        RadioModeType.FM, RadioModeType.RTTY, RadioModeType.SSB,
                    }
                },
            };
        }
    }
}