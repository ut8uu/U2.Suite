using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using U2.Contracts;
using U2.Core;

namespace U2.Core;

public class DxccParser
{
    protected Dictionary<string, List<string>> dxcc = new();      // array with main prefix -> (CQZ, ITUZ, ...) 
    protected List<string> fullcalls = new(); // array with full calls (=DL1XYZ)
    protected Dictionary<string, List<string>> prefixes = new();  // array with main prefix -> (all, prefixes,..)
    string[] lidadditions = new[] { "QRP", "LGT" };
    string[] csadditions = new[] { "P", "R", "A", "M", "LH", "SK" };
    string[] noneadditions = new[] { "AM", "MM" };

    public DxccParser(string ctyDatFilePath)
    {
        ReadCty(ctyDatFilePath);
    }

    private static string CleanupPattern(string pattern)
    {
        if (pattern.StartsWith('/') && pattern.EndsWith('/'))
        {
            return pattern[1..^1];
        }
        return pattern;
    }

    private static List<string> PregSplit(string pattern, string input)
    {
        return RegularExpressionHelper.SplitRegExpr(pattern, input).ToList();
    }

    private static bool PregMatch(string pattern, string callsign)
    {
        return PregMatch(pattern, callsign, out var _);
    }

    private static bool PregMatch(string pattern, string input, out List<string> matches)
    {
        pattern = CleanupPattern(pattern);

        return RegularExpressionHelper.Match(pattern, input, out matches);

        //matches = new List<string>();
        //var x = Regex.Match(input, pattern);
        //if (x.Success)
        //{
        //    matches.Add(input);
        //    foreach (Capture m in x.Captures)
        //    {
        //        matches.Add(m.Value);
        //    }
        //}

        //return matches.Count > 0;
    }

    private static bool PregMatchAll(string pattern, string input, out List<string> matches)
    {
        pattern = CleanupPattern(pattern);
        matches = new List<string>();

        var match = Regex.Match(pattern, input, RegexOptions.IgnoreCase);
        if (match.Success)
        {
            foreach (Group g in match.Groups)
            {
                matches.Add(g.Value);
            }
        }

        return matches.Count > 0;

        //return PregMatch(pattern, input, out matches);

        //matches = new List<string>();

        //var collection = Regex.Matches(input, pattern);
        //foreach (Match match in collection)
        //{
        //    matches.Add(match.Value);
        //}
        //return matches.Count > 0;
    }

    public List<string> CallTester(string callsign)
    {
        return dxcc1(callsign);
    }

    public Tuple<double, double> qrbqtf(float mylat, float mylon, float hislat, float hislon)
    {
        var PI = 3.14159265;
        var z = 180 / PI;

        var g = Math.Acos(Math.Sin(mylat / z) * Math.Sin(hislat / z) + Math.Cos(mylat / z) * Math.Cos(hislat / z) * Math.Cos((hislon - mylon) / z));

        var dist = g * 6371;
        double dir = 0;

        if (dist != 0)
        {
            dir = Math.Acos((Math.Sin(hislat / z) - Math.Sin(mylat / z) * Math.Cos(g)) / (Math.Cos(mylat / z) * Math.Sin(g))) * 360 / (2 * PI);
        }

        if (Math.Sin((hislon - mylon) / z) < 0)
        {
            dir = 360 - dir;
        }
        dir = 360 - dir;

        return new Tuple<double, double>(dist, dir);
    }

