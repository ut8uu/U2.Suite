namespace U2.WebApp;

public sealed class CallInfoSection : List<CallInfoRow>
{
	public CallInfoSection(string title)
	{
		Title = title;
	}

	public string Title { get; }
}
