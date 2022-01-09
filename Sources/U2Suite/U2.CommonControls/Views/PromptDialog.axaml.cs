using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

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

    public partial class PromptDialog : Window
    {
        private TextBlock _title;
        private TextBox _response;
        private Button _ok;
        private Button _cancel;

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
            _title = (TextBlock)this.Find<TextBlock>("PromptText");
            Debug.Assert(_title != null);

            _response = (TextBox)this.Find<TextBox>("PromptResponse");
            Debug.Assert(_response != null);

            _ok = (Button)this.FindControl<Button>("OkButton");
            Debug.Assert(_ok != null);
            _ok.Click += Ok_Click;

            _cancel = (Button)this.FindControl<Button>("CancelButton");
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
