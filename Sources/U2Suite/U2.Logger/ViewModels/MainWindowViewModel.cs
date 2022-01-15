using System;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace U2.Logger
{
    public class LoggerMainWindowViewModel : ViewModelBase
    {
        public LoggerMainWindowViewModel()
        {
            Messenger.Default.Register<ButtonClickedMessage>(this,
                AcceptButtonClickedMessage);
            Messenger.Default.Register<TextChangedMessage>(this,
                AcceptTextChangedMessage);
        }

        private void AcceptTextChangedMessage(TextChangedMessage obj)
        {
            throw new NotImplementedException();
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
