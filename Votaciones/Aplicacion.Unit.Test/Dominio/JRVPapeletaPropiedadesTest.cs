using Aplicacion.Dominio.Entidades.Escrutinio;
using Shouldly;

namespace Aplicacion.Unit.Test.Dominio;
public class JRVPapeletaPropiedadesTest
{
    [Fact]
    public void ObtenerJRVId_RetornaJRVId()
    {
        JRVPapeleta sut = new() { JRVId = 1 };

        var resultado = sut.JRVId;

        resultado.ShouldBe(1);
    }

    [Fact]
    public void ObtenerJRVId_NoRetornaNumeroDiferente()
    {
        JRVPapeleta sut = new() { JRVId = 1 };

        var resultado = sut.JRVId;

        resultado.ShouldNotBe(10);
    }

    [Fact]
    public void ObtenerJRVId_RetornaCero()
    {
        JRVPapeleta sut = new();

        var resultado = sut.JRVId;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerJRVId_RetornaTipoInt()
    {
        JRVPapeleta sut = new();

        var resultado = sut.JRVId;

        resultado.ShouldBeOfType<int>();
    }
    [Fact]
    public void ObtenerJRVId_NoRetornaTipoString()
    {
        JRVPapeleta sut = new();

        var resultado = sut.JRVId;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerPapeletaId_RetornaPapeletaId()
    {
        JRVPapeleta sut = new() { PapeletaId = 1 };

        var resultado = sut.PapeletaId;

        resultado.ShouldBe(1);
    }

    [Fact]
    public void ObtenerPapeletaId_NoRetornaNumeroDiferente()
    {
        JRVPapeleta sut = new() { PapeletaId = 1 };

        var resultado = sut.PapeletaId;

        resultado.ShouldNotBe(10);
    }

    [Fact]
    public void ObtenerPapeletaId_RetornaCero()
    {
        JRVPapeleta sut = new();

        var resultado = sut.PapeletaId;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerPapeletaId_RetornaTipoInt()
    {
        JRVPapeleta sut = new();

        var resultado = sut.PapeletaId;

        resultado.ShouldBeOfType<int>();
    }
    [Fact]
    public void ObtenerPapeletaId_NoRetornaTipoString()
    {
        JRVPapeleta sut = new();

        var resultado = sut.PapeletaId;

        resultado.ShouldNotBeOfType<string>();
    }
    [Fact]
    public void ObtenerCreado_RetornaCreado()
    {
        JRVPapeleta sut = new() { Creado = new DateTime(2022, 9, 12) };

        var resultado = sut.Creado;

        resultado.ShouldBe(new DateTime(2022, 9, 12));
    }
    [Fact]
    public void ObtenerCreado_RetornaFechaMenor_Igual()
    {
        JRVPapeleta sut = new() { Creado = new DateTime(2022, 9, 12) };

        var resultado = sut.Creado;

        resultado.ShouldBeLessThanOrEqualTo(DateTime.Now);
    }
    [Fact]
    public void ObtenerCreado_NoRetornaValorDiferente()
    {
        JRVPapeleta sut = new() { Creado = new DateTime(2022, 9, 12) };

        var resultado = sut.Creado;

        resultado.ShouldNotBe(new DateTime(2022, 10, 12));
    }
    [Fact]
    public void ObtenerCreado_RetornaTipoDateTime()
    {
        JRVPapeleta sut = new() { Creado = new DateTime(2022, 9, 12) };

        var resultado = sut.Creado;

        resultado.ShouldBeOfType<DateTime>();
    }
    [Fact]
    public void ObtenerModificado_RetornaModificado()
    {
        JRVPapeleta sut = new() { Modificado = new DateTime(2022, 9, 12) };

        var resultado = sut.Modificado;

        resultado.ShouldBe(new DateTime(2022, 9, 12));
    }
    [Fact]
    public void ObtenerModificado_RetornaFechaMenor_Igual()
    {
        JRVPapeleta sut = new() { Modificado = new DateTime(2022, 9, 12) };

        var resultado = sut.Modificado;

        resultado.ShouldBeLessThanOrEqualTo(DateTime.Now);
    }
    [Fact]
    public void ObtenerModificado_NoRetornaValorDiferente()
    {
        JRVPapeleta sut = new() { Modificado = new DateTime(2022, 9, 12) };

        var resultado = sut.Modificado;

        resultado.ShouldNotBe(new DateTime(2022, 10, 12));
    }
    [Fact]
    public void ObtenerModificado_RetornaTipoDateTime()
    {
        JRVPapeleta sut = new() { Modificado = new DateTime(2022, 9, 12) };

        var resultado = sut.Modificado;

        resultado.ShouldBeOfType<DateTime>();
    }

    [Fact]
    public void ObtenerCreadoPor_RetornaCreadoPor()
    {
        JRVPapeleta sut = new() { CreadoPor = "Usuario Actual 1" };

        var resultado = sut.CreadoPor;

        resultado.ShouldBe("Usuario Actual 1");
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaVacio()
    {
        JRVPapeleta sut = new() { CreadoPor = "Usuario Actual 1" };

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaNull()
    {
        JRVPapeleta sut = new();

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaValorDiferente()
    {
        JRVPapeleta sut = new() { CreadoPor = "Usuario Actual 1" };

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBe("Usuario Actual 2");
    }
    [Fact]
    public void ObtenerCreadoPor_RetornaTipoString()
    {
        JRVPapeleta sut = new() { CreadoPor = "Usuario Actual 1" };

        var resultado = sut.CreadoPor;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerModificadoPor_RetornaModificadoPor()
    {
        JRVPapeleta sut = new() { ModificadoPor = "Usuario Actual 1" };

        var resultado = sut.ModificadoPor;

        resultado.ShouldBe("Usuario Actual 1");
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaVacio()
    {
        JRVPapeleta sut = new() { ModificadoPor = "Usuario Actual 1" };

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaNull()
    {
        JRVPapeleta sut = new();

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaValorDiferente()
    {
        JRVPapeleta sut = new() { ModificadoPor = "Usuario Actual 1" };

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBe("Usuario Actual 2");
    }
    [Fact]
    public void ObtenerModificadoPor_RetornaTipoString()
    {
        JRVPapeleta sut = new() { ModificadoPor = "Usuario Actual 1" };

        var resultado = sut.ModificadoPor;

        resultado.ShouldBeOfType<string>();
    }
}
