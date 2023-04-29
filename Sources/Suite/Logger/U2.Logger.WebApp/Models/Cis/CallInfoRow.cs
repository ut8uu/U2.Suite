namespace U2.Logger.WebApp;

#nullable disable

public class CallInfoRow
{
    public bool IsCaption { get; set; }
    public string Title { get; set; }
	public string Value { get; set; }

	public CallInfoRow(string title, string value, bool isCaption = false)
	{
		Title = title;
		Value = value;
		IsCaption = isCaption;
	}
}
