using Aplicacion.Caracteristicas.Escrutinio;
using Aplicacion.Integracion.Test.Comun;
using Aplicacion.Integracion.Test.Comun.Factory;
using Bogus;
using Cliente.Shared.EntidadadesDTO;
using Shouldly;

namespace Aplicacion.Integracion.Test.Caracteristicas.Escrutinio;

[Collection(nameof(SliceFixture))]
public class ObtenerJRVPorIdJRVTest
{
    private readonly SliceFixture sliceFixture;
    private readonly Faker faker;

    public ObtenerJRVPorIdJRVTest(SliceFixture sliceFixture)
    {
        this.sliceFixture = sliceFixture;
        this.faker = new Faker("es_MX");
    }

    [Fact]
    public async Task ObtenerJRVPorIdJRVTest_JrvExiste()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var consulta = new ObtenerJRVPorIdJRV.Consulta(jrv.Id);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<JRVDTO>();
        sut.Id.ShouldBe(jrv.Id);
    }

    [Fact]
    public async Task ObtenerJRVPorIdJRVTest_JrvNoExiste()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var consulta = new ObtenerJRVPorIdJRV.Consulta(int.MaxValue);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeNull();
    }
}
