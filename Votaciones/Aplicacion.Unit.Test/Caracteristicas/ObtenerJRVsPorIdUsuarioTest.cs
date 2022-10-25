using Aplicacion.Caracteristicas.Escrutinio;
using FluentValidation.TestHelper;
using Shouldly;

namespace Aplicacion.Unit.Test.Caracteristicas;
public class ObtenerJRVsPorIdUsuarioTest
{
    ObtenerJRVsPorIdUsuario.ConsultaValidacion validador = new ();

    [Fact]
    public async Task ObtenerJRVsPorIdUsuario_UsuarioIdSinValidacion()
    {
        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.ShouldNotHaveValidationErrorFor(x => x.UsuarioId);
    }
    [Fact]
    public async Task ObtenerJRVsPorIdUsuario_UsuarioIdConValidacion()
    {
        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.ShouldHaveValidationErrorFor(x => x.UsuarioId);
    }
    [Fact]
    public async Task ObtenerJRVsPorIdUsuario_ConsultaValida()
    {
        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.IsValid.ShouldBe(true);            
    }
    [Fact]
    public async Task ObtenerJRVsPorIdUsuario_ConsultaNoValida()
    {
        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.IsValid.ShouldNotBe(true);
    }
    [Fact]
    public async Task ObtenerJRVsPorIdUsuario_ConListaError()
    {
        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(-1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.Errors.Count.ShouldBe(1);            
    } 
    [Fact]
    public async Task ObtenerJRVsPorIdUsuario_SinListaError()
    {
        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(1);
        var resultado = await validador.TestValidateAsync(consulta);
        resultado.Errors.Count.ShouldBe(0);            
    }    
}
