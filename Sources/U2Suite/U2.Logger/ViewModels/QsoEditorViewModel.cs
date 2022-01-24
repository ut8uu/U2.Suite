using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
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
            Operator = record.Operator;
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
        public string RstReceivedTitle { get; set; } = "RST received";
        public string OperatorTitle { get; set; } = "Operator name";
        public string CommentsTitle { get; set; } = "Comments";
        public string FrequencyTitle { get; set; } = "Frequency";
        public string ModeTitle { get; set; } = "Mode";
        public string BandTitle { get; set; } = "Band";
        public string TimestampTitle { get; set; } = "Timestamp";

        public string Callsign { get; set; } = default!;
        public string RstSent { get; set; } = default!;
        public string RstReceived { get; set; } = default!;
        public string Operator { get; set; } = default!;
        public string Comments { get; set; } = default!;
        public string Frequency { get; set; } = default!;
        public string Mode { get; set; } = default!;
        public string Band { get; set; } = default!;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public ObservableCollection<string> AllModes =>
            new ObservableCollection<string>(
                ConversionHelper.AllModes.Select(m=>m.Name).OrderBy(mode => mode));

        public void OkButtonClick()
        {
            if (string.IsNullOrWhiteSpace(this.Frequency))
            {
                this.Frequency = ConversionHelper.BandNameToFrequency(this.Band).ToString();
            }
            var freq = double.Parse(this.Frequency, CultureInfo.InvariantCulture);
            var formData = new QsoData
            {
                Callsign = this.Callsign,
                FreqMhz = freq,
                Band = ConversionHelper.FrequencyToBandName(freq),
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
