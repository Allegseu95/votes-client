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
    [Key]    
    public int Id { get; set; }

    [Required]
    public int CantidadVotantesJRV { get; set; }
    [Required]

    public int CantidadVotaciones { get; set; }
    [Required]
    public int VotosBlancos { get; set; }
    
    [Required]
    public int VotosNulos { get; set; }
    public Boolean FirmaPresidente { get; set; }
    public Boolean FirmaSecretario { get; set; }
    [StringLength(500)]
    public string? Imagen { get; set; }
    public Boolean Estado { get; set; }

}
