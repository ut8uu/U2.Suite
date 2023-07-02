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
using System.ComponentModel.DataAnnotations;

namespace U2.Logger;

public class LogRecordDbo
{
    private string _hash = string.Empty;
    private string mode = string.Empty;
    private string callsign = string.Empty;
    private DateTime timestamp;
    private string band = string.Empty;

    public LogRecordDbo()
    {
        RecordId = Guid.NewGuid();
    }

    [Key]
    [StringLength(36)]
    public Guid RecordId { get; set; }
    [StringLength(50)]
    public string Callsign
    {
        get => callsign;
        set
        {
            callsign = value;
            ResetHash();
        }
    }
    public DateTime QsoBeginTimestamp { get; set; }
    public DateTime QsoEndTimestamp
    {
        get => timestamp;
        set
        {
            timestamp = value;
            ResetHash();
        }
    }
    public decimal Frequency { get; set; }
    [StringLength(8)]
    public string RstSent { get; set; } = string.Empty;
    [StringLength(8)]
    public string Mode
    {
        get => mode;
        set
        {
            mode = value;
            ResetHash();
        }
    }
    [StringLength(16)]
    public string Band
    {
        get => band;
        set
        {
            band = value;
            ResetHash();
        }
    }
    [StringLength(8)]
    public string RstReceived { get; set; } = string.Empty;
    [StringLength(64)]
    public string Operator { get; set; } = string.Empty;
    [StringLength(128)]
    public string Comments { get; set; } = string.Empty;

    [StringLength(256)]
    public string Hash
    {
        get => _hash;
        set => _hash = value;
    }

    public void ResetHash()
    {
        _hash = $"{Callsign}{QsoEndTimestamp}{Band}{Mode}";
    }
}
