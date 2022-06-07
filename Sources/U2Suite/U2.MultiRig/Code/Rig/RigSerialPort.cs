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

using ColorTextBlock.Avalonia;
using log4net;
using MonoSerialPort;
using MonoSerialPort.Port;
using U2.Core;

namespace U2.MultiRig.Code;

public delegate void SerialPortMessageReceivedEventHandler(object sender, SerialPortMessageReceivedEventArgs eventArgs);

public class SerialPortMessageReceivedEventArgs
{
    public SerialPortMessageReceivedEventArgs(byte[] data)
    {
        Data = data;
    }

    public byte[] Data { get; private set; }
}

public sealed class RigSerialPort : IRigSerialPort
{
    private RigSettings _rigSettings;
    private SerialPortInput _serialPort;
    private readonly ILog _logger = LogManager.GetLogger(typeof(RigSerialPort));
    private bool _logDebugEnabled = true;

    public event SerialPortMessageReceivedEventHandler SerialPortMessageReceived;

    private static readonly StopBits[] StopBits =
    {
        MonoSerialPort.Port.StopBits.One,
        MonoSerialPort.Port.StopBits.OnePointFive,
        MonoSerialPort.Port.StopBits.Two
    };
    private static readonly Parity[] Parities =
    {
        Parity.None,
        Parity.Odd,
        Parity.Even,
        Parity.Mark,
        Parity.Space
    };

    public RigSerialPort()
    {
        MessageDisplayModes = MessageDisplayModes.Error 
            | MessageDisplayModes.Warning
            | MessageDisplayModes.Info;
    }

    public event SerialPortInput.ConnectionStatusChangedEventHandler ConnectionStatusChanged;

    public RigSettings RigSettings
    {
        get => _rigSettings;
        set
        {
            _rigSettings = value;
            _serialPort = CreateSerialPort(_rigSettings);
            _serialPort.ConnectionStatusChanged += SerialPort_ConnectionStatusChanged;
            _serialPort.MessageReceived += SerialPort_MessageReceived;
        }
    }

    public MessageDisplayModes MessageDisplayModes { get; set; }
    public bool IsConnected => _serialPort?.IsConnected ?? false;
    public void Disconnect()
    {
        _serialPort.Disconnect();
    }

    public bool Connect()
    {
        return _serialPort.Connect();
    }

    public void SendMessage(byte[] data)
    {
        DisplayMessage(MessageDisplayModes.Debug, $"Sending data to rig: {ByteFunctions.BytesToHex(data)}");
        _serialPort.SendMessage(data);
    }

    private SerialPortInput CreateSerialPort(RigSettings rigSettings)
    {
        return new SerialPortInput(_rigSettings.Port,
            baudRate: ComPortStuff.BaudRates[rigSettings.BaudRate],
            parity: Parities[rigSettings.Parity],
            dataBits: ComPortStuff.DataBits[rigSettings.DataBits],
            stopBits: StopBits[_rigSettings.StopBits],
            handshake: Handshake.None,
            isVirtualPort: false);
    }

    #region Event handlers

    private void SerialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
    {
        DisplayMessage(MessageDisplayModes.Debug, $"Received message: {ByteFunctions.BytesToHex(args.Data)}");
        OnSerialPortMessageReceived(new SerialPortMessageReceivedEventArgs(args.Data));
    }

    private void SerialPort_ConnectionStatusChanged(object sender, ConnectionStatusChangedEventArgs args)
    {
        var state = args.Connected ? "Connected" : "Disconnected";
        _logger.Info($"Connection state changed to: {state}");

        OnConnectionStatusChanged(args);
    }

    void OnConnectionStatusChanged(ConnectionStatusChangedEventArgs args)
    {
        ConnectionStatusChanged?.Invoke(this, args);
    }


    #endregion

    private void OnSerialPortMessageReceived(SerialPortMessageReceivedEventArgs eventargs)
    {
        SerialPortMessageReceived?.Invoke(this, eventargs);
    }

    private void LogDebug(string message)
    {
        if (_logDebugEnabled)
        {
            _logger.Debug(message);
        }
    }

    private void DisplayMessage(MessageDisplayModes messageMode, string message)
    {
        if (MessageDisplayModes == MessageDisplayModes.All || MessageDisplayModes.HasFlag(messageMode))
        {
            Console.WriteLine(message);

            if (MessageDisplayModes.HasFlag(MessageDisplayModes.Diagnostics1)
                || MessageDisplayModes.HasFlag(MessageDisplayModes.Diagnostics2)
                || MessageDisplayModes.HasFlag(MessageDisplayModes.Diagnostics3)
                || MessageDisplayModes.HasFlag(MessageDisplayModes.Debug)
               )
            {
                LogDebug(message);
            }
            else if (MessageDisplayModes.HasFlag(MessageDisplayModes.Error))
            {
                _logger.Error(message);
            }
            else if (MessageDisplayModes.HasFlag(MessageDisplayModes.Warning))
            {
                _logger.Warn(message);
            }
            else if (MessageDisplayModes.HasFlag(MessageDisplayModes.Info))
            {
                _logger.Info(message);
            }
        }
    }
}