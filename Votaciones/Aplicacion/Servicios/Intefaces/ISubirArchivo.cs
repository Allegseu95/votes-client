using Cliente.Shared.EntidadadesDTO;

namespace Aplicacion.Servicios.Intefaces;

public interface ISubirArchivo
{
    Task<ArchivoRespuestaDTO> Ejecutar(string nombre, string contenido);
}