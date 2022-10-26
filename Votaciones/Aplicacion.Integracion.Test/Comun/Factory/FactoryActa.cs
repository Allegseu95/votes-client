
using Aplicacion.Dominio.Entidades.Escrutinio;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Integracion.Test.Comun.Factory;
//internal class FactoryActa
//{
//}
public static class FactoryActa
{
    //public static Acta CrearActa(string descripcionUbicacion = null, bool activo = true) => new()
    //{

    //    DescripcionUbicacion = descripcionUbicacion ?? $"{new Faker("es_MX").Address.City()} {Guid.NewGuid()}",
    //    Activo = activo
    //};

    public static List<Acta> CrearActas(int cantidadUbicaciones)
    {
        var listaActas = new List<Acta>();
        for (var i = 0; i < cantidadUbicaciones; i++) listaActas.Add(CrearActa());
        return listaActas;
    }

    //public static List<Estudiantes> CrearEstudiantes(int numeroEstudiantes)
    //{
    //    var listaRetorno = new List<Estudiantes>();
    //    for (var i = 0; i < numeroEstudiantes; i++) listaRetorno.Add(CrearEstudiante());

    //    return listaRetorno;
    //}

    private static Acta CrearActa()
    {
        var estudiante = new Faker<Acta>("es_MX")
            .RuleFor(x => x.CantidadVotaciones, y => y.Company.Random.Number(2, 100))
            .RuleFor(x => x.VotosBlancos, y => y.Company.Random.Number(2, 100))
            .RuleFor(x => x.VotosNulos, y => y.Company.Random.Number(2, 100))
            .RuleFor(x => x.FirmaPresidente, y => y.Company.Random.Bool())
            .RuleFor(x => x.FirmaSecretario, y => y.Company.Random.Bool())
            .RuleFor(x => x.Imagen, y => y.Person.Random.AlphaNumeric(45))
            .RuleFor(x => x.Estado, y => y.Company.Random.Bool());
         //   .RuleFor(x => x.Observador, y => y.Person.Random.AlphaNumeric(45));

        return estudiante.Generate();
    }
}

