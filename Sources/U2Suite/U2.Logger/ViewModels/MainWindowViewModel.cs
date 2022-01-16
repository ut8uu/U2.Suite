using System;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;

[assembly: InternalsVisibleTo("U2.Logger.Tests")]
namespace U2.Logger
{
    public class LoggerMainWindowViewModel : ViewModelBase
    {
        internal ApplicationFormData _currentFormData;

        public LoggerMainWindowViewModel()
        {
            Messenger.Default.Register<ButtonClickedMessage>(this,
                AcceptButtonClickedMessage);
            Messenger.Default.Register<TextChangedMessage>(this,
                AcceptTextChangedMessage);
        }

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
            }
        }

        private void AcceptButtonClickedMessage(ButtonClickedMessage obj)
        {
            throw new NotImplementedException();
        }

        public LoggerMainWindowViewModel(Window owner)
        {
            Owner = owner;
        }

        public Window Owner { get; } = default!;
        public string StatusText { get; set; } = default!;
    }
}
