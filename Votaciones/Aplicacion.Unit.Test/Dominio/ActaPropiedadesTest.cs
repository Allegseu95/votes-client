using Aplicacion.Dominio.Entidades.Escrutinio;
using Shouldly;

namespace Aplicacion.Unit.Test.Dominio;

public class ActaPropiedadesTest
{
    public int digitos = 7;
    public bool logicos = true;
    public string text = "prueba";

    [Fact]
    public void ObtenerCantidadVotaciones_RetornaNumeros()
    {
        Acta sut = new() { CantidadVotaciones = this.digitos };
        var resultado = sut.CantidadVotaciones;
        resultado.ShouldBe(this.digitos);
    }

    [Fact]
    public void ObtenerVotosBlancos_RetornaNumeros()
    {
        Acta sut = new() { VotosBlancos = this.digitos };
        var resultado = sut.VotosBlancos;
        resultado.ShouldBe(this.digitos);
    }

    [Fact]
    public void ObtenerVotosNulos_RetornaNumeros()
    {
        Acta sut = new() { VotosNulos = this.digitos };
        var resultado = sut.VotosNulos;
        resultado.ShouldBe(this.digitos);
    }

    [Fact]
    public void ObtenerFirmaPresidente_RetornaNumeros()
    {
        Acta sut = new() { FirmaPresidente = this.logicos };
        var resultado = sut.FirmaPresidente;
        resultado.ShouldBe(this.logicos);
    }

    [Fact]
    public void ObtenerFirmaSecretario_RetornaNumeros()
    {
        Acta sut = new() { FirmaSecretario = this.logicos };
        var resultado = sut.FirmaSecretario;
        resultado.ShouldBe(this.logicos);
    }

    [Fact]
    public void ObtenerImagen_RetornaString()
    {
        Acta sut = new() { Imagen = this.text };
        var resultado = sut.Imagen;
        resultado.ShouldBe(this.text);
    }
    //[Fact]
    //public void ObtenerEstado_RetornaBool()
    //{
    //    Acta sut = new() { Estado = logicos };
    //    var resultado = sut.Estado;
    //    resultado.ShouldBe(logicos);
    //}

    [Fact]
    public void ObtenerCandidato_RetornaObjetoCandidato()
    {
        Candidato sut = new()
        {
            Nombre = this.text,
            Apellido = this.text,
            Genero = this.text,
            FechaNacimiento = DateTime.Now.Date,
            // Dignidad = text,
            OrganizacionPolitica = this.text
        };
        var resultado = sut;
        resultado.Nombre.ShouldBe(this.text);
        resultado.Apellido.ShouldBe(this.text);
        resultado.Genero.ShouldBe(this.text);
        resultado.FechaNacimiento.ShouldBe(DateTime.Now.Date);
        //resultado.Dignidad.ShouldBe(text);
        resultado.OrganizacionPolitica.ShouldBe(this.text);
    }

    [Fact]
    public void ObtenerJRV_RetornaJRV()
    {
        JRV sut = new()
        {
            Numero = this.digitos,
            // Tipo = text,
            Recinto = this.text,
            ZonaElectoral = this.text,
            Parroquia = this.text,
            TipoParroquia = this.text,
            Canton = this.text,
            Circunscripcion = this.text,
            Provincia = this.text
        };
        var resultado = sut;
        resultado.Numero.ShouldBe(this.digitos);
        // resultado.Tipo.ShouldBe(text);
        resultado.Recinto.ShouldBe(this.text);
        resultado.ZonaElectoral.ShouldBe(this.text);
        resultado.Parroquia.ShouldBe(this.text);
        resultado.TipoParroquia.ShouldBe(this.text);
        resultado.Canton.ShouldBe(this.text);
        resultado.Circunscripcion.ShouldBe(this.text);
        resultado.Provincia.ShouldBe(this.text);
    }
}