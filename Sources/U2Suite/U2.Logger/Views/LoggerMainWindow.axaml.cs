using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LoggerMainWindow : Window
    {
        private TextInputPanel _textInputs = default!;
        private FuncButtonsPanel _funcButtonsPanel;

        public LoggerMainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _textInputs = this.FindControl<TextInputPanel>("TextInputs");
            _textInputs.Owner = this;
            _textInputs.DataContext = new TextInputPanelViewModel();

            _funcButtonsPanel = this.FindControl<FuncButtonsPanel>("FuncButtons");
            _funcButtonsPanel.Owner = this;
            _funcButtonsPanel.DataContext = new FuncButtonsPanelViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
