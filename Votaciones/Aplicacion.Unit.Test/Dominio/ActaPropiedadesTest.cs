using Aplicacion.Dominio.Entidades.Escrutinio;
using Bogus;
using Shouldly;

namespace Aplicacion.Unit.Test.Dominio;
public class ActaPropiedadesTest
{
    public string text = new Faker("es_MX").Random.AlphaNumeric(10);
    public string textDiferente = new Faker("es_MX").Random.AlphaNumeric(20);
    public int digito = new Faker().Random.Int(1, 10);
    public int digitoDiferente = new Faker().Random.Int(11,20);
    public bool logicoTrue = true;
    public bool logicoFalse = false;
    public DateTime fecha =  new DateTime(2022, 9, 12);
    public DateTime fechaDiferente = new DateTime(2021, 10, 2);

    [Fact]
    public void ObtenerId_RetornaId()
    {
        Acta sut = new() { Id = digito };

        var resultado = sut.Id;

        resultado.ShouldBe(digito);
    }

    [Fact]
    public void ObtenerId_NoRetornaNumeroDiferente()
    {
        Acta sut = new() { Id = digito };

        var resultado = sut.Id;

        resultado.ShouldNotBe(digitoDiferente);
    }

    [Fact]
    public void ObtenerId_RetornaCero()
    {
        Acta sut = new();

        var resultado = sut.Id;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerId_RetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.Id;

        resultado.ShouldBeOfType<int>();
    }

