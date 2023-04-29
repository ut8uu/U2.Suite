namespace U2.WebApp;

#nullable disable

public abstract class ListBoxControl<T> : VisualControl 
	where T : class
{
	protected ListBoxControl(string name, string viewName) : base(name, viewName)
	{
	}

	public List<T> Items { get; set; }
}
