namespace U2.WebApp;

public class VerticalLayoutControl : ContainerControl
{
	public VerticalLayoutControl(string name, List<VisualControl> items) 
		: base(name, "/Views/CommonControls/VerticalLayout.cshtml")
	{
		this.Children = items;
	}
}
