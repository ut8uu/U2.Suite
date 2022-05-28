using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using U2.Core;
using U2.MultiRig.Code;
using U2.MultiRig.Utils;
using U2.Tests.Common;
using Xunit;

namespace U2.MultiRig.Tests;

public abstract class RigTestsBase
{
    private static readonly string TempPath = TestHelpers.GetLocalTempPath();
    private static readonly string TestsDirectory = Path.Combine(TempPath, nameof(RigTestsBase));
    private static readonly string IniDirectory = Path.Combine(TempPath, nameof(RigTestsBase), "INI");

    protected RigTestsBase()
    {
        FileSystemHelper.GetLocalFolderFunc = () => TestsDirectory;
        InitTestFolder();

        MultiRigApplicationContext.Instance.Builder
            .Register(c => new IcomIC705SerialPortEmulator())
            .As<IRigSerialPort>();
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

    protected HostRig GetHostRig()
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

    protected GuestRig GetGuestRig()
    {
        return new GuestRig(1, KnownIdentifiers.U2Logger);
    }
}
