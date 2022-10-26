using Aplicacion.Helper.Dominio.Comunes;

namespace Aplicacion.Dominio.Entidades.Escrutinio;

public partial class Acta : IEntity, IAuditableEntity
{
    public int Id { get; set; }
    public int JRVId { get; set; }
    public int PapeletaId { get; set; }
    public string Codigo
    {
        get => $"Acta-{JRVId}/{PapeletaId}";

        set
        {
        }
    }
    public int CantidadVotaciones { get; set; }
    public int VotosBlancos { get; set; }
    public int VotosNulos { get; set; }
    public Boolean FirmaPresidente { get; set; }
    public Boolean FirmaSecretario { get; set; }
    public string Imagen { get; set; } = string.Empty;
    public Boolean Estado
    {
        get => ValidacionActa();
        set
        {
        }
    }
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public string CreadoPor { get; set; } = string.Empty;
    public string ModificadoPor { get; set; } = string.Empty;
    public JRVPapeleta JRVPapeleta { get; set; }
    public List<DetalleActa> DetalleActas { get; set; } = new List<DetalleActa>();
}