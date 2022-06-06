using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace U2.MultiRig.Tests
{
    public class RigTests : RigTestsBase
    {
        /// <summary>
        /// This is to test the passing information about
        /// changed rig parameter on HostRig and reflected
        /// on GuestRig.
        /// </summary>
        [Fact]
        public void ParameterSettingFromHostToGuest()
        {
            var packetReceived = false;
            var guestRig = GetGuestRig();
            guestRig.UdpPacketReceived += (sender, args) => packetReceived = true;
            
            var hostRig = GetHostRig();

            var task = Task.Run(() =>
            {
                hostRig.FreqA = 1234567;

                while (!packetReceived)
                {
                    
                }
            });

            task.Wait(CancellationToken.None);

            Assert.Equal(hostRig.FreqA, guestRig.FreqA);
        }
    }
}
