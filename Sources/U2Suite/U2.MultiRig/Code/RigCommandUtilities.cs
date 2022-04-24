using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCircuits.IniFileParser;
using U2.Core;
using U2.MultiRig.Code;

namespace U2.MultiRig;

internal static class RigCommandUtilities
{
    public const string ReplyLength = nameof(ReplyLength);
    public const string ReplyEnd = nameof(ReplyEnd);
    public const string Command = nameof(Command);
    public const string Validate = nameof(Validate);
    public const string Value = nameof(Value);

    public static readonly RigParameter[] NumericParameters =
    {
        RigParameter.Freq,
        RigParameter.FreqA,
        RigParameter.FreqB,
        RigParameter.Pitch,
        RigParameter.RitOffset,
    };

    public static readonly RigParameter[] VfoParams =
    {
        RigParameter.VfoAA, RigParameter.VfoAB, RigParameter.VfoBA,
        RigParameter.VfoBB, RigParameter.VfoA, RigParameter.VfoB,
        RigParameter.VfoEqual, RigParameter.VfoSwap,
    };

    public static readonly RigParameter[] SplitParams = { RigParameter.SplitOn, RigParameter.SplitOff, };
    public static readonly RigParameter[] RitOnParams = { RigParameter.RitOn, RigParameter.RitOff, };
    public static readonly RigParameter[] XitOnParams = { RigParameter.XitOn, RigParameter.XitOff, };
    public static readonly RigParameter[] TxParams = { RigParameter.Rx, RigParameter.Tx, };

    public static readonly RigParameter[] ModeParams =
    {
        RigParameter.CW_U, RigParameter.CW_L, RigParameter.SSB_U, RigParameter.SSB_L,
        RigParameter.DIG_U, RigParameter.DIG_L, RigParameter.AM, RigParameter.FM,
    };

    private static readonly Type[] IniFileRelatedExceptions =
    {
        typeof(LoadInitCommandsException),
        typeof(LoadWriteCommandException),
        typeof(LoadStatusCommandsException),
    };

