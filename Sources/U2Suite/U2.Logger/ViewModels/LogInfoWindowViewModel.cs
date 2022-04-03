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
using U2.Resources;

namespace U2.Logger
{
    public class LogInfoWindowViewModel : ViewModelBase
    {
        protected bool _initiating = false;
        private Window? _owner;

        public LogInfoWindowViewModel() 
        {
            CommandToExecute = CommandToExecute.CreateLog;
            WindowTitle = Resources.CreateNewLog;
        }

        public LogInfoWindowViewModel(CommandToExecute commandToExecute)
        {
            CommandToExecute = commandToExecute;

            WindowTitle = commandToExecute switch
            {
                CommandToExecute.CreateLog => Resources.CreateNewLog,
                CommandToExecute.UpdateLog => Resources.UpdateLog,
                CommandToExecute.OpenLog => Resources.OpenLog,
                _ => throw new ArgumentOutOfRangeException(nameof(commandToExecute)),
            };

            if (commandToExecute == CommandToExecute.UpdateLog)
            {
                SetLogInfo(LogInfoHelper.LoadLogInfo(AppSettings.Default.LogName));
            }
        }

        public void SetLogInfo(LogInfo logInfo)
        {
            _initiating = true;
            LogName = logInfo?.LogName ?? String.Empty;
            StationCallsign = logInfo?.StationCallsign ?? String.Empty;
            OperatorCallsign = logInfo?.OperatorCallsign ?? String.Empty;
            ActivatedReference = logInfo?.ActivatedReference ?? String.Empty;
            Description = logInfo?.Description ?? String.Empty;
            _initiating = false;

            if (logInfo == null)
            {
                return;
            }

            OnPropertyChanged(nameof(LogName));
            OnPropertyChanged(nameof(StationCallsign));
            OnPropertyChanged(nameof(OperatorCallsign));
            OnPropertyChanged(nameof(ActivatedReference));
            OnPropertyChanged(nameof(Description));
        }

        public string WindowTitle { get; set; } = string.Empty;
        public string LogNameTitle { get; set; } = Resources.LogName;
        public string LogNameToolTip { get; set; } = Resources.LogNameToolTip;
        public string OperatorCallsignTitle { get; set; } = Resources.OperatorCallsign;
        public string OperatorCallsignToolTip { get; set; } = Resources.OperatorCallsignToolTip;
        public string StationCallsignTitle { get; set; } = Resources.StationCallsign;
        public string StationCallsignToolTip { get; set; } = Resources.StationCallsignToolTip;
        public string ActivatedReferenceTitle { get; set; } = Resources.ActivatedReference;
        public string ActivatedReferenceToolTip { get; set; } = Resources.ActivatedReferenceToolTip;
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

        public string LogName { get; set; }
        public string Description { get; set; } = default!;
        public string StationCallsign { get; set; } = default!;
        public string OperatorCallsign { get; set; } = default!;
        public string ActivatedReference { get; set; } = default!;

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (_initiating)
            {
                return;
            }

            if (propertyName == nameof(LogName)
                || propertyName == nameof(StationCallsign))
            {
                CanExecute(throwException: true, out var _);
            }
            base.OnPropertyChanged(propertyName);
        }

        internal bool CanExecute(bool throwException, out string message)
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

            if (string.IsNullOrEmpty(StationCallsign))
            {
                if (throwException)
                {
                    throw new Avalonia.Data.DataValidationException(Resources.EmptyStationCallsignException);
                }
                message = Resources.EmptyStationCallsignException;
                return false;
            }

            var logDirectory = FileSystemHelper.GetDatabaseFolderPath(ApplicationNames.LoggerLinux);
            Directory.CreateDirectory(logDirectory);
            var logFiles = Directory.GetFiles(logDirectory, CommonConstants.DatabaseExtension);
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
                    ButtonDefinitions = new[]
                    {
                        new MessageBox.Avalonia.Models.ButtonDefinition
                        {
                            Name = "OK",
                            Type = MessageBox.Avalonia.Enums.ButtonType.Default,
                            IsDefault = true,
                        }
                    }
                };

                var messageBox = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxCustomWindow(@params);
                messageBox.Show();
                return;
            }

            var logInfo = new LogInfo
            {
                LogName = this.LogName,
                Description = this.Description,
                StationCallsign = this.StationCallsign,
                OperatorCallsign = this.OperatorCallsign,
                ActivatedReference = this.ActivatedReference,
            };
            var message = new ExecuteCommandMessage(CommandToExecute, logInfo);
            Messenger.Default.Send(message);

            Owner.Close();
        }

        public void CloseWindow()
        {
            Owner.Close();
        }
    }

    public sealed class DemoLogInfoWindowViewModel : LogInfoWindowViewModel
    {
        public DemoLogInfoWindowViewModel()
        {
            _initiating = true;
            LogName = nameof(LogName);
            Description = nameof(Description);
            StationCallsign = nameof(StationCallsign);
            OperatorCallsign = nameof(OperatorCallsign);
            ActivatedReference = nameof(ActivatedReference);
            _initiating = false;
        }

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
        }
    }
}
