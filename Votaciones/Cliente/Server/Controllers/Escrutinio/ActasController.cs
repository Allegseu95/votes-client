using Aplicacion.Caracteristicas.Escrutinio;
using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared.Escrutinio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers.Escrutinio;

public class ActasController : ApiControllerBase
{
    private readonly IMediator mediator;

    private readonly ILogger<ActasController> logger;
    public ActasController( ILogger<ActasController> logger, IMediator mediator)
    {
        this.mediator = mediator;
        this.logger = logger;
    }

    //public ActasController(ILogger<ActasController> logger)
    //{
    //    this.logger = logger;
    //}


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

    [HttpPut("comando")]
    public async Task<int> Add(InsertarActa.Consulta comando)
    {
        return await mediator.Send(comando);
    }

}
