namespace Cliente.Shared.EntidadadesDTO;
public record ArchivoRespuestaDTO(
    string Nombre,
    string Ruta,
    bool Estado,
    int Cantidad);