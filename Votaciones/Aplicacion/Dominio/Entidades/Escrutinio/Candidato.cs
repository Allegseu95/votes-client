using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class Candidato
{
    [Key]
    public int CandidatiId { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }
    [StringLength(100)]
    public string? Apellido { get; set; }
    [StringLength(100)]
    public string? Genero { get; set; }
    [StringLength(100)]
    public DateTime FechaNacimiento { get; set; }

    [StringLength(100)]
    public string? Dignidad { get; set; }
    //posible para cambio en otra tabla y realizar la relacion

    [StringLength(100)]
    public string? OrganizacionPolitica { get; set; }
}
