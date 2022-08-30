using Aplicacion.Helper.Dominio.Comunes;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class JRV : IEntity, IAuditableEntity
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public string Genero { get; set; } = string.Empty;
    public string DireccionRecinto { get; set; } = string.Empty;
    public string Recinto { get; set; } = string.Empty;
    public string ZonaElectoral { get; set; } = string.Empty;
    public string Parroquia { get; set; } = string.Empty;
    public string TipoParroquia { get; set; } = string.Empty;
    public string Canton { get; set; } = string.Empty;
    public string Circunscripcion { get; set; } = string.Empty;
    public string Provincia { get; set; } = string.Empty;
    public int CantidadVotantes { get; set; }
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public string CreadoPor { get; set; } = string.Empty;
    public string ModificadoPor { get; set; } = string.Empty;
    public List<JRVPapeleta> JRVPapeletas { get; set; } = new List<JRVPapeleta>();
}
