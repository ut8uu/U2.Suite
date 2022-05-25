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
    public class HostRigTests
    {
        private static readonly string TempPath = TestHelpers.GetLocalTempPath();
        private static readonly string TestsDirectory = Path.Combine(TempPath, nameof(RigCommandTests));
        private static readonly string IniDirectory = Path.Combine(TempPath, nameof(RigCommandTests), "INI");

        public HostRigTests()
        {
            FileSystemHelper.GetLocalFolderFunc = () => TestsDirectory;
            InitTestFolder();
        }

        public void Dispose()
        {
            InitTestFolder();
            FileSystemHelper.GetLocalFolderFunc = null;
        }

        private void InitTestFolder()
        {
            if (Directory.Exists(TestsDirectory))
            {
                Directory.Delete(TestsDirectory, recursive: true);
            }

            Directory.CreateDirectory(TestsDirectory);
            PrepareIniFiles();
        }

        private void PrepareIniFiles()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Assert.NotNull(currentDirectory);
            var sourceDirectory = Path.Combine(currentDirectory, "TestData", "RigCommand", "INI");
            Directory.CreateDirectory(IniDirectory);

            var sourceFiles = Directory.EnumerateFiles(sourceDirectory);
            foreach (var file in sourceFiles)
            {
                var destinationFileName = Path.Combine(IniDirectory, Path.GetFileName(file));
                File.Copy(file, destinationFileName, overwrite: true);
            }

            var expectedCount = Directory.EnumerateFiles(sourceDirectory).Count();
            var actualCount = Directory.EnumerateFiles(IniDirectory).Count();
            Assert.Equal(expectedCount, actualCount);
        }

        private RigCommands LoadIni(string iniFile)
        {
            var file = Path.Combine(IniDirectory, iniFile);
            var cmd = RigCommandUtilities.LoadRigCommands(file);
            Assert.NotNull(cmd);

            return cmd;
        }


        private HostRig GetHostRig()
        {
            var commands = LoadIni("IC-705.ini");
            var settings = new RigSettings
            {
                RigId = "1",
                Enabled = true,
                RigType = "IC-705",
                Port = "1",
                BaudRate = 0,
                DataBits = 0,
                Parity = 0,
                StopBits = 0,
                RtsMode = 0,
                DtrMode = 0,
                PollMs = 0,
                TimeoutMs = 0,
            };
            return new HostRig(1, KnownIdentifiers.U2MultiRig,
                settings, commands);
        }

        [Theory]
        [ClassData(typeof(HostRigValidateReplyTestData))]
        public void ValidateReply(HostRigValidateReplyTestDataObject testItem)
        {
            var rig = GetHostRig();
            if (testItem.ExceptionIsExpected)
            {
                var exception = Assert.ThrowsAny<Exception>(() => rig.ValidateReply(testItem.Data, testItem.BitMask));
                Assert.Equal(testItem.ExceptionType, exception.GetType());
            }
            else
            {
                rig.ValidateReply(testItem.Data, testItem.BitMask);
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
