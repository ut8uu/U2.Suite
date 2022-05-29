using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.MultiRig.Code;

namespace U2.MultiRig.Utils
{
    public sealed class IcomIC705SerialPortEmulator : IRigSerialPort
    {
        public bool IsConnected { get; }
        public RigSettings RigSettings { get; set; }
        public event SerialPortMessageReceivedEventHandler SerialPortMessageReceived;
        private RigCommands _rigCommands;

        public IcomIC705SerialPortEmulator()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.IC_705));
            _rigCommands = RigCommandUtilities.LoadRigCommands(stream);
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
            // init1
            if (str == "FEFEA4E01A05013201FD")
            {
                ReportMessageReceived("FEFEA4E01A05013201FD.FEFEE0A4FBFD");
            }
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
