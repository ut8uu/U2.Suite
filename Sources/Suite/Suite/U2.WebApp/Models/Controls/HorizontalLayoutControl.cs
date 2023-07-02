namespace U2.WebApp;

public class HorizontalLayoutControl : ContainerControl
{
	public HorizontalLayoutControl(string name, List<VisualControl> items) 
		: base(name, "/Views/CommonControls/HorizontalLayout.cshtml")
	{
		this.Children = items;
	}
}
