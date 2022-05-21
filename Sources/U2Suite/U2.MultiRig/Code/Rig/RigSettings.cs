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

using DynamicData;
using U2.MultiRig.Code;

namespace U2.MultiRig;

public class RigSettings
{
    public RigSettings()
    {
        BaudRate = Data.BaudRates.IndexOf(9600);
        DataBits = Data.DataBits.IndexOf(8);
        StopBits = Data.StopBits.IndexOf(1m);

        Enabled = true;
    }

    public string RigId { get; set; } = string.Empty;
    public bool Enabled { get; set; } = false;
    public string RigType { get; set; } = "";
    public string Port { get; set; } = "";
    public int BaudRate { get; set; }
    public int DataBits { get; set; }
    public int Parity { get; set; } = 0;
    public int StopBits { get; set; }
    public int RtsMode { get; set; } = 0;
    public int DtrMode { get; set; } = 0;
    public int PollMs { get; set; } = 500;
    public int TimeoutMs { get; set; } = 3000;
}
