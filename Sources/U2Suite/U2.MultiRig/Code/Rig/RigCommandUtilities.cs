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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SoftCircuits.IniFileParser;
using U2.Core;

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

    private static ILog ClassLog => LogManager.GetLogger(typeof(RigCommandUtilities));

    public static ReadOnlyCollection<RigCommands> LoadAllRigCommands()
    {
        var list = new List<RigCommands>();
        var iniDirectory = Path.Combine(FileSystemHelper.GetLocalFolder(), "INI");
        var files = Directory.EnumerateFiles(iniDirectory, "*.ini");
        var logger = LogManager.GetLogger(typeof(RigCommandUtilities));
        foreach (var file in files)
        {
            try
            {
                list.Add(LoadRigCommands(file));
            }
            catch (IniFileLoadException ex)
            {
                var fileName = Path.GetFileName(file);
                logger.Error($"Error loading ini file {fileName}. {ex.Message}");
            }
        }

        return new ReadOnlyCollection<RigCommands>(list);
    }

    public static IEnumerable<string> EnumerateAllRigCommandNames()
    {
        var list = new List<RigCommands>();
        var iniDirectory = Path.Combine(FileSystemHelper.GetLocalFolder(), "INI");
        var files = Directory.EnumerateFiles(iniDirectory, "*.ini");
        return files.Select(f => Path.GetFileNameWithoutExtension(f) ?? string.Empty)
            .Where(entry => !string.IsNullOrEmpty(entry));
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
            var rigType = Path.GetFileNameWithoutExtension(pathToIniFile);
            var result = new RigCommands
            {
                InitCmd = LoadInitCommands(iniFile),
                StatusCmd = LoadStatusCommands(iniFile),
                WriteCmd = LoadWriteCommands(iniFile),
                Title = rigType,
                RigType = rigType,
            };

            return result;
        }
        catch (Exception ex) when (IniFileRelatedExceptions.Contains(ex.GetType()))
        {
            throw new IniFileLoadException(ex.Message, ex);
        }
    }

    private static readonly Func<string, string, bool> StartsWith
     = (haystack, needle) => haystack.Trim().StartsWith(needle.Trim(), StringComparison.InvariantCultureIgnoreCase);

    private static KeyValuePair<string, string>[] LoadSectionSettings(IniFile iniFile, string section)
    {
        return iniFile.GetSectionSettings(section)
            .Where(e => !string.IsNullOrEmpty(e.Name)
                        && !StartsWith(e.Name, ";")
                        && !StartsWith(e.Name, ":"))
            .Select(e => new KeyValuePair<string, string>(e.Name ?? string.Empty, e.Value ?? string.Empty))
            .ToArray();
    }

    private static void ValidateWriteCommandEntries(IniFile iniFile, string section)
    {
        try
        {
            var allowedEntries = new[]
            {
                Entry.Command, Entry.ReplyLength, Entry.ReplyEnd, Entry.Validate,
                Entry.Value
            };
            var entries = LoadSectionSettings(iniFile, section);
            ValidateEntries(entries, allowedEntries);
        }
        catch (UnexpectedEntryException ex)
        {
            throw new LoadWriteCommandException(ex.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iniFile"></param>
    /// <returns></returns>
    /// <exception cref="LoadWriteCommandException"></exception>
    private static Dictionary<int, RigCommand> LoadWriteCommands(IniFile iniFile)
    {
        var result = new Dictionary<int, RigCommand>();
        var sections = iniFile.GetSections()
            .Where(s => !StartsWith(s, "status") && !StartsWith(s, "init"));

        foreach (var section in sections)
        {
            try
            {
                if (!LoadSectionSettings(iniFile, section).Any())
                {
                    // the entire section is empty
                    continue;
                }
                ValidateWriteCommandEntries(iniFile, section);

                var cmd = LoadCommon(iniFile, section);
                cmd.Value = LoadValue(iniFile, section, Value);
                ValidateValue(cmd.Value, cmd.Code.Length);

                if (cmd.Value.Param != RigParameter.None)
                {
                    throw new LoadWriteCommandException("parameter name is not allowed");
                }

                var param = ConversionFunctions.StrToRigParameter(section);
                if (NumericParameters.Contains(param) && cmd.Value.Len == 0)
                {
                    throw new LoadWriteCommandException("Value is missing");
                }

                if (!NumericParameters.Contains(param) && cmd.Value.Len > 0)
                {
                    throw new LoadWriteCommandException("parameter does not require a value");
                }

                var id = (int)Enum.Parse<RigParameter>(section.Replace("pm", ""));
                result[id] = cmd;
            }
            catch (Exception ex) when (ex is not LoadWriteCommandException)
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
                var entries = LoadSectionSettings(iniFile, section);
                if (!entries.Any())
                {
                    continue;
                }

                var allowedEntries = new[]
                {
                    Entry.Command, Entry.ReplyLength, Entry.ReplyEnd, Entry.Validate,
                    Entry.Value,
                    Entry.Value1, Entry.Value2, Entry.Value3, Entry.Value4, Entry.Value5,
                    Entry.Value6, Entry.Value7, Entry.Value8, Entry.Value9, Entry.Value10,
                    Entry.Flag1, Entry.Flag2, Entry.Flag3, Entry.Flag4,
                    Entry.Flag5, Entry.Flag6, Entry.Flag7, Entry.Flag8,
                    Entry.Flag9, Entry.Flag10, Entry.Flag11, Entry.Flag12, Entry.Flag13,
                    Entry.Flag14, Entry.Flag15, Entry.Flag16, Entry.Flag17, Entry.Flag18,
                    Entry.Flag19, Entry.Flag20, Entry.Flag21, Entry.Flag22,
                };
                ValidateEntries(entries, allowedEntries);

                //common fields
                var cmd = LoadCommon(iniFile, section);

                if (cmd.ReplyLength == 0 && cmd.ReplyEnd.Length == 0)
                {
                    throw new LoadStatusCommandsException("Reply length or reply end must be specified.");
                }

                LoadStatusCommandsEntries(iniFile, section, entries, cmd);

                if (!cmd.Values.Any() && !cmd.Flags.Any())
                {
                    throw new LoadStatusCommandsException("at least one ValueNN or FlagNN must be defined");
                }

                result.Add(cmd);
            }
            catch (Exception ex) when (ex is not LoadStatusCommandsException)
            {
                throw new LoadStatusCommandsException($"Error loading of STATUS section. {ex.Message}", ex);
            }
        }

        return result;
    }

    private static void LoadStatusCommandsEntries(IniFile iniFile, string section, 
        IEnumerable<KeyValuePair<string, string>> entries, RigCommand cmd)
    {
        cmd.Values.Clear();
        cmd.Flags.Clear();

        foreach (var entry in entries)
        {
            if (CanReadStatusEntryValue(cmd, iniFile, section, entry, out var value))
            {
                cmd.Values.Add(value.Value);
            }
            else if (CanReadStatusEntryFlag(cmd, entry, out var flag))
            {
                cmd.Flags.Add(flag.Value);
            }
        }
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

        var sections = iniFile.GetSections().Where(s => StartsWith(s, "init"));
        foreach (var section in sections)
        {
            try
            {
                var entries = LoadSectionSettings(iniFile, section);
                if (!entries.Any())
                {
                    continue;
                }

                var allowedEntries = new[] { Entry.Command, Entry.ReplyLength, Entry.ReplyEnd, Entry.Validate, };
                ValidateEntries(entries, allowedEntries);

                var command = LoadCommon(iniFile, section);
                if (command.Code.Length > 0)
                {
                    result.Add(command);
                }
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
    internal static void ValidateEntries(IEnumerable<KeyValuePair<string, string>> keys,
        Entry[] allowedEntries)
    {
        if (!keys.Any())
        {
            return;
        }

        var allowedEntriesTitles = allowedEntries.Select(e => e.ToString());
        var inputKeys = keys.Select(x => x.Key).ToArray();
        var unresolvedEntries = inputKeys
            .Where(k => !allowedEntriesTitles.Contains(k, StringComparer.InvariantCultureIgnoreCase)).ToArray();
        if (keys.Any(n => !allowedEntriesTitles.Contains(n.Key, StringComparer.CurrentCultureIgnoreCase)))
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
            if (StartsWith(settingValue, "("))
            {
                result.Code = ByteFunctions.StrToBytes(settingValue);
            }
            else
            {
                result.Code = ByteFunctions.HexStrToBytes(settingValue);
            }
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
            result.Validation = ConversionFunctions.StrToBitMask(maskValue);
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
            return (iniSetting.Value ?? defaultValue).Trim();
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
    /// <param name="length"></param>
    /// <param name="replyEnd"></param>
    /// <exception cref="MaskValidationException"></exception>
    internal static void ValidateMask(string entryName, BitMask mask, int length, byte[] replyEnd)
    {
        if (mask.Mask.Length == 0
            && mask.Flags.Length == 0
            && (mask.Param == RigParameter.None))
        {
            return;
        }

        ValidateMaskChecks(mask, length);

        if (AreEqual(entryName, "validate"))
        {
            if (mask.Param != RigParameter.None)
            {
                throw new MaskValidationException("Parameter name is not allowed");
            }

            var startIndex = mask.Flags.Length - replyEnd.Length;
            var ending = mask.Flags[startIndex..];

            if (!ending.SequenceEqual(replyEnd))
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
    /// Perform initial checks of the mask.
    /// Throws exceptions in case the rule is broken.
    /// Extracted to reduce the cognitive complexity
    /// of the method it was extracted from.
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="length"></param>
    /// <exception cref="MaskValidationException">Is thrown when mask is invalid.</exception>
    private static void ValidateMaskChecks(BitMask mask, int length)
    {
        if (mask.Mask.Length == 0 || mask.Flags.Length == 0)
        {
            throw new MaskValidationException("Incorrect mask length");
        }

        if (mask.Mask.Length != mask.Flags.Length)
        {
            throw new MaskValidationException("Incorrect mask length");
        }

        if (length > 0 && mask.Mask.Length != length)
        {
            throw new MaskValidationException("Mask length <> ReplyLength");
        }

        if (!ByteFunctions.BytesAnd(mask.Flags, mask.Flags).SequenceEqual(mask.Flags))
        {
            throw new MaskValidationException("Mask hides valid bits");
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
                    result.Param = ConversionFunctions.StrToRigParameter(elements[5]);
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

            result.Format = ConversionFunctions.StrToValueFormat(elements[2]);

            try
            {
                result.Mult = Convert.ToDouble(elements[3], CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new ValueLoadErrorException($"invalid Multiplier value in '{value}'. {ex.Message}");
            }

            try
            {
                result.Add = Convert.ToDouble(elements[4], CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new ValueLoadErrorException($"invalid Add value in '{value}'. {ex.Message}");
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

            if (value.Start < 0 || value.Start >= len)
            {
                throw new ValueValidationException($"Invalid Start value: {value.Start}");
            }

            if (value.Len < 0 || value.Start + value.Len > len)
            {
                throw new ValueValidationException($"invalid Length value. Start={value.Start}, Len={value.Len}");
            }

            if (value.Mult <= 0)
            {
                throw new ValueValidationException($"invalid Multiplier value: {value.Mult}");
            }
        }
        catch (Exception e)
        {
            throw new ValueValidationException(e.Message);
        }
    }

    internal static bool CanReadStatusEntryFlag(RigCommand cmd,
        KeyValuePair<string, string> iniSetting, out BitMask? mask)
    {
        mask = null;
        if (!iniSetting.Key.StartsWith("flag", StringComparison.CurrentCultureIgnoreCase))
        {
            return false;
        }

        try
        {
            var flag = ConversionFunctions.StrToBitMask(iniSetting.Value);
            ValidateMask(iniSetting.Key, flag, cmd.ReplyLength, cmd.ReplyEnd);
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
        IniFile iniFile, string section, KeyValuePair<string, string> iniSetting,
        out ParameterValue? result)
    {
        result = null;
        try
        {
            if (!iniSetting.Key.StartsWith("value", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            var value = LoadValue(iniFile, section, iniSetting.Key);
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

    public static ulong ParametersToUlong(IEnumerable<RigParameter> parameters)
    {
        return (ulong)parameters.Aggregate(0, (current, param) => current | (int)param);
    }

    public static ulong ParamToInt64(RigParameter parameter)
    {
        return Convert.ToUInt64(parameter);
    }

    public static RigParameter Int64ToParam(ulong value)
    {
        return (RigParameter)value;
    }
}