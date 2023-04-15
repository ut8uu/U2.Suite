using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using U2.LoggerSvc.Data;

namespace U2.LoggerSvc.Core;

public static class ContactConversionHelper
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

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new LoggerMappingProfile());
        });
        var mapper =  mappingConfig.CreateMapper();
        try
        {
            var entry = mapper.Map<LogEntry>(contact);
            return entry;
        }
        catch (Exception ex)
        {
            throw new ConversionFailedException(typeof(Contact), typeof(LogEntry), ex.Message);
        }
    }
}
