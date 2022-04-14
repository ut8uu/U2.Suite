using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Markup.Xaml;

namespace U2.CommonControls
{
    [PropertyChanged.DoNotNotify]
    public partial class TextBoxWithTitle : TemplatedControl
    {
        public TextBoxWithTitle()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        #region Title DP

        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<TextBoxWithTitle, string>(nameof(Title),
                defaultBindingMode: BindingMode.TwoWay);

        public string Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        #endregion

        #region Value DP

        public static readonly StyledProperty<string> ValueProperty =
            AvaloniaProperty.Register<TextBoxWithTitle, string>(nameof(Value));

        public string Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion

        #region ToolTip DP

        public static readonly StyledProperty<string> ToolTipProperty =
            AvaloniaProperty.Register<TextBoxWithTitle, string>(nameof(ToolTip));

        public string ToolTip
        {
            get => GetValue(ToolTipProperty);
            set => SetValue(ToolTipProperty, value);
        }

        #endregion
    }
}
