using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using U2.Core;
using U2.LoggerSvc.ApiTypes;
using U2.LoggerSvc.ApiTypes.v1;
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create([FromBody] Contact contact, CancellationToken cancellationToken)
    {
        try
        {
            var id = await _loggerService.CreateContactAsync(contact, cancellationToken);

            return Ok(id);
        }
        catch (ContactCreationFailedException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Description("Deletes a contact from the database.")]
    [HttpDelete]
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

    [Description("Updates a contact by its id.")]
    [HttpPut]
    [Route("update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, 
        [FromBody] ContactDto contactDto, 
        CancellationToken cancellationToken)
    {
        try
        {
            var contact = contactDto.ToContact();
            contact.Id = id;
            if (await _loggerService.UpdateContactAsync(contact, cancellationToken))
            {
                return Ok();
            }
            return NotFound(id);
        }
        catch (ContactUpdateFailedException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ContactNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [Description("Lists all contacts from the database.")]
    [HttpGet]
    [Route("list")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactDto>>> List(
        [FromQuery] SearchParameters searchParameters,
        [FromQuery] LoggerFilteringParameters filteringParameters,
        [FromQuery] PaginationParameters paginationParameters,
        [FromQuery] SortingParameters sortingParameters,
        CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new LoggerFilteringSearchingPaginationParameters
            {
                SortingParameters = sortingParameters,
                PaginationParameters = paginationParameters,
                LoggerFilteringParameters = filteringParameters,
                SearchParameters = searchParameters,
            };
            var contacts = await _loggerService.GetContactsAsync(parameters, cancellationToken);
            var contactsDto = contacts.Select(_ => _.ToContactDto());
            return Ok(contactsDto);
        }
        catch
        {
            return BadRequest();
        }
    }

    #endregion
}
