using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Suite
{
    public partial class AboutFormView : Window
    {
        public AboutFormView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = new AboutFormViewModel(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
