using Cliente.Shared.Escrutinio;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace Cliente.Client.Pages.Observador;

public partial class Acta
{
    [Parameter]
    public int JRVId { get; set; }
    [Parameter]
    public int PapeletaId { get; set; }
    public int CantidadVotaciones { get; set; }
    public int VotosBlancos { get; set; }
    public int VotosNulos { get; set; }
    public bool FirmaPresidente { get; set; }
    public bool FirmaSecretario { get; set; }
    public string Imagen { get; set; } = string.Empty;


    public string respuesta = string.Empty;

    public async void RegistrarActa()
    {
        var acta = new ActaComandoDTO
        (
            JRVId,
            PapeletaId,
            $"Acta-00{JRVId}/00{PapeletaId}",
            CantidadVotaciones,
            VotosBlancos,
            VotosNulos,
            FirmaPresidente,
            FirmaSecretario,
            Imagen,
            FirmaPresidente && FirmaSecretario ? true : false
        );

        Console.WriteLine(acta);

        //using var response = await this.Http.PostAsJsonAsync("api/actas", acta);

        //var data = await response.Content.ReadFromJsonAsync<JsonElement>();



        ////this.respuesta = data.GetProperty("Id").ToString();
        ////this.respuesta = await data.ToString();

        
        //Console.WriteLine($"{response}  \nresultado de la peticion: {data}");
        
    }

    protected override async Task OnInitializedAsync() => Console.WriteLine($"Acta a registrar {JRVId} => {PapeletaId} ");



}
