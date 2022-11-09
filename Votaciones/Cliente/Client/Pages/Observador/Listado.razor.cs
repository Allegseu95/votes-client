using Cliente.Shared.EntidadadesDTO;
using Cliente.Shared.Mensajes;
using System.Text.Json;

namespace Cliente.Client.Pages.Observador;

public partial class Listado
{
    public string Titulo { get; set; } = string.Empty;
    public bool ListaLlena { get; set; } = false;
    public int UserId { get; set; } = 308;
    public string MensajeDatosVacios { get; set; } = MensajesAlerta.MENSAJE_DATOS_VACIOS;

    private JRVDTO[]? jrvs;

    protected override async Task OnInitializedAsync()
    {
        HttpResponseMessage response = await this.Http.GetAsync($"api/jrvs/{UserId}");
        int code = (int)response.StatusCode;

        switch (code)
        {
            case 200:
                var result = await response.Content.ReadAsStringAsync();
                this.jrvs = JsonSerializer.Deserialize<JRVDTO[]>(result, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                if (jrvs != null)
                {
                    Titulo = jrvs[0].Recinto;
                    ListaLlena = true;
                }
                break;
            case 204:
                Titulo = MensajesAlerta.MENSAJE_REGISTROS_VACIOS;
                jrvs = new JRVDTO[0];
                break;
            case 404:
                Titulo = MensajesError.MENSAJE_ID_INVALIDO;
                jrvs = new JRVDTO[0];
                break;
            default:
                Titulo = MensajesError.MENSAJE_ERROR_INESPERADO;
                jrvs = new JRVDTO[0];
                break;
        }
    }
}
