using Cliente.Shared.EntidadadesDTO;
using MediatR;

namespace Cliente.Shared.ComandosDTO;
public class ArchivoComandoDTO : IRequest<RespuestaDTO>
{
    public string Path { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Contenido { get; set; } = string.Empty;
    public int Tamano { get; set; }
}