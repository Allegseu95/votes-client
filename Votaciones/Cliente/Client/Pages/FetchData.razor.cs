using Cliente.Shared;
using Cliente.Shared.Escrutinio;
using System.Net.Http.Json;

namespace Cliente.Client.Pages;

public partial class FetchData
{
    private ActaDTO[]? actas;

    protected override async Task OnInitializedAsync() =>
        this.actas = await this.Http.GetFromJsonAsync<ActaDTO[]>("api/actas");
}