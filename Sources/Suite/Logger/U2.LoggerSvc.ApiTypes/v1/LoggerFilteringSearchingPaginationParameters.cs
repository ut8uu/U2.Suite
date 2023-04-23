using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Core;

namespace U2.LoggerSvc.ApiTypes;

public sealed class LoggerFilteringSearchingPaginationParameters
{
    public SearchParameters SearchParameters { get; set; }
    public SortingParameters SortingParameters { get; set; }
    public PaginationParameters PaginationParameters { get; set; }
    public LoggerFilteringParameters LoggerFilteringParameters { get; set; }
}
