
using Aplicacion.Caracteristicas.Escrutinio;
using Aplicacion.Integracion.Test.Comun;
using Aplicacion.Integracion.Test.Comun.Factory;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Integracion.Test.Caracteristicas.Escrutinio;


[Collection(nameof(SliceFixture))]
public class RegistrarActaTest
{
    private readonly SliceFixture sliceFixture;
    private readonly Faker faker;

    public RegistrarActaTest(SliceFixture sliceFixture)
    {
        this.sliceFixture = sliceFixture;
        this.faker = new Faker("es_MX");
    }
    [Fact]
    public async Task RegistrarActa_Exito()
    {
        var acta = FactoryActa.CrearActas(1);
        await sliceFixture.InsertAsync(acta);
        var comando = new InsertarActa.Comando
        {
            CantidadVotaciones = faker.Random.Int(1, 100),
            VotosBlancos = faker.Random.Int(1, 100),
            VotosNulos = faker.Random.Int(1, 100),
            FirmaPresidente = true,
            FirmaSecretario = true,
            Imagen = faker.Random.AlphaNumeric(50),
            Estado = faker.Random.Bool(),
          //  Observador = faker.Random.AlphaNumeric(50),


        };
        var respuesta = await sliceFixture.SendAsync(comando);
        respuesta.ShouldBeOfType<int>();
        respuesta.ShouldBe(1);

        //var verificador = await sliceFixture.ExecuteDbContextAsync
        //    (
        //    async db => await db.Actas.FirstOrDefaultAsync(x => x.Id == acta.Id)           

        //    );
        //verificador.ShouldNotBeNull();

    }
    //public async Task RegistrarActa_Comando()
    //{
    //    var validador = new InsertarActa.ActaValidacion();
    //    var comando = new InsertarActa.Consulta();
    //    var resultado = await validador.TestValidateAsync(comando);
    //    resultado.ShouldHaveValidationErrorFor(x => x.CantidadVotaciones);
    //    resultado.ShouldHaveValidationErrorFor(x => x.VotosBlancos);
    //    resultado.ShouldHaveValidationErrorFor(x => x.VotosNulos);
    //    resultado.ShouldHaveValidationErrorFor(x => x.FirmaPresidente);
    //    resultado.ShouldHaveValidationErrorFor(x => x.FirmaSecretario);
    //    resultado.ShouldHaveValidationErrorFor(x => x.Imagen);
    //    resultado.ShouldHaveValidationErrorFor(x => x.Estado);
    //    resultado.ShouldHaveValidationErrorFor(x => x.Observador);
    //}
}

