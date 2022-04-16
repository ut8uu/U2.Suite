using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using log4net;
using Microsoft.EntityFrameworkCore;
using U2.CommonControls;
using U2.Core;
using U2.Core.Models;
using U2.Resources;

[assembly: InternalsVisibleTo("U2.Logger.Tests")]
namespace U2.Logger
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ILog _logger = LogManager.GetLogger("Logger");

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
            SetWindowTitle();
            try
            {
                LoggerDbContext.Reset();
                LoggerDbContext.Instance.Database.Migrate();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void SetWindowTitle()
        {
            WindowTitle = $"U2.Logger - {AppSettings.Default.LogName}";
        }

        public Window? Owner { get; set; } = null;

        public string StatusText { get; set; } = default!;
        public string WindowTitle { get; set; } = default!;

        public string ImportFromAdifTitle { get; set; } = "Import ADIF from file";
        public string ExportToAdifTitle { get; set; } = "Export to ADIF file";
        public string ConfigMenuTitle { get; set; } = Resources.ConfigMenuTitle;
        public string ConfigCatMenuTitle { get; set; } = Resources.ConfigCatMenuTitle;

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
            switch (message.CommandToExecute)
            {
                case CommandToExecute.SaveQso:
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

                    break;
                }
                case CommandToExecute.DeleteQso:
                {
                    if (message.CommandParameters is Guid[] records)
                    {
                        LoggerDbContext.Instance.DeleteQso(records);
                        Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.RefreshLog));
                    }

                    break;
                }
                case CommandToExecute.CreateLog:
                {
                    // create a new log
                    if (message.CommandParameters is not LogInfo logInfo)
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

                    LogInfoHelper.SaveLogInfo(logInfo);

                    AppSettings.Default.LogName = logInfo.LogName;
                    AppSettings.Default.Save();

                    var switchLogMessage = new ExecuteCommandMessage(CommandToExecute.SwitchLog, null);
                    Messenger.Default.Send(switchLogMessage);
                    break;
                }
                case CommandToExecute.UpdateLog:
                {
                    if (message.CommandParameters is not LogInfo logInfo)
                    {
                        return;
                    }

                    LogInfoHelper.SaveLogInfo(logInfo);
                    SetWindowTitle();
                    break;
                }
                case CommandToExecute.SwitchLog:
                    OpenDatabase();
                    break;
                case CommandToExecute.ShutDown:
                    LoggerDbContext.ShutDown();
                    break;
                case CommandToExecute.ClearTextInputs:
                    break;
                case CommandToExecute.InitQso:
                    break;
                case CommandToExecute.RefreshLog:
                    break;
                case CommandToExecute.OpenLog:
                    break;
                case CommandToExecute.ShowMessage:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AcceptDatabaseCorruptedMessage(DatabaseCorruptedMessage message)
        {
            _logger.Debug($"Database {message.CorruptedDatabaseName} is corrupted.");


        }

        #region Action handlers

        public async Task NewLog()
        {
            var form = new LogInfoWindow(CommandToExecute.CreateLog);
            await form.ShowDialog(Owner);
        }

        public async Task OpenLog()
        {
            var form = new LogListWindow();
            await form.ShowDialog(Owner);
        }

        public async Task UpdateLog()
        {
            var form = new LogInfoWindow(CommandToExecute.UpdateLog);
            await form.ShowDialog(Owner);
        }

        public async Task ImportFromAdif()  
        {
            var form = new ImportAdifFromFileWindow();
            await form.ShowDialog(Owner);
        }

        public async Task ExecuteExportToAdifAction()
        {
            var saveDialog = new SaveFileDialog();
            Debug.Assert(Owner != null, "Owner not set.");
            var fileName = await saveDialog.ShowAsync(Owner);
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            var extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension))
            {
                fileName += ".adi";
            }

            var logInfo = LogInfoHelper.GetCurrentLogInfo();
            if (await AdifHelper.ExportAsync(fileName, logInfo, LoggerDbContext.Instance.Records))
            {
                MessageBoxHelper.ShowMessageBox("Success", Resources.ExportToAdifSuccessfulMessage);
            }
            else
            {
                MessageBoxHelper.ShowMessageBox("Error", Resources.ExportToAdifFailedMessage);
            }
        }

        public void ExecuteCatControlConfig()
        {

        }

        #endregion
    }

    public sealed class DesignMainWindowViewModel : MainWindowViewModel
    {

    }
}
