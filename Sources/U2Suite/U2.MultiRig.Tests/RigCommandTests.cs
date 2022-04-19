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
            Assert.True(AllRigCommands.TryLoadRigCommands(file, out var cmd));
            Assert.Equal(3, cmd.StatusCmd.Count);
        }

        [Fact]
        public void LoadRigCommands()
        {
            AllRigCommands.LoadRigCommands();
            Assert.Equal(2, AllRigCommands.RigCommands.Count);
        }
    }
}
