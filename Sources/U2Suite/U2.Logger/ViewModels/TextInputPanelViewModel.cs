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
        public string CallsignInputTitle { get; set; } = "Callsign";
        public string RstSentInputTitle { get; set; } = "Rst Sent";
        public string RstRvcdInputTitle { get; set; } = "Rst Rvcd";
        public string OperatorInputTitle { get; set; } = "Operator";
        public string CommentsInputTitle { get; set; } = "Comments";


        public Window Owner { get; set; } = default!;
        public string Callsign { get; set; } = default!;
        public string RstSent { get; set; } = default!;
        public string RstRcvd { get; set; } = default!;
        public string Operator { get; set; } = default!;
        public string Comments { get; set; } = default!;

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

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
