using System;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.Tar;
using U2.Suite.Helpers.Dxcc;

namespace U2.Suite.Helpers;

public sealed class DxccHelper
{
    public static bool DEFAULT_AUTOFETCH_FILES = false; // Set your desired value
    public static string DEFAULT_CTYFILES_URL = "http://www.ok2cqr.com/linux/cqrlog/ctyfiles/cqrlog-cty.tar.gz";
    public static string DEFAULT_CTYFILES_PATH = null;
    public static string DxccFolder = "dxcc";

    private readonly int DEBUG = 3;   
    private readonly int VERBOSE = 3;
    private readonly int TRACE1 = 4;
    //private readonly int TRACE2 = 5;

    private bool autoFetchFiles = DEFAULT_AUTOFETCH_FILES;
    private string ctyFilesUrl = DEFAULT_CTYFILES_URL;
    private string ctyFilesPath;

    private List<DxccCacheEntry> callsignCache = [];
    private Dictionary<string, DxccEntries> GLOBAL_DXCC_LIST = [];
    private DxccEntry NODXCC = new DxccEntry
    {
        Adif = "0",
        Lat = "0",
        Lng = "0",
        Continent = "0",
        Details = "0",
        Itu = "0",
        Pattern = "",
        Utc = "0",
        ValidFrom = null,
        ValidTo = null,
        Waz = "0",
    };
    
    private static DxccHelper _instance;

    public static DxccHelper Instance { 
        get
        {
            if (_instance == null)
            {
                if (string.IsNullOrEmpty(DEFAULT_CTYFILES_PATH))
                {
                    DEFAULT_CTYFILES_PATH = FileSystemHelper.ChildFolder(DxccFolder);
                }
                Directory.CreateDirectory(DEFAULT_CTYFILES_PATH);

                _instance = new DxccHelper(DEFAULT_CTYFILES_PATH, DEFAULT_CTYFILES_URL, autofetchFiles: DEFAULT_AUTOFETCH_FILES);
            }
            return _instance;
        }
    }

    protected DxccHelper(string ctyfilesPath, string ctyfilesUrl, 
        bool autofetchFiles, int verbose = 3)
    {
        ctyFilesPath = ctyfilesPath;
        ctyFilesUrl = ctyfilesUrl;
        autoFetchFiles = autofetchFiles;
        VERBOSE = verbose;

        // Initialize the country tab here
        InitCountryTab(null);
    }


