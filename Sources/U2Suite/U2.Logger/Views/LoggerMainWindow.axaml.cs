using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using GalaSoft.MvvmLight.Messaging;

namespace U2.Logger
{
    [PropertyChanged.DoNotNotify]
    public partial class LoggerMainWindow : Window
    {
        private TextInputPanel _textInputs = default!;
        private FuncButtonsPanel _funcButtonsPanel;
        internal ApplicationTextBox? _selectedTextBox = null;

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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Space)
            {
                Messenger.Default.Send(new ButtonClickedMessage(this, ApplicationButton.SpaceButton));
                e.Handled = true;
                return;
            }
        }

        protected override void OnGotFocus(GotFocusEventArgs e)
        {
            base.OnGotFocus(e);

            if (e.Source is TextBox tb)
            {
                _selectedTextBox = ControlHelper.TextBoxFromString(tb.Name ?? string.Empty);
            }
            else
            {
                _selectedTextBox = null;
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            _selectedTextBox = null;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
