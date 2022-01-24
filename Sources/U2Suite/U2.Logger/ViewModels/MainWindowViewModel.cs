using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using log4net;
using Microsoft.EntityFrameworkCore;
using U2.Core;
using U2.Logger.Models;

[assembly: InternalsVisibleTo("U2.Logger.Tests")]
namespace U2.Logger
{
    public class LoggerMainWindowViewModel : ViewModelBase
    {
        ILog _logger = LogManager.GetLogger("Logger");
        internal LoggerDbContext _dbContext;

        private Window _owner;

        public LoggerMainWindowViewModel()
        {
            Messenger.Default.Register<ButtonClickedMessage>(this,
                AcceptButtonClickedMessage);
            Messenger.Default.Register<ExecuteCommandMessage>(this, 
                AcceptExecuteCommandMessage);


            _dbContext = new LoggerDbContext();
            try
            {
                _dbContext.Database.Migrate();
            }
            catch (Exception ex)
            { 
                if (ex != null)
                {

                }
            }
        }

        public Window Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public string StatusText { get; set; } = default!;

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
            logWindow.Show(_owner);
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
                        _dbContext.SaveQso(formData);
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
                    _dbContext.DeleteQso(records);
                    Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.RefreshLog));
                }
            }
        }
    }
}
