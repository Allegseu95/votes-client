namespace Cliente.Shared.EntidadadesDTO;
public record RespuestaDTO(
    string Mensaje,
    bool Estado,
    int CantidadCambios);