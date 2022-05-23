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
using System.Globalization;
using System.Runtime.InteropServices;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using U2.MultiRig.Code;
using log4net;
using U2.Core;
using System.Reflection.Metadata;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace U2.MultiRig;

public delegate void RigParameterChangedEventHandler(object sender, int rigNumber,
    RigParameter parameter, object value);

public delegate void UdpPacketReceivedEventHandler(object sender, RigUdpMessengerPacketEventArgs eventArgs);

public enum RigControlType
{
    Host,
    Guest,
}

public abstract class Rig : CustomRig
{
    protected readonly ILog _logger = LogManager.GetLogger(typeof(Rig));
    protected readonly List<RigParameter> _changedParams = new();

    protected Rig(RigControlType rigControlType, int rigNumber, RigSettings settings, RigCommands rigCommands) 
        : base(rigControlType, rigNumber, settings, rigCommands)
    {
    }

    public event UdpPacketReceivedEventHandler UdpPacketReceived;

    protected virtual void OnUdpPacketReceived(RigUdpMessengerPacketEventArgs eventArgs)
    {
        UdpPacketReceived?.Invoke(this, eventArgs);
    }
}

public sealed class RigUdpMessengerPacketEventArgs
{
    public RigUdpMessengerPacket Packet { get; init; }
    public IPEndPoint RemoteEndpoint { get; init; }
}