using Cliente.Shared.EntidadadesDTO;
using Cliente.Shared.Mensajes;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Text.Json;
using MudBlazor;

namespace Cliente.Client.Pages.Observador;

public partial class Listado
{
    public string Titulo { get; set; } = string.Empty;
    public bool ListaLlena { get; set; } = false;
    public string MensajeDatosVacios { get; set; } = MensajesAlerta.MENSAJE_DATOS_VACIOS;
    public UsuarioDTO Usuario { get; set; }

    public JRVDTO[]? JRVS;

    private UsuarioDTO[]? usuarios;

    protected override async Task OnInitializedAsync()
    {

        try
        {
            var AccessTokenResult = await AccessTokenProvider.RequestAccessToken();
            if (AccessTokenResult.TryGetToken(out var Token))
            {
                Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Value);

                HttpResponseMessage? responseAuth = await this.Http.GetAsync("api/autenticacion");
                int codeAuth = (int)responseAuth.StatusCode;

                switch (codeAuth)
                {
                    case 200:
                        var _usuarios = await responseAuth.Content.ReadAsStringAsync();
                        this.usuarios = JsonSerializer.Deserialize<UsuarioDTO[]>(_usuarios, new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        this.Usuario = usuarios[0];
                        HttpResponseMessage response = await this.Http.GetAsync($"api/jrvs/{Usuario.Id}");
                        int code = (int)response.StatusCode;

                        switch (code)
                        {
                            case 200:
                                var result = await response.Content.ReadAsStringAsync();
                                this.JRVS = JsonSerializer.Deserialize<JRVDTO[]>(result, new JsonSerializerOptions()
                                {
                                    PropertyNameCaseInsensitive = true
                                });

                                if (JRVS != null)
                                {
                                    Titulo = JRVS[0].Recinto;
                                    ListaLlena = true;
                                }
                                break;
                            case 204:
                                MostrarAlerta(MensajesAlerta.MENSAJE_USUARIO_SIN_JRVS_ASIGNADAS, Severity.Warning);
                                Titulo = MensajesAlerta.MENSAJE_USUARIO_SIN_JRVS_ASIGNADAS;
                                JRVS = new JRVDTO[0];
                                break;
                            case 404:
                                MostrarAlerta(MensajesError.MENSAJE_ID_INVALIDO, Severity.Warning);
                                Titulo = MensajesError.MENSAJE_ID_INVALIDO;
                                JRVS = new JRVDTO[0];
                                break;
                            default:
                                MostrarAlerta(MensajesError.MENSAJE_ERROR_INESPERADO, Severity.Error);
                                Titulo = MensajesError.MENSAJE_ERROR_INESPERADO;
                                JRVS = new JRVDTO[0];
                                break;
                        }
                        break;

                    case 204:
                        MostrarAlerta(MensajesAlerta.MENSAJE_USUARIO_SIN_JRVS_ASIGNADAS, Severity.Info);
                        Titulo = MensajesAlerta.MENSAJE_USUARIO_SIN_JRVS_ASIGNADAS;
                        JRVS = new JRVDTO[0];
                        break;

                    default:
                        MostrarAlerta(MensajesError.MENSAJE_ERROR_INESPERADO, Severity.Error);
                        Titulo = MensajesError.MENSAJE_ERROR_INESPERADO;
                        JRVS = new JRVDTO[0];
                        break;
                }
            }
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }

    }
    public void MostrarAlerta(string mensaje, Severity tipo) => Snackbar.Add(mensaje, tipo);

}
