using Aplicacion.Caracteristicas.Escrutinio;
using Bogus;
using Cliente.Shared.Escrutinio;
using FluentValidation.TestHelper;
using Shouldly;

namespace Aplicacion.Unit.Test.Caracteristicas;
public class InsertarActaTest
{
    InsertarActa.ComandoValidacion validador = new();
    InsertarActa.ComandoValidacionDetallesActa validadorDetallesActa = new();

    private int numeroMayorIgualUno = new Faker().Random.Int(1, 100);
    private int numeroMayorIgualCero = new Faker().Random.Int(0, 100);
    private int numeroMenorUno = new Faker().Random.Int(-100, 0);
    private int numeroMenorCero = new Faker().Random.Int(-100, -1);
    private Boolean logico = new Faker().Random.Bool();
    private string textoMayorIgual8 = $"{new Faker("es_MX").Random.AlphaNumeric(8)}";
    private string textoMenor8 = $"{new Faker("es_MX").Random.AlphaNumeric(7)}";
    private List<DetalleActaComandoDTO> detallesActa = new List<DetalleActaComandoDTO>();

    [Fact]
    public async Task InsertarActa_ComandoSinValidacion()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultado.ShouldNotHaveValidationErrorFor(x => x.JRVId);
        resultado.ShouldNotHaveValidationErrorFor(x => x.PapeletaId);
        resultado.ShouldNotHaveValidationErrorFor(x => x.CantidadVotaciones);
        resultado.ShouldNotHaveValidationErrorFor(x => x.VotosBlancos);
        resultado.ShouldNotHaveValidationErrorFor(x => x.VotosNulos);
        resultado.ShouldNotHaveValidationErrorFor(x => x.Imagen);
        resultado.ShouldNotHaveValidationErrorFor(x => x.DetalleActas);

        resultadoDetalleActa.ShouldNotHaveValidationErrorFor(x => x.CandidatoId);
        resultadoDetalleActa.ShouldNotHaveValidationErrorFor(x => x.CantidadVotos);
    }

    [Fact]
    public async Task InsertarActa_ComandoConValidacion()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMenorUno,
            numeroMenorCero);

        var comando = new ActaComandoDTO(
            numeroMenorUno,
            numeroMenorUno,
            numeroMenorCero,
            numeroMenorCero,
            numeroMenorCero,
            logico,
            logico,
            textoMenor8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultado.ShouldHaveValidationErrorFor(x => x.JRVId);
        resultado.ShouldHaveValidationErrorFor(x => x.PapeletaId);
        resultado.ShouldHaveValidationErrorFor(x => x.CantidadVotaciones);
        resultado.ShouldHaveValidationErrorFor(x => x.VotosBlancos);
        resultado.ShouldHaveValidationErrorFor(x => x.VotosNulos);
        resultado.ShouldHaveValidationErrorFor(x => x.Imagen);
        resultado.ShouldHaveValidationErrorFor(x => x.DetalleActas);

        resultadoDetalleActa.ShouldHaveValidationErrorFor(x => x.CandidatoId);
        resultadoDetalleActa.ShouldHaveValidationErrorFor(x => x.CantidadVotos);
    }

    [Fact]
    public async Task InsertarActa_ComandoValido()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(0);

        resultado.IsValid.ShouldBe(true);
        resultado.Errors.Count.ShouldBe(0);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMenorUno,
            numeroMenorCero);

        var comando = new ActaComandoDTO(
            numeroMenorUno,
            numeroMenorUno,
            numeroMenorCero,
            numeroMenorCero,
            numeroMenorCero,
            logico,
            logico,
            textoMenor8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldNotBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(2);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(7);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_JrvId()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMenorUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(0);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_PapeletaId()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMenorUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(0);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_CantidadVotaciones()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMenorCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(0);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_VotosBlancos()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMenorCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(0);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_VotosNulos()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMenorCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(0);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_Imagen()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMenor8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(0);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_DetalleActas()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualCero);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(0);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_DetallesActa_CandidatoId()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMenorUno,
            numeroMayorIgualCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldNotBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(1);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_DetallesActa_CantidadVotos()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMayorIgualUno,
            numeroMenorCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldNotBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(1);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task InsertarActa_ComandoNoValido_DetallesActa_CandidatoId_CantidadVotos()
    {
        var detalleActa = new DetalleActaComandoDTO(
            numeroMenorUno,
            numeroMenorCero);

        detallesActa.Add(detalleActa);

        var comando = new ActaComandoDTO(
            numeroMayorIgualUno,
            numeroMayorIgualUno,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var resultadoDetalleActa = await validadorDetallesActa.TestValidateAsync(detalleActa);
        var resultado = await validador.TestValidateAsync(comando);

        resultadoDetalleActa.IsValid.ShouldNotBe(true);
        resultadoDetalleActa.Errors.Count.ShouldBe(2);

        resultado.IsValid.ShouldNotBe(true);
        resultado.Errors.Count.ShouldBe(2);
    }
}
