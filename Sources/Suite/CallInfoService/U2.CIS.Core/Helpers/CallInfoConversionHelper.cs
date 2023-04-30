using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using U2.CIS.Data;
using U2.Core;

namespace U2.CIS.Core;

public static class CallInfoConversionHelper
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
					mc.AddProfile(new CisMapperProfile());
				});
				_mapper = mappingConfig.CreateMapper();
			}

			return _mapper;
		}
	}

	public static CallInfoEntry ToCallInfoEntry(this CallInfo callInfo)
	{
		if (callInfo == null)
		{
			throw new ArgumentNullException(nameof(callInfo));
		}

		try
		{
			return Mapper.Map<CallInfoEntry>(callInfo);
		}
		catch (Exception ex)
		{
			throw new ConversionFailedException(typeof(CallInfo), typeof(CallInfoEntry), ex.Message);
		}
	}

	public static CallInfo ToCallInfo(this CallInfoEntry callInfo)
	{
		if (callInfo == null)
		{
			throw new ArgumentNullException(nameof(callInfo));
		}

		try
		{
			return Mapper.Map<CallInfo>(callInfo);
		}
		catch (Exception ex)
		{
			throw new ConversionFailedException(typeof(CallInfoEntry), typeof(CallInfo), ex.Message);
		}
	}
}
