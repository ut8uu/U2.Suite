using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using U2.LoggerSvc.ApiTypes.v1;

namespace U2.Logger.Api.Controllers.v1;

[Route("logger-service/v1/health")]
[ApiController]
public class HealthController : ControllerBase
{
    private readonly HealthCheckService _healthCheckService;

    public HealthController(HealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
    }

    #region HTTP Methods
    [Description("Inform clients about the service health.")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HealthDto>> Health(CancellationToken cancellationToken)
    {
        var report = await _healthCheckService.CheckHealthAsync(cancellationToken);
        var healthInfo = new HealthDto
        {
            Status = report.Status.ToString(),
        };

        return Ok(healthInfo);
    }
    #endregion
}
