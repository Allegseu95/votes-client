using Aplicacion.Dominio.Entidades.Escrutinio;
using Bogus;

namespace Aplicacion.Integracion.Test.Comun.Factory;
public static class FactoryJRVPapeleta
{
    public static JRVPapeleta CrearJRVPapeleta(int jrvId, int papeletaId)
        => new JRVPapeleta()
        {
            JRVId = jrvId,
            PapeletaId = papeletaId,
        };
}
