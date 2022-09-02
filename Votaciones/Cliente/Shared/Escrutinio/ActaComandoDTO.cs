namespace Cliente.Shared.Escrutinio;
public record ActaComandoDTO
(
     int JRVId,
     int PapeletaId,
     string Codigo,
     int CantidadVotaciones,
     int VotosBlancos,
     int VotosNulos,
     Boolean FirmaPresidente,
     Boolean FirmaSecretario,
     string Imagen,
     Boolean Estado
);
