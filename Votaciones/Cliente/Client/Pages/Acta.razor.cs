using Cliente.Shared.Escrutinio;
using System.Net.Http.Json;
using System.Text.Json;

namespace Cliente.Client.Pages;

public partial class Acta
{
    public int CantidadVotaciones { get; set; }
    public int VotosBlancos { get; set; }
    public int VotosNulos { get; set; }
    public Boolean FirmaPresidente { get; set; }
    public Boolean FirmaSecretario { get; set; }
    public string Imagen { get; set; } = string.Empty;

    
    public string respuesta = string.Empty;

    private int NumeroJRV = 0;

    public int CantidadVotantesJRV = 350;

    public async void RegistrarActa()
    {
        ActaComandoDTO acta = new ActaComandoDTO
        (

            NumeroJRV + 1,
            1,
            $"Acta-00{NumeroJRV + 1}",
            this.CantidadVotaciones,
            this.VotosBlancos,
            this.VotosNulos,
            this.FirmaPresidente,
            this.FirmaSecretario,
            this.Imagen,
            this.FirmaPresidente && this.FirmaSecretario ? true : false,
            DateTime.Now,
            DateTime.Now,
            "Usuario Actual",
            "test"
        );

        using var response = await this.Http.PostAsJsonAsync("api/actas", acta);

        var data = await response.Content.ReadFromJsonAsync<JsonElement>();



        //this.respuesta = data.GetProperty("Id").ToString();
        //this.respuesta = await data.ToString();

        this.respuesta = data.ToString();
        Console.WriteLine(response);
        Console.WriteLine($"resultado de peticion: {data}");
        this.NumeroJRV++;
    }



}
