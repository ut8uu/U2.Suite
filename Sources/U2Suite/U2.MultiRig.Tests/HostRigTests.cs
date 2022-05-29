using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using U2.Core;
using U2.Tests.Common;
using Xunit;

namespace U2.MultiRig.Tests
{
    public class HostRigTests : RigTestsBase
    {
        [Theory]
        [ClassData(typeof(HostRigValidateReplyTestData))]
        public void ValidateReply(HostRigValidateReplyTestDataObject testItem)
        {
            if (testItem.ExceptionIsExpected)
            {
                var exception = Assert.ThrowsAny<Exception>(() => HostRig.ValidateReply(testItem.Data, testItem.BitMask));
                Assert.Equal(testItem.ExceptionType, exception.GetType());
            }
            else
            {
                HostRig.ValidateReply(testItem.Data, testItem.BitMask);
            }
            
        }

        [Theory]
        [ClassData(typeof(HostRigProcessInitReplyTestData))]
        public void ProcessInitReply(HostRigProcessInitReplyTestDataObject testItem)
        {
            var rig = GetHostRig();
            if (testItem.ExceptionIsExpected)
            {
                var exception = Assert.ThrowsAny<Exception>(() => rig.ProcessInitReply(testItem.CommandIndex, testItem.Data));
                Assert.Equal(testItem.ExceptionType, exception.GetType());
            }
            else
            {
                rig.ProcessInitReply(testItem.CommandIndex, testItem.Data);
            }
        }

        [Theory]
        [ClassData(typeof(HostRigProcessStatusReplyTestData))]
        public void ProcessStatusReply(HostRigProcessStatusReplyTestDataObject testItem)
        {
            var rig = GetHostRig();
            if (testItem.ExceptionIsExpected)
            {
                var exception = Assert.ThrowsAny<Exception>(() => rig.ProcessStatusReply(testItem.CommandIndex, testItem.Data));
                Assert.Equal(testItem.ExceptionType, exception.GetType());
            }
            else
            {
                rig.ProcessStatusReply(testItem.CommandIndex, testItem.Data);
            }
        }
    }
}