    private List<string> dxcc1(string testcall)
    {
        var matchchars = 0;
        var matchprefix = "";
        var goodzone = "";

        testcall = testcall.ToUpper();

        if (fullcalls.Contains(testcall))
        {
            // direct match with "="
            // do nothing! don"t try to resolve WPX, it"s a full
            // call and will match correctly even if it contains a /
        }
        else if (testcall.StartsWith("OH/", StringComparison.InvariantCultureIgnoreCase)
            || RegularExpressionHelper.Match("/oh[1-9]$", testcall)) 
        {   // non-Aland prefix!
            testcall = "OH";                                           // make callsign OH = finland
        }
        else if (PregMatch("'/(^3D2R)|(^3D2.+\\/R)/", testcall))
        {     // seems to be from Rotuma
            testcall = "3D2RR";                                        // will match with Rotuma
        }
        else if (PregMatch("/^3D2C/", testcall))
        {                   // seems to be from Conway Reef
            testcall = "3D2CR";                                        // will match with Conway
        }
        else if (PregMatch(@"/(^LZ\/)|(\/LZ[1-9]?$)/", testcall))
        {   // LZ/ is LZ0 by DXCC but this is VP8h
            testcall = "LZ";
        }
        else if (PregMatch("/(^KG4)[A-Z09]{3}/", testcall))
        {        // KG4/ and KG4 5 char calls are Guantanamo Bay. If 6 char, it is USA
            testcall = "K";
        }
        else if (PregMatch("/(^KG4)[A-Z09]{2}/", testcall))
        {        // KG4/ and KG4 5 char calls are Guantanamo Bay. If 6 char, it is USA
            testcall = "KG4";
        }
        else if (PregMatch("/(^KG4)[A-Z09]{1}/", testcall))
        {        // KG4/ and KG4 5 char calls are Guantanamo Bay. If 6 char, it is USA
            testcall = "K";
        }
        else if (PregMatch(@"/\w\/\w/", testcall))
        {
            // check if the callsign has a "/"
            var tpl = @"^((\d|[A-Z])+\/)?((\d|[A-Z]){3,})(\/(\d|[A-Z])+)?(\/(\d|[A-Z])+)?$";
            var hasSlashMatch = Regex.Match(testcall, tpl);
            //if (PregMatchAll(tpl, testcall, out var matches))
            if (hasSlashMatch.Success)
            {
                var prefix = hasSlashMatch.Groups[1].Value;
                var callsign = hasSlashMatch.Groups[3].Value;
                var suffix = "";
                if (hasSlashMatch.Groups.Count > 4) 
                    suffix = hasSlashMatch.Groups[5].Value;

                if (!string.IsNullOrEmpty(prefix) && prefix.EndsWith('/'))
                {
                    prefix = prefix[..^1]; // Remove the / at the end 
                }
                if (!string.IsNullOrEmpty(suffix) && suffix.StartsWith('/'))
                {
                    suffix = suffix[1..]; // Remove the / at the beginning
                };
                if (csadditions.Contains(suffix.ToUpper()))
                {
                    if (!string.IsNullOrEmpty(prefix))
                    {
                        testcall = prefix;
                    }
                    else
                    {
                        testcall = callsign;
                    }
                }
                else
                {
                    testcall = wpx(testcall, 1);
                    if (testcall == "")
                    {
                        return new List<string>();
                    }

                    testcall += "AA"; // use the wpx prefix instead, which may
                                      // intentionally be wrong, see &wpx!
                }
            }
        }

        string letter = testcall[..1];
        var testCalLen = testcall.Length;

        foreach (var mainprefix in prefixes.Keys)
        {                  // Runs through the DXCC list
            foreach (string test in prefixes[mainprefix])
            {
                var len = test.Length;
                if (!test.StartsWith(letter))
                {
                    // Continues if no match, will speed up things
                    continue;
                }
                string zones = "";

                if (len > 5 && (test.Contains('(') || test.Contains('[')))
                { // extra zones
                    PregMatch(@"/^([A-Z0-9\/]+)([\[\(].+)/", test, out var matches);
                    if (matches.Count > 2)
                    {
                        zones += matches[2];
                    }
                    len = matches[1].Length;
                }

                if (len > testCalLen)
                {
                    continue;
                }
                if (testcall[0..len].Equals(test[0..len], StringComparison.InvariantCultureIgnoreCase)
                    && matchchars <= len)
                {
                    matchchars = len;
                    matchprefix = mainprefix;
                    goodzone = zones;
                }
            }
        }

        List<string> mydxcc = new() { "Unknown", "", "", "", "", "", "" };

        if (dxcc.ContainsKey(matchprefix))
        {
            mydxcc = dxcc[matchprefix];
        }

        // Different zones?
        if (!string.IsNullOrEmpty(goodzone))
        {
            if (PregMatch(@"/\((\d+)\)/", goodzone, out var matches))
            { // CQ-Zone in ()
                mydxcc.Add(matches[1]);
            }
            if (PregMatch(@"/\[(\d+)\]/", goodzone, out matches))
            { // ITU-Zone in []
                mydxcc.Add(matches[1]);
            }
        }

        // cty.dat has special entries for WAE countries which are not separate DXCC
        // countries. Those start with a "*", for example *TA1. Those have to be changed
        // to the proper DXCC. Since there are opnly a few of them, it is hardcoded in
        // here.
        if (mydxcc[7].StartsWith('*'))
        { // WAE country!
            if (mydxcc[7] == "*TA1")
            {
                mydxcc[7] = "TA";// Turkey
            }
            if (mydxcc[7] == "*4U1V")
            {
                mydxcc[7] = "OE";// 4U1VIC is in OE..
            }
            if (mydxcc[7] == "*GM/s")
            {
                mydxcc[7] = "GM";// Shetlands
            }
            if (mydxcc[7] == "*IG9")
            {
                mydxcc[7] = "I";// African Italy
            }
            if (mydxcc[7] == "*IT9")
            {
                mydxcc[7] = "I";// Sicily
            }
            if (mydxcc[7] == "*JW/b")
            {
                mydxcc[7] = "JW";// Bear Island
            }
        }

        return mydxcc;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    // &wpx derives the Prefix following WPX rules from a call. These can be found
    // at: http://www.cq-amateur-radio.com/wpxrules.html
    // e.g. DJ1YFK/TF3  can be counted as both DJ1 or TF3, but this sub does 
    // not ask for that, always TF3 (= the attached prefix) is returned. If that is 
    // not want the OP wanted, it can still be modified manually.
    //
    // Addendum by LA8AJA.
    // Here are some calls to test in each case
    // OH/DJ1YFK -> since we are adding a 0, it could be interpreted as OH0, that"s why we set it as OH - Finland
    // N6TR/7 -> USA
    // KH0CW -> USA (if everything is not ok, this was Mariana Island)
    // A45XR/0 -> Oman
    // RV0AL/0/P -> Asiatic Russia
    // DJ1YFK/VE1 -> Canada
    // DJ1YFK/QRP -> Germany
    // DJ1YFK/LGT -> Germany
    // RAEM -> Asiatic Russia
    // HD1QRC90 -> Ecuador
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private string wpx(string testcall, int i)
    {
        var prefix = "";

        // First check if the call is in the proper format, A/B/C where A and C
        // are optional (prefix of guest country and P, MM, AM etc) and B is the
        // callsign. Only letters, figures and "/" is accepted, no further check if the
        // callsign "makes sense".
        // 23.Apr.06: Added another "/X" to the regex, for calls like RV0AL/0/P
        // as used by RDA-DXpeditions....

        var tpl = @"^((\d|[A-Z])+\/)?((\d|[A-Z]){3,})(\/(\d|[A-Z])+)?(\/(\d|[A-Z])+)?$";
        var hasSlashMatch = Regex.Match(testcall, tpl);
        if (hasSlashMatch.Success)
        //if (PregMatchAll(tpl, testcall, out var matches))
        {
            var matches = hasSlashMatch.Groups.Values.Select(x => x.Value).ToList();

            // Now 1 holds A (incl /), 3 holds the callsign B and 5 has C
            // We save them to a, b and c respectively to ensure they won"t get 
            // lost in further Regex evaluations.
            string a = matches[1];
            string b = matches[3];
            string c = matches[5];
            if (!string.IsNullOrEmpty(a))
            {
                a = a[..^1]; // Remove the / at the end 
            }
            if (!string.IsNullOrEmpty(c))
            {
                c = c[1..]; // Remove the / at the beginning
            };

            // In some cases when there is no part A but B and C, and C is longer than 2
            // letters, it happens that a and b get the values that b and c should
            // have. This often happens with liddish callsign-additions like /QRP and
            // /LGT, but also with calls like DJ1YFK/KP5. ~/.yfklog has a line called    
            // "lidadditions", which has QRP and LGT as defaults. This sorts out half of
            // the problem, but not calls like DJ1YFK/KH5. This is tested in a second
            // try: a looks like a call (.\d[A-Z]) and b doesn"t (.\d), they are
            // swapped. This still does not properly handle calls like DJ1YFK/KH7K where
            // only the OP"s experience says that it"s DJ1YFK on KH7K.
            if (string.IsNullOrEmpty(c)
                && !string.IsNullOrEmpty(a)
                && !string.IsNullOrEmpty(b))
            {
                // a and b exist, no c
                if (lidadditions.Any(_ => _.Equals(b, StringComparison.InvariantCultureIgnoreCase)))
                {        
                    // check if b is a lid-addition
                    b = a;
                    a = null; // a goes to b, delete lid-add
                }
                else if (PregMatch(@"/\d[A-Z]+$/", a) && PregMatch(@"/\d$/", b))
                {   
                    // check for call in a
                    var temp = b;
                    b = a;
                    a = temp;
                }
            }

            // *** Added later ***  The check didn"t make sure that the callsign
            // contains a letter. there are letter-only callsigns like RAEM, but not
            // figure-only calls. 

            if (PregMatch("/^[0-9]+$/", b))
            {            
                // Callsign only consists of numbers. Bad!
                return null;            // exit, undef
            }

            // Depending on these values we have to determine the prefix.
            // Following cases are possible:
            //
            // 1.    a and c undef --> only callsign, subcases
            // 1.1   b contains a number -> everything from start to number
            // 1.2   b contains no number -> first two letters plus 0 
            // 2.    a undef, subcases:
            // 2.1   c is only a number -> a with changed number
            // 2.2   c is /P,/M,/MM,/AM -> 1. 
            // 2.3   c is something else and will be interpreted as a Prefix
            // 3.    a is defined, will be taken as PFX, regardless of c 

            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(c))
            {                     
                // Case 1
                if (PregMatch(@"/\d/", b))
                {                       
                    // Case 1.1, contains number
                    PregMatch(@"/(.+\d)[A-Z]*/", b, out matches);     // Prefix is all but the last
                    prefix = matches[1]; // Letters
                }
                else
                {
                    // Case 1.2, no number 
                    prefix = b[0..2] + "0"; // first two + 0
                }
            }
            else if (string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(c))
            {                
                // Case 2, CALL/X
                if (PregMatch(@"/^(\d)/", c))
                {                    
                    // Case 2.1, number
                    PregMatch(@"/(.+\d)[A-Z]*/", b, out matches);     // regular Prefix in 1
                                                                      // Here we need to find out how many digits there are in the
                                                                      // prefix, because for example A45XR/0 is A40. If there are 2
                                                                      // numbers, the first is not deleted. If course in exotic cases
                                                                      // like N66A/7 -> N7 this brings the wrong result of N67, but I
                                                                      // think that"s rather irrelevant cos such calls rarely appear
                                                                      // and if they do, it"s very unlikely for them to have a number
                                                                      // attached.   You can still edit it by hand anyway..  
                    if (PregMatch(@"/^([A-Z]\d)\d$/", matches[1]))
                    {        
                        // e.g. A45   c = 0
                        prefix = matches[1] + c;  // ->   A40
                    }
                    else
                    {                         
                        // Otherwise cut all numbers
                        PregMatch(@"/(.*[A-Z])\d+/", matches[1], out var match); // Prefix w/o number in 1
                        prefix = match[1] + c; // Add attached number   
                    }
                }
                else if (csadditions.Any(_ => _.Equals(c, StringComparison.InvariantCultureIgnoreCase)))
                {
                    PregMatch(@"/(.+\d)[A-Z]*/", b, out matches);     // Known attachment -> like Case 1.1
                    prefix = matches[1];
                }
                else if (noneadditions.Any(_ => _.Equals(c, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return "";
                }
                else if (PregMatch(@"/^\d\d+$/", c))
                {            
                    // more than 2 numbers -> ignore
                    PregMatch(@"/(.+\d)[A-Z]* /", b, out matches);    // see above
                    prefix = matches[1];
                }
                else
                {                                            
                    // Must be a Prefix!
                    if (PregMatch(@"/\d$/", c))
                    {                  
                        // ends in number -> good prefix
                        prefix = c;
                    }
                    else
                    {                                        
                        // Add Zero at the end
                        prefix = c + "0";
                    }
                }
            }
            else if (!string.IsNullOrEmpty(a) && 
                noneadditions.Any(_ => _.Equals(c, StringComparison.InvariantCultureIgnoreCase)))
            {                
                // Case 2.1, X/CALL/X ie TF/DL2NWK/MM - DXCC none
                return "";
            }
            else if (!string.IsNullOrEmpty(a))
            {
                // a contains the prefix we want
                if (PregMatch(@"/\d$/", a))
                {                      
                    // ends in number -> good prefix
                    prefix = a;
                }
                else
                {                                            
                    // add zero if no number
                    prefix = a + "0";
                }
            }
            // In very rare cases (right now I can only think of KH5K and KH7K and FRxG/T
            // etc), the prefix is wrong, for example KH5K/DJ1YFK would be KH5K0. In this
            // case, the superfluous part will be cropped. Since this, however, changes the
            // DXCC of the prefix, this will NOT happen when invoked from with an
            // extra parameter _[1]; this will happen when invoking it from &dxcc.

            if (PregMatch(@"/(\w+\d)[A-Z]+\d/", prefix, out matches) && i == null)
            {
                prefix = matches[1];
            }
            return prefix;
        }
        else
        {
            return string.Empty;
        }       // no proper callsign received.*/
    }           // wpx ends here
    /*
    * Read cty.dat from AD1C
    */
    private void ReadCty(string file)
    {
        var mainprefix = "";

        Debug.Assert(File.Exists(file));

        var lines = File.ReadAllLines(file);

        foreach (var theLine in lines)
        {
            var line = theLine;
            if (!line.StartsWith(' '))
            {
                // New DXCC
                if (PregMatch(@"/\s+([*A-Za-z0-9\/]+):+$/", line, out var matches))
                {
                    var chunks = line.Split(':', StringSplitOptions.RemoveEmptyEntries)
                        .Select(_ => _.Trim())
                        .ToList();
                    mainprefix = chunks.Last();
                    dxcc[mainprefix] = chunks;
                }
            }
            else
            {
                // prefix-line

                // read full calls into separate array. This array only
                // contains the information that this is a full call

                line = line.Replace(";", "").Trim();
                var calls = line.Split(',');
                foreach (var call in calls)
                {
                    if (call.Length > 0)
                    {
                        var x = call.Replace("=", "");
                        if (call.StartsWith('='))
                        {
                            if (!fullcalls.Contains(x))
                            {
                                fullcalls.Add(x);
                            }
                        }

                        if (!prefixes.ContainsKey(mainprefix))
                        {
                            prefixes.Add(mainprefix, new List<string>());
                        }
                        prefixes[mainprefix].Add(x);
                    }
                }
            }
        }
    }
}