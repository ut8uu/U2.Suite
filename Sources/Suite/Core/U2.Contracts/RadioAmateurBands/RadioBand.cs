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

using System.Collections.Generic;

namespace U2.Contracts;

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
    public decimal BeginMhz { get; set; }
    /// <summary>
    /// A type of the band.
    /// </summary>
    public RadioBandType Type { get; set; }
    /// <summary>
    /// An upper boundary of the band, exclusive.
    /// </summary>
    public decimal EndMhz { get; set; }
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
    public decimal BeginMhz { get; set; }
    /// <summary>
    /// An upper boundary of the band, exclusive.
    /// </summary>
    public decimal EndMhz { get; set; }
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
