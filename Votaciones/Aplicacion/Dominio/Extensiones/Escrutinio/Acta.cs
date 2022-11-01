namespace Aplicacion.Dominio.Entidades.Escrutinio;
public partial class Acta
{
    public bool ValidacionActa()
    {
        if (!FirmaPresidente || !FirmaSecretario)
            return false;

        if (DetalleActas.Count < 1)
            return false;

        int votosCandidatos = 0;
        foreach (var detalleActa in DetalleActas)
        {
            votosCandidatos += detalleActa.CantidadVotos;
            if (votosCandidatos > CantidadVotaciones)
                return false;
        }

        return votosCandidatos + VotosBlancos + VotosNulos == CantidadVotaciones;
    }
}
