using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LogInfoUserControl : UserControl
    {
        public LogInfoUserControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
