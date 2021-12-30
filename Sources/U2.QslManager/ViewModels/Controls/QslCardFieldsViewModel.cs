using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using GalaSoft.MvvmLight.Messaging;
using ReactiveUI;
using U2.QslManager.Helpers;

namespace U2.QslManager
{
    public class QslCardFieldsViewModel : ViewModelBase
    {
        public Window Owner { get; set; }

        public QslCardFieldsViewModel(QslCardFieldsModel qslCardFields,
            List<QslCardDesign> designs)
        {
            SelectedDesignIndex = 0;

            QslCardFields = qslCardFields;
            Designs = designs;

            Callsign = qslCardFields.Callsign;
            CqZone = qslCardFields.CqZone;
            ItuZone = qslCardFields.ItuZone;
            Grid = qslCardFields.Grid;
            Qth = qslCardFields.Qth;
            OperatorName = qslCardFields.OperatorName;
            Text1 = qslCardFields.Text1;
            Text2 = qslCardFields.Text2;
        }

        private async Task<string?> SelectImage()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter
                    {
                        Extensions = new[] {"gif", "png", "jpg", "jpeg", "tif", "tiff"}.ToList(),
                        Name = "Image files"
                    }
                }
            };
            var list = await openFileDialog.ShowAsync(new Window());
            return list?.First();
        }

        private async Task SelectBackgroundImageAsync()
        {
            BackgroundImage = await SelectImage();
        }

        private async Task SelectImage1Async()
        {
            Image1 = await SelectImage();
        }

        private async Task SelectImage2Async()
        {
            Image2 = await SelectImage();
        }

        public string? Callsign { get; set; }
        public string? CqZone { get; set; }
        public string? ItuZone { get; set; }
        public string? Grid { get; set; }
        public string? Qth { get; set; }
        public string? OperatorName { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? BackgroundImage { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }

        public QslCardFieldsModel QslCardFields { get; }
        public List<QslCardDesign> Designs { get; set; }
        public int SelectedDesignIndex { get; set; }

        private void ClearFields()
        {
            SelectedDesignIndex = 0;
            Callsign = string.Empty;
            OperatorName = string.Empty;
            CqZone = string.Empty;
            ItuZone = string.Empty;
            Grid = string.Empty;
            Qth = string.Empty;
            Text1 = string.Empty;
            Text2 = string.Empty;
            BackgroundImage = string.Empty;
            Image1 = string.Empty;
            Image2 = string.Empty;
        }

        private void PreviewCard()
        {
            var fields = new QslCardFieldsModel
            {
                Callsign = this.Callsign,
                CqZone = this.CqZone,
                ItuZone = this.ItuZone,
                Grid = this.Grid,
                OperatorName = this.OperatorName,
                Qth = this.Qth,
                Text1 = this.Text1,
                Text2 = this.Text2,
                BackgroundImage = this.BackgroundImage,
            };
            var message = new RenderQslMessage
            {
                Fields = fields,
                Design = Designs?[SelectedDesignIndex],
            };
            Messenger.Default.Send(message);
        }

        private async Task ExportCardAsync()
        {
            var fileDialog = new SaveFileDialog();
            var fileName = await fileDialog.ShowAsync(new Window());
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            var fields = new QslCardFieldsModel
            {
                Callsign = this.Callsign,
                CqZone = this.CqZone,
                ItuZone = this.ItuZone,
                Grid = this.Grid,
                OperatorName = this.OperatorName,
                Qth = this.Qth,
                Text1 = this.Text1,
                Text2 = this.Text2,
                BackgroundImage = this.BackgroundImage,
            };
            var design = Designs?[SelectedDesignIndex];
            var bitmap = QslCardGenerator.Generate(design.DensityDpi, fields, design);
            bitmap.Save(fileName);
        }
    }
}
