using Cliente.Shared.EntidadadesDTO;
using MediatR;

namespace Cliente.Shared.ComandosDTO;
public record ActaComandoDTO
(
     int JRVId,
     int PapeletaId,
     int CantidadVotaciones,
     int VotosBlancos,
     int VotosNulos,
     bool FirmaPresidente,
     bool FirmaSecretario,
     string Imagen,
     List<DetalleActaComandoDTO> DetalleActas
) : IRequest<RespuestaDTO>;
