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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using U2.Core;
using U2.MultiRig.Code;

namespace U2.MultiRig.Emulators;

public abstract class RigSerialPortEmulatorBase : IRigSerialPort
{
    public event SerialPortMessageReceivedEventHandler SerialPortMessageReceived;
    private readonly RigCommands _rigCommands;
    private readonly Queue<string> _reportQueue = new();

    protected RigSerialPortEmulatorBase(string iniFileContent)
    {
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(iniFileContent));
        _rigCommands = RigCommandUtilities.LoadRigCommands(stream, "IC-705");
    }

    public bool IsConnected { get; private set; }
    public RigSettings RigSettings { get; set; }
    public MessageDisplayModes MessageDisplayModes { get; set; }

    private void DisplayMessage(MessageDisplayModes messageMode, string message)
    {
        if (MessageDisplayModes.HasFlag(messageMode))
        {
            Console.WriteLine(message);
        }
    }

    public void Start()
    {
        IsConnected = true;
    }

    public void Stop()
    {
        IsConnected = false;
    }

    public bool Connect()
    {
        IsConnected = true;
        return true;
    }

    public void SendMessage(byte[] data)
    {
        var str = ByteFunctions.BytesToHex(data);
        DisplayMessage(MessageDisplayModes.Debug, $"Sending message: {str}");

        // Init commands
        foreach (var command in _rigCommands.InitCmd)
        {
            if (command.Code.SequenceEqual(data))
            {
                ReportMessageReceivedAsync(ByteFunctions.BytesToHex(command.Validation.Flags));
                return;
            }
        }

        // Status commands
        var statusCommand = _rigCommands.StatusCmd
            .FirstOrDefault(c => c.Code.SequenceEqual(data));

        if (statusCommand != null)
        {
            // in the case of the Status command we have to inject
            // the actual value of the parameter
            if (RigEmulatorBase.Instance.TryPrepareResponse(statusCommand, out var response))
            {
                ReportMessageReceivedAsync(ByteFunctions.BytesToHex(response));
                return;
            }
            Debug.Fail($"Processing the status command for {statusCommand.Values[0].Param} failed.");
        }

        // Write commands
        foreach (var writeCommand in _rigCommands.WriteCmd)
        {
            if (RigEmulatorBase.Instance.TryExtractValue(_rigCommands, request: data))
            {
                var parameter = (RigParameter) writeCommand.Key;
                if (RigEmulatorBase.Instance.TryPrepareWriteCommandResponse(parameter, writeCommand.Value, out var response))
                {
                    ReportMessageReceivedAsync(ByteFunctions.BytesToHex(response));
                    return;
                }
                Debug.Fail($"Processing the write command for {writeCommand.Value.Values[0].Param} failed.");
            }
        }

        DisplayMessage(MessageDisplayModes.Error, $"A message {str} not recognized.");
        //throw new ArgumentException($"A message '{str}' was not recognized.");
    }

    private async Task ReportMessageReceivedAsync(string hexMessage)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(100));

        var data = ByteFunctions.HexStrToBytes(hexMessage);
        DisplayMessage(MessageDisplayModes.Diagnostics3, $"Reporting {hexMessage} back.");
        OnSerialPortMessageReceived(new SerialPortMessageReceivedEventArgs(data));
    }

    private void OnSerialPortMessageReceived(SerialPortMessageReceivedEventArgs eventargs)
    {
        SerialPortMessageReceived?.Invoke(this, eventargs);
    }
}