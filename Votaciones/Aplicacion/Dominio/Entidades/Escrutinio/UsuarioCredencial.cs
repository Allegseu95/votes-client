using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class UsuarioCredencial : IdentityUser
{
    public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
}