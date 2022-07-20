using Aplicacion.Caracteristicas.Clima;
using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ApiControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PronosticoClimaDto>>> Get()
    {
        var resultado = await Mediator.Send(new ObtenerPronosticoClima.Consulta());
        return Ok(resultado);
    }
}