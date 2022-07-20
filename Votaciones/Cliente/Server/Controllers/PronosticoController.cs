using Aplicacion.Caracteristicas.Clima;
using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PronosticoController : ApiControllerBase
{
    private readonly ILogger<PronosticoController> logger;

    public PronosticoController(ILogger<PronosticoController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PronosticoClimaDto>>> Get()
    {
        var resultado = await Mediator.Send(new ObtenerPronosticoClima.Consulta());
        return Ok(resultado);
    }
}