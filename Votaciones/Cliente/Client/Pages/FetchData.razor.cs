using Cliente.Shared;
using Cliente.Shared.Escrutinio;
using System.Net.Http.Json;

namespace Cliente.Client.Pages;

public partial class FetchData
{
    private ActaDTO[]? registro;

    protected override async Task OnInitializedAsync() =>
        this.registro = await this.Http.GetFromJsonAsync<ActaDTO[]>("api/actas");
}