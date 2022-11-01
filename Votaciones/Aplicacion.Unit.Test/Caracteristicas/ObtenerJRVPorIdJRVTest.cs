using Aplicacion.Caracteristicas.Escrutinio;
using FluentValidation.TestHelper;
using Shouldly;

namespace Aplicacion.Unit.Test.Caracteristicas;
public class ObtenerJRVPorIdJRVTest
{
    ObtenerJRVPorIdJRV.ConsultaValidacion validador = new();

    [Fact]
    public async Task ObtenerJRVPorIdJRV_JRVIdSinValidacion()
    {
        var consulta = new ObtenerJRVPorIdJRV.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.ShouldNotHaveValidationErrorFor(x => x.JRVId);
    }

    [Fact]
    public async Task ObtenerJRVPorIdJRV_JRVIdConValidacion()
    {
        var consulta = new ObtenerJRVPorIdJRV.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.ShouldHaveValidationErrorFor(x => x.JRVId);
    }

    [Fact]
    public async Task ObtenerJRVPorIdJRV_ConsultaValida()
    {
        var consulta = new ObtenerJRVPorIdJRV.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.IsValid.ShouldBe(true);
    }

    [Fact]
    public async Task ObtenerJRVPorIdJRV_ConsultaNoValida()
    {
        var consulta = new ObtenerJRVPorIdJRV.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.IsValid.ShouldNotBe(true);
    }

    [Fact]
    public async Task ObtenerJRVPorIdJRV_ConListaError()
    {
        var consulta = new ObtenerJRVPorIdJRV.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.Errors.Count.ShouldBe(1);
    }

    [Fact]
    public async Task ObtenerJRVPorIdJRV_SinListaError()
    {
        var consulta = new ObtenerJRVPorIdJRV.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.Errors.Count.ShouldBe(0);
    }
}
