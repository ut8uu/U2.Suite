namespace U2.Suite.Brandmeister.Core.Models;

internal class ReportsFilterItem
{
    public ReportsFilterItem() { }
    public ReportsFilterItem(string text, FilterCriteria criteria, FilterTarget target)
    {
        Text = text;
        Criteria = criteria;
        Target = target;
    }

    public string Text { get; set; }
    public FilterCriteria Criteria { get; set; }
    public string CriteriaText
    {
        get
        {
            return ReportsFilter.AllSearchCriteriaOptions[(int)Criteria];
        }
    }
    public FilterTarget Target { get; set; }
    public string TargetText
    {
        get
        {
            return ReportsFilter.AllFilterTargetOptions[(int)Target];
        }
    }
}
