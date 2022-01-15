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
        [PropertyChanged.DoNotNotify]
        public string CallsignInputTitle { get; set; } = "Callsign";
        [PropertyChanged.DoNotNotify]
        public string RstSentInputTitle { get; set; } = "Rst Sent";
        [PropertyChanged.DoNotNotify]
        public string RstRvcdInputTitle { get; set; } = "Rst Rvcd";
        [PropertyChanged.DoNotNotify]
        public string OperatorInputTitle { get; set; } = "Operator";
        [PropertyChanged.DoNotNotify]
        public string CommentsInputTitle { get; set; } = "Comments";


        public Window Owner { get; set; } = default!;
        public string Callsign { get; set; } = default!;
        public string RstSent { get; set; } = default!;
        public string RstRvcd { get; set; } = default!;
        public string Operator { get; set; } = default!;
        public string Comments { get; set; } = default!;

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            var textBox = ApplicationTextBox.Callsign;
            var value = Callsign;
            switch (propertyName)
            {
                case nameof(Callsign):
                    textBox = ApplicationTextBox.Callsign;
                    value = Callsign;
                    break;
                case nameof(RstRvcd):
                    textBox = ApplicationTextBox.RstReceived;
                    value = RstRvcd;
                    break;
                case nameof(RstSent):
                    textBox = ApplicationTextBox.RstSent;
                    value = RstSent;
                    break;
                case nameof(Operator):
                    textBox = ApplicationTextBox.Operator;
                    value = Operator;
                    break;
                case nameof(Comments):
                    textBox = ApplicationTextBox.Comments;
                    value = Comments;
                    break;
                default:
                    return;
            }

            var message = new TextChangedMessage
            {
                NewValue = value,
                TextBox = textBox,
                Sender = this
            };
            Messenger.Default.Send(message);
        }
    }
}
