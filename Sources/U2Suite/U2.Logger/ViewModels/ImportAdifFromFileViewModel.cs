using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Extensions;
using Avalonia.Threading;
using U2.CommonControls;
using U2.Contracts;

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
        internal CancellationTokenSource _cancellationTokenSource;

        internal readonly List<LogRecordDbo> _duplicates = new();
        internal readonly List<LogRecordDbo> _loadedRecords = new();

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

        public string ProgressText { get; set; }
        public bool ProgressPanelVisible { get; set; } = false;

        #endregion

        #region Buttons

        public string ImportButtonTitle { get; set; } = Resources.ImportButtonTitle;
        public string CloseButtonTitle { get; set; } = Resources.CloseButtonTitle;

        public string CancelOperationButtonTitle { get; set; } = Resources.CancelOperationButtonTitle;
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

        protected override void SetOwner(Window owner)
        {
            base.SetOwner(owner);
        }

        internal void ExecuteCloseAction()
        {
            Owner.Close();
        }

        internal void ExecuteOverwriteSelectedAction()
        {
            _duplicateRecordSaveOption = DuplicateRecordSaveOption.Overwrite;
        }

        internal void ExecuteIgnoreSelectedAction()
        {
            _duplicateRecordSaveOption = DuplicateRecordSaveOption.Ignore;
        }

        internal void ExecuteAddSelectedAction()
        {
            _duplicateRecordSaveOption = DuplicateRecordSaveOption.Add;
        }

        internal void ExecuteImportAction()
        {
            if (_loadedRecords == null || !_loadedRecords.Any())
            {
                AddLogItem(LogEntryType.Warning, "No records to import.");
                return;
            }

            AddLogItem(LogEntryType.Info, "Import started.");

            var records = LoggerDbContext.Instance.Records;

            ShowProgressPanel();

            var totalRecords = _loadedRecords.Count;
            var currentRecord = 1.0m;

            foreach (var record in _loadedRecords)
            {
                if (_duplicates.Any(d => d.Hash == record.Hash))
                {
                    if (_duplicateRecordSaveOption == DuplicateRecordSaveOption.Overwrite)
                    {
                        var existingRecord = records.FirstOrDefault(d => d.Hash == record.Hash);
                        if (existingRecord != null) 
                        {
                            records.Remove(existingRecord);
                            LoggerDbContext.Instance.SaveChanges();
                        }
                    }
                    else if (_duplicateRecordSaveOption == DuplicateRecordSaveOption.Ignore)
                    {
                        continue;
                    }
                }

                if (currentRecord++ % 10 == 1)
                {
                    var percentage = 100m * Math.Round(currentRecord / totalRecords);
                    DisplayProgressText(string.Format(Resources.ImportProgressFormat, currentRecord, totalRecords, percentage));
                }

                records.Add(record);
            }

            HideProgressPanel();

            LoggerDbContext.Instance.SaveChanges();
            AddLogItem(LogEntryType.Info, "Import finished.");
        }

        internal void ExecuteCancelOperationAction()
        {
            _cancellationTokenSource.Cancel();
            HideProgressPanel();
        }

        internal async Task ExecuteSelectAdifFileAction()
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
                _duplicates.Clear();
                _loadedRecords.Clear();
                ClearLog();
                ResetAdifFileInfoGrid();

                var files = await dialog.ShowAsync(Owner) ?? Array.Empty<string>();
                if (files.Any() && !File.Exists(files[0]))
                {
                    AddLogItem(LogEntryType.Error, $"File {AdifFileName} not found.");
                    return;
                }

                var filePath = files[0];
                AdifFileName = filePath;
                OnPropertyChanged(nameof(AdifFileName));

                _cancellationTokenSource = new CancellationTokenSource();

                await ProcessAdifFileAsync(filePath, _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {

            }
        }

        internal async Task ProcessAdifFileAsync(string filePath, CancellationToken cancellationToken)
        {
            ShowProgressPanel(string.Empty);

            try
            {
                var progressFormat = string.Empty;
                var progress = new Progress<string>(text =>
                {
                    DisplayProgressText(text);
                });

                var errors = new List<LogEntry>();
                _loadedRecords.AddRange(await AdifHelper.LoadAdifAsync(filePath, cancellationToken, progress, errors));
                AddLogItem(LogEntryType.Info, "ADIF file loaded.");

                if (cancellationToken.IsCancellationRequested)
                {
                    ResetAdifFileInfoGrid();
                    AddLogItem(LogEntryType.Info, Resources.OperationCancelledMessage);
                    return;
                }

                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        LogContent.Add(error);
                    }
                    OnPropertyChanged(nameof(LogContent));
                }

                AdifFileErrors = errors.Count(e => e.Type == LogEntryType.Error);
                AdifFileWarnings = errors.Count(e => e.Type == LogEntryType.Warning);
                AdifFileRecords = _loadedRecords.Count();
                UpdateAdifFileInfoGrid();

                if (errors.Any(e => e.Type == LogEntryType.Error))
                {
                    return;
                }

                if (!_loadedRecords.Any())
                {
                    return;
                }

                var mainLogHashes = LoggerDbContext.Instance.Records.Select(r => r.Hash).AsEnumerable();
                AddLogItem(LogEntryType.Info, "Looking for duplicates.");
                if (AdifHelper.HasDuplicates(mainLogHashes, _loadedRecords, out var duplicates))
                {
                    AdifFileDuplicates = duplicates.Count();
                    _duplicates.AddRange(duplicates);
                    UpdateAdifFileInfoGrid();
                }
                AddLogItem(LogEntryType.Info, "Lookup finished.");
            }
            finally
            {
                HideProgressPanel();
            }
        }

        private void ClearLog()
        {
            LogContent.Clear();
            OnPropertyChanged(nameof(LogContent));
        }

        private void AddLogItem(LogEntryType type, string message)
        {
            LogContent.Add(new LogEntry(type, message));
            OnPropertyChanged(nameof(LogContent));
        }

        private void ResetAdifFileInfoGrid()
        {
            AdifFileLines = 0;
            AdifFileRecords = 0;
            AdifFileDuplicates = 0;
            AdifFileWarnings = 0;
            AdifFileErrors = 0;

            UpdateAdifFileInfoGrid();
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
            AdifFileInfoItems.Add(new GroupViewItem(value.ToString(), check: true));
        }

        private void ShowProgressPanel(string? initialText = null)
        {
            if (initialText != null)
            {
                DisplayProgressText(initialText);
            }
            ProgressPanelVisible = true;
            OnPropertyChanged(nameof(ProgressPanelVisible));
        }

        private void HideProgressPanel()
        {
            ProgressPanelVisible = false;
            OnPropertyChanged(nameof(ProgressPanelVisible));
        }

        private void DisplayProgressText(string text)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                ProgressText = text;
                OnPropertyChanged(nameof(ProgressText));
            });
        }
    }

    internal class ImportAdifFromFileViewModelDemo : ImportAdifFromFileViewModel
    {
        public ImportAdifFromFileViewModelDemo()
        {
            ProgressPanelVisible = true;
            LogContent = new ObservableCollection<LogEntry> {
                new LogEntry(LogEntryType.Info, "Data loaded"),
                new LogEntry(LogEntryType.Warning, "Record found too early"),
                new LogEntry(LogEntryType.Error, "Parsing error"),
            };
        }
    }
}
