using System;

namespace U2.MultiRig;

public partial class RigCommands
{
    public string RigType = string.Empty;
    public List<RigCommand> InitCmd = new();
    public List<RigCommand> WriteCmd = new();
    public List<RigCommand> StatusCmd = new();
    public List<RigParameter> ReadableParams = new();
    public List<RigParameter> WriteableParams = new();

    public string? Title { get; set; }
}
