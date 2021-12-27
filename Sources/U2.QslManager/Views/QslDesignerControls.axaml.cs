using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using System.Reactive;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class QslDesignerControls : UserControl
    {
        private readonly QslCardFieldsModel _qslCardFields;
        private readonly QslCardFieldsViewModel _viewModel;

        public QslDesignerControls()
        {
            InitializeComponent();

            QslCardFieldsModel qslCardFields = new QslCardFieldsModel
            {
                Callsign = "UT8UU",
                CqZone = "16",
                Grid = "KO50gk",
                ItuZone = "29",
                OperatorName = "Sergey Usmanov",
                Qth = "Kyiv",
                Text1 = string.Empty,
                Text2 = string.Empty
            };
            _viewModel = new QslCardFieldsViewModel(qslCardFields, Utilities.GetDesigns());
            DataContext = _viewModel;
            this._qslCardFields = qslCardFields;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
