using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace U2.MultiRig.Tests
{
    public class HostRigTests
    {
        private static HostRig GetHostRig()
        {
            return new HostRig(1, KnownIdentifiers.U2MultiRig,
                new RigSettings(), new RigCommands());
        }

        [Theory]
        [ClassData(typeof(HostRigValidateReplyTestData))]
        public void ValidateReply(HostRigValidateReplyTestDataObject testItem)
        {
            var rig = GetHostRig();
            var isValid = rig.ValidateReply(testItem.Data, testItem.BitMask);
            Assert.Equal(testItem.IsValid, isValid);
        }
    }
}
