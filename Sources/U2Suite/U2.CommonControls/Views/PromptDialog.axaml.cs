using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.CommonControls
{
    public enum DialogResult
    {
        OK,
        Cancel,
        Abort,
        Yes,
        No
    }

    public class PromptDialog : Window
    {
        private TextBlock _title = default!;
        private TextBox _response = default!;
        private Button _ok = default!;
        private Button _cancel = default!;

        public PromptDialog()
        {
            AssignControls();
        }

        public PromptDialog(string promptText, string promptInitialResponse = "")
        {
            PromptText = promptText;
            PromptResponse = promptInitialResponse;

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            AssignControls();

            _title.Text = promptText;
            _response.Text = promptInitialResponse;
        }

        private void AssignControls()
        {
            _title = this.Find<TextBlock>("PromptText");
            Debug.Assert(_title != null);

            _response = this.Find<TextBox>("PromptResponse");
            Debug.Assert(_response != null);

            _ok = this.FindControl<Button>("OkButton");
            Debug.Assert(_ok != null);
            _ok.Click += Ok_Click;

            _cancel = this.FindControl<Button>("CancelButton");
            Debug.Assert(_cancel != null);
            _cancel.Click += Cancel_Click;
        }

        private void Cancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Ok_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            PromptResponse = _response.Text;
            this.Close();
        }

        public DialogResult DialogResult { get; set; } = DialogResult.OK;
        public string PromptText { get; set; } = "Prompt";
        public string PromptResponse { get; set; } = "Response";

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
