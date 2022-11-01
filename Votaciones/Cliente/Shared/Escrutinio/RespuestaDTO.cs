namespace Cliente.Shared.Escrutinio;
public record RespuestaDTO(
    string Mensaje,
    bool Estado,
    int CantidadCambios);