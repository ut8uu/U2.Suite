namespace U2.Logger.WebApp;

public sealed class ShortCallListControl : ListBoxControl<CisCallShort>
{
	public ShortCallListControl(List<CisCallShort> items)
	{
		this.ViewName = "ShortCallList";
		this.Items = items;
	}
}