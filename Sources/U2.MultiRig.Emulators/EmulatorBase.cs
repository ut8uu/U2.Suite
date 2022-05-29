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

using System.Text;
using U2.MultiRig.Code;

namespace U2.MultiRig.Emulators;

public abstract class EmulatorBase
{
    private int _freq;
    private int _freqA;
    private int _freqB;
    private int _pitch;
    private int _ritOffset;
    private RigParameter _vfo;
    private RigParameter _rit;
    private RigParameter _xit;
    private RigParameter _tx;
    private RigParameter _mode;
    private RigParameter _split;

    protected RigSerialPortEmulatorBase SerialPortEmulator;

    protected RigCommands RigCommands;

    protected EmulatorBase(string iniFileContent)
    {
        var stream = new MemoryStream(Encoding.ASCII.GetBytes(iniFileContent));
        RigCommands = RigCommandUtilities.LoadRigCommands(stream, "IC-705");
    }

    public int Freq
    {
        get => _freq;
        set => _freq = value;
    }

    public int FreqA
    {
        get => _freqA;
        set => _freqA = value;
    }

    public int FreqB
    {
        get => _freqB;
        set => _freqB = value;
    }

    public int Pitch
    {
        get => _pitch;
        set => _pitch = value;
    }

    public int RitOffset
    {
        get => _ritOffset;
        set => _ritOffset = value;
    }

    public RigParameter Vfo
    {
        get => _vfo;
        set => _vfo = value;
    }

    public RigParameter Rit
    {
        get => _rit;
        set => _rit = value;
    }

    public RigParameter Xit
    {
        get => _xit;
        set => _xit = value;
    }

    public RigParameter Tx
    {
        get => _tx;
        set => _tx = value;
    }

    public RigParameter Mode
    {
        get => _mode;
        set => _mode = value;
    }

    public RigParameter Split
    {
        get => _split;
        set => _split = value;
    }
}
