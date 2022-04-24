using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using U2.Core;
using U2.MultiRig.Code;
using U2.Tests.Common;
using Xunit;

namespace U2.MultiRig.Tests
{
    public class RigCommandTests : IDisposable
    {
        private static readonly string TempPath = TestHelpers.GetLocalTempPath();
        private static readonly string TestsDirectory = Path.Combine(TempPath, nameof(RigCommandTests));
        private static readonly string IniDirectory = Path.Combine(TempPath, nameof(RigCommandTests), "INI");

        public RigCommandTests()
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
            var currentDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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

        [Fact]
        public void Status3()
        {
            var file = Path.Combine(IniDirectory, "Status3.ini");
            var cmd = RigCommandUtilities.LoadRigCommands(file);
            Assert.NotNull(cmd);
            //Assert.True(AllRigCommands.TryLoadRigCommands(file, out var cmd));
            Assert.Equal(3, cmd.StatusCmd.Count);
        }

        [Fact]
        public void StatusWithValidateAndFlags()
        {
            var file = Path.Combine(IniDirectory, "StatusWithValidateAndFlags.ini");
            var cmd = RigCommandUtilities.LoadRigCommands(file);
            Assert.NotNull(cmd);
            var status = Assert.Single(cmd.StatusCmd);
            var value = Assert.Single(status.Values);
            Assert.Equal(5, value.Start);
            Assert.Equal(10, value.Len);
            Assert.Equal(ValueFormat.Text, value.Format);
            Assert.Equal(1, value.Mult);
            Assert.Equal(0, value.Add);
            Assert.Equal(RigParameter.Freq, value.Param);

            Assert.Equal(5, status.Flags.Count);
            var flag = status.Flags.First();
            var expectedFlagStr = "V..RF...........ST........AU..MD0...";
            for (var i = 0; i < expectedFlagStr.Length; i++)
            {
                var ch = expectedFlagStr[i];
                var b1 = (byte) ch;
                byte b2 = 0xff;
                if (ch == '.')
                {
                    b1 = 0;
                    b2 = 0;
                }
                Assert.Equal(b1, flag.Flags[i]);
                Assert.Equal(b2, flag.Mask[i]);
            }
            Assert.Equal(RigParameter.FM, flag.Param);
        }

        [Fact]
        public void LoadRigCommands()
        {
            var file = Path.Combine(IniDirectory, "ADT-200A.ini");
            var commands = RigCommandUtilities.LoadRigCommands(file);
            Assert.NotNull(commands);
            Assert.Equal(7, commands.InitCmd.Count);

            var expectedBytes = new byte[] {0x24, 0x56, 0x31, 0x3E, 0x0D};
            Assert.True(expectedBytes.SequenceEqual(commands.InitCmd.First().Code));

            Assert.Equal(3, commands.StatusCmd.Count);

            Assert.Equal(10, commands.WriteCmd.Count);
        }

        [Fact]
        public void WriteOnly1()
        {
            var file = Path.Combine(IniDirectory, "WriteOnly1.ini");
            var cmd = RigCommandUtilities.LoadRigCommands(file);
            Assert.NotNull(cmd);

            var write = Assert.Single(cmd.WriteCmd);
            Assert.NotNull(write);
            
            Assert.Equal(new byte[]{0x0D}, write.ReplyEnd);
            Assert.Equal(new byte[]{ 0x24, 0x46, 0x52, 0x31, 0x3A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0D }, write.Code);
            Assert.Equal(5, write.Value.Start);
            Assert.Equal(8, write.Value.Len);
            Assert.Equal(ValueFormat.Text, write.Value.Format);
            Assert.Equal(1, write.Value.Mult);
            Assert.Equal(0, write.Value.Add);
        }

        private void TestRigCommand(RigCommand expectedCommand, RigCommand actualCommand)
        {

        }
    }
}
