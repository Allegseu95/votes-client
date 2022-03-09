using Cliente.Shared.Escrutinio;
using System.Net.Http.Json;
using System.Text.Json;

namespace Cliente.Client.Pages;

public partial class Acta
{
    
    public int NumeroJRV { get; set; } = 2;
    public int CantidadVotantesJRV { get; set; } = 350;
    public int CantidadVotaciones { get; set; }
    public int VotosBlancos { get; set; }
    public int VotosNulos { get; set; }
    public Boolean FirmaPresidente { get; set; }
    public Boolean FirmaSecretario { get; set; }
    public string Imagen { get; set; }
    public Boolean Estado { get; set; }

    private ActaDTO acta;

    public string respuesta;

    public int statusCode { get; set; }


    public async void RegistrarActa()
    {
        this.Estado = FirmaPresidente && FirmaSecretario ? true : false ;

        acta = new ActaDTO
            (CantidadVotantesJRV, CantidadVotaciones, VotosBlancos,VotosNulos, 
            FirmaPresidente, FirmaSecretario, Imagen, Estado);
     
        using var response = await this.Http.PostAsJsonAsync("api/actas", acta);

        var data = await response.Content.ReadFromJsonAsync<JsonElement>();
        this.statusCode = (int)response.StatusCode;


        //this.respuesta = data.GetProperty("Id").ToString();
        //this.respuesta = await data.ToString();
 
        this.respuesta = data.ToString();
        Console.WriteLine(response);
        Console.WriteLine($"resultado de peticion: {data}");
    }

}
