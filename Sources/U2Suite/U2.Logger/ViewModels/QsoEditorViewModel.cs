using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using log4net;
using U2.Core;

namespace U2.Logger
{
    public sealed class QsoEditorViewModel : ViewModelBase
    {
        private LogRecordDbo _record = default!;
        private bool _internalChange;
        ILog _logger = LogManager.GetLogger("Logger");

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
            Band = record.Band;
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
                ConversionHelper.AllModes.Select(m=>m.Name)
                .OrderBy(mode => mode));

        public ObservableCollection<string> AllBands =>
            new ObservableCollection<string>(
                ConversionHelper.AllBands.Select(b => b.Name)
                .OrderBy(name => name));

        public void OkButtonClick()
        {
            if (string.IsNullOrWhiteSpace(this.Frequency))
            {
                this.Frequency = ConversionHelper.BandNameToFrequency(this.Band).ToString();
            }
            var freq = double.Parse(this.Frequency, CultureInfo.InvariantCulture);
            var formData = new QsoData(_record.RecordId)
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
                Modified = true,

            };
            Messenger.Default.Send(new ExecuteCommandMessage(CommandToExecute.SaveQso, formData));
            Owner.Close();
        }

        public void CancelButtonClick()
        {
            Owner.Close();
        }

        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (_internalChange)
            {
                return;
            }

            switch (propertyName)
            {
                case nameof(Callsign):
                    _internalChange = true;
                    Callsign = Callsign.ToUpper();
                    OnPropertyChanged(nameof(Callsign));
                    _internalChange = false;
                    _logger.Debug($"New {propertyName} value: {Callsign}");
                    break;
                case nameof(Frequency):
                    if (double.TryParse(Frequency, out var freq))
                    {
                        var bandName = ConversionHelper.FrequencyToBandName(freq);
                        if (!string.IsNullOrEmpty(bandName))
                        {
                            if (Band != bandName)
                            {
                                Band = bandName;
                                _internalChange = true;
                                OnPropertyChanged(nameof(Band));
                                _internalChange = false;
                                _logger.Debug($"Frequency is {Frequency}. Mode changed to {Mode}.");
                            }
                        }
                        _logger.Debug($"New {propertyName} value: {Frequency}");
                    }
                    break;
                default:
                    return;
            }
        }
    }
}
