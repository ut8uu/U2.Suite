using U2.LoggerSvc.ApiTypes.v1;

namespace U2.LoggerSvc.RestApiClient;

public interface IU2LoggerSvcRestApiClient : IDisposable
{
    /// <summary>
    /// Returns health of the BP service.
    /// </summary>
    Task<HealthDto> GetHealthAsync(CancellationToken ct);

    /// <summary>
    /// Creates a contact in the database.
    /// </summary>
    /// <param name="contactDto"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<int> CreateContactAsync(ContactDto contactDto, CancellationToken ct);

    /// <summary>
    /// Deletes a contact by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> DeleteContactAsync(int id, CancellationToken ct);

    /// <summary>
    /// Updates a contact
    /// </summary>
    /// <param name="contactDto"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<bool> UpdateContactAsync(int id, ContactDto contactDto, CancellationToken ct);

    /// <summary>
    /// Fetches the list of contacts from the database.
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken ct);
}