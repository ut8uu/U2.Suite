/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

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
using U2.MultiRig.Emulators;
using U2.MultiRig.Utils;
using U2.Tests.Common;
using Xunit;

namespace U2.MultiRig.Tests;

public abstract class RigTestsBase
{
    protected static readonly string TempPath = TestHelpers.GetLocalTempPath();
    protected static readonly string TestsDirectory = Path.Combine(TempPath, nameof(RigTestsBase));
    protected static readonly string IniDirectory = Path.Combine(TempPath, nameof(RigTestsBase), "INI");

    protected IRigEmulator Emulator;

    protected RigTestsBase()
    {
        FileSystemHelper.GetLocalFolderFunc = () => TestsDirectory;
        InitTestFolder();

        MultiRigApplicationContext.Instance.ResetBuilder();
        IC705Emulator.Register();
        MultiRigApplicationContext.Instance.BuildContainer();
        Emulator = RigEmulatorBase.Instance;
    }

    public void Dispose()
    {
        InitTestFolder();
        FileSystemHelper.GetLocalFolderFunc = null;
    }

    protected void InitTestFolder()
    {
        if (Directory.Exists(TestsDirectory))
        {
            Directory.Delete(TestsDirectory, recursive: true);
        }

        Directory.CreateDirectory(TestsDirectory);
        PrepareIniFiles();
    }

    protected void PrepareIniFiles()
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

    protected RigCommands LoadIni(string iniFile)
    {
        var file = Path.Combine(IniDirectory, iniFile);
        var cmd = RigCommandUtilities.LoadRigCommands(file);
        Assert.NotNull(cmd);

        return cmd;
    }

    protected RigCommands LoadIC705Ini()
    {
        return LoadIni("IC-705.ini");
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
            settings, commands)
        {
            Enabled = true,
        };
    }

    protected GuestRig GetGuestRig()
    {
        return new GuestRig(1, KnownIdentifiers.U2Logger)
        {
            Enabled = true,
        };
    }
}
