using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using U2.Contracts;

namespace U2.Core.Helpers;

public class DxccHelper
{
    public static DxccList FromFile(string path)
    {
        Debug.Assert(path != null);
        Debug.Assert(File.Exists(path));

        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Delete);
        var result = JsonSerializer.Deserialize<DxccList>(fs);
        return result;
    }

    public static DxccList FromString(string json)
    {
        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        var result = JsonSerializer.Deserialize<DxccList>(ms);
        return result;
    }
}
