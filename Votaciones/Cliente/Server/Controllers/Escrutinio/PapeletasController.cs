using Aplicacion.Caracteristicas.Escrutinio;
using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared.Escrutinio;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers.Escrutinio;

public class PapeletasController : ApiControllerBase
{
    private readonly ILogger<PapeletasController> logger;

    public PapeletasController(ILogger<PapeletasController> logger)
    {
        this.logger = logger;
    }

    [HttpGet("{JRVId:int}")]
    public async Task<ActionResult<IReadOnlyList<JRVPapeletaDTO>>> Get(int JRVId)
    {
        try
        {
            var resultado = await Mediator.Send(new ObtenerPapeletasPorIdJRV.Consulta(JRVId));
            return Ok(resultado);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
