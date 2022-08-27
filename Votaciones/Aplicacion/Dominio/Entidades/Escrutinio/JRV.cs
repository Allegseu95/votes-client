using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class JRV
{
    [Key]
    public int JrvId { get; set; }
    public int Numero { get; set; }

    [StringLength(200)]
    public string? Tipo { get; set; }
    
    [StringLength(200)]
    public string? Recinto { get; set; }

    [StringLength(100)]
    public string? ZonaElectoral { get; set; }

    [StringLength(100)]
    public string? Parroquia { get; set; }

    [StringLength(100)]
    public string? TipoParroquia { get; set; }

    [StringLength(100)]
    public string? Canton { get; set; }

    [StringLength(100)]
    public string? Circunscripcion { get; set; }

    [StringLength(100)]
    public string? Provincia { get; set; }

}
