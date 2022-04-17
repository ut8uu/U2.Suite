using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.MultiRig
{
    public class RigSettingsViewModel
    {

        public RigSettings RigSettings { get; set; } = new();
    }

    public sealed class DesignMultiRigViewModel : RigSettingsViewModel
    {
        public DesignMultiRigViewModel()
        {
        }
    }
}
