using Cliente.Shared.EntidadadesDTO;

namespace Aplicacion.Servicios.Intefaces;

public interface ISubirArchivo
{
    Task<ArchivoRespuestaDTO> Ejecutar(string path, string nombreArchivo, string contenido);
}