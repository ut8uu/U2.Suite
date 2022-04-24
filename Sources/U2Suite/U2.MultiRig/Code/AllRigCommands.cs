using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace U2.MultiRig;

public static class AllRigCommands
{
    public static ReadOnlyCollection<RigCommands> RigCommands = RigCommandUtilities.LoadAllRigCommands();
}
