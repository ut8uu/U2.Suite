namespace U2.WebApp;

#nullable disable

public abstract class ContainerControl : VisualControl 
{
	protected ContainerControl(string name, string viewName) : base(name, viewName)
	{
	}

	public List<VisualControl> Children { get; set; }
}
