namespace U2.Logger.WebApp;

public sealed class CallInfoSection : List<CallInfoRow>
{
	public CallInfoSection(string title)
	{
		Title = title;
	}

	public string Title { get; }
}
