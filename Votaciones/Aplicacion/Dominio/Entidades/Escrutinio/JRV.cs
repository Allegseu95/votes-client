using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class JRV
{
    public int Numero { get; set; }
    public string Tipo { get; set; }
    public string Recinto { get; set; }
    public string ZonaElectoral { get; set; }
    public string Parroquia { get; set; }
    public string TipoParroquia { get; set; }
    public string Canton { get; set; }
    public string Circunscripcion { get; set; }
    public string Provincia { get; set; }

}
