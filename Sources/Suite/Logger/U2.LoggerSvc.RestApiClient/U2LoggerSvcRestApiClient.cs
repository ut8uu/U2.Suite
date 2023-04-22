using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
//using U2.ApiCore.Extensions;
using U2.LoggerSvc.ApiTypes.v1;

namespace U2.LoggerSvc.RestApiClient;

public sealed class U2LoggerSvcRestApiClient : IU2LoggerSvcRestApiClient
{
    private readonly Uri _healthPathUri = new Uri("logger-service/v1/health", UriKind.Relative);
    private readonly Uri _createContactPathUri = new Uri("logger-service/v1/logger/create", UriKind.Relative);
    private readonly Uri _listContactsPathUri = new Uri("logger-service/v1/logger/list", UriKind.Relative);
    private readonly string _deleteContactPathUri = "logger-service/v1/logger/delete/{0}";
    private readonly string _updateContactPathUri = "logger-service/v1/logger/update/{0}";

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

    #region Logger

    public async Task<int> CreateContactAsync(ContactDto contactDto, CancellationToken ct)
    {
        if (contactDto == null)
        {
            throw new ArgumentNullException(nameof(contactDto));
        }

        var response = await _httpClient.PostAsync(_createContactPathUri, contactDto, _defaultJsonFormatter, ct);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsAsync<int>();
    }

    public async Task<bool> DeleteContactAsync(int id, CancellationToken ct)
    {
        try
        {
            var url = string.Format(_deleteContactPathUri, id);
            var uri = new Uri(url, UriKind.Relative);

            var response = await _httpClient.DeleteAsync(uri, ct);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<bool>();
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public async Task<bool> UpdateContactAsync(int id, ContactDto contactDto, CancellationToken ct)
    {
        try
        {
            var url = string.Format(_updateContactPathUri, id);
            var uri = new Uri(url, UriKind.Relative);

            var response = await _httpClient.PostAsync(uri, contactDto, _defaultJsonFormatter, ct);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<bool>();
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public async Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken ct)
    {
        try
        {
            var response = await _httpClient.GetAsync(_listContactsPathUri, ct);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<IEnumerable<ContactDto>>();
            return result;
        }
        catch (HttpRequestException)
        {
            return Enumerable.Empty<ContactDto>();
        }
    }

    #endregion

    public async Task<ResourceStreamWithMediaType> GetResourceAsStreamAsync(string requestUri, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        //await response.ThrowOnProblem();
        Debug.Assert(response != null);

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var mediaType = response.Content.Headers.ContentType.MediaType;
        return new ResourceStreamWithMediaType(stream, mediaType);
    }

    private async Task<TOutType> GetTypeByUriAsync<TOutType>(string uri, CancellationToken ct)
    {
        var response = await _httpClient.GetAsync(uri, ct);
        //await response.ThrowOnProblem();

        return await response.Content.ReadAsAsync<TOutType>(_formatters, ct);
    }
}
