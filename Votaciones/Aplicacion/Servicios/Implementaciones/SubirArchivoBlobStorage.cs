using Aplicacion.Servicios.Intefaces;
using Cliente.Shared.EntidadadesDTO;

namespace Aplicacion.Servicios.Implementaciones;
public class SubirArchivoBlobStorage : ISubirArchivo
{
    public async Task<ArchivoRespuestaDTO> Ejecutar(string path, string nombreArchivo, string contenido)
    {
        //implementacion de subida de arhivo a BlobStorage
        return await Task.FromResult(new ArchivoRespuestaDTO(nombreArchivo, contenido, false, 0));
    }
}