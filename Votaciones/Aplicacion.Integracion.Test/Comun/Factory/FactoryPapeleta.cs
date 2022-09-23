using Aplicacion.Dominio.Entidades.Escrutinio;
using Bogus;

namespace Aplicacion.Integracion.Test.Comun.Factory;
public static class FactoryPapeleta
{
    public static Papeleta CrearPapeleta(
        string codigo = null, string dignidad = null, DateTime? fechaEleccion = null)
        => new Papeleta()
        {
            Codigo = codigo ?? $"{new Faker("es_MX").Random.AlphaNumeric(60)}",
            Dignidad = dignidad ?? $"{new Faker("es_MX").Address.Country()}",
            FechaEleccion = fechaEleccion ?? new Faker("es_MX").Date.Recent(),
        };

    public static List<Papeleta> CrearPapeletas(int cantidadPapeletas)
    {

        var listaPapeletas = new List<Papeleta>();
        for (int i = 0; i < cantidadPapeletas; i++)
        {
            listaPapeletas.Add(CrearPapeleta());
        }
        return listaPapeletas;
    }
}
