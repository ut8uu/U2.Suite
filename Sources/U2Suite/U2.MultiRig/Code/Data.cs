using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig.Code
{
    public static class Data
    {
        public static readonly int[] BaudRates = {
            110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 56000,
            57600, 115200, 128000, 256000,
        };

        public static readonly int[] DataBits = {5, 6, 7, 8};
        public static readonly decimal[] StopBits = {1m, 1.5m, 2m};

        public enum Parity
        {
            None,
            Odd,
            Even,
            Mark,
            Space,
        }

        public enum RtsMode
        {
            High,
            Low,
            Handshake,
        }

        public enum DtrMode
        {
            High,
            Low,
        }
    }
}
