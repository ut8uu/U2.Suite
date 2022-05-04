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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace U2.Core;

public static class RegularExpressionHelper
{

    //===========================================
    public static string MatchAndGetFirst(string template, string input)
    {
        var res = string.Empty;
        if (Match(template, input, out var m, RegexOptions.IgnoreCase | RegexOptions.Singleline) && m.Count > 1)
        {
            res = m[1];
        }
        return res;
    }

    public static bool Match(string template, string input)
    {
        return Regex.IsMatch(input, template, RegexOptions.IgnoreCase);
    }

    public static bool Match(string template, string input, RegexOptions opt)
    {
        return Regex.IsMatch(input, template, opt);
    }

    //===========================================
    public static bool Match(string template, string input, out List<string> matches, RegexOptions opt)
    {
        var m = Regex.Match(input, template, opt);
        var res = m.Success;
        matches = new List<string>();
        if (res)
        {
            matches.Add(input);
        }
        ProcessMatches(matches, m);
        return res;
    }

    public static bool Match(string template, string input, out List<string> matches)
    {
        var res = Match(template, input, out matches, RegexOptions.IgnoreCase);
        return res;
    }

    private static void ProcessMatches(List<string> matches, Match foundMatches)
    {
        var allMatches = foundMatches;
        while (allMatches.Success)
        {
            for (var i = 1; i <= allMatches.Groups.Count; i++)
            {
                var g = allMatches.Groups[i];
                var cc = g.Captures;
                if (cc.Count <= 0)
                {
                    matches.Add("");
                    continue;
                }

                for (var j = 0; j < cc.Count; j++)
                {
                    var c = cc[j];
                    var s = c.Value;
                    matches.Add(s);
                }
            }

            allMatches = allMatches.NextMatch();
        }
    }

    //===========================================
    public static string ReplaceRegExpr(string template, string replace, string input, RegexOptions opt)
    {
        string res;
        try
        {
            res = Regex.Replace(input, template, replace, opt);
        }
        catch
        {
            // Most likely cause is a syntax error in the regular expression
            res = input;
        }

        return res;
    }

    //===========================================
    public static string ReplaceRegExpr(string template, string replace, string input)
    {
        return ReplaceRegExpr(template, replace, input, RegexOptions.IgnoreCase);
    }

    //=====================================================
    public static string[] SplitRegExpr(string template, string input)
    {
        var res = Regex.Split(input, template);
        return res;
    }

}
