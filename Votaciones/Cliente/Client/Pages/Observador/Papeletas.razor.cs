using Cliente.Shared.Escrutinio;
using Cliente.Shared.Mensajes;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Cliente.Client.Pages.Observador;

public partial class Papeletas
{
    [Parameter]
    public int JRVId { get; set; }
    public string Aviso { get; set; } = MensajesNotificacion.MENSAJE_JRV_SIN_PAPELETAS_ASIGNADAS;

    private JRVPapeletaDTO[]? papeletas;

    protected override async Task OnInitializedAsync() =>
        this.papeletas = await this.Http.GetFromJsonAsync<JRVPapeletaDTO[]>($"api/papeletas/{JRVId}");
}
