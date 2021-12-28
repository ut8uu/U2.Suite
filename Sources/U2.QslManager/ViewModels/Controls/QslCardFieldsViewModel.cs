using System.Collections.Generic;
using System.Reactive;
using GalaSoft.MvvmLight.Messaging;
using ReactiveUI;

namespace U2.QslManager
{
    public class QslCardFieldsViewModel : ViewModelBase
    {
        public QslCardFieldsViewModel(QslCardFieldsModel qslCardFields,
            List<QslCardDesign> designs)
        {
            ClearFieldsCommand = ReactiveCommand.Create(ClearFields);
            PreviewCardCommand = ReactiveCommand.Create(PreviewCard);

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

        public string? Callsign { get; set; }
        public string? CqZone { get; set; }
        public string? ItuZone { get; set; }
        public string? Grid { get; set; }
        public string? Qth { get; set; }
        public string? OperatorName { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }

        public QslCardFieldsModel QslCardFields { get; }
        public List<QslCardDesign>? Designs { get; set; }
        public int SelectedDesignIndex { get; set; }

        public ReactiveCommand<Unit, Unit> ClearFieldsCommand { get; }
        public ReactiveCommand<Unit, Unit> PreviewCardCommand { get; }

        internal void Clear()
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
        }

        private void ClearFields()
        {
            Clear();
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
            };
            var message = new RenderQslMessage
            {
                Fields = fields,
                Design = Designs?[SelectedDesignIndex],
            };
            Messenger.Default.Send(message);
        }
    }
}
