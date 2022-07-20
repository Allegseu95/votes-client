namespace Aplicacion.Dominio.Entidades;

public partial class PronosticoClima
{
    public DateTime Fecha { get; set; }

    public int TemperaturaC { get; set; }

    public string? Resumen { get; set; }

    public int TemperaturaF => 32 + (int)(TemperaturaC / 0.5556);
}