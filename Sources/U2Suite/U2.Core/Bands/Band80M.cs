using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core
{
    public class Band80M : RadioBand
    {
        public Band80M()
        {
            Name = RadioBandName.B80m;
            BeginMhz = 3.500;
            EndMhz = 3.800;
            Group = RadioBandGroup.HF;
            Type = RadioBandType.B80m;
            SubBands = new List<SubBand>
            {
                new SubBand
                {
                    BeginMhz = 3.500,
                    EndMhz = 3.570,
                    Modes = new[] {RadioModeType.CW}
                },
                new SubBand
                {
                    BeginMhz = 3.570,
                    EndMhz = 3.600,
                    Modes = new[] {RadioModeType.CW, RadioModeType.PSK, RadioModeType.RTTY,}
                },
                new SubBand
                {
                    BeginMhz = 3.600,
                    EndMhz = 3.800,
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