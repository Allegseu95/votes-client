namespace Cliente.Shared.EntidadadesDTO;

public record ActaDTO(
    string Codigo,
    int CantidadVotaciones,
    int VotosBlancos,
    int VotosNulos,
    bool FirmaPresidente,
    bool FirmaSecretario,
    string Imagen,
    bool Estado,
    int JRVId,
    int PapeletaId);