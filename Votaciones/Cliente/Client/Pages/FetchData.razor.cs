using Cliente.Shared;
using System.Net.Http.Json;

namespace Cliente.Client.Pages;

public partial class FetchData
{
    private PronosticoClimaDto[]? pronostico;

    protected override async Task OnInitializedAsync() =>
        this.pronostico = await this.Http.GetFromJsonAsync<PronosticoClimaDto[]>("Pronostico");
}