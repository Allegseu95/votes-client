using Aplicacion.Caracteristicas.Escrutinio;
using Bogus;
using Cliente.Shared.ComandosDTO;
using FluentValidation.TestHelper;
using Shouldly;

namespace Aplicacion.Unit.Test.Caracteristicas;
public class SubirImagenEvidenciaTest
{
    SubirImagenEvidencia.ComandoValidacion validador = new();

    private readonly int tamanoCorrecto = new Faker().Random.Int(1, 1024 * 1024 * 8);
    private readonly int tamanoIncorrecto = int.MinValue;
    private readonly string textoLleno = new Faker("es_MX").Random.AlphaNumeric(10);
    private readonly string textoVacio = string.Empty;

    [Fact]
    public async Task SubirImagenEvidencia_ComandoSinValidacion()
    {
        var comando = new ArchivoComandoDTO()
        {
            Path = textoLleno,
            Nombre = textoLleno,
            Contenido = textoLleno,
            Tamano = tamanoCorrecto,
        };

        var resultado = await validador.TestValidateAsync(comando);

        resultado.ShouldNotHaveValidationErrorFor(x => x.Path);
        resultado.ShouldNotHaveValidationErrorFor(x => x.Nombre);
        resultado.ShouldNotHaveValidationErrorFor(x => x.Contenido);
        resultado.ShouldNotHaveValidationErrorFor(x => x.Tamano);
    }

    [Fact]
    public async Task SubirImagenEvidencia_ComandoConValidacion()
    {
        var comando = new ArchivoComandoDTO();

        var resultado = await validador.TestValidateAsync(comando);

        resultado.ShouldHaveValidationErrorFor(x => x.Path);
        resultado.ShouldHaveValidationErrorFor(x => x.Nombre);
        resultado.ShouldHaveValidationErrorFor(x => x.Contenido);
        resultado.ShouldHaveValidationErrorFor(x => x.Tamano);
    }

    [Fact]
    public async Task SubirImagenEvidencia_ComandoValido()
    {
        var comando = new ArchivoComandoDTO()
        {
            Path = textoLleno,
            Nombre = textoLleno,
            Contenido = textoLleno,
            Tamano = tamanoCorrecto,
        };

        var resultado = await validador.TestValidateAsync(comando);

        resultado.IsValid.ShouldBe(true);
        resultado.Errors.Count.ShouldBe(0);
    }

    [Fact]
    public async Task SubirImagenEvidencia_ComandoNoValido()
    {
        var comando = new ArchivoComandoDTO()
        {
            Path = textoVacio,
            Nombre = textoVacio,
            Contenido = textoVacio,
            Tamano = tamanoIncorrecto,
        };
        var resultado = await validador.TestValidateAsync(comando);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(4);
    }

    [Fact]
    public async Task SubirImagenEvidencia_ComandoNoValido_Path()
    {
        var comando = new ArchivoComandoDTO()
        {
            Path = textoVacio,
            Nombre = textoLleno,
            Contenido = textoLleno,
            Tamano = tamanoCorrecto,
        };

        var resultado = await validador.TestValidateAsync(comando);      

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task SubirImagenEvidencia_ComandoNoValido_Nombre()
    {
        var comando = new ArchivoComandoDTO()
        {
            Path = textoLleno,
            Nombre = textoVacio,
            Contenido = textoLleno,
            Tamano = tamanoCorrecto,
        };

        var resultado = await validador.TestValidateAsync(comando);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task SubirImagenEvidencia_ComandoNoValido_Contenido()
    {
        var comando = new ArchivoComandoDTO()
        {
            Path = textoLleno,
            Nombre = textoLleno,
            Contenido = textoVacio,
            Tamano = tamanoCorrecto,
        };

        var resultado = await validador.TestValidateAsync(comando);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task SubirImagenEvidencia_ComandoNoValido_Tamano()
    {
        var comando = new ArchivoComandoDTO()
        {
            Path = textoLleno,
            Nombre = textoLleno,
            Contenido = textoLleno,
            Tamano = tamanoIncorrecto,
        };

        var resultado = await validador.TestValidateAsync(comando);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }
}
