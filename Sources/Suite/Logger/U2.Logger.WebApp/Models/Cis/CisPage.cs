namespace U2.Logger.WebApp;

#nullable disable

public class CisPage
{
    private int pageIndex;
    private string searchString;
    private string call;

    public CisPage(int pageIndex, string searchString, string call)
    {
        this.pageIndex = pageIndex;
        this.searchString = searchString;
        this.call = call;
    }

    public CisCallList Calls { get; set; }
    public CisFilter Filter { get; set; }
    public CisPager Pager { get; set; }
    public CisCallInfo CallInfo { get; set; }
}
