using Aplicacion.Dominio.Entidades.Escrutinio;
using Bogus;

namespace Aplicacion.Integracion.Test.Comun.Factory;
public static class FactoryJRV
{
    public static JRV CrearJRV(
        int usuarioId,
        int? numero = null,
        string genero = null, string direccionRecinto = null,
        string recinto = null, string zonaElectoral = null,
        string parroquia = null, string tipoParroquia = null,
        string canton = null, string circunscripcion = null,
        string provincia = null, int? cantidadVotantes = null)
        => new JRV()
        {
            UsuarioId = usuarioId,
            Numero = numero ?? new Faker().Random.Int(1, 30),
            Genero = genero ?? $"{new Faker("es_MX").Person.Gender}",
            DireccionRecinto = direccionRecinto ?? $"{new Faker("es_MX").Address.Direction()}",
            Recinto = recinto ?? $"{new Faker("es_MX").Company.CompanyName(2)}",
            ZonaElectoral = zonaElectoral ?? $"{new Faker("es_MX").Address.StateAbbr()}",
            Parroquia = parroquia ?? $"{new Faker("es_MX").Address.State()}",
            TipoParroquia = tipoParroquia ?? $"{new Faker("es_MX").Lorem.Word()}",
            Canton = canton ?? $"{new Faker("es_MX").Address.City()}",
            Circunscripcion = circunscripcion ?? $"{new Faker("es_MX").Lorem.Word()}",
            Provincia = provincia ?? $"{new Faker("es_MX").Address.County()}",
            CantidadVotantes = cantidadVotantes ?? new Faker().Random.Int(350, 355)
        };

    public static List<JRV> CrearJRVs(int cantidadJRVs, int usuarioId)
    {

        var listaJRVs = new List<JRV>();
        for (int i = 0; i < cantidadJRVs; i++)
        {
            listaJRVs.Add(CrearJRV(usuarioId));
        }
        return listaJRVs;
    }
}
