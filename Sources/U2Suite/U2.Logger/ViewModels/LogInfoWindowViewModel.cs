using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace U2.Logger
{
    public sealed class LogInfoWindowViewModel : ViewModelBase
    {
        private Window _owner;

        public string LogNameTitle { get; set; } = Resources.LogName;
        public string LogNameToolTip { get; set; } = Resources.LogNameToolTip;
        public string DescriptionTitle { get; set; } = Resources.Description;
        public string DescriptionToolTip { get; set; } = Resources.DescriptionToolTip;
        public string CancelButtonTitle { get; set; } = Resources.Cancel;
        public string OkButtonTitle { get; set; } = Resources.OK;

        public Window Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public string LogName { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
