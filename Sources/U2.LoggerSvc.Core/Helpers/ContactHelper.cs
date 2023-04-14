using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U2.Logger.Data;

namespace U2.LoggerSvc.Core;

public static class ContactHelper
{
    /// <summary>
    /// Converts given log entry to contact.
    /// </summary>
    /// <param name="logEntry">An entry to be converted.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ConversionFailedException"></exception>
    public static Contact ToContact(this LogEntry logEntry)
    {
        if (logEntry == null)
        {
            throw new ArgumentNullException(nameof(logEntry));
        }

        var contact = new Contact();
        // TODO implement this
        return contact;
    }

    /// <summary>
    /// Converts contact to log entry.
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ConversionFailedException"></exception>
    public static LogEntry ToLogEntry(this Contact contact) 
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact));
        }

        var entry = new LogEntry();
        // TODO implement this
        return entry;
    }
}
