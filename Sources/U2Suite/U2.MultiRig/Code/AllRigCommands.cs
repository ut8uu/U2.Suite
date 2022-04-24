using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace U2.MultiRig;

public static class AllRigCommands
{
    public static readonly ReadOnlyCollection<RigCommands> RigCommands = RigCommandUtilities.LoadAllRigCommands();
}
