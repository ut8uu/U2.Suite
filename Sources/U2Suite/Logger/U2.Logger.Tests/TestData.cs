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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Contracts;

namespace U2.Logger.Tests
{
    internal class TestData
    {
        public static IEnumerable<LogRecordDbo> GetLogRecords()
        {
            var expectedDate = DateTime.UtcNow;

            return new List<LogRecordDbo>
            {
                new LogRecordDbo
                {
                    Band = RadioBandName.B40m,
                    Callsign = "UT2AB",
                    Frequency = 7.023m,
                    Mode = RadioMode.CW,
                    Operator = "UT8UU",
                    RecordId = Guid.NewGuid(),
                    RstReceived = "599",
                    RstSent = "589",
                    QsoEndTimestamp = expectedDate,
                },
                new LogRecordDbo
                {
                    Band = RadioBandName.B20m,
                    Callsign = "ON4ON",
                    Frequency = 14.223m,
                    Mode = RadioMode.SSB,
                    Operator = "UT8UU",
                    RecordId = Guid.NewGuid(),
                    RstReceived = "579",
                    RstSent = "569",
                    QsoEndTimestamp = expectedDate.AddMinutes(1),
                },
                new LogRecordDbo
                {
                    Band = RadioBandName.B17m,
                    Callsign = "N1MM",
                    Frequency = 18.160m,
                    Mode = RadioMode.RTTY,
                    Operator = "UT8UU",
                    RecordId = Guid.NewGuid(),
                    RstReceived = "559",
                    RstSent = "549",
                    QsoEndTimestamp = expectedDate.AddMinutes(2),
                },
            };
        }
    }
}
