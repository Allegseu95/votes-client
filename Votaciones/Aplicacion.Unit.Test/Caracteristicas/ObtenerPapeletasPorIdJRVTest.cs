using Aplicacion.Caracteristicas.Escrutinio;
using FluentValidation.TestHelper;
using Shouldly;

namespace Aplicacion.Unit.Test.Caracteristicas;
public class ObtenerPapeletasPorIdJRVTest
{
    ObtenerPapeletasPorIdJRV.ConsultaValidacion validador = new ();

    [Fact]
    public async Task ObtenerPapeletasPorIdJRV_JRVIdSinValidacion()
    {
        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.ShouldNotHaveValidationErrorFor(x => x.JRVId);
    }
    [Fact]
    public async Task ObtenerPapeletasPorIdJRV_JRVIdConValidacion()
    {
        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.ShouldHaveValidationErrorFor(x => x.JRVId);
    }
    [Fact]
    public async Task ObtenerPapeletasPorIdJRV_ConsultaValida()
    {
        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.IsValid.ShouldBe(true);            
    }
    [Fact]
    public async Task ObtenerPapeletasPorIdJRV_ConsultaNoValida()
    {
        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.IsValid.ShouldNotBe(true);
    }
    [Fact]
    public async Task ObtenerPapeletasPorIdJRV_ConListaError()
    {
        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.Errors.Count.ShouldBe(1);            
    } 
    [Fact]
    public async Task ObtenerPapeletasPorIdJRV_SinListaError()
    {
        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.Errors.Count.ShouldBe(0);            
    }    
}
