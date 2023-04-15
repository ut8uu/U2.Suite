using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using U2.LoggerSvc.Data;

namespace U2.LoggerSvc.Core;

public class LoggerMappingProfile : Profile
{
    public LoggerMappingProfile()
    {
        CreateMap<LogEntry, Contact>();
        CreateMap<Contact, LogEntry>();
    }
}
