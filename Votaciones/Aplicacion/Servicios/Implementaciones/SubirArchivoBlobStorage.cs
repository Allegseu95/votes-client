using Aplicacion.Servicios.Intefaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Cliente.Shared.EntidadadesDTO;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace Aplicacion.Servicios.Implementaciones;
public class SubirArchivoBlobStorage : ISubirArchivo
{
    private const string CONNECTION = "DefaultEndpointsProtocol=https;AccountName=votacionesstorage;AccountKey=cW/F75r4u+7QXIlRY1bP902ju7ZdoC6GRGLiNEhhezyQp4UCVA2QIgnnnsO92PYP9T7OIuReQU7O+AStgxI0OA==;EndpointSuffix=core.windows.net";
    public async Task<ArchivoRespuestaDTO> Ejecutar(string path, string nombreArchivo, string contenido)
    {
        try
        {

        
        // Get a reference to a container named "sample-container" and then create it
        BlobContainerClient container = new BlobContainerClient(CONNECTION,path);
        //container.Create(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
        //var kalo = await container.CreateAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
        // Get a reference to a blob named "sample-file" in a container named "sample-container"
        
            
            
            //COMPROBAR QUE EL CONTAINER NO ESTE CREDO PORQUE DA ERROR
            container.Create();

        BlobClient blob = container.GetBlobClient(nombreArchivo);

        // Upload local file
        //byte[] newBytes = Convert.FromBase64String(contenido);
        //if (newBytes is not null)
        //{
        

        // Get a reference to a blob named "sample-file" in a container named "sample-container"

        

        //}

        byte[] newBytes = Convert.FromBase64String(contenido);
        MemoryStream stream = new MemoryStream(newBytes);
        var result = await blob.UploadAsync(stream);




            //foreach (BlobItem koko in container.GetBlobs())
            //{
            //    var gero = koko;
            //    Console.WriteLine(koko.Name);
            //}
            //var bytes = Convert.FromBase64String(contenido);
            //var contents = new StreamContent(new MemoryStream(bytes));
            //if (contents is not null)
            //{

            //}



            return await Task.FromResult(new ArchivoRespuestaDTO(nombreArchivo, "sin ruta por el momento", true, 1));
        }
        catch (Exception)
        {

            return await Task.FromResult(new ArchivoRespuestaDTO("error", "fallo", false, 0));

        }
    }
}