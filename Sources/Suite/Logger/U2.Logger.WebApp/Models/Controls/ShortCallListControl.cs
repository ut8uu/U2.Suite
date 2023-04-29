namespace U2.WebApp;

public sealed class ShortCallListControl : ListBoxControl<CisCallShort>
{
	public ShortCallListControl(string name, List<CisCallShort> items) : base(name, "ShortCallList")
	{
		this.Items = items;
	}
}