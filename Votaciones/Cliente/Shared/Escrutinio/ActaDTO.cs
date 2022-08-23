

namespace Cliente.Shared.Escrutinio;

public record ActaDTO(
    int CantidadVotaciones ,
    int VotosBlancos ,
    int VotosNulos ,
    Boolean FirmaPresidente ,
    Boolean FirmaSecretario ,
    string Imagen ,
    Boolean Estado,
    string Observador);