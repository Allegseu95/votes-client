using Aplicacion.Caracteristicas.Escrutinio;
using Aplicacion.Integracion.Test.Comun;
using Aplicacion.Integracion.Test.Comun.Factory;
using Bogus;
using Cliente.Shared.EntidadadesDTO;
using Shouldly;

namespace Aplicacion.Integracion.Test.Caracteristicas.Escrutinio;

[Collection(nameof(SliceFixture))]
public class ObtenerCandidatosPorIdPapeletaTest
{
    private readonly SliceFixture sliceFixture;
    private readonly Faker faker;

    public ObtenerCandidatosPorIdPapeletaTest(SliceFixture sliceFixture)
    {
        this.sliceFixture = sliceFixture;
        this.faker = new Faker("es_MX");
    }

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeletaTest_PapeletaConCandidatos()
    {
        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(papeleta.Id);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<CandidatoDTO>>();
        sut.Count.ShouldBe(10);
    }

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeletaTest_PapeletaSinCandidatos()
    {
        var numeroPapeletas = 2;
        var papeletas = FactoryPapeleta.CrearPapeletas(numeroPapeletas);
        await sliceFixture.InsertAsync(papeletas);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeletas.First().Id);
        await sliceFixture.InsertAsync(candidatos);

        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(papeletas.Last().Id);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<CandidatoDTO>>();
        sut.Count.ShouldBe(0);
    }

    [Fact]
    public async Task ObtenerCandidatosPorIdPapeletaTest_PapeletaInexistente()
    {
        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        var consulta = new ObtenerCandidatosPorIdPapeleta.Consulta(int.MaxValue);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<CandidatoDTO>>();
        sut.Count.ShouldBe(0);
    }
}
