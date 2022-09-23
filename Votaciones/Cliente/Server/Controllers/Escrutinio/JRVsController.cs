﻿using Aplicacion.Caracteristicas.Escrutinio;
using Aplicacion.Helper.Comunes.Excepciones;
using Aplicacion.Helper.Comunes.Modelos;
using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared.Escrutinio;
using Cliente.Shared.Mensajes;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Server.Controllers.Escrutinio;

public class JRVsController : ApiControllerBase
{
    private readonly ILogger<JRVsController> logger;

    public JRVsController(ILogger<JRVsController> logger)
    {
        this.logger = logger;
    }

    [HttpGet("{usuarioId:int}")]
    public async Task<ActionResult<IReadOnlyList<JRVDTO>>> Get(int usuarioId)
    {
        try
        {
            var resultado = await Mediator.Send(new ObtenerJRVsPorIdUsuario.Consulta(usuarioId));
            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }
        catch (ExcepcionValidacion e)
        {
            return NotFound(e.Message);
        }
    }
}
