using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using U2.Contracts;
using U2.Core;
using U2.LoggerSvc.ApiTypes.v1;
using U2.LoggerSvc.Data;

namespace U2.LoggerSvc.Core;

public class LoggerMappingProfile : Profile
{
    public LoggerMappingProfile()
    {
        CreateMap<Contact, ContactDto>()
            .ForMember(dest => dest.Band, act => act.MapFrom(src => src.Band.Name))
            .ForMember(dest => dest.BandRx, act => act.MapFrom(src => src.BandRx.Name))
            .ForMember(dest => dest.Mode, act => act.MapFrom(src => src.Mode.Name))
            ;
        CreateMap<ContactDto, Contact>()
            .ForMember(dest => dest.Band, act => act.MapFrom(src => ConversionHelper.BandNameToBand(src.Band)))
            .ForMember(dest => dest.BandRx, act => act.MapFrom(src => ConversionHelper.BandNameToBand(src.BandRx ?? src.Band)))
            .ForMember(dest => dest.Mode, act => act.MapFrom(src => ConversionHelper.ModeNameToMode(src.Mode)))
            ;

        CreateMap<Contact, LoggerEntry>()
            .ForMember(dest => dest.Band, act => act.MapFrom(src => src.Band.Name))
            .ForMember(dest => dest.BandRx, act => act.MapFrom(src => src.BandRx.Name))
            .ForMember(dest => dest.Mode, act => act.MapFrom(src => src.Mode.Name))
            ;
        CreateMap<LoggerEntry, Contact>()
            .ForMember(dest => dest.Band, act => act.MapFrom(src => ConversionHelper.BandNameToBand(src.Band)))
            .ForMember(dest => dest.BandRx, act => act.MapFrom(src => MapBand(src.BandRx, src.Band, src.Frequency)))
            .ForMember(dest => dest.Mode, act => act.MapFrom(src => ConversionHelper.ModeNameToMode(src.Mode)))
            ;
    }

    private static RadioBand MapBand(string bandName, string bandNameExt, decimal frequency)
    {
        var band = ConversionHelper.BandNameToBand(bandName);
        if (band != null)
        {
            return band;
        }
        band = ConversionHelper.BandNameToBand(bandNameExt);
        if (band != null)
        {
            return band;
        }
        var bandNameCalculated = ConversionHelper.FrequencyToBandName(frequency);
        return ConversionHelper.BandNameToBand(bandNameCalculated);
    }
}
