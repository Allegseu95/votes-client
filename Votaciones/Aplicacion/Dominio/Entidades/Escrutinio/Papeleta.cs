using Aplicacion.Helper.Dominio.Comunes;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class Papeleta : IEntity, IAuditableEntity
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Dignidad { get; set; } = string.Empty;
    public DateTime FechaEleccion { get; set; }
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public string CreadoPor { get; set; } = string.Empty;
    public string ModificadoPor { get; set; } = string.Empty;
    public List<Candidato> Candidatos { get; set; } = new List<Candidato>();
    public List<JRVPapeleta> JRVPapeletas { get; set; } = new List<JRVPapeleta>();
}
