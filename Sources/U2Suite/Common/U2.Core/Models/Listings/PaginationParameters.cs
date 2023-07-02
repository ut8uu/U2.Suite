using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace U2.Core;

public sealed class PaginationParameters
{
    [Description("Defines the size of a single page. Must be greater than 0. Default value is 50.")]
    [FromQuery(Name = "page_size")]
    public int PageSize { get; set; } = 50;

    [Description("Specifies the index of the requested page. Mandatory.")]
    [FromQuery(Name = "page_index")]
    public int PageIndex { get; set; }

    public QueryString ToQueryString()
    {
        return new QueryBuilder
            {
                {
                    "page_index",
                    PageIndex.ToString(CultureInfo.InvariantCulture)
                },
                {
                    "page_size",
                    PageSize.ToString(CultureInfo.InvariantCulture)
                }
            }.ToQueryString();
    }
}
