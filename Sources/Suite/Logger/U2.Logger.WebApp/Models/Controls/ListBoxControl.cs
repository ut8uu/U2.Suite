namespace U2.Logger.WebApp;

#nullable disable

public abstract class ListBoxControl<T> : VisualControl 
	where T : class
{
    public List<T> Items { get; set; }
}
