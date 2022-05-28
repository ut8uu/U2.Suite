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
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public bool Connect()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(byte[] data)
        {
            throw new NotImplementedException();
        }

        private void OnSerialPortMessageReceived(SerialPortMessageReceivedEventArgs eventargs)
        {
            SerialPortMessageReceived?.Invoke(this, eventargs);
        }
    }
}
