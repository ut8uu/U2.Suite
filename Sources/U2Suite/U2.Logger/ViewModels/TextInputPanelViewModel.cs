using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Tmds.DBus;

namespace U2.Logger
{
    public sealed class TextInputPanelViewModel : ViewModelBase
    {
        bool _internalChange = false;

        public TextInputPanelViewModel()
        {
            Messenger.Default.Register<ButtonClickedMessage>(this,
                AcceptButtonClickedMessage);
            Messenger.Default.Register<ExecuteCommandMessage>(this,
                AcceptExecuteCommandMessage);
        }

        public const string CallsignTextBox = nameof(CallsignTextBox);
        public const string RstSentTextBox = nameof(RstSentTextBox);
        public const string RstRcvdTextBox = nameof(RstRcvdTextBox);
        public const string OperatorTextBox = nameof(OperatorTextBox);
        public const string CommentsTextBox = nameof(CommentsTextBox);

        public string CallsignInputTitle { get; set; } = "Callsign";
        public string RstSentInputTitle { get; set; } = "Rst Sent";
        public string RstRcvdInputTitle { get; set; } = "Rst Received";
        public string OperatorInputTitle { get; set; } = "Operator";
        public string CommentsInputTitle { get; set; } = "Comments";

        public Window Owner { get; set; } = default!;
        public string Callsign { get; set; } = default!;
        public string RstSent { get; set; } = default!;
        public string RstRcvd { get; set; } = default!;
        public string Operator { get; set; } = default!;
        public string Comments { get; set; } = default!;

        public ApplicationTextBox FocusedTextBox { get; set; } = ApplicationTextBox.Callsign;

        private void AcceptExecuteCommandMessage(ExecuteCommandMessage message)
        {
            if (message.CommandToExecute == CommandToExecute.ClearTextInputs)
            {
                ClearAll();
            }
        }

        private void ClearAll()
        {
            _internalChange = true;

            Callsign = string.Empty;
            RstSent = string.Empty;
            RstRcvd = string.Empty;
            Operator = string.Empty;
            Comments = string.Empty;

            _internalChange = false;
        }

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (_internalChange)
            {
                return;
            }

            TextChangedMessage message;
            switch (propertyName)
            {
                case nameof(Callsign):
                    message = new TextChangedMessage(this, ApplicationTextBox.Callsign, Callsign);
                    break;
                case nameof(RstRcvd):
                    message = new TextChangedMessage(this, ApplicationTextBox.RstReceived, RstRcvd);
                    break;
                case nameof(RstSent):
                    message = new TextChangedMessage(this, ApplicationTextBox.RstSent, RstSent);
                    break;
                case nameof(Operator):
                    message = new TextChangedMessage(this, ApplicationTextBox.Operator, Operator);
                    break;
                case nameof(Comments):
                    message = new TextChangedMessage(this, ApplicationTextBox.Comments, Comments);
                    break;
                default:
                    return;
            }

            Messenger.Default.Send(message);
        }
    }
}
