using Aplicacion.Helper.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class Acta : IEntity
{
    public int Id { get; set; }
    public int CantidadVotaciones { get; set; }
    public int VotosBlancos { get; set; }
    public int VotosNulos { get; set; }
    public Boolean FirmaPresidente { get; set; }
    public Boolean FirmaSecretario { get; set; }
    public string Imagen { get; set; }
    public Boolean Estado { get; set; }
    public string Observador { get; set; }
}