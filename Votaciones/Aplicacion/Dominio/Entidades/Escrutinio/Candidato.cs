using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class Candidato
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Dignidad { get; set; }
    //posible para cambio en otra tabla y realizar la relacion
    public string OrganizacionPolitica { get; set; }
}
