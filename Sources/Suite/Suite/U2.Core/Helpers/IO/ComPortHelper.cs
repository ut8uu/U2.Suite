using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;

namespace U2.Core;

public static class ComPortHelper
{
    /// <summary>
    /// Enumerates all ports known to the system.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<ComPortInfo> EnumerateComPorts()
    {
        var result = new SortedList<int, ComPortInfo>
            {
                {
                    -1000, new ComPortInfo
                    {
                        Name = ComPortInfo.None,
                        Description = ComPortInfo.None,
                        Caption = "",
                    }
                }
            };

        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            var searcher = new ManagementObjectSearcher("root\\cimv2",
                "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");

            // Add all the available (COM)-ports to the result
            foreach (var obj in searcher.Get())
            {
                if (obj is not ManagementObject managementObject)
                {
                    continue;
                }

                var caption = managementObject["Caption"].ToString();
                if (!RegularExpressionHelper.Match("(.*)\\((COM(\\d+))\\)",
                        caption, RegexOptions.IgnoreCase, out var matches))
                {
                    continue;
                }

                var comPortNumber = int.Parse(matches[3]);
                var portInfo = new ComPortInfo
                {
                    Name = matches[2],
                    Description = $"{matches[2]}: {matches[1]}",
                    Caption = caption,
                };
                result.Add(comPortNumber, portInfo);
            }
#pragma warning restore CA1416 // Validate platform compatibility
        }
        return result.Values;
    }
}

public sealed class ComPortInfo
{
    public const string None = "NONE";

    public string Name { get; init; }
    public string Description { get; init; }
    public string Caption { get; init; }
}
