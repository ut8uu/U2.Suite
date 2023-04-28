namespace U2.Logger.WebApp;

#nullable disable

public class CisCallShort
{
    public int Id { get; set; }
    public string Call { get; set; }

	public CisCallShort() { }

	public CisCallShort(int id, string call)
	{
		Id = id;
		Call = call;
	}
}