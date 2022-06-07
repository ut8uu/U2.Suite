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
            guestRig.Enabled = true;
            guestRig.UdpPacketReceived += (sender, args) => packetReceived = true;
            guestRig.Start();
            
            var hostRig = GetHostRig();
            hostRig.Enabled = true;
            hostRig.Start();

            var task = Task.Run(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                hostRig.FreqA = 1234567;
                while (!packetReceived)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
            });

            task.Wait();//TimeSpan.FromSeconds(5));

            hostRig.Enabled = false;
            hostRig.Stop();

            guestRig.Enabled = false;
            guestRig.Stop();

            Assert.Equal(hostRig.FreqA, guestRig.FreqA);
            Assert.True(packetReceived, "Packet was not received.");
        }
    }
}
