namespace U2.CommonControls;


public class TextBoxWithTitleViewModel
{
    public string Title { get; set; }
    public string Value { get; set; }
    public string Tooltip { get; set; }
}

internal class DemoTextBoxWithTitleViewModel : TextBoxWithTitleViewModel
{
    public DemoTextBoxWithTitleViewModel()
    {
        Title = nameof(Title);
        Value = nameof(Value);
        Tooltip = nameof(Tooltip);
        
    }
}