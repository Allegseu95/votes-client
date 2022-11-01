using Aplicacion.Caracteristicas.Escrutinio;
using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared.Escrutinio;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers.Escrutinio;

public class ActasController : ApiControllerBase
{
    private readonly ILogger<ActasController> logger;

    public ActasController(ILogger<ActasController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ActaDTO>>> Get()
    {
        this.logger.LogInformation("Consulta de Actas");
        var resultado = await Mediator.Send(new ObtenerActas.Consulta());
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<ActionResult<RespuestaDTO>> Post([FromBody] ActaComandoDTO comando)
    {
        try
        {
            var resultado = await Mediator.Send(comando);
            return !resultado.Estado
                ? (ActionResult<RespuestaDTO>)BadRequest(resultado)
                : (ActionResult<RespuestaDTO>)Created(string.Empty, resultado);
        }
        catch (Exception e)
        {
            return NotFound(new RespuestaDTO(e.Message, false, 0));
        }
    }
}
