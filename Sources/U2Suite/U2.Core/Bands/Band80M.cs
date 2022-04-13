using System.Collections.Generic;
using U2.Contracts;

namespace U2.Core;

public class Band80M : RadioBand
{
    public Band80M()
    {
        Name = RadioBandName.B80m;
        BeginMhz = 3.500m;
        EndMhz = 3.800m;
        Group = RadioBandGroup.HF;
        Type = RadioBandType.B80m;
        SubBands = new List<SubBand>
        {
            new SubBand
            {
                BeginMhz = 3.500m,
                EndMhz = 3.570m,
                Modes = new[] {RadioModeType.CW}
            },
            new SubBand
            {
                BeginMhz = 3.570m,
                EndMhz = 3.600m,
                Modes = new[] {RadioModeType.CW, RadioModeType.PSK, RadioModeType.RTTY,}
            },
            new SubBand
            {
                BeginMhz = 3.600m,
                EndMhz = 3.800m,
                Modes = new[]
                {
                    RadioModeType.CW, RadioModeType.PSK, RadioModeType.DIGITALVOICE,
                    RadioModeType.FM, RadioModeType.RTTY, RadioModeType.SSB,
                }
            },
        };
    }
}
