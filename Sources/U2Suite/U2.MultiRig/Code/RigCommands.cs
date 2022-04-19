using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCircuits.IniFileParser;

namespace U2.MultiRig;

public partial class RigCommands
{
    private readonly IniFile _iniFile = new(StringComparer.CurrentCultureIgnoreCase);
    private string _section = string.Empty;
    private string _entry = string.Empty;
    private List<string> _fList = new();
    private bool _wasError = false;
    private readonly char[] _delimiter = {'|'};

    private readonly List<string> _log = new();

    public string RigType = string.Empty;
    public List<RigCommand> InitCmd = new();
    public List<RigCommand> WriteCmd = new();
    public List<RigCommand> StatusCmd = new();
    public List<RigParameter> ReadableParams = new();
    public List<RigParameter> WriteableParams = new();

    public string? Title { get; set; }

    public bool Read(Stream inputStream)
    {
        using var streamReader = new StreamReader(inputStream);
        _iniFile.Load(streamReader);

        foreach (var section in _iniFile.GetSections())
        {
            _section = section;
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
