using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using U2.Core;
using U2.LoggerSvc.ApiTypes.v1;
using U2.LoggerSvc.Data;

namespace U2.LoggerSvc.Core;

public static class ContactConversionHelper
{
    private static IMapper _mapper;
    private static IMapper Mapper
    {
        get
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new LoggerMappingProfile());
                });
                _mapper = mappingConfig.CreateMapper();
            }

            return _mapper;
        }
    }

    /// <summary>
    /// Converts given log entry to contact.
    /// </summary>
    /// <param name="logEntry">An entry to be converted.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ConversionFailedException"></exception>
    public static Contact ToContact(this LoggerEntry logEntry)
    {
        if (logEntry == null)
        {
            throw new ArgumentNullException(nameof(logEntry));
        }

        try
        {
            return Mapper.Map<Contact>(logEntry);
        }
        catch (Exception ex)
        {
            throw new ConversionFailedException(typeof(LoggerEntry), typeof(Contact), ex.Message);
        }
    }

    /// <summary>
    /// Converts contact to log entry.
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ConversionFailedException"></exception>
    public static LoggerEntry ToLogEntry(this Contact contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact));
        }

        try
        {
            return Mapper.Map<LoggerEntry>(contact);
        }
        catch (Exception ex)
        {
            throw new ConversionFailedException(typeof(Contact), typeof(LoggerEntry), ex.Message);
        }
    }

    public static ContactDto ToContactDto(this Contact contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact));
        }
        try
        {
            return Mapper.Map<ContactDto>(contact);
        }
        catch (Exception ex)
        {
            throw new ConversionFailedException(typeof(Contact), typeof(ContactDto), ex.Message);
        }
    }

    public static Contact ToContact(this ContactDto contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact));
        }
        try
        {
            return Mapper.Map<Contact>(contact);
        }
        catch (Exception ex)
        {
            throw new ConversionFailedException(typeof(ContactDto), typeof(Contact), ex.Message);
        }
    }
}
