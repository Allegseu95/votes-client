using Aplicacion.Dominio.Entidades.Escrutinio;
using Shouldly;

namespace Aplicacion.Unit.Test.Dominio;
public class ActaPropiedadesTest
{
    public string text = "prueba";
    public int digitos = 7;
    public bool logicos = true;

    [Fact]
    public void ObtenerCantidadVotaciones_RetornaNumeros()
    {
        Acta sut = new() { CantidadVotaciones = digitos };
        var resultado = sut.CantidadVotaciones;
        resultado.ShouldBe(digitos);
    }

    [Fact]
    public void ObtenerVotosBlancos_RetornaNumeros()
    {
        Acta sut = new() { VotosBlancos = digitos };
        var resultado = sut.VotosBlancos;
        resultado.ShouldBe(digitos);
    }

    [Fact]
    public void ObtenerVotosNulos_RetornaNumeros()
    {
        Acta sut = new() { VotosNulos = digitos };
        var resultado = sut.VotosNulos;
        resultado.ShouldBe(digitos);
    }

    [Fact]
    public void ObtenerFirmaPresidente_RetornaNumeros()
    {
        Acta sut = new() { FirmaPresidente = logicos };
        var resultado = sut.FirmaPresidente;
        resultado.ShouldBe(logicos);
    }
    [Fact]
    public void ObtenerFirmaSecretario_RetornaNumeros()
    {
        Acta sut = new() { FirmaSecretario = logicos };
        var resultado = sut.FirmaSecretario;
        resultado.ShouldBe(logicos);
    }

    [Fact]
    public void ObtenerImagen_RetornaString()
    {
        Acta sut = new() { Imagen = text };
        var resultado = sut.Imagen;
        resultado.ShouldBe(text);
    }
    [Fact]
    public void ObtenerEstado_RetornaBool()
    {
        Acta sut = new() { Estado = logicos };
        var resultado = sut.Estado;
        resultado.ShouldBe(logicos);
    }

    [Fact]
    public void ObtenerCandidato_RetornaObjetoCandidato()
    {

        Candidato sut = new()
        {
            Nombre = text,
            Apellido = text,
            Genero = text,
            FechaNacimiento = DateTime.Now.Date,
            // Dignidad = text,
            OrganizacionPolitica = text


        };
        var resultado = sut;
        resultado.Nombre.ShouldBe(text);
        resultado.Apellido.ShouldBe(text);
        resultado.Genero.ShouldBe(text);
        resultado.FechaNacimiento.ShouldBe(DateTime.Now.Date);
        //resultado.Dignidad.ShouldBe(text);
        resultado.OrganizacionPolitica.ShouldBe(text);

    }

    [Fact]
    public void ObtenerJRV_RetornaJRV()
    {

        JRV sut = new()
        {
            Numero = digitos,
            // Tipo = text,
            Recinto = text,
            ZonaElectoral = text,
            Parroquia = text,
            TipoParroquia = text,
            Canton = text,
            Circunscripcion = text,
            Provincia = text,
        };
        var resultado = sut;
        resultado.Numero.ShouldBe(digitos);
        // resultado.Tipo.ShouldBe(text);
        resultado.Recinto.ShouldBe(text);
        resultado.ZonaElectoral.ShouldBe(text);
        resultado.Parroquia.ShouldBe(text);
        resultado.TipoParroquia.ShouldBe(text);
        resultado.Canton.ShouldBe(text);
        resultado.Circunscripcion.ShouldBe(text);
        resultado.Provincia.ShouldBe(text);




    }
}
