using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using U2.Core.Extensions;
using U2.LoggerSvc.ApiTypes.v1;

namespace U2.LoggerSvc.RestApiClient;

public sealed class U2LoggerSvcRestApiClient : IU2LoggerSvcRestApiClient
{
    private readonly Uri _healthPathUri = new Uri("logger-service/v1/health", UriKind.Relative);

    private static readonly JsonMediaTypeFormatter _defaultJsonFormatter =
        new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            }
        };
    private static readonly List<MediaTypeFormatter> _formatters =
        new List<MediaTypeFormatter> { _defaultJsonFormatter };

    private readonly HttpClient _httpClient;
    private readonly bool _disposeClient;

    public U2LoggerSvcRestApiClient(string connectionAddress)
    {
        var httpClient = new HttpClient { BaseAddress = new Uri(connectionAddress) };
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("User-Agent", "U2LoggerSvc Client");
        httpClient.Timeout = new TimeSpan(0, 0, 10, 0); // wait ten minutes

        _httpClient = httpClient;
        _disposeClient = true;
    }

    public U2LoggerSvcRestApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _disposeClient = false;
    }

    public void Dispose()
    {
        if (_disposeClient)
        {
            _httpClient.Dispose();
        }
    }

    public async Task<HealthDto> GetHealthAsync(CancellationToken ct)
    {
        return await GetTypeByUriAsync<HealthDto>(_healthPathUri.ToString(), ct);
    }

    public async Task<ResourceStreamWithMediaType> GetResourceAsStreamAsync(string requestUri, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        await response.ThrowOnProblem();

        var stream = await response.Content.ReadAsStreamAsync();
        var mediaType = response.Content.Headers.ContentType.MediaType;
        return new ResourceStreamWithMediaType(stream, mediaType);
    }

    private async Task<TOutType> GetTypeByUriAsync<TOutType>(string uri, CancellationToken ct)
    {
        var response = await _httpClient.GetAsync(uri, ct);
        await response.ThrowOnProblem();

        return await response.Content.ReadAsAsync<TOutType>(_formatters, ct);
    }
}
