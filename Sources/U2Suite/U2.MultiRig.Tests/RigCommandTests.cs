using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using U2.Core;
using U2.MultiRig.Code;
using U2.Tests.Common;
using Xunit;
using Assert = Xunit.Assert;

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

        #region Private methods

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

        private RigCommands LoadIni(string iniFile)
        {
            var file = Path.Combine(IniDirectory, iniFile);
            var cmd = RigCommandUtilities.LoadRigCommands(file);
            Assert.NotNull(cmd);

            return cmd;
        }

        #endregion

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
            var cmd = LoadIni("StatusWithValidateAndFlags.ini");

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
            var commands = LoadIni("ADT-200A.ini");

            Assert.Equal(7, commands.InitCmd.Count);

            var expectedBytes = new byte[] {0x24, 0x56, 0x31, 0x3E, 0x0D};
            Assert.True(expectedBytes.SequenceEqual(commands.InitCmd.First().Code));

            Assert.Equal(3, commands.StatusCmd.Count);

            Assert.Equal(10, commands.WriteCmd.Count);
        }

        [Fact]
        public void WriteOnly1()
        {
            var cmd = LoadIni("WriteOnly1.ini");

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

        [Fact]
        public void InitOnly1()
        {
            var file = Path.Combine(IniDirectory, "InitOnly1.ini");
            var cmd = RigCommandUtilities.LoadRigCommands(file);
            Assert.NotNull(cmd);

            var init = Assert.Single(cmd.InitCmd);
            Assert.NotNull(init);

            Assert.Equal(new byte[]{ 0x24, 0x56, 0x31, 0x3E, 0x0D }, init.Code);
        }

        [Theory]
        [InlineData("[pmFreq]\r\nCommand=hello")] // bad value
        [InlineData("[pmFreq]\r\nValue=4|13|vfText|1|0|pmFreqA|qww|aad")] // bad value
        [InlineData("[pmFreq]\r\nReplyEnd=asas")] // bad value
        [InlineData("[pmFreck]\r\nReplyEnd=0D")] // bad parameter name
        [InlineData("[INIT1]\r\nCommand=hello")] // bad value
        [InlineData("[STATUS1]\r\nCommand=hello")] // bad value
        [InlineData("[STATUS1]\r\nReplyEnd=asas")] // bad value
        [InlineData("[STATUS1]\r\nValue1=4|13|vfText|1|0|pmFreqA|qww")] // bad value
        [InlineData("[STATUS1]\r\nTheCommand=24.46.52.31.3F.0D")] // bad entry
        public void BadValues(string data)
        {
            var fileName = "BadValues.ini";
            var file = Path.Combine(IniDirectory, fileName);
            File.WriteAllText(file, data);
            Assert.Throws<IniFileLoadException>(() => RigCommandUtilities.LoadRigCommands(file));
        }

        [Theory]
        [ClassData(typeof(RigCommandTestsStatusRecordsData))]
        public void ReadStatusRecords(StatusTestData testData)
        {
            var fileName = "ReadStatusRecords.ini";
            var file = Path.Combine(IniDirectory, fileName);
            File.WriteAllText(file, testData.Text);

            var cmd = LoadIni(fileName);
            var statusCmd = cmd.StatusCmd.Single();
            Assert.Equal(testData.Command, statusCmd.Code);
            var value = Assert.Single(statusCmd.Values);
            Assert.Equal(testData.ParameterValue.Len, value.Len);
            Assert.Equal(testData.ParameterValue.Add, value.Add);
            Assert.Equal(testData.ParameterValue.Mult, value.Mult);
            Assert.Equal(testData.ParameterValue.Start, value.Start);
            Assert.Equal(testData.ParameterValue.Format, value.Format);
            Assert.Equal(testData.ParameterValue.Param, value.Param);

            if (testData.Flags != null && testData.Flags.Any())
            {
                Assert.Equal(testData.Flags.Length, statusCmd.Flags.Count);
                var expectedFlags = testData.Flags.First();
                var actualFlags = statusCmd.Flags.First();
                Assert.Equal(expectedFlags.Flags, actualFlags.Flags);
                Assert.Equal(expectedFlags.Mask, actualFlags.Mask);
                Assert.Equal(expectedFlags.Param, actualFlags.Param);
            }
        }

        [Theory]
        [ClassData(typeof(RigCommandTestsWriteRecordsData))]
        public void ReadWriteRecords(WriteTestData testData)
        {
            var fileName = "ReadWriteRecords.ini";
            var file = Path.Combine(IniDirectory, fileName);
            File.WriteAllText(file, testData.Text);

            var cmd = LoadIni(fileName);
            var writeCmd = cmd.WriteCmd.Single();
            Assert.Equal(testData.Command, writeCmd.Code);
            var value = writeCmd.Value;
            Assert.Equal(testData.ParameterValue.Len, value.Len);
            Assert.Equal(testData.ParameterValue.Add, value.Add);
            Assert.Equal(testData.ParameterValue.Mult, value.Mult);
            Assert.Equal(testData.ParameterValue.Start, value.Start);
            Assert.Equal(testData.ParameterValue.Format, value.Format);
            Assert.Equal(testData.ParameterValue.Param, value.Param);

            if (testData.Command != null && testData.Command.Any())
            {
                Assert.Equal(testData.Command, writeCmd.Code);
                Assert.Equal(testData.Validate, writeCmd.Validation.Flags);
                Assert.Equal(testData.ReplyLength, writeCmd.ReplyLength);
                Assert.Equal(testData.ParameterValue, writeCmd.Value);
            }
        }

        [Fact]
        public void CanReadIc705()
        {
            var cmd = LoadIni("IC-705.ini");
            Assert.Equal(3, cmd.InitCmd.Count);
            Assert.Equal(9, cmd.StatusCmd.Count);
            Assert.Equal(24, cmd.WriteCmd.Count);
        }
    }
}
