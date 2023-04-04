using U2.LoggerSvc.ApiTypes.v1;

namespace U2.LoggerSvc.RestApiClient
{
    public interface IU2LoggerSvcRestApiClient
    {
        /// <summary>
        /// Returns health of the BP service.
        /// </summary>
        Task<HealthDto> GetHealthAsync(CancellationToken ct);
    }
}