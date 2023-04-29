namespace U2.Logger.WebApp;

#nullable disable

public abstract class ContainerControl : VisualControl 
{
	protected ContainerControl(string name, string viewName) : base(name, viewName)
	{
	}

	public List<VisualControl> Children { get; set; }
}
