using System.Collections.Generic;

namespace U2.Contracts
{
    public enum RadioBandType
    {
        Unspecified,
        B160m,
        B80m,
        B60m,
        B50m,
        B40m,
        B30m,
        B20m,
        B17m,
        B15m,
        B12m,
        B11m,
        B10m,
        B6m,
        B4m,
        B2m,
        B70cm,
        B23cm,
    }

    public enum RadioBandGroup
    {
        Unspecified,
        MW,
        LW,
        HF,
        VHF,
        UHF
    }

    /// <summary>
    /// Represents an amateur radio band
    /// </summary>
    public abstract class RadioBand
    {
        /// <summary>
        /// A human-readable name of the band.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// An optional group of bands this band belongs to.
        /// </summary>
        public RadioBandGroup Group { get; set; }
        /// <summary>
        /// A lower boundary of the band, inclusive.
        /// </summary>
        public double BeginMhz { get; set; }
        /// <summary>
        /// A type of the band.
        /// </summary>
        public RadioBandType Type { get; set; }
        /// <summary>
        /// An upper boundary of the band, exclusive.
        /// </summary>
        public double EndMhz { get; set; }
        /// <summary>
        /// Optional collection of sub-bands.
        /// </summary>
        public List<SubBand> SubBands { get; set; }
    }

    /// <summary>
    /// Represents a sub-band of the amateur band.
    /// Can be used to automatically get the Mode using the frequency.
    /// </summary>
    public sealed class SubBand
    {
        /// <summary>
        /// A lower boundary of the band, inclusive.
        /// </summary>
        public double BeginMhz { get; set; }
        /// <summary>
        /// An upper boundary of the band, exclusive.
        /// </summary>
        public double EndMhz { get; set; }
        /// <summary>
        /// A mode allowed on this sub-band.
        /// </summary>
        public RadioModeType[] Modes { get; set; }
    }

    public static class RadioBandName
    {
        public const string B160m = "160m";
        public const string B80m = "80m";
        public const string B60m = "60m";
        public const string B40m = "40m";
        public const string B30m = "30m";
        public const string B20m = "20m";
        public const string B17m = "17m";
        public const string B15m = "15m";
        public const string B12m = "12m";
        public const string B10m = "10m";
        public const string B6m = "6m";
        public const string B4m = "4m";
        public const string B2m = "2m";
        public const string B70cm = "70cm";
    }
}