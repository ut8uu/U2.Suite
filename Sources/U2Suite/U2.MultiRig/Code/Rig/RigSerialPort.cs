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

using MonoSerialPort;

namespace U2.MultiRig.Code;

public sealed class RigSerialPort : IRigSerialPort
{
    private readonly SerialPortInput _serialPort;

    public RigSerialPort()
    {
            _serialPort = CreateSerialPort(_rigSettings);
            _serialPort.ConnectionStatusChanged += SerialPort_ConnectionStatusChanged;
            _serialPort.MessageReceived += SerialPort_MessageReceived;

            _connectivityTimer = new Timer(ConnectivityTimerCallbackFunc);
            DisableConnectivityTimer();
            _timeoutTimer = new Timer(TimeoutTimerCallbackFunc);
            DisableTimeoutTimer();

    }
}