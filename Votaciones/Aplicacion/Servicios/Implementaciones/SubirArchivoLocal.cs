using Aplicacion.Servicios.Intefaces;
using Cliente.Shared.EntidadadesDTO;
using Cliente.Shared.Mensajes;

namespace Aplicacion.Servicios.Implementaciones;
public class SubirArchivoLocal : ISubirArchivo
{
    public async Task<ArchivoRespuestaDTO> Ejecutar(string path, string nombreArchivo, string contenido)
    {
        try
        {
            var localPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", path);

            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }

            var imgPath = Path.Combine(localPath, nombreArchivo);
            byte[] imageBytes = Convert.FromBase64String(contenido);
            File.WriteAllBytes(imgPath, imageBytes);

            var resultPath = Path.Combine("uploads", path, nombreArchivo);

            return await Task.FromResult(new ArchivoRespuestaDTO(nombreArchivo, resultPath, true, 1));
        }
        catch (Exception)
        {
            return await Task.FromResult(new ArchivoRespuestaDTO(nombreArchivo, MensajesError.MENSAJE_ERROR_IMAGEN_NO_GUARDADA, false, 0));
        }
    }
}