using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace U2.Logger
{
    public sealed class FuncButtonsPanelViewModel
    {
        public string WipeButtonTitle { get; set; } = "Wipe";
        public string SaveButtonTitle { get; set; } = "Save";

        public Window Owner { get; set; } = default!;

        public void Save()
        {
            Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.SaveButton));
        }

        public void Wipe()
        {
            Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.WipeButton));
        }
    }
}
