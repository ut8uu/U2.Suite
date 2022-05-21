namespace U2.MultiRig;

public sealed class GuestRig : Rig
{
    public GuestRig(int rigNumber)
        : base(RigControlType.Guest, rigNumber, new RigSettings(), new RigCommands())
    {
    }

    #region CustomRig members

    protected override void AddCommands(IEnumerable<RigCommand> commands, CommandKind kind)
    {
    }

    protected override void ProcessInitReply(int number, byte[] data)
    {
    }

    protected override void ProcessStatusReply(int number, byte[] data)
    {
    }

    protected override void ProcessWriteReply(RigParameter param, byte[] data)
    {
    }

    public override void AddWriteCommand(RigParameter param, int value = 0)
    {
    }

    #endregion
}