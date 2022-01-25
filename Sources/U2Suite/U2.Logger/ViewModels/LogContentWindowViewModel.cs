using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace U2.Logger
{
    public sealed class LogContentWindowViewModel : ViewModelBase
    {
        private readonly LoggerDbContext _dbContext;

        public LogContentWindowViewModel()
        {

        }

        public LogContentWindowViewModel(LoggerDbContext dbContext)
        {
            this._dbContext = dbContext;
            FullList = new ObservableCollection<LogRecordDbo>(_dbContext.Records);

            Messenger.Default.Register<ExecuteCommandMessage>(this,
                AcceptExecuteCommandMessage);
        }

        public Window Owner { get; set; }

        public string CloseButtonText { get; set; } = "Close";
        public string EditButtonText { get; set; } = "Edit";
        public string DeleteButtonText { get; set; } = "Delete";

        public string CallsignColumnHeader { get; set; } = "Callsign";
        public string TimestampColumnHeader { get; set; } = "Timestamp";
        public string FrequencyColumnHeader { get; set; } = "Freq (MHz)";
        public string ModeColumnHeader { get; set; } = "Mode";
        public string RstSentColumnHeader { get; set; } = "Snt";
        public string RstReceivedColumnHeader { get; set; } = "Rcv";
        public string NameColumnHeader { get; set; } = "Name";
        public string CommentsColumnHeader { get; set; } = "Comments";

        public ObservableCollection<LogRecordDbo> FullList { get; set; } = default!;
        public ObservableCollection<LogRecordDbo> FilteredList { get; set; } = default!;

        public LogRecordDbo SelectedRecord { get; set; } = default!;
        public List<LogRecordDbo> SelectedItems = new List<LogRecordDbo>();

        private void AcceptExecuteCommandMessage(ExecuteCommandMessage message)
        {
            if (message.CommandToExecute == CommandToExecute.RefreshLog)
            {
                RefreshLog();
            }
        }

        public void RefreshLog()
        {
            FullList = new ObservableCollection<LogRecordDbo>(_dbContext.Records);
        }

        public void CloseButtonClick()
        {
            Owner.Close();
        }

        public void EditButtonClick()
        {
            if (SelectedRecord == null)
            {
                return;
            }

            var editor = new QsoEditorWindow(SelectedRecord);
            editor.ShowDialog(Owner);
        }

        public void SelectItems(List<object> selectedItems)
        {
            if (selectedItems == null)
            {
                return;
            }
            SelectedItems.AddRange(selectedItems.Cast<LogRecordDbo>().Except(SelectedItems));
        }

        public void DeselectItems(IEnumerable<LogRecordDbo> deselectedItems)
        {
            if (deselectedItems == null)
            {
                return;
            }
            SelectedItems = SelectedItems.Except(deselectedItems).ToList();
        }

        /// <summary>
        /// Emits a commend for QSO deletion.
        /// Sends identifiers of all the selected records, if any.
        /// </summary>
        public void DeleteButtonClick()
        {
            if (!SelectedItems.Any())
            {
                return;
            }

            var message = new ExecuteCommandMessage(CommandToExecute.DeleteQso, 
                SelectedItems.Select(i => i.RecordId).ToArray());
            Messenger.Default.Send(message);
            SelectedItems = new List<LogRecordDbo>();
        }
    }
}
