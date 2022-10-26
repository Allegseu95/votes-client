using Aplicacion.Caracteristicas.Escrutinio;
using Aplicacion.Integracion.Test.Comun;
using Aplicacion.Integracion.Test.Comun.Factory;
using Bogus;
using Cliente.Shared.Escrutinio;
using Shouldly;

namespace Aplicacion.Integracion.Test.Caracteristicas.Escrutinio;

[Collection(nameof(SliceFixture))]
public class ObtenerJRVsPorIdUsuarioTest
{
    private readonly SliceFixture sliceFixture;
    private readonly Faker faker;

    public ObtenerJRVsPorIdUsuarioTest(SliceFixture sliceFixture)
    {
        this.sliceFixture = sliceFixture;
        this.faker = new Faker("es_MX");
    }

    [Fact]
    public async Task ObtenerJRVsPorIdUsuarioTest_UsuarioConJRVs()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var numeroJRVS = 10;
        var jrvs = FactoryJRV.CrearJRVs(numeroJRVS, usuario.Id);
        await sliceFixture.InsertAsync(jrvs);

        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(usuario.Id);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<JRVDTO>>();

        sut.Count.ShouldBe(10);
    }
    [Fact]
    public async Task ObtenerJRVsPorIdUsuarioTest_UsuarioSinJRVs()
    {
        var numeroUsuarios = 2;
        var usuarios = FactoryUsuario.CrearUsuarios(numeroUsuarios);
        await sliceFixture.InsertAsync(usuarios);

        var numeroJRVS = 10;
        var jrvs = FactoryJRV.CrearJRVs(numeroJRVS, usuarios.First().Id);
        await sliceFixture.InsertAsync(jrvs);

        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(usuarios.Last().Id);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<JRVDTO>>();

        sut.Count.ShouldBe(0);
    }
    [Fact]
    public async Task ObtenerJRVsPorIdUsuarioTest_UsuarioInexistente()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var numeroJRVS = 10;
        var jrvs = FactoryJRV.CrearJRVs(numeroJRVS, usuario.Id);
        await sliceFixture.InsertAsync(jrvs);

        var consulta = new ObtenerJRVsPorIdUsuario.Consulta(usuario.Id + 1);
        var sut = await sliceFixture.SendAsync(consulta);

        sut.ShouldBeOfType<List<JRVDTO>>();

        sut.Count.ShouldBe(0);
    }
}
