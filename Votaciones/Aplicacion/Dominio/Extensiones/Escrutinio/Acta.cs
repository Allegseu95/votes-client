namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class Acta
{
    public bool ValidacionActa()
    {
        if (!FirmaPresidente || !FirmaSecretario)
            return false;

        int votosCandidatos = 0;
        foreach (var detalleActa in DetalleActas)
        {
            votosCandidatos += detalleActa.CantidadVotos;
            if (votosCandidatos > CantidadVotaciones)
                return false;
        }      
        
        if (votosCandidatos + VotosBlancos + VotosNulos != CantidadVotaciones)
            return false;

        return true;
    }
}
