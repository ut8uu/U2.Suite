using Avalonia.Markup.Xaml.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Xunit;

namespace U2.MultiRig.Tests;

public class Ic705SerialPortEmulatorInitCommandTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var iniDirectory = Path.Combine(currentDirectory, "TestData", "RigCommand", "INI");
        Assert.True(Directory.Exists(iniDirectory));
        var ic705IniFile = Path.Combine(iniDirectory, "IC-705.ini");
        Assert.True(File.Exists(ic705IniFile));
        var ic705Commands = RigCommandUtilities.LoadRigCommands(ic705IniFile);
        Assert.NotNull(ic705Commands);

        var testData = new[]
        {
            InitCommand(ic705Commands, index: 0),
            InitCommand(ic705Commands, index: 1),
            InitCommand(ic705Commands, index: 2),
        };

        return testData.Select(td => new[] { td })
            .GetEnumerator();
    }

    private Ic705SerialPortEmulatorInitCommandTestDataObject InitCommand(RigCommands ic705Commands, int index)
    {
        return new Ic705SerialPortEmulatorInitCommandTestDataObject()
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueLoadException),
            RigCommand = ic705Commands.InitCmd[index],
        };
    }

    private RigCommandTestsParseValueTestDataObject InvalidStringIncorrectValueFormat()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(FormatParseException),
            Value = "1|2|vfTextus|1|pmFreqA",
            ExpectedParameterValue = new ParameterValue(),
        };
    }

    private RigCommandTestsParseValueTestDataObject InvalidStringFourElements()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = true,
            ExceptionType = typeof(ValueLoadException),
            Value = "1|2|vfText|1",
            ExpectedParameterValue = new ParameterValue(),
        };
    }

    private RigCommandTestsParseValueTestDataObject ValidStringFiveElements()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = false,
            ExceptionType = null,
            Value = "1|2|vfText|1|0",
            ExpectedParameterValue = new ParameterValue
            {
                Add = 0,
                Mult = 1,
                Format = ValueFormat.Text,
                Param = RigParameter.None,
                Start = 1,
                Len = 2,
            }
        };
    }

    private RigCommandTestsParseValueTestDataObject ValidStringSixElements()
    {
        return new RigCommandTestsParseValueTestDataObject()
        {
            ExceptionIsExpected = false,
            ExceptionType = null,
            Value = "1|2|vfText|1|0|pmFreqA",
            ExpectedParameterValue = new ParameterValue
            {
                Add = 0,
                Mult = 1,
                Format = ValueFormat.Text,
                Param = RigParameter.FreqA,
                Start = 1,
                Len = 2,
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}