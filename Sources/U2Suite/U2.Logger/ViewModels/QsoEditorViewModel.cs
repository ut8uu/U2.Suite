using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Net.Http;
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
            TimestampString = record.Timestamp.ToString("g");
        }

        public Window Owner { get; set; }

        public string OkButtonTitle { get; set; } = Resources.OK;
        public string CancelButtonTitle { get; set; } = Resources.Cancel;
        public string CallsignTitle { get; set; } = Resources.Callsign;
        public string RstSentTitle { get; set; } = Resources.RstSent;
        public string RstReceivedTitle { get; set; } = Resources.RstReceived;
        public string OperatorTitle { get; set; } = Resources.Operator;
        public string CommentsTitle { get; set; } = Resources.Comments;
        public string FrequencyTitle { get; set; } = Resources.Frequency;
        public string ModeTitle { get; set; } = Resources.Mode;
        public string BandTitle { get; set; } = Resources.Band;
        public string TimestampTitle { get; set; } = Resources.Timestamp;

        public string Callsign { get; set; } = default!;
        public string RstSent { get; set; } = default!;
        public string RstReceived { get; set; } = default!;
        public string Operator { get; set; } = default!;
        public string Comments { get; set; } = default!;
        public string Frequency { get; set; } = default!;
        public string Mode { get; set; } = default!;
        public string Band { get; set; } = default!;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string TimestampString { get; set; }

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
                this.Frequency = ConversionHelper.BandNameToFrequency(this.Band).ToString(CultureInfo.InvariantCulture);
            }

            var freq = StringConverter.StringToDouble(this.Frequency);
            if (freq < 1)
            {
                freq = ConversionHelper.BandNameAndModeToFrequency(Band, Mode);
            }
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
                    _internalChange = false;
                    _logger.Debug($"New {propertyName} value: {Callsign}");
                    break;
                case nameof(Frequency):
                    var freq = StringConverter.StringToDouble(Frequency);
                    if (freq > 0)
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
                case nameof(TimestampString):
                    if (!IsTimestampValid())
                    {
                        throw new Avalonia.Data.DataValidationException(Resources.TimestampNotRecognized);
                    }
                    break;
                default:
                    return;
            }
        }

        private bool IsTimestampValid()
        {
            return (DateTime.TryParse(TimestampString, out var _)
                    || DateTime.TryParse(TimestampString,
                        CultureInfo.InvariantCulture, 
                        DateTimeStyles.AssumeUniversal, out _));
        }

        private bool IsCallsignValid()
        {
            return !string.IsNullOrEmpty(Callsign);
        }

        internal bool CanSave()
        {
            return IsCallsignValid()
                   && IsTimestampValid();
        }
    }
}
