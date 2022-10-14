using MediatR;

namespace Cliente.Shared.Escrutinio;
public record ActaComandoDTO
(
     int JRVId,
     int PapeletaId,
     int CantidadVotaciones,
     int VotosBlancos,
     int VotosNulos,
     Boolean FirmaPresidente,
     Boolean FirmaSecretario,
     string Imagen,
     List<DetalleActaComandoDTO> DetalleActas
) : IRequest<bool>;
