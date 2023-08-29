using Aplicacion.Helper.Dominio.Comunes;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class Candidato : IEntity, IAuditableEntity
{
    public int Id { get; set; }
    public int PapeletaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public DateTime? FechaNacimiento { get; set; }
    public string OrganizacionPolitica { get; set; } = string.Empty;
    public string Imagen { get; set; } = string.Empty;
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public string CreadoPor { get; set; } = string.Empty;
    public string ModificadoPor { get; set; } = string.Empty;
    public Papeleta Papeleta { get; set; }
    public List<DetalleActa> DetalleActas { get; set; } = new List<DetalleActa>();
}