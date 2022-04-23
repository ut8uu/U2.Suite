using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using U2.Core;

namespace U2.MultiRig.Code
{
    public static class AllRigCommands
    {
        internal static bool TryLoadRigCommands(string iniFile, out RigCommands rigCommands)
        {
            rigCommands = new RigCommands();

            using (var stream = File.OpenRead(iniFile))
            {
                if (rigCommands.Read(stream))
                {
                    return true;
                }
            }

            return false;
        }

        internal static void LoadRigCommands()
        {
            var list = new List<RigCommands>();
            try
            {
                var iniDirectory = Path.Combine(FileSystemHelper.GetLocalFolder(), "INI");
                var files = Directory.EnumerateFiles(iniDirectory, "*.ini");
                foreach (var file in files)
                {
                    if (TryLoadRigCommands(file, out var rigCommand))
                    {
                        list.Add(rigCommand);
                    }
                }

                RigCommands = new ReadOnlyCollection<RigCommands>(list);
            }
            catch (Exception ex)
            {
                if (ex.Message != null)
                {

                }

                throw;
            }
        }

        public static ReadOnlyCollection<RigCommands> RigCommands { get; set; }
    }
}
