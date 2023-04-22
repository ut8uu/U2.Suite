using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.LoggerSvc.Core;

namespace U2.LoggerSvc.Core;

public interface ILoggerService
{
    /// <summary>
    /// Retrieves all contacts from the database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Contact>> GetContactsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new contact using given data.
    /// </summary>
    /// <param name="contact">A contact to be created.</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ContactCreationFailedException"></exception>
    Task<int> CreateContactAsync(Contact contact, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a contact by its identifier.
    /// </summary>
    /// <param name="id">An identifier of the contact to be deleted.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns <see langword="true"/> when entity was deleted or <see langword="false"/> otherwise.</returns>
    /// <exception cref="ContactRemovingFailedException"></exception>
    Task<bool> DeleteContactAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Updates given contact in the database.
    /// </summary>
    /// <param name="contact"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ContactUpdateFailedException"></exception>
    Task<bool> UpdateContactAsync(Contact contact, CancellationToken cancellationToken);
}
