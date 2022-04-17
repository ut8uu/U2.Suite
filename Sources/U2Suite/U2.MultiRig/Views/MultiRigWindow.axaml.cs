using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PropertyChanged;

namespace U2.MultiRig
{
    [DoNotNotify]
    public partial class MultiRigWindow : Window
    {
        public MultiRigWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
