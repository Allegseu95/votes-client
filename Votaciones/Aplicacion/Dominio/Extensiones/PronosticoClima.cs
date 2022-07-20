using Aplicacion.Helper.Dominio.Comunes;

namespace Aplicacion.Dominio.Entidades;

public partial class PronosticoClima : IEntity, IAuditableEntity
{
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public string CreadoPor { get; set; }
    public string ModificadoPor { get; set; }
    public int Id { get; }
}