using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using U2.Core;

namespace U2.QslManager
{
    public class QslCardFieldsViewModel : ViewModelBase
    {
        public QslCardFieldsViewModel(QslCardFieldsModel qslCardFields,
            List<QslCardDesign> designs)
        {
            ClearFieldsCommand = ReactiveCommand.Create(ClearFields);
            PreviewCardCommand = ReactiveCommand.Create(PreviewCard);

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

        internal void Clear()
        {
            Callsign = string.Empty;
            OperatorName = string.Empty;
            CqZone = string.Empty;
            ItuZone = string.Empty;
            Grid = string.Empty;
            Qth = string.Empty;
            Text1 = string.Empty;
            Text2 = string.Empty;
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
        public ReactiveCommand<Unit, Unit> ClearFieldsCommand { get; }
        public ReactiveCommand<Unit, Unit> PreviewCardCommand { get; }

        private void ClearFields()
        {
            Clear();
        }

        private void PreviewCard()
        {
            var a = Callsign;
        }
    }
}
