using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using U2.Core;

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

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (propertyName == nameof(LogName))
            {
                var logDirectory = FileSystemHelper.GetDatabaseFolderPath("U2.Logger");
                Directory.CreateDirectory(logDirectory);
                var logFiles = Directory.GetFiles(logDirectory, "*.sqlite");
                if (logFiles.Any(f => Path.GetFileNameWithoutExtension(f)
                    .Equals(LogName, StringComparison.InvariantCultureIgnoreCase)))
                {
                    var msg = string.Format(Resources.LogNameIsInUseFmt, LogName);
                    throw new Avalonia.Data.DataValidationException(msg);
                }
            }
            base.OnPropertyChanged(propertyName);
        }
    }
}
