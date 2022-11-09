namespace Cliente.Shared.EntidadadesDTO;
public class CandidatoDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Imagen { get; set; } = string.Empty;
    public string PapeletaDignidad { get; set; } = string.Empty;
    public int Votos { get; set; }
}