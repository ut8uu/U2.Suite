using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using U2.Core;
using U2.Logger.Models;

[assembly: InternalsVisibleTo("U2.Logger.Tests")]
namespace U2.Logger
{
    public class LoggerMainWindowViewModel : ViewModelBase
    {
        internal ApplicationFormData _currentFormData = new ApplicationFormData();
        internal LoggerDbContext _dbContext;

        private Window _owner;

        public LoggerMainWindowViewModel()
        {
            Messenger.Default.Register<ButtonClickedMessage>(this,
                AcceptButtonClickedMessage);
            Messenger.Default.Register<TextChangedMessage>(this,
                AcceptTextChangedMessage);
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

        private void AcceptTextChangedMessage(TextChangedMessage message)
        {
            if (_currentFormData == null)
            {
                _currentFormData = new ApplicationFormData();
            }

            ProcessTextChangedMessage(message, _currentFormData);
        }

        internal static void ProcessTextChangedMessage(TextChangedMessage message, ApplicationFormData formData)
        {
            switch (message.TextBox)
            {
                case ApplicationTextBox.Callsign:
                    formData.Callsign = message.NewValue;
                    break;
                case ApplicationTextBox.Operator:
                    formData.Operator = message.NewValue;
                    break;
                case ApplicationTextBox.RstReceived:
                    formData.RstRcvd = message.NewValue;
                    break;
                case ApplicationTextBox.RstSent:
                    formData.RstSent = message.NewValue;
                    break;
                case ApplicationTextBox.Comments:
                    formData.Comments = message.NewValue;
                    break;
                case ApplicationTextBox.Timestamp:
                    formData.Timestamp = DateTime.Parse(message.NewValue);
                    break;
                case ApplicationTextBox.Mode:
                    formData.Mode = message.NewValue;
                    break;
                case ApplicationTextBox.Band:
                    formData.Band = ConversionHelper.AllBands.FirstOrDefault(b => b.Name == message.NewValue).Name;
                    break;
                case ApplicationTextBox.Frequency:
                    formData.Comments = message.NewValue;
                    break;
            }
        }

        private void AcceptButtonClickedMessage(ButtonClickedMessage message)
        {
            switch (message.Button)
            {
                case ApplicationButton.WipeButton:
                    Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.ClearTextInputs));
                    _currentFormData = new ApplicationFormData();
                    break;
                case ApplicationButton.SaveButton:
                    ProcessSaveButton();
                    break;
                default:
                    // unknown buttons are ignored
#warning TODO What about logging this?
                    break;
            }
        }

        private void ProcessSaveButton()
        {
            if (CanSaveQso())
            {
                Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.SaveQso, _currentFormData));
                Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.ClearTextInputs));
                _currentFormData = new ApplicationFormData();
            }
        }

        private bool CanSaveQso()
        {
            if (_currentFormData == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(_currentFormData.Callsign))
            {
                return false;
            }

            return true;
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
                if (message.CommandParameters is ApplicationFormData formData)
                {
                    _dbContext.SaveQso(formData);
                    Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.RefreshLog));
                }
            }
        }
    }
}
