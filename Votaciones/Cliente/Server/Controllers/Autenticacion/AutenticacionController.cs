using Aplicacion.Caracteristicas.Escrutinio;
using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Helper.Comunes.Excepciones;
using Cliente.Server.Controllers.Interfaces;
using Cliente.Shared.EntidadadesDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cliente.Server.Controllers.Autenticacion;

public class AutenticacionController : ApiControllerBase
{
    private readonly ILogger<AutenticacionController> logger;

    private readonly UserManager<UsuarioCredencial> userManager;

    public AutenticacionController(ILogger<AutenticacionController> logger, UserManager<UsuarioCredencial> userManager)
    {
        this.logger = logger;
        this.userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<UsuarioDTO>>> ObtenerUsuario()
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return NoContent();

            var resultado = await Mediator.Send(new ObtenerUsuarioPorEmail.Consulta(user.Email));

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