    public static ReadOnlyCollection<RigCommands> LoadAllRigCommands()
    {
        var list = new List<RigCommands>();
        var iniDirectory = Path.Combine(FileSystemHelper.GetLocalFolder(), "INI");
        var files = Directory.EnumerateFiles(iniDirectory, "*.ini");
        foreach (var file in files)
        {
            try
            {
                list.Add(RigCommandUtilities.LoadRigCommands(file));
            }
            catch (IniFileLoadException)
            {
#warning Log this
            }
        }

        return new ReadOnlyCollection<RigCommands>(list);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pathToIniFile"></param>
    /// <returns></returns>
    /// <exception cref="IniFileLoadException"></exception>
    public static RigCommands LoadRigCommands(string pathToIniFile)
    {
        using var stream = File.OpenRead(pathToIniFile);
        using var streamReader = new StreamReader(stream);
        var iniFile = new IniFile(StringComparer.CurrentCultureIgnoreCase);
        iniFile.Load(streamReader);

        try
        {
            var result = new RigCommands
            {
                InitCmd = LoadInitCommands(iniFile),
                StatusCmd = LoadStatusCommands(iniFile),
                WriteCmd = LoadWriteCommands(iniFile),
            };

            return result;
        }
        catch (Exception ex) when (IniFileRelatedExceptions.Contains(ex.GetType()))
        {
            throw new IniFileLoadException(ex.Message, ex);
        }
    }

    private static readonly Func<string, string, bool> StartsWith
     = (haystack, needle) => haystack.StartsWith(needle, StringComparison.InvariantCultureIgnoreCase);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iniFile"></param>
    /// <returns></returns>
    /// <exception cref="LoadWriteCommandException"></exception>
    private static List<RigCommand> LoadWriteCommands(IniFile iniFile)
    {
        var result = new List<RigCommand>();

        var sections = iniFile.GetSections();

        foreach (var section in sections)
        {
            if (StartsWith(section, "status") || StartsWith(section, "init"))
            {
                continue;
            }

            try
            {
                RigParameter param;

                try
                {
                    param = ConversionFunctions.StrToParam(section);
                }
                catch (ParameterParseException)
                {
                    continue;
                }

                var entries = iniFile.GetSectionSettings(section)
                    .Where(e => !string.IsNullOrEmpty(e.Name))
                    .Select(e => new KeyValuePair<string, string>(e.Name ?? string.Empty, e.Value ?? string.Empty))
                    .ToArray();
                if (!entries.Any())
                {
                    continue;
                }

                try
                {
                    var keys = entries.Select(e => e.Key);
                    var allowedEntries = new[]
                    {
                        Entry.Command, Entry.ReplyLength, Entry.ReplyEnd, Entry.Validate, Entry.Value
                    };
                    ValidateEntries(keys, allowedEntries);
                }
                catch (UnexpectedEntryException)
                {
                    continue;
                }

                var cmd = LoadCommon(iniFile, section);
                cmd.Value = LoadValue(iniFile, section, Value);
                ValidateValue(cmd.Value, cmd.Code.Length);

                if (cmd.Value.Param != RigParameter.None)
                {
                    throw new LoadWriteCommandException("parameter name is not allowed");
                }

                if (NumericParameters.Contains(param) && cmd.Value.Len == 0)
                {
                    throw new LoadWriteCommandException("Value is missing");
                }

                if (!NumericParameters.Contains(param) && cmd.Value.Len > 0)
                {
                    throw new LoadWriteCommandException("parameter does not require a value");
                }

                result.Add(cmd);
            }
            catch (LoadWriteCommandException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new LoadWriteCommandException(ex.Message, ex);
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iniFile"></param>
    /// <returns></returns>
    /// <exception cref="LoadStatusCommandsException"></exception>
    private static List<RigCommand> LoadStatusCommands(IniFile iniFile)
    {
        var result = new List<RigCommand>();

        var sections = iniFile.GetSections()
            .Where(s => StartsWith(s, "status"));
        foreach (var section in sections)
        {
            try
            {
                var settings = iniFile.GetSectionSettings(section);
                if (!settings.Any())
                {
                    continue;
                }

                var keys = settings.Where(e => !string.IsNullOrEmpty(e.Name))
                    .Select(e => e.Name ?? string.Empty);
                var allowedEntries = new[]
                {
                    Entry.Command, Entry.ReplyLength, Entry.ReplyEnd, Entry.Validate,
                    Entry.Value1, Entry.Value2, Entry.Value3, Entry.Value4, Entry.Value5, Entry.Value6,
                    Entry.Flag1, Entry.Flag2, Entry.Flag3, Entry.Flag4, Entry.Flag5, Entry.Flag6,
                };
                ValidateEntries(keys, allowedEntries);

                //common fields
                var cmd = LoadCommon(iniFile, section);

                if (cmd.ReplyLength == 0 && cmd.ReplyEnd.Length == 0)
                {
                    throw new LoadStatusCommandsException("Reply length or reply end must be specified.");
                }

                cmd.Validation.Mask = Array.Empty<byte>();
                cmd.Values.Clear();
                cmd.Flags.Clear();

                foreach (var setting in settings.Where(s => !string.IsNullOrEmpty(s.Name)))
                {
                    if (CanReadStatusEntryValue(cmd, iniFile, section, setting, out var value))
                    {
                        cmd.Values.Add(value.Value);
                    }
                    else if (CanReadStatusEntryFlag(cmd, setting, out var flag))
                    {
                        cmd.Flags.Add(flag.Value);
                    }
                }

                if (!cmd.Values.Any() && !cmd.Flags.Any())
                {
                    throw new LoadStatusCommandsException("at least one ValueNN or FlagNN must be defined");
                }

                result.Add(cmd);
            }
            catch (LoadStatusCommandsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new LoadStatusCommandsException("Error loading of STATUS section.", ex);
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iniFile"></param>
    /// <returns></returns>
    /// <exception cref="IniFileLoadException"></exception>
    internal static List<RigCommand> LoadInitCommands(IniFile iniFile)
    {
        var result = new List<RigCommand>();

        var sections = iniFile.GetSections()
            .Where(s => StartsWith(s, "init"));
        foreach (var section in sections)
        {
            try
            {
                var entries = iniFile.GetSectionSettings(section);
                if (!entries.Any())
                {
                    continue;
                }

                var keys = entries.Select(e => e.Name);
                var allowedEntries = new[]
                {
                    Entry.Command, Entry.ReplyLength, Entry.ReplyEnd, Entry.Validate,
                };
                ValidateEntries(keys, allowedEntries);

                var command = LoadCommon(iniFile, section);
                result.Add(command);
            }
            catch (Exception ex)
            {
                throw new LoadInitCommandsException("Error loading of INIT section.", ex);
            }
        }

        return result;
    }

    /// <summary>
    /// Validates given collection against allowed collection.
    /// </summary>
    /// <param name="keys">A keys to be validated.</param>
    /// <param name="allowedEntries">A collection of allowed keys.</param>
    /// <exception cref="UnexpectedEntryException">Is thrown when unexpected key met.</exception>
    internal static void ValidateEntries(IEnumerable<string> keys, Entry[] allowedEntries)
    {
        var allowedEntriesTitles = allowedEntries.Select(e => e.ToString());
        if (keys.Any(n => !allowedEntriesTitles.Contains(n, StringComparer.CurrentCultureIgnoreCase)))
        {
            throw new UnexpectedEntryException();
        }
    }

    /// <summary>
    /// Reads the common data from the INI file
    /// </summary>
    /// <param name="iniFile"></param>
    /// <param name="section"></param>
    /// <returns></returns>
    /// <exception cref="EntryLoadErrorException"></exception>
    internal static RigCommand LoadCommon(IniFile iniFile, string section)
    {
        var result = new RigCommand();

        try
        {
            var settingValue = ReadStringFromIni(iniFile, section, Command, string.Empty);
            result.Code = ByteFunctions.HexStrToBytes(settingValue);
        }
        catch (Exception)
        {
            throw new EntryLoadErrorException(section, Command);
        }

        if (result.Code.Length == 0)
        {
            throw new EntryLoadErrorException(section, Command, "Command code is missing.");
        }

        result.ReplyLength = ReadIntFromIni(iniFile, section, ReplyLength, 0);
        result.ReplyEnd = ByteFunctions.HexStrToBytes(ReadStringFromIni(iniFile, section, ReplyEnd, string.Empty));

        try
        {
            var maskValue = ReadStringFromIni(iniFile, section, Validate, string.Empty);
            result.Validation = ConversionFunctions.StrToMask(maskValue);
        }
        catch (MaskParseException ex)
        {
            throw new EntryLoadErrorException(section, Validate, ex.Message);
        }

        ValidateMask(Validate, result.Validation, result.ReplyLength, result.ReplyEnd);
        return result;
    }

    private static string ReadStringFromIni(IniFile iniFile, string section,
        string settingName, string defaultValue = "")
    {
        var iniSetting = iniFile.GetSectionSettings(section)
            .FirstOrDefault(s => s.Name == settingName);
        if (iniSetting != null)
        {
            return iniSetting.Value ?? defaultValue;
        }

        return defaultValue;
    }

    private static int ReadIntFromIni(IniFile iniFile, string section,
        string settingName, int defaultValue = 0)
    {
        var iniSetting = iniFile.GetSectionSettings(section)
            .FirstOrDefault(s => s.Name == settingName);
        if (iniSetting == null)
        {
            return defaultValue;
        }
        if (int.TryParse(iniSetting.Value ?? defaultValue.ToString(), out var result))
        {
            return result;
        }

        return defaultValue;
    }

    private static bool AreEqual(string stringOne, string stringTwo)
    {
        return stringOne.Equals(stringTwo, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entryName"></param>
    /// <param name="mask"></param>
    /// <param name="len"></param>
    /// <param name="end"></param>
    /// <exception cref="MaskValidationException"></exception>
    internal static void ValidateMask(string entryName, BitMask mask, int len, byte[] end)
    {
        if (mask.Mask.Length == 0
            && mask.Flags.Length == 0
            && (mask.Param == RigParameter.None))
        {
            return;
        }

        if (mask.Mask.Length == 0 || mask.Flags.Length == 0)
        {
            throw new MaskValidationException("Incorrect mask length");
        }

        if (mask.Mask.Length != mask.Flags.Length)
        {
            throw new MaskValidationException("Incorrect mask length");
        }

        if (len > 0 && mask.Mask.Length != len)
        {
            throw new MaskValidationException("Mask length <> ReplyLength");
        }

        if (!ByteFunctions.ByteArraysEqual(ByteFunctions.BytesAnd(mask.Flags, mask.Flags), mask.Flags))
        {
            throw new MaskValidationException("Mask hides valid bits");
        }

        if (AreEqual(entryName, "validate"))
        {
            if (mask.Param != RigParameter.None)
            {
                throw new MaskValidationException("Parameter name is not allowed");
            }

            var startIndex = mask.Flags.Length - end.Length;
            var ending = mask.Flags[startIndex..];

            if (!ByteFunctions.ByteArraysEqual(ending, end))
            {
                throw new MaskValidationException("Mask does not end with ReplyEnd");
            }
        }
        else
        {
            if (mask.Param == RigParameter.None)
            {
                throw new MaskValidationException("Parameter name is missing");
            }

            if (mask.Mask.Length == 0)
            {
                throw new MaskValidationException("Mask is blank");
            }
        }
    }

    /// <summary>
    /// Loads value from ini file
    /// </summary>
    /// <param name="iniFile"></param>
    /// <param name="section"></param>
    /// <param name="settingName"></param>
    /// <returns></returns>
    /// <exception cref="ValueLoadErrorException"></exception>
    /// <example>Value=5|5|vfBcdL|1|0[|pmXXX]</example>
    internal static ParameterValue LoadValue(IniFile iniFile, string section, string settingName)
    {
        try
        {
            var result = new ParameterValue();
            var value = ReadStringFromIni(iniFile, section, settingName, string.Empty);
            if (string.IsNullOrEmpty(value))
            {
                return result;
            }
            var elements = value.Split(ConversionFunctions.Delimiter).ToList();

            switch (elements.Count)
            {
                case 0:
                    return result;

                case 5:
                    break;

                case 6:
                    result.Param = ConversionFunctions.StrToParam(elements[5]);
                    break;

                default:
                    throw new ValueLoadErrorException($"Invalid syntax in {section} value '{value}'");
            }

            try
            {
                result.Start = Convert.ToInt32(elements[0]);
            }
            catch (Exception)
            {
                throw new ValueLoadErrorException($"invalid Start value in '{value}'");
            }

            try
            {
                result.Len = Convert.ToInt32(elements[1]);
            }
            catch (Exception)
            {
                throw new ValueLoadErrorException($"Invalid Length value in '{value}'");
            }

            result.Format = ConversionFunctions.StrToFmt(elements[2]);

            try
            {
                result.Mult = Convert.ToDouble(elements[3], CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new ValueLoadErrorException($"invalid Multiplier value in '{value}'");
            }

            try
            {
                result.Add = Convert.ToDouble(elements[4]);
            }
            catch (Exception)
            {
                throw new ValueLoadErrorException($"invalid Add value in '{value}'");
            }

            return result;
        }
        catch (Exception ex)
        {
            throw new ValueLoadErrorException(ex.Message);
        }
    }

    /// <summary>
    /// Validates given value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="len"></param>
    /// <exception cref="ValueValidationException"></exception>
    internal static void ValidateValue(ParameterValue value, int len)
    {
        try
        {
            if (value.Param == RigParameter.None)
            {
                return;
            }

            if (len == 0)
            {
                len = int.MaxValue;
            }

            {
                if ((value.Start < 0) || (value.Start >= len))
                {
                    throw new ValueValidationException("Invalid Start value");
                }

                if (value.Len < 0 || value.Start + value.Len > len)
                {
                    throw new ValueValidationException("invalid Length value");
                }

                if (value.Mult <= 0)
                {
                    throw new ValueValidationException("invalid Multiplier value");
                }
            }
        }
        catch (Exception e)
        {
            throw new ValueValidationException(e.Message);
        }
    }

    internal static bool CanReadStatusEntryFlag(RigCommand cmd,
        IniSetting iniSetting, out BitMask? mask)
    {
        mask = null;
        if (!iniSetting.Name.StartsWith("flag", StringComparison.CurrentCultureIgnoreCase))
        {
            return false;
        }

        try
        {
            var flag = ConversionFunctions.StrToMask(iniSetting.Value);
            ValidateMask(iniSetting.Name, flag, cmd.ReplyLength, cmd.ReplyEnd);
            mask = flag;
        }
        catch (MaskParseException)
        {
            return false;
        }
        catch (MaskValidationException)
        {
            return false;
        }

        return true;
    }

    internal static bool CanReadStatusEntryValue(RigCommand cmd,
        IniFile iniFile, string section, IniSetting iniSetting,
        out ParameterValue? result)
    {
        result = null;
        try
        {
            if (!iniSetting.Name.StartsWith("value", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            var value = LoadValue(iniFile, section, iniSetting.Name);
            ValidateValue(value, Math.Max(cmd.ReplyLength, cmd.Validation.Mask.Length));

            if (value.Param == RigParameter.None)
            {
                // parameter name is missing
                return false;
            }
            else if (!NumericParameters.Contains(value.Param))
            {
                // parameter must be of numeric type
                return false;
            }

            result = value;

            return true;
        }
        catch (ValueLoadErrorException)
        {
            return false;
        }
    }

    internal static byte[] StrToBytes(string s)
    {
        var preparedString = RegularExpressionHelper.ReplaceRegExpr("[^a-f0-9]", string.Empty, s);
        if (preparedString.Length % 2 != 0)
        {
            return Array.Empty<byte>();
        }

        return Enumerable.Range(0, preparedString.Length / 2)
            .Select(x => ToByte(preparedString, x))
            .ToArray();

        byte ToByte(string str, int x)
        {
            return Convert.ToByte(str.Substring(x * 2, 2), 16);
        }
    }
}