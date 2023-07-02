using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using U2.CIS.ApiTypes.v1;
using U2.CIS.Data;

namespace U2.CIS.Core;

public sealed class CisMapperProfile : Profile
{
	public CisMapperProfile() 
	{
		CreateMap<CallInfo, CallInfoDto>();
		CreateMap<CallInfoDto, CallInfo>();

		CreateMap<CallInfo, CallInfoEntry>();
		CreateMap<CallInfoEntry, CallInfo>();
	}
}
