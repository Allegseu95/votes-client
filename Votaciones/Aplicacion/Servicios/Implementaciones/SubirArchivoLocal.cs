using Aplicacion.Servicios.Intefaces;
using Cliente.Shared.Constantes;
using Cliente.Shared.EntidadadesDTO;
using Cliente.Shared.Mensajes;

namespace Aplicacion.Servicios.Implementaciones;
public class SubirArchivoLocal : ISubirArchivo
{
    public async Task<ArchivoRespuestaDTO> Ejecutar(string nombre, string contenido)
    {
        try
        {
            var localPath = Path.Combine(Directory.GetCurrentDirectory(), Constantes.CARPETA_ACTAS);

            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }

            var imgPath = Path.Combine(localPath, nombre);
            byte[] imageBytes = Convert.FromBase64String(contenido);
            File.WriteAllBytes(imgPath, imageBytes);

            return await Task.FromResult(new ArchivoRespuestaDTO(imgPath, true));
        }
        catch (Exception)
        {
            return await Task.FromResult(new ArchivoRespuestaDTO(MensajesError.MENSAJE_ERROR_IMAGEN_NO_GUARDADA, false));
        }
    }
}