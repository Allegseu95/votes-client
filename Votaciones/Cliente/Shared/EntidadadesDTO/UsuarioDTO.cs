namespace Cliente.Shared.EntidadadesDTO;

public record UsuarioDTO(
    int Id,
    string Nombre,
    string Apellido,
    string Genero,
    string Cedula,
    string Email);