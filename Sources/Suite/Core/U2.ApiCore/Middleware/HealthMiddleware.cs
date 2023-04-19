/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace U2.ApiCore;

public static class HealthMiddleware
{
    public static void UseHealth(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = delegate (HttpContext httpContext, HealthReport report)
            {
                httpContext.Response.ContentType = "text/plain";
                StringBuilder stringBuilder = new StringBuilder();
                foreach (KeyValuePair<string, HealthReportEntry> entry in report.Entries)
                {
                    entry.Deconstruct(out var key, out var value);
                    string value2 = key;
                    HealthReportEntry healthReportEntry = value;
                    StringBuilder stringBuilder2 = stringBuilder;
                    StringBuilder stringBuilder3 = stringBuilder2;
                    StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(3, 2, stringBuilder2);
                    handler.AppendFormatted(value2);
                    handler.AppendLiteral(" : ");
                    handler.AppendFormatted(healthReportEntry.Status);
                    stringBuilder3.AppendLine(ref handler);
                    if (string.IsNullOrEmpty(healthReportEntry.Description))
                    {
                        stringBuilder2 = stringBuilder;
                        StringBuilder stringBuilder4 = stringBuilder2;
                        handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
                        handler.AppendFormatted(healthReportEntry.Description);
                        stringBuilder4.AppendLine(ref handler);
                    }
                }

                return httpContext.Response.WriteAsync(stringBuilder.ToString());
            }
        });
    }
}
//*/