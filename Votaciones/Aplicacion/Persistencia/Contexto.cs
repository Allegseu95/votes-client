using Aplicacion.Dominio.Entidades;

namespace Aplicacion.Persistencia;

public class Contexto
{
    private static readonly string[] mensajes =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public IReadOnlyList<PronosticoClima> Pronosticos => Enumerable.Range(1, 5)
        .Select(index => new PronosticoClima
        {
            Fecha = DateTime.Now.AddDays(index),
            TemperaturaC = Random.Shared.Next(-20, 55),
            Resumen = mensajes[Random.Shared.Next(mensajes.Length)]
        })
        .ToList();
}