using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using U2.Core.Extensions;

namespace U2.Core.Exceptions;

[Serializable]
public sealed class ProblemDetailsException : Exception
{
    private readonly JsonSerializerSettings _settings = new JsonSerializerSettings();

    public ProblemDetails ProblemDetails { get; }

    public ProblemDetailsException(ProblemDetails problemDetails)
        : base(problemDetails.PrettyPrint())
    {
        ProblemDetails = problemDetails;
    }

    public ProblemDetailsException(ProblemDetails problemDetails, Exception innerException)
        : base(problemDetails.PrettyPrint(), innerException)
    {
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("ProblemDetails", JsonConvert.SerializeObject(ProblemDetails, _settings));
    }

    private ProblemDetailsException(SerializationInfo info, StreamingContext streamingContext)
    {
        ProblemDetails = JsonConvert.DeserializeObject<ProblemDetails>((string)info.GetValue("ProblemDetails", typeof(string)), _settings);
    }
}
