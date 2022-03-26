using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using log4net;
using Microsoft.EntityFrameworkCore;
using U2.Core;
using U2.Core.Models;
using U2.Logger.Models;
using U2.Resources;

[assembly: InternalsVisibleTo("U2.Logger.Tests")]
namespace U2.Logger
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ILog _logger = LogManager.GetLogger("Logger");

        public MainWindowViewModel()
        {
            Messenger.Default.Register<ButtonClickedMessage>(this,
                AcceptButtonClickedMessage);
            Messenger.Default.Register<ExecuteCommandMessage>(this,
                AcceptExecuteCommandMessage);
            Messenger.Default.Register<DatabaseCorruptedMessage>(this,
                AcceptDatabaseCorruptedMessage);

            OpenDatabase();
        }

        private void OpenDatabase()
        {
            WindowTitle = $"U2.Logger - {AppSettings.Default.LogName}";
            try
            {
                LoggerDbContext.Instance.Database.Migrate();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public Window? Owner { get; set; } = null;

        public string StatusText { get; set; } = default!;
        public string WindowTitle { get; set; } = default!;

        private void AcceptButtonClickedMessage(ButtonClickedMessage message)
        {
            switch (message.Button)
            {
                case ApplicationButton.WipeButton:
                    _logger.Debug("Accepted WipeButtonClicked command.");
                    Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.ClearTextInputs));
                    break;
                case ApplicationButton.SaveButton:
                    _logger.Debug("Accepted SaveButtonClicked command.");
                    _logger.Debug("Issued SaveQso(null) command.");
                    Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.SaveQso, null));
                    break;
                default:
                    // unknown buttons are ignored
#warning TODO What about logging this?
                    break;
            }
        }

        public void ViewLog()
        {
            var logWindow = new LogContentWindow();
            logWindow.Show(Owner);
        }

        public void ViewSettings()
        {
            var settingsWindow = new LoggerSettingsWindow();
            settingsWindow.ShowDialog(Owner);
        }

        private void AcceptExecuteCommandMessage(ExecuteCommandMessage message)
        {
            if (message.CommandToExecute == CommandToExecute.SaveQso)
            {
                if (message.CommandParameters is QsoData formData)
                {
                    _logger.Debug($"Accepted SaveQso(notNullObject) command. Value: \r\n{formData.ToString()}");
                    if (formData.CanBeSaved())
                    {
                        LoggerDbContext.Instance.SaveQso(formData);
                        Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.ClearTextInputs, null));
                        Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.InitQso, null));
                        Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.RefreshLog));
                    }
                }
            }
            else if (message.CommandToExecute == CommandToExecute.DeleteQso)
            {
                if (message.CommandParameters is Guid[] records)
                {
                    LoggerDbContext.Instance.DeleteQso(records);
                    Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.RefreshLog));
                }
            }
            else if (message.CommandToExecute == CommandToExecute.CreateLog)
            {
                // create a new log
                if (!(message.CommandParameters is LogInfo logInfo))
                {
                    return;
                }

                var dbDirectory = FileSystemHelper.GetDatabaseFolderPath(ApplicationNames.LoggerLinux);
                var dbPath = Path.Combine(dbDirectory, $"{logInfo}{CommonConstants.DatabaseExtension}");
                if (File.Exists(dbPath))
                {
                    var msg = string.Format(Resources.LogNameIsInUseFmt, logInfo.LogName);
                    var showMessageMsg = new ExecuteCommandMessage(CommandToExecute.ShowMessage, msg);
                    Messenger.Default.Send(showMessageMsg);
                    return;
                }

                AppSettings.Default.LogName = Path.GetFileNameWithoutExtension(logInfo.LogName);
                AppSettings.Default.Save();

                var switchLogMessage = new ExecuteCommandMessage(CommandToExecute.SwitchLog, null);
                Messenger.Default.Send(switchLogMessage);
            }
            else if (message.CommandToExecute == CommandToExecute.SwitchLog)
            {
                OpenDatabase();
            }
        }

        private void AcceptDatabaseCorruptedMessage(DatabaseCorruptedMessage message)
        {
            _logger.Debug($"Database {message.CorruptedDatabaseName} is corrupted.");


        }

        public async Task NewLog()
        {
            var form = new LogInfoWindow(CommandToExecute.CreateLog);
            await form.ShowDialog(Owner);
        }
    }
}
