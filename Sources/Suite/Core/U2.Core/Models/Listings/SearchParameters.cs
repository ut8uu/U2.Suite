using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace U2.Core;

public sealed class SearchParameters
{
    [Description("String is used to search by content.")]
    [FromQuery(Name = "search")]
    public string Search { get; set; }

    [Description("Allows specify how search text must be used. Default value - 'Contains'.")]
    public SearchOption SearchOption { get; set; } = SearchOption.Contains;

    public QueryString ToQueryString()
    {
        return new QueryBuilder { 
            { "search", Search }, 
            { "search_option", SearchOption.ToString() } }
        .ToQueryString();
    }
}
