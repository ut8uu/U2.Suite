using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using U2.Logger.ViewModels;

namespace U2.Logger
{
    internal class ImportAdifFromFileViewModel : WindowViewModelBase
    {
        public ImportAdifFromFileViewModel()
        {
            WindowTitle = Resources.ImportFromAdifWindowTitle;
        }

        public string AdifFileName { get; set; } = string.Empty;

        public string AdifFilenameTitle { get; set; } = Resources.AdifFilenameTitle;
        public string OptionsTitle { get; set; } = Resources.ImportFromAdifFileOptionsTitle;
        public string DuplicatesTitle { get; set; } = Resources.ImportFromAdifFileOptionsDuplicates;
        public string DuplicatesOverwriteTitle { get; set; } = Resources.ImportFromAdifFileOptionsDuplicatesOverwrite;
        public string DuplicatesIgnoreTitle { get; set; } = Resources.ImportFromAdifFileOptionsDuplicatesIgnore;
        public string DuplicatesAddTitle { get; set; } = Resources.ImportFromAdifFileOptionsDuplicatesAdd;

        public string DuplicatesOptionsGroup { get; init; } = nameof(DuplicatesOptionsGroup);
        public string DuplicatesOverwriteKey { get; init; } = "overwrite";
        public string DuplicatesIgnoreKey { get; init; } = "ignore";
        public string DuplicatesAddKey { get; init; } = "add";

        public override void ExecuteOkAction()
        {

        }

        public override void ExecuteCancelAction()
        {
            Owner.Close();
        }

        public void ExecuteOverwriteSelectedAction()
        {

        }

        public void ExecuteIgnoreSelectedAction()
        {

        }

        public void ExecuteAddSelectedAction()
        {

        }

        public async Task SelectAdifFile()
        {
            var dialog = new SaveFileDialog
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
                DefaultExtension = "adi",
                Title = Resources.AdifFilenameTitle,
            };
            try
            {
                AdifFileName = await dialog.ShowAsync(Owner) ?? string.Empty;
            }
            catch (OperationCanceledException)
            {

            }
        }
    }

    internal class ImportAdifFromFileViewModelDemo : ImportAdifFromFileViewModel
    {

    }
}
