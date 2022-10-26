namespace Cliente.Shared.Escrutinio;

public record ActaDTO(
    string Codigo,
    int CantidadVotaciones ,
    int VotosBlancos ,
    int VotosNulos ,
    Boolean FirmaPresidente ,
    Boolean FirmaSecretario ,
    string Imagen ,
    Boolean Estado,
    int JRVId,
    int PapeletaId);