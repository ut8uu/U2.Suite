using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PropertyChanged;

namespace U2.MultiRig.Views
{
    [DoNotNotify]
    public class RigSettingsView : UserControl
    {
        private readonly RigSettingsViewModel _model;

        public RigSettingsView()
        {
            InitializeComponent();

            _model = new RigSettingsViewModel();
            DataContext = _model;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
