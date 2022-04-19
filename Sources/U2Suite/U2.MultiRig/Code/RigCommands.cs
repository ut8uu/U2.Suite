using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCircuits.IniFileParser;

namespace U2.MultiRig;

public partial class RigCommands
{
    internal IniFile FIni = new(StringComparer.CurrentCultureIgnoreCase);
    internal string FSection = string.Empty;
    internal string FEntry = string.Empty;
    internal List<string> FList = new();
    internal bool WasError = false;
    private  readonly char[] FDelimiter = {'|'};

    internal List<string> FLog = new();

    public string RigType = string.Empty;
    public List<RigCommand> InitCmd = new();
    public List<RigCommand> WriteCmd = new();
    public List<RigCommand> StatusCmd = new();
    public List<TRigParam> ReadableParams = new();
    public List<TRigParam> WriteableParams = new();

    public string? Title { get; set; }

    public bool Read(Stream inputStream)
    {
        using var streamReader = new StreamReader(inputStream);
        FIni.Load(streamReader);

        foreach (var section in FIni.GetSections())
        {
            FSection = section;
            if (StartsWith(section, "init"))
            {
                LoadInitCmd();
            }
            else if (StartsWith(section, "status"))
            {
                LoadStatusCmd();
            }
            else
            {
                LoadWriteCmd();
            }
        }

        ListSupportedParams();

        return true;

        bool StartsWith(string haystack, string needle)
        {
            return haystack.StartsWith(needle, StringComparison.CurrentCultureIgnoreCase);
        }
    }

    public void Write(Stream outputStream)
    {
        throw new NotImplementedException();
    }
}
