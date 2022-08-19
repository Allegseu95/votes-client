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
        this.logger.LogInformation($"Consulta de Actas");
        var resultado = await Mediator.Send(new ObtenerActas.Consulta());      
        return Ok(resultado);
    }
 

    [HttpPost]
    public async Task<int> Post(InsertarActa.Consulta consulta)
    {
        this.logger.LogInformation($"Objeto Enviado: {consulta}");
        return await this.Mediator.Send(consulta);
    }

}
