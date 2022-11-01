using Aplicacion.Integracion.Test.Comun;
using Aplicacion.Integracion.Test.Comun.Factory;
using Bogus;
using Cliente.Shared.Escrutinio;
using Cliente.Shared.Mensajes;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Aplicacion.Integracion.Test.Caracteristicas.Escrutinio;

[Collection(nameof(SliceFixture))]
public class InsertarActaTest
{
    private readonly SliceFixture sliceFixture;
    private readonly Faker faker;

    private int numeroMayorIgualUno = new Faker().Random.Int(1, 100);
    private int numeroMayorIgualCero = new Faker().Random.Int(0, 100);
    private int numeroMenorUno = new Faker().Random.Int(-100, 0);
    private int numeroMenorCero = new Faker().Random.Int(-100, -1);
    private int numeroEnteroMaximo = int.MaxValue;
    private Boolean logico = new Faker().Random.Bool();
    private string textoMayorIgual8 = $"{new Faker("es_MX").Random.AlphaNumeric(8)}";
    private string textoMenor8 = $"{new Faker("es_MX").Random.AlphaNumeric(7)}";
    private List<DetalleActaComandoDTO> detallesActa = new List<DetalleActaComandoDTO>();

    public InsertarActaTest(SliceFixture sliceFixture)
    {
        this.sliceFixture = sliceFixture;
        this.faker = new Faker("es_MX");
    }

    [Fact]
    public async Task RegistrarActa_Exito()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
        await sliceFixture.InsertAsync(jrvPapeleta);

        foreach (var candidato in candidatos)
        {
            detallesActa.Add(new DetalleActaComandoDTO(candidato.Id, numeroMayorIgualCero));
        }

        var comando = new ActaComandoDTO(
            jrvPapeleta.JRVId,
            jrvPapeleta.PapeletaId,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_REGISTRADA);
        sut.Estado.ShouldBe(true);
        sut.CantidadCambios.ShouldBe(numeroCandidatos + 1);

        var verificador = await sliceFixture.ExecuteDbContextAsync
            (
            async db => await db.Actas.FirstOrDefaultAsync()

            );

        verificador.ShouldNotBeNull();
        verificador.JRVId.ShouldBe(jrvPapeleta.JRVId);
        verificador.PapeletaId.ShouldBe(jrvPapeleta.PapeletaId);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_FksInexistentes()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
        await sliceFixture.InsertAsync(jrvPapeleta);

        for (var i = 0; i < candidatos.Count; i++)
        {
            detallesActa.Add(new DetalleActaComandoDTO(numeroEnteroMaximo - i, numeroMayorIgualCero));
        }

        var comando = new ActaComandoDTO(
            numeroEnteroMaximo,
            numeroEnteroMaximo,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_CandidatoIdRepetido()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
        await sliceFixture.InsertAsync(jrvPapeleta);

        var idCandidatoFirst = candidatos.First().Id;
        for (var i = 0; i < candidatos.Count; i++)
        {
            detallesActa.Add(new DetalleActaComandoDTO(idCandidatoFirst, numeroMayorIgualCero));
        }

        var comando = new ActaComandoDTO(
            jrvPapeleta.JRVId,
            jrvPapeleta.PapeletaId,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_JrvIdInexistente()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
        await sliceFixture.InsertAsync(jrvPapeleta);

        foreach (var candidato in candidatos)
        {
            detallesActa.Add(new DetalleActaComandoDTO(candidato.Id, numeroMayorIgualCero));
        }

        var comando = new ActaComandoDTO(
            numeroEnteroMaximo,
            jrvPapeleta.PapeletaId,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_PapeletaIdInexistente()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
        await sliceFixture.InsertAsync(jrvPapeleta);

        foreach (var candidato in candidatos)
        {
            detallesActa.Add(new DetalleActaComandoDTO(candidato.Id, numeroMayorIgualCero));
        }

        var comando = new ActaComandoDTO(
            jrvPapeleta.JRVId,
            numeroEnteroMaximo,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_CandidatoIdInexistente()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
        await sliceFixture.InsertAsync(jrvPapeleta);

        for (var i = 0; i < candidatos.Count; i++)
        {
            detallesActa.Add(new DetalleActaComandoDTO(numeroEnteroMaximo - i, numeroMayorIgualCero));
        }

        var comando = new ActaComandoDTO(
            jrvPapeleta.JRVId,
            jrvPapeleta.PapeletaId,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_SinRegistroJrvPapeleta()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        foreach (var candidato in candidatos)
        {
            detallesActa.Add(new DetalleActaComandoDTO(candidato.Id, numeroMayorIgualCero));
        }

        var comando = new ActaComandoDTO(
            jrv.Id,
            papeleta.Id,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_SinRegistroJrv()
    {
        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var numeroCandidatos = 10;
        var candidatos = FactoryCandidato.CrearCandidatos(numeroCandidatos, papeleta.Id);
        await sliceFixture.InsertAsync(candidatos);

        foreach (var candidato in candidatos)
        {
            detallesActa.Add(new DetalleActaComandoDTO(candidato.Id, numeroMayorIgualCero));
        }

        var comando = new ActaComandoDTO(
            numeroEnteroMaximo,
            papeleta.Id,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_SinRegistroCandidato()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        var papeleta = FactoryPapeleta.CrearPapeleta();
        await sliceFixture.InsertAsync(papeleta);

        var jrvPapeleta = FactoryJRVPapeleta.CrearJRVPapeleta(jrv.Id, papeleta.Id);
        await sliceFixture.InsertAsync(jrvPapeleta);

        detallesActa.Add(new DetalleActaComandoDTO(numeroEnteroMaximo, numeroMayorIgualCero));

        var comando = new ActaComandoDTO(
            jrvPapeleta.JRVId,
            jrvPapeleta.PapeletaId,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_SinRegistroPapeleta()
    {
        var usuario = FactoryUsuario.CrearUsuario();
        await sliceFixture.InsertAsync(usuario);

        var jrv = FactoryJRV.CrearJRV(usuario.Id);
        await sliceFixture.InsertAsync(jrv);

        detallesActa.Add(new DetalleActaComandoDTO(numeroEnteroMaximo, numeroMayorIgualCero));

        var comando = new ActaComandoDTO(
            jrv.Id,
            numeroEnteroMaximo,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }

    [Fact]
    public async Task RegistrarActa_NoExito_BaseDatosVacia()
    {
        detallesActa.Add(new DetalleActaComandoDTO(numeroEnteroMaximo, numeroMayorIgualCero));

        var comando = new ActaComandoDTO(
            numeroEnteroMaximo,
            numeroEnteroMaximo,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            numeroMayorIgualCero,
            logico,
            logico,
            textoMayorIgual8,
            detallesActa);

        var sut = await sliceFixture.SendAsync(comando);

        sut.ShouldBeOfType<RespuestaDTO>();
        sut.Mensaje.ShouldBe(MensajesNotificacion.MENSAJE_ACTA_NO_REGISTRADA);
        sut.Estado.ShouldBe(false);
        sut.CantidadCambios.ShouldBe(0);
    }
}