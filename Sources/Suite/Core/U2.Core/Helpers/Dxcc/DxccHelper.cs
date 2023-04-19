using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Newtonsoft.Json;
using U2.Contracts;

namespace U2.Core;

public class DxccHelper
{
    public static string CtyDatFile = "cty.dat";
    public static string GetDxccFilePath() 
    {
        var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.Combine(currentDir, "Data", "DXCC", CtyDatFile);
        Debug.Assert(File.Exists(path));
        return path;
    }

    private static DxccParser _parser = null;

    public static Lazy<DxccParser> DxccParser = new(() =>
    {
        if (_parser == null)
        {
            var path = GetDxccFilePath();
            _parser = new DxccParser(path);
        }

        return _parser;
    });

    /// <summary>
    /// Performs an attempt to calculate the dxcc entry from the callsign.
    /// </summary>
    /// <param name="call">A call to be used for calculation.</param>
    /// <returns></returns>
    public static Dxcc CalculateFromCall(string call)
    {
        var data = DxccParser.Value.CallTester(call);
        if (data == null || data.Count == 0)
        {
            throw new CallResolvingFailedException(call);
        }

        var lat = Convert.ToDecimal(data[4], CultureInfo.InvariantCulture);
        return new Dxcc
        {
            Name = data[0],
            CqZone = Convert.ToInt32(data[1]),
            ItuZone = Convert.ToInt32(data[2]),
            Continent = data[3],
            Latitude = Convert.ToDecimal(data[4], CultureInfo.InvariantCulture),
            Longitude = Convert.ToDecimal(data[5], CultureInfo.InvariantCulture),
            TimeZoneOffset = Convert.ToDecimal(data[6], CultureInfo.InvariantCulture),
            CountryCode = data[7],
        };
    }
}
