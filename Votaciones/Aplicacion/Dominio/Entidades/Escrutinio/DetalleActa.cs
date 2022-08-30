using Aplicacion.Helper.Dominio.Comunes;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class DetalleActa : IAuditableEntity
{
    public int ActaId { get; set; }
    public int CandidatoId { get; set; }
    public int CantidadVotos { get; set; }
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public string CreadoPor { get; set; } = string.Empty;
    public string ModificadoPor { get; set; } = string.Empty;
    public Acta Acta { get; set; } = new Acta();
    public Candidato Candidato { get; set; } = new Candidato();
}
