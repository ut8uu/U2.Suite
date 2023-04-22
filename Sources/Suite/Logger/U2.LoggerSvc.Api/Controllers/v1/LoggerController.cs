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

    [Description("Deletes a contact from the database.")]
    [HttpGet]
    [Route("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            if (await _loggerService.DeleteContactAsync(id, cancellationToken))
            {
                return Ok();
            }
            return NotFound(id);
        }
        catch (ContactRemovingFailedException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ContactNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    #endregion
}
