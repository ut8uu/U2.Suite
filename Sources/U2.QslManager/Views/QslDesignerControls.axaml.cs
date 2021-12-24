using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.QslManager
{
    public partial class QslDesignerControls : UserControl
    {
        private readonly QslCardFieldsModel _qslCardFields;

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
            DataContext = new QslCardFieldsViewModel(qslCardFields);
            this._qslCardFields = qslCardFields;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
