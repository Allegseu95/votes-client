using Aplicacion.Dominio.Entidades.Escrutinio;
using Bogus;

namespace Aplicacion.Integracion.Test.Comun.Factory;
public static class FactoryCandidato
{
    public static Candidato CrearCandidato(
        int papeletaId,
        string nombre = null, string apellido = null,
        string genero = null, DateTime? fechaNacimiento = null,
        string organizacionPolitica = null, string imagen = null)
        => new Candidato()
        {
            PapeletaId = papeletaId,
            Nombre = nombre ?? $"{new Faker("es_MX").Person.FirstName}",
            Apellido = apellido ?? $"{new Faker("es_MX").Person.LastName}",
            Genero = genero ?? $"{new Faker("es_MX").Person.Gender}",
            FechaNacimiento = fechaNacimiento ?? new Faker("es_MX").Date.Recent(),
            OrganizacionPolitica = organizacionPolitica ?? $"{new Faker("es_MX").Company.CompanyName(2)}",
            Imagen = imagen ?? $"{new Faker("es_MX").Image.PicsumUrl()}"
        };

    public static List<Candidato> CrearCandidatos(int cantidadCandidatos, int papeletaId)
    {
        var listaCandidatos = new List<Candidato>();
        for (int i = 0; i < cantidadCandidatos; i++)
        {
            listaCandidatos.Add(CrearCandidato(papeletaId));
        }
        return listaCandidatos;
    }
}
