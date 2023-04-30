using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using U2.CIS.ApiTypes.v1;

namespace U2.CIS.API.Controllers.v1;

[ApiController]
[Route("cis/v1/cis")]
public class CisController : ControllerBase
{
	private readonly ILogger<CisController> _logger;

	public CisController(ILogger<CisController> logger)
	{
		_logger = logger;
	}

	[Description("Reads the information for the given call.")]
	[HttpGet(Name = "GetCallInfo")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<CallInfoDto>> GetCallInfo(
		[FromQuery] string call,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	[Description("Reads the information for the given call.")]
	[HttpPost(Name = "AddCall")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<CallInfoDto>> AddCall(
		[FromQuery] string call,
		CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}