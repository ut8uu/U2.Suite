using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using U2.Contracts;
using U2.Core;

namespace U2.Logger;

internal static class AdifHelper
{
    /// <summary>
    /// Loads and parses ADIF from given file and 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static async Task<IEnumerable<LogRecordDbo>> LoadAdifAsync(string fileName,
        CancellationToken cancellationToken, List<LogEntry> errors)
    {
        var content = File.ReadAllText(fileName);
        return await ParseAdifAsync(content, cancellationToken, errors);
    }

    public static async Task<IEnumerable<LogRecordDbo>> LoadAdifAsync(string fileName,
        CancellationToken cancellationToken, IProgress<string> progress, List<LogEntry> errors)
    {
        var content = File.ReadAllText(fileName);
        return await ParseAdifAsync(content, cancellationToken, progress, errors);
    }

    public static async Task<IEnumerable<LogRecordDbo>> ParseAdifAsync(string adif,
    CancellationToken cancellationToken, List<LogEntry> errors)
    {
        var progress = new Progress<string>();
        return await ParseAdifAsync(adif, cancellationToken, progress, errors);
    }

    public static async Task<IEnumerable<LogRecordDbo>> ParseAdifAsync(string adif, 
        CancellationToken cancellationToken, IProgress<string> progress, List<LogEntry> errors)
    {
        var result = new List<LogRecordDbo>();

        var splitSeparator = new[] { '|' };
        var str = RegularExpressionHelper.ReplaceRegExpr("[\r\n\t\v\b]", string.Empty, adif);
        str = RegularExpressionHelper.ReplaceRegExpr("<eor>", "|", str, RegexOptions.IgnoreCase);

        str = RegularExpressionHelper.ReplaceRegExpr("^.+<eoh>", string.Empty, str, RegexOptions.IgnoreCase);

        var records = str.Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
        var currentRecord = 1;
        var totalRecords = records.Length;
        foreach (var @record in records)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                result.Clear();
                errors.Add(new LogEntry(LogEntryType.Error, Resources.OperationCancelledMessage));
                return result;
            }

            if (currentRecord++ % 10 == 1)
            {
                progress.Report(string.Format(Resources.ReadingAdifRecordsFormat, currentRecord, totalRecords, Math.Round(100m * currentRecord / totalRecords)));
            }

            var newRecord = new LogRecordDbo();

            var qsoDate = string.Empty;
            var qsoTime = string.Empty;
            var tags = @record.Replace("<", "|<").Split(splitSeparator, StringSplitOptions.RemoveEmptyEntries);
            ProcessTags(tags, newRecord, ref qsoDate, ref qsoTime);

            if (!string.IsNullOrEmpty(qsoDate) && !string.IsNullOrEmpty(qsoTime))
            {
                try
                {
                    var date = qsoDate + qsoTime;
                    var dateValue = DateTime.ParseExact(date, "yyyyMMddHHmmss",
                        CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
                    newRecord.QsoEndTimestamp = dateValue;
                    newRecord.QsoBeginTimestamp = dateValue;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            result.Add(newRecord);
        }

        return result;
    }

    private static void ProcessTags(string[] tags, LogRecordDbo newRecord, ref string qsoDate, ref string qsoTime)
    {
        foreach (var tag in tags)
        {
            if (RegularExpressionHelper.Match("<([^:]+):(\\d+)>(.+)", tag, out var matches, RegexOptions.IgnoreCase))
            {
                var len = int.Parse(matches[2]);
                var adifTag = matches[1].ToUpper().Trim();

                var value = matches[3].PadRight(len, ' ')[..len].Trim();
                switch (adifTag)
                {
                    case KnownAdifTags.TagBand:
                        newRecord.Band = value;
                        break;
                    case KnownAdifTags.TagCall:
                        newRecord.Callsign = value;
                        break;
                    case KnownAdifTags.TagComment:
                        newRecord.Comments = value;
                        break;
                    case KnownAdifTags.TagFreq:
                        var freqValue = value.Replace(",", ".");
                        newRecord.Frequency = decimal.Parse(freqValue,
                            NumberStyles.AllowDecimalPoint,
                            CultureInfo.InvariantCulture);
                        break;
                    case KnownAdifTags.TagMode:
                        newRecord.Mode = value;
                        break;
                    case KnownAdifTags.TagQsoDate:
                        qsoDate = value;
                        break;
                    case KnownAdifTags.TagTimeOn:
                        qsoTime = value;
                        break;
                    case KnownAdifTags.TagRstRcvd:
                        newRecord.RstReceived = value;
                        break;
                    case KnownAdifTags.TagRstSent:
                        newRecord.RstSent = value;
                        break;
                    case KnownAdifTags.TagSigInfo:
                        newRecord.Comments += " " + value;
                        break;
                    case KnownAdifTags.TagSotaRef:
                        newRecord.Comments += " " + value;
                        break;
                    case KnownAdifTags.TagGridSquare:
                        break;
                    default:
                        continue;
                }
            }
        }
    }

    public static string GenerateAdif(LogInfo logInfo, IEnumerable<LogRecordDbo> records)
    {
        var builder = new StringBuilder();
        GenerateAdifHeader(builder);
        GenerateAdifRows(records, logInfo, builder);

        return builder.ToString();
    }

    public static async Task<bool> ExportAsync(string pathToFile, LogInfo logInfo, IEnumerable<LogRecordDbo> records)
    {
        var content = Encoding.UTF8.GetBytes(GenerateAdif(logInfo, records));
        return await FileUtilities.SaveAsync(pathToFile, content, useBackup: true);
    }

    private static bool GenerateAdifHeader(StringBuilder builder)
    {
        var version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
        builder.AppendLine($"ADIF Export from U2.Logger - Version {version}");
        builder.AppendLine("(c) 2022 Sergey Usmanov (UT8UU)");
        builder.AppendLine($"Exported {DateTime.Now:R}");
        builder.AppendLine("<EOH>");

        return true;
    }

    private static bool GenerateAdifRows(IEnumerable<LogRecordDbo> records,
        LogInfo logInfo,
        StringBuilder builder)
    {
        foreach (var row in records)
        {
            AddTag(KnownAdifTags.TagStationCallsign, logInfo.StationCallsign ?? string.Empty, builder);
            AddTag(KnownAdifTags.TagOperator, logInfo.OperatorCallsign ?? logInfo.StationCallsign, builder);
            AddTag(KnownAdifTags.TagCall, row.Callsign, builder);
            AddTag(KnownAdifTags.TagRstSent, row.RstSent, builder);
            AddTag(KnownAdifTags.TagRstRcvd, row.RstReceived, builder);
            AddTag(KnownAdifTags.TagFreq, row.Frequency.ToString(CultureInfo.InvariantCulture), builder);
            AddTag(KnownAdifTags.TagStationCallsign, logInfo.StationCallsign, builder);
#warning TODO Add MySig and MySigInfo to log info
            AddTag(KnownAdifTags.TagMySig, "WWFF", builder);
            AddTag(KnownAdifTags.TagMySigInfo, logInfo.ActivatedReference, builder);
            AddTag(KnownAdifTags.TagBand, row.Band, builder);
            AddTag(KnownAdifTags.TagMode, row.Mode, builder);
            AddTag(KnownAdifTags.TagQsoDate, row.QsoEndTimestamp.ToString("yyyyMMdd"), builder);
            AddTag(KnownAdifTags.TagTimeOn, row.QsoEndTimestamp.ToString("HHmmss"), builder);

            var comments = row.Comments;
            if (!string.IsNullOrEmpty(comments))
            {
                var wwffResult = ExtractWwffReference(comments);
                if (wwffResult.hasReference)
                {
                    // WWFF
                    AddTag(KnownAdifTags.TagSig, "WWFF", builder);
                    AddTag(KnownAdifTags.TagSigInfo, wwffResult.foundReference, builder);
                }
                var sotaResult = ExtractSotaReference(comments);
                if (sotaResult.hasReference)
                {
                    // SOTA
                    AddTag(KnownAdifTags.TagSotaRef, sotaResult.foundReference, builder);
                }
            }

            builder.AppendLine("<EOR>");
        }

        return true;
    }

    public static (bool hasReference, string foundReference) ExtractWwffReference(string input)
    {
        var reference = string.Empty;
        var found = RegularExpressionHelper.Match("([a-z]?[a-z\\d]ff)[^\\d]?(\\d+)", input, out var matches, RegexOptions.IgnoreCase);

        if (found)
        {
            reference = $"{matches[1].ToUpper()}-{matches[2].PadLeft(4, '0')}";
        }
        return (found, reference);
    }

    public static (bool hasReference, string foundReference) ExtractSotaReference(string input)
    {
        var reference = string.Empty;
        var found = RegularExpressionHelper.Match("([a-z][a-z\\d]?)[/-]?([a-z][a-z])-?(\\d+)", input, out var matches, RegexOptions.IgnoreCase);

        if (found)
        {
            if (matches[3].Length > 3)
            {
                found = false;
            }
            else
            {
                reference = $"{matches[1].ToUpper()}/{matches[2].ToUpper()}-{matches[3].PadLeft(3, '0')}";
            }
        }
        return (found, reference);
    }

    private static void AddTag(string tagName, DataRow row, StringBuilder builder)
    {
        var value = row[tagName].ToString() ?? string.Empty;
        if (value.Length > 0)
        {
            builder.Append($"<{tagName}:{value.Length}>{value}");
        }
    }

    private static void AddTag(string tagName, string value, StringBuilder builder)
    {
        if (value?.Length > 0)
        {
            builder.Append($"<{tagName}:{value.Length}>{value}");
        }
    }

    public static bool HasDuplicates(IEnumerable<string> mainLogHashes, 
        IEnumerable<LogRecordDbo> logToSearch, 
        out List<LogRecordDbo> duplicates)
    {
        var newLogHashes = logToSearch.Select(x => x.Hash);
        var duplicateHashes = mainLogHashes.Intersect(newLogHashes);
        duplicates = logToSearch.Where(r => duplicateHashes.Contains(r.Hash)).ToList();
        return duplicates.Count > 0;
    }
}
