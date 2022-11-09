using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared.ComandosDTO;
using Cliente.Shared.EntidadadesDTO;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers.Escrutinio;

public class ArchivosController : ApiControllerBase
{
    private readonly ILogger<ArchivosController> logger;

    public ArchivosController(ILogger<ArchivosController> logger)
    {
        this.logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<RespuestaDTO>> Post([FromBody] ArchivoComandoDTO comando)
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