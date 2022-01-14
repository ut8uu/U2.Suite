using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.QslManager
{
    [PropertyChanged.DoNotNotify]
    public partial class QslDesignerControls : UserControl
    {
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
                Text2 = string.Empty,
                BackgroundImage = @"Images/kyiv.jpg"
            };
            _viewModel = new QslCardFieldsViewModel(qslCardFields);
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void SetOwner(Window owner)
        {
            _viewModel.SetOwner(owner);
        }
    }
}
