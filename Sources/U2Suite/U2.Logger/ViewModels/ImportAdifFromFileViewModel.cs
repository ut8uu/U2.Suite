using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Extensions;
using U2.Contracts;
using U2.Logger.ViewModels;

namespace U2.Logger
{
    internal enum DuplicateRecordSaveOption
    {
        Overwrite,
        Ignore,
        Add,
    }

    internal class ImportAdifFromFileViewModel : WindowViewModelBase
    {
        internal DuplicateRecordSaveOption _duplicateRecordSaveOption = DuplicateRecordSaveOption.Overwrite;

        public ImportAdifFromFileViewModel()
        {
            WindowTitle = Resources.ImportFromAdifWindowTitle;

            UpdateAdifFileInfoGrid();
        }

        #region Properties

        public int AdifFileLines { get; set; } = 0;
        public int AdifFileRecords { get; set; } = 0;
        public int AdifFileDuplicates { get; set; } = 0;
        public int AdifFileWarnings { get; set; } = 0;
        public int AdifFileErrors { get; set; } = 0;

        #endregion

        public string AdifFileName { get; set; } = string.Empty;

        public string AdifFilenameTitle { get; set; } = Resources.AdifFilenameTitle;

        #region Import progress

        public string ImportProgressText { get; set; } = String.Format(Resources.ImportProgressFormat, 0, 0, 0);
        public bool ImportProgressVisible { get; set; } = false;

        #endregion

        #region Buttons

        public string ImportButtonTitle { get; set; } = Resources.ImportButtonTitle;
        public string CloseButtonTitle { get; set; } = Resources.CloseButtonTitle;

        #endregion

        #region Duplicate records options

        public string DuplicatesTitle { get; set; } = Resources.ImportFromAdifFileOptionsDuplicates;
        public string DuplicatesOverwriteTitle { get; set; } = Resources.ImportFromAdifFileOptionsDuplicatesOverwrite;
        public string DuplicatesIgnoreTitle { get; set; } = Resources.ImportFromAdifFileOptionsDuplicatesIgnore;
        public string DuplicatesAddTitle { get; set; } = Resources.ImportFromAdifFileOptionsDuplicatesAdd;

        public string DuplicatesOptionsGroupName { get; init; } = nameof(DuplicatesOptionsGroupName);

        #endregion

        #region Adif file info

        public string AdifFileLinesTitle { get; set; } = Resources.AdifFileLinesTitle;
        public string AdifFileDuplicatesTitle { get; set; } = Resources.AdifFileDuplicatesTitle;
        public string AdifFileRecordsTitle { get; set; } = Resources.AdifFileRecordsTitle;
        public string AdifFileWarningsTitle { get; set; } = Resources.AdifFileWarningsTitle;
        public string AdifFileErrorsTitle { get; set; } = Resources.AdifFileErrorsTitle;

        public ObservableCollection<GroupViewItem> AdifFileInfoItems { get; set; } = new ObservableCollection<GroupViewItem>();

        #endregion

        #region Log

        public ObservableCollection<LogEntry> LogContent { get; set; } = new ObservableCollection<LogEntry>();

        #endregion

        public void ExecuteCloseAction()
        {
            Owner.Close();
        }

        public void ExecuteOverwriteSelectedAction()
        {
            _duplicateRecordSaveOption = DuplicateRecordSaveOption.Overwrite;
        }

        public void ExecuteIgnoreSelectedAction()
        {
            _duplicateRecordSaveOption = DuplicateRecordSaveOption.Ignore;
        }

        public void ExecuteAddSelectedAction()
        {
            _duplicateRecordSaveOption = DuplicateRecordSaveOption.Add;
        }

        public void ExecuteImportAction()
        {

        }

        public async Task ExecuteSelectAdifFileAction()
        {
            var dialog = new OpenFileDialog
            {
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter
                    {
                        Extensions = new List<string>{ "adi", "adif" },
                        Name = "ADIF files"
                    },
                    new FileDialogFilter
                    {
                        Extensions = new List<string>{ "*" },
                        Name = "All files"
                    },
                },
                Title = Resources.AdifFilenameTitle,
                AllowMultiple = false,
            };

            try
            {
                LogContent.Clear();

                var files = await dialog.ShowAsync(Owner) ?? Array.Empty<string>();
                if (files.Any() && !File.Exists(files[0]))
                {
                    AddLogItem(LogEntryType.Error, $"File {AdifFileName} not found.");
                    return;
                }

                var records = AdifHelper.ParseAdif(files[0], out var errors);
                foreach (var error in errors)
                {
                    LogContent.Add(error);
                }
                if (errors.Any(e => e.Type == LogEntryType.Error))
                {
                    return;
                }


            }
            catch (OperationCanceledException)
            {

            }
        }

        private void AddLogItem(LogEntryType type, string message)
        {
            LogContent.Add(new LogEntry(type, message));
        }

        private void UpdateAdifFileInfoGrid()
        {
            AdifFileInfoItems.Clear();
            AddAdifFileInfoGridRow(AdifFileLinesTitle, AdifFileLines);
            AddAdifFileInfoGridRow(AdifFileRecordsTitle, AdifFileRecords);
            AddAdifFileInfoGridRow(AdifFileDuplicatesTitle, AdifFileDuplicates);
            AddAdifFileInfoGridRow(AdifFileWarningsTitle, AdifFileWarnings);
            AddAdifFileInfoGridRow(AdifFileErrorsTitle, AdifFileErrors);

            OnPropertyChanged(nameof(AdifFileInfoItems));
        }

        private void AddAdifFileInfoGridRow(string key, int value)
        {
            AdifFileInfoItems.Add(new GroupViewItem(key));
            var stringValue = value.ToString();
            if (value == 0)
            {
                stringValue = string.Empty;
            }
            AdifFileInfoItems.Add(new GroupViewItem(stringValue, check: true));
        }
    }

    internal class ImportAdifFromFileViewModelDemo : ImportAdifFromFileViewModel
    {
        public ImportAdifFromFileViewModelDemo()
        {
            ImportProgressVisible = true;
            LogContent = new ObservableCollection<LogEntry> {
                new LogEntry(LogEntryType.Info, "Data loaded"),
                new LogEntry(LogEntryType.Warning, "Record found too early"),
                new LogEntry(LogEntryType.Error, "Parsing error"),
            };
        }
    }
}
