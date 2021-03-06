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
using System.Text;
using U2.Contracts;
using U2.Core;

namespace U2.Logger;

public class QsoData
{
    private Guid _recordId;
    private string _callsign = string.Empty;
    private string _operator = string.Empty;
    private string _rstSent = string.Empty;
    private string _rstRcvd = string.Empty;
    private DateTime _timestamp = DateTime.UtcNow;
    private string _comments = string.Empty;
    private string _band = string.Empty;
    private decimal? _freqMhz = null;
    private string _mode = string.Empty;

    public QsoData()
    {
        _recordId = Guid.NewGuid();
    }

    public QsoData(Guid recordId)
    {
        _recordId = recordId;
    }

    public string Callsign
    {
        get => _callsign;
        set
        {
            _callsign = value;
            Modified = true;
        }
    }

    public string Operator
    {
        get => _operator;
        set
        {
            _operator = value;
            Modified = true;
        }
    }

    public string Band
    {
        get => _band;
        set
        {
            _band = value;
            if (!string.IsNullOrEmpty(value) && !_freqMhz.HasValue)
            {
                try
                {
                    _freqMhz = ConversionHelper.BandNameToFrequency(value);
                }
                catch (ArgumentException)
                {
                    _freqMhz = null;
                }
            }
            Modified = true;
        }
    }

    public decimal? FreqMhz
    {
        get => _freqMhz;
        set
        {
            _freqMhz = value;
            _band = ConversionHelper.FrequencyToBandName(value.GetValueOrDefault(-1));
            Modified = true;
        }
    }

    public string Mode
    {
        get => _mode;
        set
        {
            _mode = value;
            Modified = true;
        }
    }

    public string RstSent
    {
        get => _rstSent;
        set
        {
            _rstSent = value;
            Modified = true;
        }
    }

    public string RstRcvd
    {
        get => _rstRcvd;
        set
        {
            _rstRcvd = value;
            Modified = true;
        }
    }

    public DateTime Timestamp
    {
        get => _timestamp;
        set
        {
            _timestamp = value;
            Modified = true;
        }
    }

    public string Comments
    {
        get => _comments;
        set
        {
            _comments = value;
            Modified = true;
        }
    }

    public bool Modified { get; set; }

    public Guid RecordId => _recordId;

    public void Clear()
    {
        Callsign = string.Empty;
        RstSent = string.Empty;
        RstRcvd = string.Empty;
        Timestamp = DateTime.UtcNow;
        Comments = string.Empty;
        Band = string.Empty;
        FreqMhz = null;
        Mode = string.Empty;
        _recordId = Guid.NewGuid();

        Modified = false;
    }

    public void Assign(QsoData data)
    {
        Callsign = data.Callsign;
        RstSent = data.RstSent;
        RstRcvd = data.RstRcvd;
        Timestamp = data.Timestamp;
        Comments = data.Comments;
        Mode = data.Mode;
        Band = data.Band;
        FreqMhz = data.FreqMhz;
        _recordId = data.RecordId;
    }

    public void Assign(LogRecordDbo data)
    {
        Callsign = data.Callsign;
        RstSent = data.RstSent;
        RstRcvd = data.RstReceived;
        Timestamp = data.QsoEndTimestamp;
        Comments = data.Comments;
        Mode = data.Mode;
        FreqMhz = data.Frequency;
        Band = ConversionHelper.FrequencyToBandName(data.Frequency);
        _recordId = data.RecordId;
    }

    public bool CanBeSaved()
    {
        return Modified
               && !string.IsNullOrEmpty(Callsign)
               && !string.IsNullOrEmpty(RstSent)
               && !string.IsNullOrEmpty(RstRcvd);
    }

    public new string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Callsign: {Callsign}");
        sb.AppendLine($"Timestamp: {Timestamp}");
        sb.AppendLine($"Band: {Band}");
        sb.AppendLine($"FreqMhz: {FreqMhz}");
        sb.AppendLine($"Mode: {Mode}");
        sb.AppendLine($"Operator: {Operator}");
        sb.AppendLine($"RstSent: {RstSent}");
        sb.AppendLine($"RstRcvd: {RstRcvd}");
        sb.AppendLine($"Comments: {Comments}");

        return sb.ToString();
    }
}
