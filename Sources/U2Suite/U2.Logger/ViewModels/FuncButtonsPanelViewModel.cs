using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace U2.Logger.ViewModels
{
    public sealed class FuncButtonsPanelViewModel
    {
        public string WipeButtonTitle { get; set; } = "Wipe";
        public string SaveButtonTitle { get; set; } = "Save";

        public Window Owner { get; set; } = default!;

        public void Save()
        {

        }
        public void Wipe()
        {

        }
    }
}
