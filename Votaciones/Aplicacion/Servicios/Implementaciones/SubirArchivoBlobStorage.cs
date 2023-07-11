using Aplicacion.Servicios.Intefaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Cliente.Shared.Constantes;
using Cliente.Shared.EntidadadesDTO;
using Cliente.Shared.Mensajes;
using Microsoft.Extensions.Configuration;

namespace Aplicacion.Servicios.Implementaciones;
public class SubirArchivoBlobStorage : ISubirArchivo
{
    public SubirArchivoBlobStorage(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    private readonly IConfiguration configuration;

    public async Task<ArchivoRespuestaDTO> Ejecutar(string nombre, string contenido)
    {
        try
        {
            BlobContainerClient container = new BlobContainerClient(configuration.GetConnectionString("BlobStorageConnection"), Constantes.CARPETA_ACTAS);
            bool exists = await container.ExistsAsync();

            if (!exists)
            {
                await container.CreateAsync();
                await container.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            }

            BlobClient blob = container.GetBlobClient(nombre);

            int contador = 1;

            while (await blob.ExistsAsync())
            {
                blob = container.GetBlobClient(contador.ToString() + nombre);
                contador++;
            }

            byte[] imageBytes = Convert.FromBase64String(contenido);
            MemoryStream stream = new MemoryStream(imageBytes);
            var result = await blob.UploadAsync(stream);

            string rutaCompleta = "";

            if (result?.GetRawResponse().Status == 201)
            {
                rutaCompleta = blob.Uri.ToString();
            }

            return await Task.FromResult(new ArchivoRespuestaDTO(rutaCompleta, true));
        }
        catch (Exception)
        {
            return await Task.FromResult(new ArchivoRespuestaDTO(MensajesError.MENSAJE_ERROR_IMAGEN_NO_GUARDADA, false));
        }
    }
}