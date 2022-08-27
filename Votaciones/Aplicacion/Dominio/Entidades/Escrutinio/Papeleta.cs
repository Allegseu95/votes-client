using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class Papeleta
{
    [Key]
    public int PapeletaId { get; set; }

    [StringLength(200)]
    public string? Descripcion { get; set; }

}
