using Aplicacion.Caracteristicas.Escrutinio;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Unit.Test.Caracteristicas;
public class EscrutinioValidacionTest
{
    [Fact]
    public async Task RegistrarActa_Comando()
    {
        var validador = new InsertarActa.ActaValidacion();
        var comando = new InsertarActa.Comando();
        var resultado = await validador.TestValidateAsync(comando);
        resultado.ShouldHaveValidationErrorFor(x => x.CantidadVotaciones);
        resultado.ShouldHaveValidationErrorFor(x => x.VotosBlancos);
        resultado.ShouldHaveValidationErrorFor(x => x.VotosNulos);
        resultado.ShouldHaveValidationErrorFor(x => x.FirmaPresidente);
        resultado.ShouldHaveValidationErrorFor(x => x.FirmaSecretario);
        resultado.ShouldHaveValidationErrorFor(x => x.Imagen);
        resultado.ShouldHaveValidationErrorFor(x => x.Estado);
        //resultado.ShouldHaveValidationErrorFor(x => x.Observador);

        //{ 
        //    CantidadVotaciones= 3,
        //    VotosBlancos= 4,
        //    VotosNulos= 5,
        //    FirmaPresidente=true,
        //    FirmaSecretario = true,
        //    Imagen= "s",
        //    Estado=true,
        //    Observador="",
        //};



    }
}
