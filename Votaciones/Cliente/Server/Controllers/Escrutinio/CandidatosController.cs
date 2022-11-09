using Aplicacion.Caracteristicas.Escrutinio;
using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared.EntidadadesDTO;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers.Escrutinio;

public class CandidatosController : ApiControllerBase
{
    private readonly ILogger<CandidatosController> logger;

    public CandidatosController(ILogger<CandidatosController> logger)
    {
        this.logger = logger;
    }

    [HttpGet("{PapeletaId:int}")]
    public async Task<ActionResult<IReadOnlyList<CandidatoDTO>>> Get(int PapeletaId)
    {
        try
        {
            var resultado = await Mediator.Send(new ObtenerCandidatosPorIdPapeleta.Consulta(PapeletaId));
            return Ok(resultado);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
