using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.QslManager
{
    public partial class TextField : UserControl
    {
        public TextField()
        {
            InitializeComponent();

            DataContext = new TextFieldViewModel
            {
                Name = "callsign",
                Text = "UT8UU"
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
