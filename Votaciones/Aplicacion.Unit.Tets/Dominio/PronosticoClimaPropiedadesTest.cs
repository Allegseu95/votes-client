using Aplicacion.Dominio.Entidades;
using Shouldly;

namespace Aplicacion.Unit.Test.Dominio;

public class PronosticoClimaPropiedadesTest
{
    [Fact]
    public void TemperaturaFahrenheit()
    {
        var clima = new PronosticoClima { TemperaturaC = 0 };
        var espera = 32;
        var resultado = clima.TemperaturaF;

        resultado.ShouldBe(espera);
    }
}