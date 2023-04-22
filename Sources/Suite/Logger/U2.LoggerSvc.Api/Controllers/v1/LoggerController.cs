using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using U2.LoggerSvc.Core;

namespace U2.LoggerSvc.Api.Controllers.v1;

[Route("logger-service/v1/logger")]
[ApiController]
public class LoggerController : ControllerBase
{
    private readonly ILoggerService _loggerService;

    public LoggerController(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }

    #region HTTP Methods

    [Description("Adds a contact to the database.")]
    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] Contact contact, CancellationToken cancellationToken)
    {
        try
        {
            await _loggerService.CreateContactAsync(contact, cancellationToken);

            return Ok();
        }
        catch (ContactCreationFailedException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion
}
