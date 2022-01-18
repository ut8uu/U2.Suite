using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Globalization;
using System.Text;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using U2.Core;

namespace U2.Logger
{
    public sealed class QsoEditorViewModel : ViewModelBase
    {
        private LogRecordDbo _record = default!;

        public QsoEditorViewModel()
        {
            _record = new LogRecordDbo();
        }

        public QsoEditorViewModel(LogRecordDbo record)
        {
            _record = record;

            Callsign = record.Callsign;
            Operator = record.Callsign;
            RstReceived = record.RstReceived;
            RstSent = record.RstSent;
            Comments = record.Comments;
            Frequency = record.Frequency.ToString(CultureInfo.DefaultThreadCurrentUICulture);
            Mode = record.Mode;
            Timestamp = record.Timestamp;
        }

        public Window Owner { get; set; }

        public string OkButtonTitle { get; set; } = "OK";
        public string CancelButtonTitle { get; set; } = "Cancel";
        public string CallsignTitle { get; set; } = "Callsign";
        public string RstSentTitle { get; set; } = "RST sent";
        public string RstReceivedTitle { get; set; } = "RS received";
        public string OperatorTitle { get; set; } = "Operator name";
        public string CommentsTitle { get; set; } = "Comments";
        public string FrequencyTitle { get; set; } = "Frequency";
        public string ModeTitle { get; set; } = "Mode";
        public string TimestampTitle { get; set; } = "Timestamp";

        public string Callsign { get; set; }
        public string RstSent { get; set; }
        public string RstReceived { get; set; }
        public string Operator { get; set; }
        public string Comments { get; set; }
        public string Frequency { get; set; }
        public string Mode { get; set; }
        public DateTime Timestamp { get; set; }

        public ObservableCollection<string> AllModes =>
            new ObservableCollection<string>(new[]
            {
                "Cw", "SSB", "RTTY", "Olivia", "THOR", "PSK"
            });

        public void OkButtonClick()
        {
            var freq = double.Parse(this.Frequency, CultureInfo.InvariantCulture);
            var formData = new ApplicationFormData
            {
                Callsign = this.Callsign,
                FreqKhz = freq,
                Band = ConversionHelper.FrequencyToBand(freq),
                Mode = this.Mode,
                Comments = this.Comments,
                Timestamp = this.Timestamp,
                Operator = this.Operator,
                RstRcvd = this.RstReceived,
                RstSent = this.RstSent,
            };
            Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.SaveQso, formData));
            Owner.Close();
        }

        public void CancelButtonClick()
        {
            Owner.Close();
        }
    }
}
