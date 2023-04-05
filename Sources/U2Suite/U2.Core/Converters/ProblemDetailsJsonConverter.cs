using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.Core.Converters;

internal sealed class ProblemDetailsJsonConverter : JsonConverter<ProblemDetails>
{
    public override bool CanWrite => false;

    public override ProblemDetails ReadJson(JsonReader reader, Type objectType, ProblemDetails existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        ProblemDetails problemDetails = (hasExistingValue ? existingValue : new ProblemDetails());
        if (reader.TokenType != JsonToken.StartObject)
        {
            throw new JsonException("Expected Json Start token");
        }

        while (reader.Read() && reader.TokenType != JsonToken.EndObject)
        {
            string text = reader.Value!.ToString();
            if (text.Equals("type", StringComparison.OrdinalIgnoreCase))
            {
                problemDetails.Type = reader.ReadAsString();
            }
            else if (text.Equals("title", StringComparison.OrdinalIgnoreCase))
            {
                problemDetails.Title = reader.ReadAsString();
            }
            else if (text.Equals("status", StringComparison.OrdinalIgnoreCase))
            {
                problemDetails.Status = reader.ReadAsInt32();
            }
            else if (text.Equals("detail", StringComparison.OrdinalIgnoreCase))
            {
                problemDetails.Detail = reader.ReadAsString();
            }
            else if (text.Equals("instance", StringComparison.OrdinalIgnoreCase))
            {
                problemDetails.Instance = reader.ReadAsString();
            }
            else if (text.Equals("errors", StringComparison.OrdinalIgnoreCase))
            {
                reader.Read();
                IDictionary<string, string[]> value = serializer.Deserialize<IDictionary<string, string[]>>(reader);
                problemDetails.Extensions[text] = value;
            }
            else
            {
                reader.Read();
                object value2 = serializer.Deserialize(reader);
                problemDetails.Extensions[text] = value2;
            }
        }

        if (reader.TokenType != JsonToken.EndObject)
        {
            throw new JsonException("Expected Json End token");
        }

        return problemDetails;
    }

    public override void WriteJson(JsonWriter writer, ProblemDetails value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
