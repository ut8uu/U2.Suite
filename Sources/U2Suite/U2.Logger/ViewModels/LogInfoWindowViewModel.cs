using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using U2.Core;
using U2.Logger.Models;

namespace U2.Logger
{
    public sealed class LogInfoWindowViewModel : ViewModelBase
    {
        private Window _owner;

        public LogInfoWindowViewModel() { }

        public LogInfoWindowViewModel(CommandToExecute commandToExecute)
        {
            CommandToExecute = commandToExecute;

            WindowTitle = commandToExecute switch
            {
                CommandToExecute.CreateLog => Logger.Resources.CreateNewLog,
                CommandToExecute.UpdateLog => Logger.Resources.UpdateLog,
                _ => throw new ArgumentOutOfRangeException(nameof(commandToExecute)),
            };
        }

        public string WindowTitle { get; set; } = string.Empty;
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
        public CommandToExecute CommandToExecute { get; set; }

        public string LogName { get; set; } = default!;
        public string Description { get; set; } = default!;

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (propertyName == nameof(LogName))
            {
                CanExecute(throwException: true, out var _);
            }
            base.OnPropertyChanged(propertyName);
        }

        private bool CanExecute(bool throwException, out string message)
        {
            if (string.IsNullOrEmpty(LogName))
            {
                if (throwException)
                {
                    throw new Avalonia.Data.DataValidationException(Resources.EmptyLogNameException);
                }
                message = Resources.EmptyLogNameException;
                return false;
            }

            var logDirectory = FileSystemHelper.GetDatabaseFolderPath("U2.Logger");
            Directory.CreateDirectory(logDirectory);
            var logFiles = Directory.GetFiles(logDirectory, "*.sqlite");
            if (logFiles.Any(f => Path.GetFileNameWithoutExtension(f)
                .Equals(LogName, StringComparison.InvariantCultureIgnoreCase)))
            {
                message = string.Format(Resources.LogNameIsInUseFmt, LogName);
                if (throwException)
                {
                    throw new Avalonia.Data.DataValidationException(message);
                }
                return false;
            }

            message = string.Empty;
            return true;
        }

        public void ExecuteOkAction()
        {
            if (!CanExecute(throwException: false, out string errorMessage))
            {
                MessageBox.Avalonia.DTO.MessageBoxCustomParams @params = new MessageBox.Avalonia.DTO.MessageBoxCustomParams
                {
                    CanResize = false,
                    ShowInCenter = true,
                    Topmost = true,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    ContentTitle = "Error",
                    ContentMessage = errorMessage,
                    SizeToContent = SizeToContent.WidthAndHeight,
                };

                var messageBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxCustomWindow(@params);
                messageBox.Show();
                return;
            }

            var logInfo = new LogInfo
            {
                LogName = this.LogName,
                Description = this.Description,
            };
            var message = new ExecuteCommandMessage(CommandToExecute, logInfo);
            Messenger.Default.Send(message);

            AppSettings.Default.LogName = this.LogName;
            AppSettings.Default.Save();
            Owner.Close();
        }

        public void CloseWindow()
        {
            Owner.Close();
        }
    }
}
