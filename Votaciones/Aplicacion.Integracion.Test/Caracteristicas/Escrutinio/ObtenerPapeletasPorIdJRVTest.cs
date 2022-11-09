using Aplicacion.Caracteristicas.Escrutinio;
using Aplicacion.Dominio.Entidades.Escrutinio;
using Aplicacion.Integracion.Test.Comun;
using Aplicacion.Integracion.Test.Comun.Factory;
using Bogus;
using Cliente.Shared.EntidadadesDTO;
using Shouldly;

namespace Aplicacion.Integracion.Test.Caracteristicas.Escrutinio;

[Collection(nameof(SliceFixture))]
public class ObtenerPapeletasPorIdJRVTest
{
    private readonly SliceFixture sliceFixture;
    private readonly Faker faker;

    public ObtenerPapeletasPorIdJRVTest(SliceFixture sliceFixture)
    {
        this.sliceFixture = sliceFixture;
        this.faker = new Faker("es_MX");
    }

    [Fact]
    public async Task ObtenerPapeletasPorIdJRVTest_JRVConPapeletas()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var numeroPapeletas = 5;
        var papeletas = FactoryPapeleta.CrearPapeletas(numeroPapeletas);
        await sliceFixture.InsertAsync(papeletas);

        foreach (var papeleta in papeletas)
        {
            var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
            await sliceFixture.InsertAsync(jrvPapeleta);
        }

        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(jrv.Id);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<JRVPapeletaDTO>>();

        sut.Count.ShouldBe(5);
    }

    [Fact]
    public async Task ObtenerPapeletasPorIdJRVTest_JRVSinPapeletas()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var numeroJRVs = 2;
        var jrvs = FactoryJRV.CrearJRVs(numeroJRVs, usuario.Id);
        await sliceFixture.InsertAsync(jrvs);

        var numeroPapeletas = 5;
        var papeletas = FactoryPapeleta.CrearPapeletas(numeroPapeletas);
        await sliceFixture.InsertAsync(papeletas);

        foreach (var papeleta in papeletas)
        {
            var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrvs.First().Id, papeleta.Id);
            await sliceFixture.InsertAsync(jrvPapeleta);
        }

        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(jrvs.Last().Id);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<JRVPapeletaDTO>>();

        sut.Count.ShouldBe(0);
    }
    [Fact]
    public async Task ObtenerPapeletasPorIdJRVTest_JRVsConDiferentesPapeletas()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var numeroJRVs = 3;
        var jrvs = FactoryJRV.CrearJRVs(numeroJRVs, usuario.Id);
        await sliceFixture.InsertAsync(jrvs);

        var numeroPapeletas = 5;
        var papeletas = FactoryPapeleta.CrearPapeletas(numeroPapeletas);
        await sliceFixture.InsertAsync(papeletas);

        var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrvs.First().Id, papeletas.First().Id);
        await sliceFixture.InsertAsync(jrvPapeleta);
        
        var jrvPapeleta2 = FactoryJRVPapeleta.CrearJRVPapeleta(jrvs.First().Id, papeletas.Last().Id);
        await sliceFixture.InsertAsync(jrvPapeleta2);

        foreach (var papeleta in papeletas)
        {
            var jrvPapeletas = FactoryJRVPapeleta.CrearJRVPapeleta(jrvs.Last().Id, papeleta.Id);
            await sliceFixture.InsertAsync(jrvPapeletas);
        }

        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(jrvs.First().Id);
        var sut = await sliceFixture.SendAsync(consulta);

        var consulta2 = new ObtenerPapeletasPorIdJRV.Consulta(jrvs[1].Id);
        var sut2 = await sliceFixture.SendAsync(consulta2);
        
        var consulta3 = new ObtenerPapeletasPorIdJRV.Consulta(jrvs.Last().Id);
        var sut3 = await sliceFixture.SendAsync(consulta3);

        sut.ShouldBeOfType<List<JRVPapeletaDTO>>();
        
        sut2.ShouldBeOfType<List<JRVPapeletaDTO>>();
        
        sut3.ShouldBeOfType<List<JRVPapeletaDTO>>();

        sut.Count.ShouldBe(2);

        sut2.Count.ShouldBe(0);
        
        sut3.Count.ShouldBe(5);
    }

    [Fact]
    public async Task ObtenerPapeletasPorIdJRVTest_JRVInexistente()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var numeroPapeletas = 5;
        var papeletas = FactoryPapeleta.CrearPapeletas(numeroPapeletas);
        await sliceFixture.InsertAsync(papeletas);

        foreach (var papeleta in papeletas)
        {
            var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
            await sliceFixture.InsertAsync(jrvPapeleta);
        }

        var consulta = new ObtenerPapeletasPorIdJRV.Consulta(jrv.Id + 1);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<JRVPapeletaDTO>>();

        sut.Count.ShouldBe(0);
    }


}
