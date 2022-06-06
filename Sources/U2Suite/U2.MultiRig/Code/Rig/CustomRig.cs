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
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using log4net;
using U2.Core;
using U2.MultiRig.Code;
using U2.MultiRig.Code.UDP;

namespace U2.MultiRig;

public enum RigCtlStatus
{
    NotConfigured, Disabled, PortBusy, NotResponding, OnLine
}

#nullable disable
public abstract class CustomRig : IDisposable
{
    private readonly RigControlType _rigControlType;
    protected readonly ushort ApplicationId;
    protected RigUdpMessenger UdpMessenger;
    protected CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    protected bool _online = false;
    protected RigParameter LastWrittenMode = RigParameter.None;
    private bool _logDebugEnabled = true;

    private static readonly object GetStatusLockObject = new();

    public int RigNumber { get; set; } = 0;

    protected CustomRig(RigControlType rigControlType, int rigNumber, ushort applicationId)
    {
        RigNumber = rigNumber;
        _rigControlType = rigControlType;
        ApplicationId = applicationId;

        UdpMessenger = new RigUdpMessenger(rigControlType, _cancellationTokenSource.Token);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        LogDebug("Disposing");

        Stop();

        UdpMessenger.Dispose();
    }

    #region Properties

    public virtual MessageDisplayModes MessageDisplayModes { get; set; }

    public bool Enabled { get; set; }

    public RigCtlStatus Status => GetStatus();

    public int Freq
    {
        get => _freq;
        set => SetFreq(value);
    }

    public int FreqA
    {
        get => _freqA;
        set => SetFreqA(value);
    }

    public int FreqB
    {
        get => _freqB;
        set => SetFreqB(value);
    }

    public int Pitch
    {
        get => _pitch;
        set => SetPitch(value);
    }

    public int RitOffset
    {
        get => _ritOffset;
        set => SetRitOffset(value);
    }

    public RigParameter Vfo
    {
        get => _vfo;
        set => SetVfo(value);
    }

    public RigParameter Split
    {
        get => GetSplit();
        set => SetSplit(value);
    }

    public RigParameter Rit
    {
        get => _rit;
        set => SetRit(value);
    }

    public RigParameter Xit
    {
        get => _xit;
        set => SetXit(value);
    }

    public RigParameter Tx
    {
        get => _tx;
        set => SetTx(value);
    }

    public RigParameter Mode
    {
        get => _mode;
        set => SetMode(value);
    }

    #endregion

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

    protected void DisplayMessage(MessageDisplayModes messageMode, string message)
    {
        if (MessageDisplayModes.HasFlag(messageMode))
        {
            Console.WriteLine(message);
        }
    }

    private RigCtlStatus GetStatus()
    {
        lock (GetStatusLockObject)
        {
            if (_rigControlType == RigControlType.Guest)
            {
                return RigCtlStatus.OnLine;
            }
            if (!Enabled)
            {
                return RigCtlStatus.Disabled;
            }
            if (!IsConnected())
            {
                return RigCtlStatus.PortBusy;
            }
            if (!_online)
            {
                return RigCtlStatus.NotResponding;
            }
            return RigCtlStatus.OnLine;
        }
    }

    protected virtual bool IsConnected()
    {
        return false;
    }

    #region Setters

    public virtual void SetFreq(int value)
    {
        _freq = value;
    }

    public virtual void SetFreqA(int value)
    {
        _freqA = value;
    }

    public virtual void SetFreqB(int value)
    {
        _freqB = value;
    }

    public virtual void SetRitOffset(int value)
    {
        _ritOffset = value;
    }

    public virtual void SetPitch(int value)
    {
        _pitch = value;
    }

    public virtual void SetVfo(RigParameter value)
    {
        _vfo = value;
    }

    public virtual void SetSplit(RigParameter value)
    {
        _split = value;   
    }

    public virtual void SetRit(RigParameter value)
    {
        _rit = value;
    }

    public virtual void SetXit(RigParameter value)
    {
        _xit = value;
    }

    public virtual void SetTx(RigParameter value)
    {
        _tx = value;
    }

    public virtual void SetMode(RigParameter value)
    {
        _mode = value;
    }

    #endregion

    private RigParameter GetSplit()
    {
        if (_split != RigParameter.None)
        {
            return _split;
        }
        if (new[] { RigParameter.VfoAA, RigParameter.VfoBB }.Contains(Vfo))
        {
            _split = RigParameter.SplitOff;
        }
        else if (new[] { RigParameter.VfoAB, RigParameter.VfoBA }.Contains(Vfo))
        {
            _split = RigParameter.SplitOn;
        }
        return _split;
    }

    public abstract void Start();

    public abstract void Stop();

    protected virtual ILog GetLogger()
    {
        return LogManager.GetLogger(typeof(CustomRig));
    }

    private void LogDebug(string message)
    {
        if (_logDebugEnabled)
        {
            GetLogger().Debug(message);
        }
    }

}
#nullable restore