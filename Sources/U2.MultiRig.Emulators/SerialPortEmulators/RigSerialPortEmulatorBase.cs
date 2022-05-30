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
using U2.MultiRig.Code;

namespace U2.MultiRig.Emulators
{
    public abstract class RigSerialPortEmulatorBase : IRigSerialPort
    {
        public bool IsConnected { get; }
        public RigSettings RigSettings { get; set; }
        public event SerialPortMessageReceivedEventHandler SerialPortMessageReceived;
        private RigCommands _rigCommands;

        public RigSerialPortEmulatorBase(string iniFileContent)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(iniFileContent));
            _rigCommands = RigCommandUtilities.LoadRigCommands(stream, "IC-705");
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public bool Connect()
        {
            return true;
        }

        public void SendMessage(byte[] data)
        {
            var str = ByteFunctions.BytesToHex(data);

            foreach (var command in _rigCommands.InitCmd)
            {
                if (command.Code.SequenceEqual(data))
                {
                    ReportMessageReceived(ByteFunctions.BytesToHex(command.Validation.Flags));
                    return;
                }
            }

            foreach (var command in _rigCommands.StatusCmd)
            {
                if (command.Code.SequenceEqual(data))
                {
                    var resultData = command.Validation.Flags;
                    // inject the actual value here

                    ReportMessageReceived(ByteFunctions.BytesToHex(resultData));
                    return;
                }
            }

            throw new ArgumentException($"A message '{str}' was not recognized.");
        }

        private void ReportMessageReceived(string hexMessage)
        {
            var data = ByteFunctions.HexStrToBytes(hexMessage);
            OnSerialPortMessageReceived(new SerialPortMessageReceivedEventArgs(data));
        }

        private void OnSerialPortMessageReceived(SerialPortMessageReceivedEventArgs eventargs)
        {
            SerialPortMessageReceived?.Invoke(this, eventargs);
        }
    }
}
