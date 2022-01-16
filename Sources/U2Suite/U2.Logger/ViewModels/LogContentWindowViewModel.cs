using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace U2.Logger
{
    public sealed class LogContentWindowViewModel : ViewModelBase
    {
        private readonly LoggerDbContext _dbContext;

        public LogContentWindowViewModel()
        {

        }

        public string CloseButtonText { get; set; } = "Close";

        public string CallsignColumnHeader { get; set; } = "Callsign";
        public string TimestampColumnHeader { get; set; } = "Timestamp";
        public string FrequencyColumnHeader { get; set; } = "Freq";
        public string ModeColumnHeader { get; set; } = "Mode";
        public string RstSentColumnHeader { get; set; } = "Snt";
        public string RstReceivedColumnHeader { get; set; } = "Rcv";
        public string NameColumnHeader { get; set; } = "Name";
        public string CommentsColumnHeader { get; set; } = "Comments";

        public LogContentWindowViewModel(LoggerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public ObservableCollection<LogRecordDbo> FullList { get; set; } = default!;
        public ObservableCollection<LogRecordDbo> FilteredList { get; set; } = default!;

    }
}
