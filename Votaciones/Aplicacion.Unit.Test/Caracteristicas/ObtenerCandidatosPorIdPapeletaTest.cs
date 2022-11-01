using Aplicacion.Caracteristicas.Escrutinio;
using FluentValidation.TestHelper;
using Shouldly;

namespace Aplicacion.Unit.Test.Caracteristicas;
public class ObtenerCandidatosPorIdPapeletaTest
{
    ObtenerCandidatosPorIdPapeleta.ConsultaValidacion validador = new();

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeleta_PapeletaIdSinValidacion()
    {
        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.ShouldNotHaveValidationErrorFor(x => x.PapeletaId);
    }

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeleta_PapeletaIdConValidacion()
    {
        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.ShouldHaveValidationErrorFor(x => x.PapeletaId);
    }

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeleta_ConsultaValida()
    {
        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.IsValid.ShouldBe(true);
    }

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeleta_ConsultaNoValida()
    {
        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.IsValid.ShouldNotBe(true);
    }

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeleta_ConListaError()
    {
        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeleta_SinListaError()
    {
        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.Errors.Count.ShouldBe(0);
    }
}
