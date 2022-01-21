using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using Tmds.DBus;
using U2.Contracts;
using U2.Core;

namespace U2.Logger
{
    public sealed class TextInputPanelViewModel : ViewModelBase
    {
        bool _internalChange = false;
        private Timer _timer;

        public TextInputPanelViewModel()
        {
            Messenger.Default.Register<ExecuteCommandMessage>(this,
                AcceptExecuteCommandMessage);

            _timer = new Timer(TimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            Mode = AllModes.First();
            Band = AllBands.First();
            Frequency = ConversionHelper.BandNameAndModeToFrequency(Band, Mode).ToString();
            RstSent = ConversionHelper.ModeToDefaultReport(Mode);
            RstRcvd = RstSent;
        }

        private void TimerTick(object? state)
        {
            if (Realtime)
            {
                Timestamp = DateTime.UtcNow.ToString("g");
            }
        }

        public const string CallsignTextBox = nameof(CallsignTextBox);
        public const string RstSentTextBox = nameof(RstSentTextBox);
        public const string RstRcvdTextBox = nameof(RstRcvdTextBox);
        public const string OperatorTextBox = nameof(OperatorTextBox);
        public const string CommentsTextBox = nameof(CommentsTextBox);
        public const string TimestampTextBox = nameof(TimestampTextBox);
        public const string ModeTextBox = nameof(ModeTextBox);
        public const string FrequencyTextBox = nameof(FrequencyTextBox);

        public string CallsignInputTitle { get; set; } = "Callsign";
        public string RstSentInputTitle { get; set; } = "Rst Sent";
        public string RstRcvdInputTitle { get; set; } = "Rst Received";
        public string OperatorInputTitle { get; set; } = "Operator";
        public string FrequencyInputTitle { get; set; } = "Freq (MHz)";
        public string ModeInputTitle { get; set; } = "Mode";
        public string BandInputTitle { get; set; } = "Band";
        public string CommentsInputTitle { get; set; } = "Comments";
        public string TimestampInputTitle { get; set; } = "Timestamp";
        public string RealtimeTitle { get; set; } = "realtime";

        public Window Owner { get; set; } = default!;
        public string Callsign { get; set; } = default!;
        public string RstSent { get; set; } = default!;
        public string RstRcvd { get; set; } = default!;
        public string Operator { get; set; } = default!;
        public string Comments { get; set; } = default!;
        public string Frequency { get; set; } = default!;
        public string Mode { get; set; } = default!;
        public string Band { get; set; } = default!;
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("g");
        public bool Realtime { get; set; } = true;
        public bool TimestampEnabled => !Realtime;

        public ApplicationTextBox FocusedTextBox { get; set; } = ApplicationTextBox.Callsign;

        public ObservableCollection<string> AllModes => new ObservableCollection<string>(ConversionHelper.AllModes.Select(m => m.Name)); 
        public ObservableCollection<string> AllBands => new ObservableCollection<string>(ConversionHelper.AllBands.Select(m => m.Name)); 

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
            Timestamp = DateTime.UtcNow.ToString("g");

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
                case nameof(Mode):
                    message = new TextChangedMessage(this, ApplicationTextBox.Mode, Mode);
                    break;
                case nameof(Band):
                    message = new TextChangedMessage(this, ApplicationTextBox.Band, Band);
                    break;
                case nameof(Timestamp):
                    message = new TextChangedMessage(this, ApplicationTextBox.Timestamp, Timestamp);
                    break;
                case nameof(Frequency):
                    message = new TextChangedMessage(this, ApplicationTextBox.Frequency, Frequency);
                    break;
                default:
                    return;
            }

            Messenger.Default.Send(message);
        }
    }
}