    internal void FetchCountryFiles()
    {
        if (VERBOSE >= DEBUG)
        {
            Console.WriteLine("Fetching new countryfiles");
        }

        using WebClient webClient = new WebClient();
        byte[] data = webClient.DownloadData(ctyFilesUrl);
        using (Stream stream = new MemoryStream(data))
        using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Decompress))
        using (TarArchive tarArchive = TarArchive.CreateInputTarArchive(gzipStream))
        {
            tarArchive.ExtractContents(ctyFilesPath);
        }
    }

    public void ProcessCountryFiles()
    {
        string[] ctyfiles =
        [
            "Country.tab",
            "CallResolution.tbl",
            "AreaOK1RR.tbl"
        ];

        var path = Path.Combine(ctyFilesPath, "_country.tab");
        using (StreamWriter countrytab = new StreamWriter(path))
        {
            foreach (string filePath in ctyfiles)
            {
                var srcPath = Path.Combine(ctyFilesPath, filePath);
                using StreamReader reader = new StreamReader(srcPath);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    countrytab.WriteLine(line);
                }
            }
        }
    }

    public string[] PatternToRegex(string patternlist)
    {
        // = is the hint in country.tab, that an explicit call is given
        var returnlist = new List<string>();
        patternlist = patternlist.Replace("  ", " ");
        foreach (string pattern in patternlist.Split(' '))
        {
            string modifiedPattern = pattern;
            if (pattern.Contains('%') || pattern.Contains('#') || pattern.Contains('='))
            {
                if (pattern.Contains('%'))
                {
                    modifiedPattern += "$";
                }
                modifiedPattern = modifiedPattern.Replace("%", "[A-Z]").Replace("#", "[0-9]");
            }
            modifiedPattern = $"^{modifiedPattern}";
            returnlist.Add(modifiedPattern);
        }
        return returnlist.ToArray();
    }

    public DxccEntries GetEntries(DateTime? date = null)
    {
        if (!date.HasValue)
        {
            date = DateTime.UtcNow;
        }

        Regex dateDxccRegex = new(@"((?<from>\d{4}/\d{2}/\d{2})*-(?<to>\d{4}/\d{2}/\d{2})*)*(=(?<alt_dxcc>\d*))*");
        DxccEntries dxccList = [];

        try
        {
            using StreamReader countryTabFile = new StreamReader(Path.Combine(ctyFilesPath, "_country.tab"), System.Text.Encoding.UTF8);
            string line;
            while ((line = countryTabFile.ReadLine()) != null)
            {
                string[] rowList = line.Split('|');
                bool inDateRange = true;

                DateTime? dateTo = null;
                DateTime? dateFrom = null;
                Match dateDxccMatch;
                string altDxcc = string.Empty;

                if (!string.IsNullOrEmpty(rowList[10])) 
                {
                    try
                    {
                        dateDxccMatch = dateDxccRegex.Match(rowList[10]);
                    }
                    catch (IndexOutOfRangeException error)
                    {
                        if (VERBOSE >= DEBUG)
                        {
                            Console.WriteLine($"{error} for line {string.Join("|", rowList)}");
                        }
                        continue;
                    }

                    if (dateDxccMatch.Success)
                    {
                        Console.WriteLine(dateDxccMatch.Groups[1].Value);
                    }

                    if (dateDxccMatch.Groups["to"].Success)
                    {
                        try
                        {
                            dateTo = DateTime.ParseExact(dateDxccMatch.Groups["to"].Value, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        }
                        catch (FormatException valErr)
                        {
                            if (VERBOSE >= DEBUG)
                            {
                                Console.WriteLine($"{valErr} in date_to of line {string.Join("|", rowList)}");
                            }
                        }
                    }

                    if (dateDxccMatch.Groups["from"].Success)
                    {
                        try
                        {
                            dateFrom = DateTime.ParseExact(dateDxccMatch.Groups["from"].Value, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        }
                        catch (FormatException valErr)
                        {
                            if (VERBOSE >= DEBUG)
                            {
                                Console.WriteLine($"{valErr} in date_from of line {string.Join("|", rowList)}");
                            }
                        }
                    }

                    altDxcc = dateDxccMatch.Groups["alt_dxcc"].Value;

                    if (dateTo.HasValue && date > dateTo)
                    {
                        inDateRange = false;
                    }

                    if (inDateRange && dateFrom.HasValue && date < dateFrom)
                    {
                        inDateRange = false;
                    }
                }

                if (inDateRange)
                {
                    string pattern = rowList[0];
                    string adif = rowList[9] == "R" ? altDxcc : rowList[8];

                    foreach (string singlePattern in PatternToRegex(pattern.Trim()))
                    {
                        var x = singlePattern;
                        if (rowList[9] != "R")
                        {
                            x = $"~{singlePattern}";
                        }
                        try
                        {
                            var dxcc = new DxccEntry
                            {
                                Pattern = x,
                                Details = rowList[1],
                                Continent = rowList[2],
                                Utc = rowList[3],
                                Lat = rowList[4],
                                Lng = rowList[5],
                                Itu = rowList[6],
                                Waz = rowList[7],
                                ValidFrom = dateFrom,
                                ValidTo = dateTo,
                                Adif = adif,
                            };
                            dxccList.Add(dxcc);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            // Handle the file not found exception, or you can rethrow it if needed.
        }

        if (VERBOSE >= DEBUG)
        {
            Console.WriteLine($"{dxccList.Count} calls parsed");
        }

        return dxccList;
    }

    //public string DXCC2Xml(Dictionary<string, string> dxcc)
    //{
    //    return Converter.Convert(dxcc);
    //}

    //public string DXCC2Json(Dictionary<string, string> dxcc)
    //{
    //    return JsonSerializer.Serialize(dxcc);
    //}

    public void InitCountryTab(DateTime? date = null, bool? fetchFiles = null)
    {
        if (!date.HasValue)
        {
            date = DateTime.UtcNow;
            if (VERBOSE >= DEBUG)
            {
                Console.WriteLine("Initializing GLOBAL_DXCC_LIST with date " + date.Value.ToString("yyyy-MM-dd"));
            }
        }

        if (!fetchFiles.HasValue)
        {
            fetchFiles = autoFetchFiles;
        }

        if (fetchFiles.Value)
        {
            if (VERBOSE >= DEBUG)
            {
                Console.WriteLine("Fetching fresh tables");
            }

            FetchCountryFiles();
            ProcessCountryFiles();
        }

        GLOBAL_DXCC_LIST[date.Value.ToString("yyyy-MM-dd")] = GetEntries(date.Value);
    }

    /// <summary>
    /// Returns a collection of DXCC entries available for given date.
    /// </summary>
    /// <param name="date">The date the list of DXCC entries should be collected for.</param>
    /// <param name="fetchFiles">Indicates if files must be fetched first.</param>
    /// <returns></returns>
    public DxccEntries GetDateCountryTab(DateTime? date = null, bool? fetchFiles = null)
    {
        if (!date.HasValue)
        {
            date = DateTime.UtcNow;
        }

        if (!fetchFiles.HasValue)
        {
            fetchFiles = autoFetchFiles;
        }

        string dateStr = date.Value.ToString("yyyy-MM-dd");

        if (!GLOBAL_DXCC_LIST.ContainsKey(dateStr))
        {
            if (VERBOSE >= DEBUG)
            {
                Console.WriteLine(dateStr + " not found in GLOBAL_DXCC_LIST, adding");
            }

            if (dateStr == DateTime.UtcNow.ToString("yyyy-MM-dd") && fetchFiles.Value)
            {
                FetchCountryFiles();
                ProcessCountryFiles();
            }

            GLOBAL_DXCC_LIST[dateStr] = GetEntries(date.Value);
        }
        else
        {
            if (VERBOSE >= DEBUG)
            {
                Console.WriteLine(dateStr + " found in GLOBAL_DXCC_LIST, using that");
            }
        }

        return GLOBAL_DXCC_LIST[dateStr];
    }

    internal DxccEntry CallToDxcc(string callsign, DateTime? date = null)
    {
        EnsureCountryFiles();

        string ORIGINALCALLSIGN = callsign;

        if (date == null)
        {
            date = DateTime.UtcNow;
        }

        var entry = callsignCache.FirstOrDefault(x => x.Date == date 
            && x.Callsign.Equals(callsign, StringComparison.InvariantCultureIgnoreCase));
        if (entry != null)
        {
            var datedict = entry.Entry;
            if (VERBOSE >= DEBUG)
            {
                Console.WriteLine($"cache hit: {datedict.Pattern}, {callsign}");
            }
            return entry.Entry;
        }

        Dictionary<string, DxccEntry> directHitList = [];
        Dictionary<string, DxccEntry> prefixHitList = [];
        Dictionary<string, DxccEntry> regexHitList = [];

        var dxccList = GetDateCountryTab(date);

        foreach (var data in dxccList)
        {
            var pattern = data.Pattern;
            if (pattern.Contains('=') && callsign.Length == (pattern.Length - 2))
            {
                directHitList[pattern.Replace("=", "")] = data;
            }
            else if (pattern.Contains('~'))
            {
                prefixHitList[pattern.Replace("~", "")] = data;
            }
            else
            {
                regexHitList[pattern] = data;
            }
        }

        foreach (var kv in directHitList)
        {
            var pattern = kv.Key;
            if (Regex.IsMatch(callsign, pattern))
            {
                pattern = pattern.Replace("^", "^=");
                if (VERBOSE >= DEBUG)
                {
                    //Console.WriteLine($"found direct hit {pattern} {DXCC_LIST[pattern]}");
                }
                callsignCache.Add(
                    new DxccCacheEntry
                    {
                        Date = date!.Value,
                        Callsign = callsign,
                        Entry = kv.Value,
                    });
                return kv.Value;
            }
        }

        if (callsign.Contains('/'))
        {
            var x = HandleExtendedCalls(callsign);
            if (x == null)
            {
                if (VERBOSE >= DEBUG)
                {
                    Console.WriteLine("callsign not valid for DXCC");
                }
                return NODXCC;
            }
            callsign = x;
        }

        
        foreach (var kv in regexHitList)
        {
            var pattern = kv.Key;
            if (pattern[1] == callsign[0] || pattern[1] == '[')
            {
                if (VERBOSE >= TRACE1)
                {
                    Console.WriteLine(pattern);
                }
                if (Regex.IsMatch(callsign, pattern))
                {
                    if (VERBOSE >= DEBUG)
                    {
                        Console.WriteLine($"found {pattern} {kv.Value}");
                    }
                    callsignCache.Add(
                        new DxccCacheEntry
                        {
                            Date = date!.Value,
                            Callsign = callsign,
                            Entry = kv.Value,
                        });
                    return kv.Value;
                }
            }
        }

        var hitDict = new Dictionary<string, DxccEntry>();

        foreach (var kv in prefixHitList)
        {
            var pattern = kv.Key;
            if (VERBOSE >= TRACE1)
            {
                Console.WriteLine(pattern);
            }
            if (Regex.IsMatch(callsign, pattern))
            {
                pattern = pattern.Replace("^", "~^");
                if (VERBOSE >= DEBUG)
                {
                    Console.WriteLine($"found {pattern} {kv.Value}");
                }
                hitDict.Add(pattern, kv.Value);
            }
        }

        if (hitDict.Count > 0)
        {
            var longestPattern = hitDict.Keys.Max();
            var entry1 = hitDict[longestPattern];
            callsignCache.Add(
                new DxccCacheEntry
                {
                    Date = date!.Value,
                    Callsign = callsign,
                    Entry = entry1,
                });

            return entry1;
        }

        if (VERBOSE >= DEBUG)
        {
            Console.WriteLine("no matching DXCC found");
        }

        var cacheEntry = new DxccCacheEntry
        {
            Date = date!.Value,
            Callsign = callsign,
            Entry = NODXCC,
        };
        callsignCache.Add(cacheEntry);
        return NODXCC;
    }

    public void EnsureCountryFiles()
    {
        if (!Directory.Exists(ctyFilesPath))
        {
            FetchCountryFiles();
            ProcessCountryFiles();
        }
    }

    public static DxccEntry Call2Dxcc(string callsign, DateTime? date = null)
    {
        return Instance.CallToDxcc(callsign, date);
    }

    public string HandleExtendedCalls(string callsign)
    {
        if (VERBOSE >= DEBUG)
        {
            Console.WriteLine($"{callsign} is an extended callsign");
        }

        var callsignParts = callsign.Split('/');
        if (callsignParts.Length == 2)
        {
            var prefix = callsignParts[0];
            var suffix = callsignParts[1];

            if (suffix == "MM" || suffix == "MM1" || suffix == "MM2" || suffix == "MM3" || suffix == "AM")
            {
                return null;
            }

            if (suffix.Length == 1)
            {
                if (suffix == "M" || suffix == "P")
                {
                    if (!Regex.IsMatch(prefix, "^LU"))
                    {
                        return prefix;
                    }
                }
                else if (Regex.IsMatch(suffix[0].ToString(), "^[0-9]"))
                {
                    if (Regex.IsMatch(prefix, "^A[A-L]|^[KWN]"))
                    {
                        return "W" + suffix[0];
                    }
                    else
                    {
                        var prefixToList = prefix.ToList();
                        prefixToList[2] = suffix[0];
                        prefix = new string(prefixToList.ToArray());
                        return prefix;
                    }
                }
                else if (Regex.IsMatch(suffix, "^[A-DEHJL-VX-Z]"))
                {
                    if (Regex.IsMatch(prefix, "^(AY|AZ|L[O-W])"))
                    {
                        var prefixToList = prefix.ToList();
                        prefixToList[3] = suffix[0];
                        prefix = new string(prefixToList.ToArray());
                        return prefix;
                    }
                    else
                    {
                        return callsign;
                    }
                }
            }

            if (prefix.Length <= 3 && suffix.Length > 1)
            {
                return prefix;
            }

            if (1 < suffix.Length && suffix.Length < 5)
            {
                if (suffix == "QRP" || suffix == "QRPP")
                {
                    return prefix;
                }
                else
                {
                    return prefix;
                }
            }

            if (prefix.Length > suffix.Length)
            {
                return prefix;
            }
            else
            {
                return suffix;
            }
        }
        else if (callsignParts.Length == 3)
        {
            var prefix = callsignParts[0];
            var middle = callsignParts[1];
            var suffix = callsignParts[2];

            if (suffix == "MM" || suffix == "AM")
            {
                return null;
            }

            if (suffix == "M" || suffix == "QRP" || suffix == "P")
            {
                return HandleExtendedCalls($"{prefix}/{middle}");
            }

            if (middle.Length > 0)
            {
                if (Regex.IsMatch(middle[0].ToString(), "^[0-9]"))
                {
                    if (Regex.IsMatch(prefix, "^A[A-L]|^[KWN]"))
                    {
                        return "W" + middle[0];
                    }
                    else
                    {
                        var prefixToList = prefix.ToList();
                        prefixToList[2] = middle[0];
                        prefix = new string(prefixToList.ToArray());
                        return prefix;
                    }
                }
            }

            if (middle.Length > prefix.Length && middle.Length > suffix.Length && HandleExtendedCalls($"{prefix}/{middle}") != null)
            {
                return HandleExtendedCalls($"{prefix}/{suffix}");
            }
            else
            {
                return null;
            }
        }

        return null;
    }
}

[Serializable]
internal class NoDxccFoundException : Exception
{
    public NoDxccFoundException()
    {
    }

    public NoDxccFoundException(string? message) : base(message)
    {
    }

    public NoDxccFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NoDxccFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}