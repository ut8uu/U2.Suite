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
    Task CreateAsync(Contact contact, CancellationToken cancellationToken);
}