    [Fact]
    public void ObtenerId_NoRetornaTipoString()
    {
        Acta sut = new();

        var resultado = sut.Id;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerJrvId_RetornaJrvId()
    {
        Acta sut = new() { JRVId = digito };

        var resultado = sut.JRVId;

        resultado.ShouldBe(digito);
    }

    [Fact]
    public void ObtenerJrvId_NoRetornaNumeroDiferente()
    {
        Acta sut = new() { JRVId = digito };

        var resultado = sut.JRVId;

        resultado.ShouldNotBe(digitoDiferente);
    }

    [Fact]
    public void ObtenerJrvId_RetornaCero()
    {
        Acta sut = new();

        var resultado = sut.JRVId;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerJrvId_RetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.JRVId;

        resultado.ShouldBeOfType<int>();
    }

    [Fact]
    public void ObtenerJrvId_NoRetornaTipoString()
    {
        Acta sut = new();

        var resultado = sut.JRVId;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerPapeletaId_RetornaPapeletaId()
    {
        Acta sut = new() { PapeletaId = digito };

        var resultado = sut.PapeletaId;

        resultado.ShouldBe(digito);
    }

    [Fact]
    public void ObtenerPapeletaId_NoRetornaNumeroDiferente()
    {
        Acta sut = new() { PapeletaId = digito };

        var resultado = sut.PapeletaId;

        resultado.ShouldNotBe(digitoDiferente);
    }

    [Fact]
    public void ObtenerPapeletaId_RetornaCero()
    {
        Acta sut = new();

        var resultado = sut.PapeletaId;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerPapeletaId_RetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.PapeletaId;

        resultado.ShouldBeOfType<int>();
    }

    [Fact]
    public void ObtenerPapeletaId_NoRetornaTipoString()
    {
        Acta sut = new();

        var resultado = sut.PapeletaId;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerCodigo_RetornaCodigo()
    {
        Acta sut = new() { JRVId = digito, PapeletaId = digitoDiferente };

        var resultado = sut.Codigo;

        var esperado = $"Acta-{digito}/{digitoDiferente}";

        resultado.ShouldBe(esperado);
    }

    [Fact]
    public void ObtenerCodigo_RetornaCodigo_EntradasVacias()
    {
        Acta sut = new();

        var resultado = sut.Codigo;

        var esperado = $"Acta-{0}/{0}";

        resultado.ShouldBe(esperado);
    }

    [Fact]
    public void ObtenerCodigo_NoRetornaVacio()
    {
        Acta sut = new();

        var resultado = sut.Codigo;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerCodigo_NoRetornaNull()
    {
        Acta sut = new();

        var resultado = sut.Codigo;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerCodigo_NoRetornaValorDiferente()
    {
        Acta sut = new() { JRVId = digito, PapeletaId = digitoDiferente };

        var resultado = sut.Codigo;

        var esperado = $"Acta-{digitoDiferente}/{digito}";

        resultado.ShouldNotBe(esperado);
    }

    [Fact]
    public void ObtenerCodigo_RetornaTipoString()
    {
        Acta sut = new();

        var resultado = sut.Codigo;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerCantidadVotaciones_RetornaCantidadVotaciones()
    {
        Acta sut = new() { CantidadVotaciones = digito };

        var resultado = sut.CantidadVotaciones;

        resultado.ShouldBe(digito);
    }

    [Fact]
    public void ObtenerCantidadVotaciones_NoRetornaNumeroDiferente()
    {
        Acta sut = new() { CantidadVotaciones = digito };

        var resultado = sut.CantidadVotaciones;

        resultado.ShouldNotBe(digitoDiferente);
    }

    [Fact]
    public void ObtenerCantidadVotaciones_RetornaCero()
    {
        Acta sut = new();

        var resultado = sut.CantidadVotaciones;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerCantidadVotaciones_RetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.CantidadVotaciones;

        resultado.ShouldBeOfType<int>();
    }

    [Fact]
    public void ObtenerCantidadVotaciones_NoRetornaTipoString()
    {
        Acta sut = new();

        var resultado = sut.CantidadVotaciones;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerVotosBlancos_RetornaVotosBlancos()
    {
        Acta sut = new() { VotosBlancos = digito };

        var resultado = sut.VotosBlancos;

        resultado.ShouldBe(digito);
    }

    [Fact]
    public void ObtenerVotosBlancos_NoRetornaNumeroDiferente()
    {
        Acta sut = new() { VotosBlancos = digito };

        var resultado = sut.VotosBlancos;

        resultado.ShouldNotBe(digitoDiferente);
    }

    [Fact]
    public void ObtenerVotosBlancos_RetornaCero()
    {
        Acta sut = new();

        var resultado = sut.VotosBlancos;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerVotosBlancos_RetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.VotosBlancos;

        resultado.ShouldBeOfType<int>();
    }

    [Fact]
    public void ObtenerVotosBlancos_NoRetornaTipoString()
    {
        Acta sut = new();

        var resultado = sut.VotosBlancos;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerVotosNulos_RetornaVotosNulos()
    {
        Acta sut = new() { VotosNulos = digito };

        var resultado = sut.VotosNulos;

        resultado.ShouldBe(digito);
    }

    [Fact]
    public void ObtenerVotosNulos_NoRetornaNumeroDiferente()
    {
        Acta sut = new() { VotosNulos = digito };

        var resultado = sut.VotosNulos;

        resultado.ShouldNotBe(digitoDiferente);
    }

    [Fact]
    public void ObtenerVotosNulos_RetornaCero()
    {
        Acta sut = new();

        var resultado = sut.VotosNulos;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerVotosNulos_RetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.VotosNulos;

        resultado.ShouldBeOfType<int>();
    }

    [Fact]
    public void ObtenerVotosNulos_NoRetornaTipoString()
    {
        Acta sut = new();

        var resultado = sut.VotosNulos;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerFirmaPresidente_RetornaTrue()
    {
        Acta sut = new() { FirmaPresidente = logicoTrue };

        var resultado = sut.FirmaPresidente;

        resultado.ShouldBe(logicoTrue);
    }

    [Fact]
    public void ObtenerFirmaPresidente_RetornaFalse()
    {
        Acta sut = new() { FirmaPresidente = logicoFalse };

        var resultado = sut.FirmaPresidente;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerFirmaPresidente_NoRetornaValorDiferente()
    {
        Acta sut = new() { FirmaPresidente = logicoTrue };

        var resultado = sut.FirmaPresidente;

        resultado.ShouldNotBe(logicoFalse);
    }

    [Fact]
    public void ObtenerFirmaPresidente_RetornaFalse_Vacio()
    {
        Acta sut = new();

        var resultado = sut.FirmaPresidente;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerFirmaPresidente_RetornaTipoBoolean()
    {
        Acta sut = new();

        var resultado = sut.FirmaPresidente;

        resultado.ShouldBeOfType<Boolean>();
    }

    [Fact]
    public void ObtenerFirmaPresidente_NoRetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.FirmaPresidente;

        resultado.ShouldNotBeOfType<int>();
    }

    [Fact]
    public void ObtenerFirmaSecretario_RetornaTrue()
    {
        Acta sut = new() { FirmaSecretario = logicoTrue };

        var resultado = sut.FirmaSecretario;

        resultado.ShouldBe(logicoTrue);
    }

    [Fact]
    public void ObtenerFirmaSecretario_RetornaFalse()
    {
        Acta sut = new() { FirmaSecretario = logicoFalse };

        var resultado = sut.FirmaSecretario;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerFirmaSecretario_NoRetornaValorDiferente()
    {
        Acta sut = new() { FirmaSecretario = logicoTrue };

        var resultado = sut.FirmaSecretario;

        resultado.ShouldNotBe(logicoFalse);
    }

    [Fact]
    public void ObtenerFirmaSecretario_RetornaFalse_Vacio()
    {
        Acta sut = new();

        var resultado = sut.FirmaSecretario;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerFirmaSecretario_RetornaTipoBoolean()
    {
        Acta sut = new();

        var resultado = sut.FirmaSecretario;

        resultado.ShouldBeOfType<Boolean>();
    }

    [Fact]
    public void ObtenerFirmaSecretario_NoRetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.FirmaSecretario;

        resultado.ShouldNotBeOfType<int>();
    }

    [Fact]
    public void ObtenerImagen_RetornaImagen()
    {
        Acta sut = new() { Imagen = text };

        var resultado = sut.Imagen;

        resultado.ShouldBe(text);
    }

    [Fact]
    public void ObtenerImagen_NoRetornaVacio()
    {
        Acta sut = new() { Imagen = text };

        var resultado = sut.Imagen;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerImagen_NoRetornaNull()
    {
        Acta sut = new();

        var resultado = sut.Imagen;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerImagen_NoRetornaValorDiferente()
    {
        Acta sut = new() { Imagen = text };

        var resultado = sut.Imagen;

        resultado.ShouldNotBe(textDiferente);
    }

    [Fact]
    public void ObtenerImagen_RetornaTipoString()
    {
        Acta sut = new() { Imagen = text };

        var resultado = sut.Imagen;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerEstado_RetornaTrue_ActaValida()
    {
        Acta sut = new()
        {
            FirmaPresidente = logicoTrue,
            FirmaSecretario = logicoTrue,
            VotosBlancos = digitoDiferente,
            VotosNulos = digitoDiferente,
            CantidadVotaciones = digitoDiferente * 4,
            DetalleActas = new List<DetalleActa>()
            {
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,
                },
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,

                }
            }
        };

        var resultado = sut.Estado;

        resultado.ShouldBe(logicoTrue);
    }

    [Fact]
    public void ObtenerEstado_RetornaFalse_SinVotosCandidatos()
    {
        Acta sut = new()
        {
            FirmaPresidente = logicoTrue,
            FirmaSecretario = logicoTrue,
            VotosBlancos = digitoDiferente,
            VotosNulos = digitoDiferente,
            CantidadVotaciones = digitoDiferente * 2,
        };

        var resultado = sut.Estado;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerEstado_RetornaFalse_TotalVotos_NoIgual()
    {
        Acta sut = new()
        {
            FirmaPresidente = logicoTrue,
            FirmaSecretario = logicoTrue,
            VotosBlancos = digitoDiferente,
            VotosNulos = digitoDiferente,
            CantidadVotaciones = digitoDiferente,
            DetalleActas = new List<DetalleActa>()
            {
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,
                },
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,

                }
            }
        };

        var resultado = sut.Estado;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerEstado_RetornaFalse_SinFirmaPresidente()
    {
        Acta sut = new()
        {
            FirmaPresidente = logicoFalse,
            FirmaSecretario = logicoTrue,
            VotosBlancos = digitoDiferente,
            VotosNulos = digitoDiferente,
            CantidadVotaciones = digitoDiferente * 4,
            DetalleActas = new List<DetalleActa>()
            {
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,
                },
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,

                }
            }
        };

        var resultado = sut.Estado;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerEstado_RetornaFalse_SinFirmaSecretario()
    {
        Acta sut = new()
        {
            FirmaPresidente = logicoTrue,
            FirmaSecretario = logicoFalse,
            VotosBlancos = digitoDiferente,
            VotosNulos = digitoDiferente,
            CantidadVotaciones = digitoDiferente * 4,
            DetalleActas = new List<DetalleActa>()
            {
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,
                },
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,

                }
            }
        };

        var resultado = sut.Estado;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerEstado_RetornaFalse_VotosCandidatos_Mayor_CantidaVotaciones()
    {
        Acta sut = new()
        {
            FirmaPresidente = logicoTrue,
            FirmaSecretario = logicoTrue,
            CantidadVotaciones = digitoDiferente,
            DetalleActas = new List<DetalleActa>()
            {
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,
                },
                new DetalleActa()
                {
                    CantidadVotos= digitoDiferente,

                }
            }
        };

        var resultado = sut.Estado;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerEstado_RetornaFalse_Vacio()
    {
        Acta sut = new();

        var resultado = sut.Estado;

        resultado.ShouldBe(logicoFalse);
    }

    [Fact]
    public void ObtenerEstado_RetornaTipoBoolean()
    {
        Acta sut = new();

        var resultado = sut.Estado;

        resultado.ShouldBeOfType<Boolean>();
    }

    [Fact]
    public void ObtenerEstado_NoRetornaTipoInt()
    {
        Acta sut = new();

        var resultado = sut.Estado;

        resultado.ShouldNotBeOfType<int>();
    }

    [Fact]
    public void ObtenerCreado_RetornaCreado()
    {
        Acta sut = new() { Creado = fecha };

        var resultado = sut.Creado;

        resultado.ShouldBe(fecha);
    }

    [Fact]
    public void ObtenerCreado_RetornaFechaMenor_Igual()
    {
        Acta sut = new() { Creado = fecha };

        var resultado = sut.Creado;

        resultado.ShouldBeLessThanOrEqualTo(DateTime.Now);
    }

    [Fact]
    public void ObtenerCreado_NoRetornaValorDiferente()
    {
        Acta sut = new() { Creado = fecha };

        var resultado = sut.Creado;

        resultado.ShouldNotBe(fechaDiferente);
    }

    [Fact]
    public void ObtenerCreado_RetornaTipoDateTime()
    {
        Acta sut = new() { Creado = fecha };

        var resultado = sut.Creado;

        resultado.ShouldBeOfType<DateTime>();
    }
    [Fact]
    public void ObtenerModificado_RetornaModificado()
    {
        Acta sut = new() { Modificado = fecha };

        var resultado = sut.Modificado;

        resultado.ShouldBe(fecha);
    }
    [Fact]
    public void ObtenerModificado_RetornaFechaMenor_Igual()
    {
        Acta sut = new() { Modificado = fecha };

        var resultado = sut.Modificado;

        resultado.ShouldBeLessThanOrEqualTo(DateTime.Now);
    }
    [Fact]
    public void ObtenerModificado_NoRetornaValorDiferente()
    {
        Acta sut = new() { Modificado = fecha };

        var resultado = sut.Modificado;

        resultado.ShouldNotBe(fechaDiferente);
    }
    [Fact]
    public void ObtenerModificado_RetornaTipoDateTime()
    {
        Acta sut = new() { Modificado = fecha };

        var resultado = sut.Modificado;

        resultado.ShouldBeOfType<DateTime>();
    }

    [Fact]
    public void ObtenerCreadoPor_RetornaCreadoPor()
    {
        Acta sut = new() { CreadoPor = text };

        var resultado = sut.CreadoPor;

        resultado.ShouldBe(text);
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaVacio()
    {
        Acta sut = new() { CreadoPor = text };

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaNull()
    {
        Acta sut = new();

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaValorDiferente()
    {
        Acta sut = new() { CreadoPor = text };

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBe(textDiferente);
    }
    [Fact]
    public void ObtenerCreadoPor_RetornaTipoString()
    {
        Acta sut = new() { CreadoPor = text };

        var resultado = sut.CreadoPor;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerModificadoPor_RetornaModificadoPor()
    {
        Acta sut = new() { ModificadoPor = text };

        var resultado = sut.ModificadoPor;

        resultado.ShouldBe(text);
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaVacio()
    {
        Acta sut = new() { ModificadoPor = text };

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaNull()
    {
        Acta sut = new();

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaValorDiferente()
    {
        Acta sut = new() { ModificadoPor = text };

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBe(textDiferente);
    }
    [Fact]
    public void ObtenerModificadoPor_RetornaTipoString()
    {
        Acta sut = new() { ModificadoPor = text };

        var resultado = sut.ModificadoPor;

        resultado.ShouldBeOfType<string>();
    }
}
