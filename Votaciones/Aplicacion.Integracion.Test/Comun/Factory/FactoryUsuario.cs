using Aplicacion.Dominio.Entidades.Escrutinio;
using Bogus;

namespace Aplicacion.Integracion.Test.Comun.Factory;
public static class FactoryUsuario
{
    public static Usuario CrearUsuario(
        string nombre = null, string apellido = null,
        string genero = null, string cedula = null, string email = null)
        => new Usuario()
        {
            Nombre = nombre ?? $"{new Faker("es_MX").Person.FirstName}",
            Apellido = apellido ?? $"{new Faker("es_MX").Person.LastName}",
            Genero = genero ?? $"{new Faker("es_MX").Person.Gender}",
            Cedula = cedula ?? $"{new Faker("es_MX").Phone.PhoneNumber("1#########")}",
            Email = email ?? $"{new Faker("es_MX").Internet.ExampleEmail()}",
        };

    public static List<Usuario> CrearUsuarios(int cantidadUsuarios)
    {

        var listaUsuarios = new List<Usuario>();
        for (int i = 0; i < cantidadUsuarios; i++)
        {
            listaUsuarios.Add(CrearUsuario());
        }
        return listaUsuarios;
    }
}
