using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2.LoggerSvc.RestApiClient;

public readonly struct ResourceStreamWithMediaType
{
    public ResourceStreamWithMediaType(Stream stream, string mediaType)
    {
        Stream = stream;
        MediaType = mediaType;
    }
    public Stream Stream { get; }
    public string MediaType { get; }
}
