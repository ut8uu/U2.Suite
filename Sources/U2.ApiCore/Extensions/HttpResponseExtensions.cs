/*
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using U2.Core.Exceptions;
using U2.Core.Converters;

namespace U2.Core.Extensions;

public static class HttpResponseExtensions
{
    private static MediaTypeWithQualityHeaderValue ProblemDetailsMediaType => new MediaTypeWithQualityHeaderValue("application/problem+json")
    {
        CharSet = "utf-8"
    };

    private static JsonMediaTypeFormatter GetFormatter()
    {
        return new JsonMediaTypeFormatter
        {
            SupportedMediaTypes = { (MediaTypeHeaderValue)ProblemDetailsMediaType },
            SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter>
                {
                    new ProblemDetailsJsonConverter()
                }
            }
        };
    }

    public static async Task<HttpResponseMessage> ThrowOnProblem(this HttpResponseMessage response)
    {
        var (flag, problemDetails) = await response.ReadProblemDetailsOnError();
        if (flag)
        {
            throw new ProblemDetailsException(problemDetails);
        }

        response.EnsureSuccessStatusCode();
        return response;
    }

    public static async Task<(bool, ProblemDetails)> ReadProblemDetailsOnError(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode && response.Content.Headers.ContentType != null && response.Content.Headers.ContentType.Equals(ProblemDetailsMediaType))
        {
            return (true, await response.Content.ReadAsAsync<ProblemDetails>(new JsonMediaTypeFormatter[1] { GetFormatter() }));
        }

        return (false, null);
    }

    public static string PrettyPrint(this ProblemDetails problemDetails)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (!string.IsNullOrWhiteSpace(problemDetails.Title))
        {
            stringBuilder.AppendLine(problemDetails.Title);
        }

        if (!string.IsNullOrWhiteSpace(problemDetails.Detail))
        {
            stringBuilder.AppendLine(problemDetails.Detail);
        }
        else if (problemDetails.Extensions.ContainsKey("errors"))
        {
            object obj = problemDetails.Extensions["errors"];
            IDictionary<string, string[]> dictionary = obj as IDictionary<string, string[]>;
            if (dictionary != null)
            {
                foreach (KeyValuePair<string, string[]> item in dictionary)
                {
                    string text = string.Join(" ", item.Value);
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        if (string.IsNullOrWhiteSpace(item.Key))
                        {
                            stringBuilder.AppendLine(text);
                        }
                        else
                        {
                            stringBuilder.AppendLine(item.Key + " : " + text);
                        }
                    }
                }
            }
            else
            {
                string value = obj.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    stringBuilder.AppendLine(value);
                }
            }
        }

        if (!string.IsNullOrWhiteSpace(problemDetails.Type))
        {
            stringBuilder.AppendLine("More about this kind of errors can be found at '" + problemDetails.Type + "'.");
        }

        if (!string.IsNullOrWhiteSpace(problemDetails.Instance))
        {
            stringBuilder.AppendLine("You may find more details in server logs when searching for '" + problemDetails.Instance + "'.");
        }

        if (problemDetails.Extensions.ContainsKey("traceId"))
        {
            stringBuilder.AppendLine(string.Format("Trace identifier of failed request is '{0}'.", problemDetails.Extensions["traceId"]));
        }

        return stringBuilder.ToString();
    }
}
//*/