using Aplicacion.Dominio.Entidades.Escrutinio;
using Shouldly;

namespace Aplicacion.Unit.Test.Dominio;
public class ActaPropiedadesTest
{
    [Fact]
    public void TemperaturaFahrenheit()
    {
        var acta = new Acta { CantidadVotaciones=250 };
        var jrv = new JRV { CantidadVotantes = 350 };
        var espera = 250;
        var resultado = acta.CantidadVotaciones;

        resultado.ShouldBe(espera);
    }

    [Fact]
    public void ObtenerCantidadVotaciones_RetornaNumeros()
    {
        Acta sut = new() { CantidadVotaciones = 5 };

        var resultado = sut.CantidadVotaciones;

        Assert.Equal(5, resultado);
    }

    [Fact]
    public void ObtenerVotosBlancos_RetornaNumeros()
    {
        Acta sut = new() { VotosBlancos = 5 };

        var resultado = sut.VotosBlancos;

        Assert.Equal(5, resultado);
    }

    [Fact]
    public void ObtenerVotosNulos_RetornaNumeros()
    {
        Acta sut = new() { VotosNulos = 5 };

        var resultado = sut.VotosNulos;

        Assert.Equal(5, resultado);
    }

    [Fact]
    public void ObtenerFirmaPresidente_RetornaNumeros()
    {
        Acta sut = new() { FirmaPresidente = true };

        var resultado = sut.FirmaPresidente;
        
        Assert.True(resultado);
    }
    [Fact]
    public void ObtenerFirmaSecretario_RetornaNumeros()
    {
        Acta sut = new() { FirmaSecretario = true };

        var resultado = sut.FirmaSecretario;
        
        Assert.True(resultado);
    }
}
