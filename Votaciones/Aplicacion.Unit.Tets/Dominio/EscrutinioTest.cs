using Aplicacion.Dominio.Entidades.Escrutinio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Unit.Test.Dominio;
public class EscrutinioTest
{

    [Fact]
    public void ObtenerCantidadVotantesJRV_RetornaNumeros()
    {
        Acta sut = new() { CantidadVotantesJRV = 5 };

        var resultado = sut.CantidadVotantesJRV;

        Assert.Equal(5, resultado);
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
