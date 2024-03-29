﻿using Aplicacion.Helper.Dominio.Comunes;

namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class JRVPapeleta : IAuditableEntity
{
    public int JRVId { get; set; }
    public int PapeletaId { get; set; }
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public string CreadoPor { get; set; } = string.Empty;
    public string ModificadoPor { get; set; } = string.Empty;
    public Acta Acta { get; set; } 
    public JRV JRV { get; set; } 
    public Papeleta Papeleta { get; set; }
}
