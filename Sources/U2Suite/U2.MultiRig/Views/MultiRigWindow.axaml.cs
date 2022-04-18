using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaEdit.Utils;
using PropertyChanged;
using U2.MultiRig.ViewModels;

namespace U2.MultiRig
{
    [DoNotNotify]
    public partial class MultiRigWindow : Window
    {
        private MultiRigWindowViewModel _model;

        public MultiRigWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _model = new MultiRigWindowViewModel
            {
                Owner = this,
                SelectedRigIndex = 0,
            };
            DataContext = _model;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
