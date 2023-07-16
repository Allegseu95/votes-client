using Cliente.Shared.ComandosDTO;
using Cliente.Shared.EntidadadesDTO;
using Cliente.Shared.Mensajes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Net.Http.Json;

namespace Cliente.Client.Pages.Observador;

public partial class Acta
{
    [Parameter]
    public int JRVId { get; set; }
    [Parameter]
    public int PapeletaId { get; set; }
    public string Dignidad { get; set; } = string.Empty;
    public string JRVNombreCompleto { get; set; } = string.Empty;
    public int CantidadVotantes { get; set; }
    public int CantidadVotaciones { get; set; }
    public int VotosBlancos { get; set; }
    public int VotosNulos { get; set; }
    public bool FirmaPresidente { get; set; }
    public bool FirmaSecretario { get; set; }
    public string Imagen { get; set; } = string.Empty;
    public JRVDTO? JRV { get; set; }
    public List<CandidatoDTO> Candidatos { get; set; } = new List<CandidatoDTO>();

    private bool procesando = false;
    private bool subiendo = false;
    private long maxFileSize = 1024 * 1024 * 8;

    public async Task SubirImagen(InputFileChangeEventArgs e)
    {
        subiendo = true;

        var image = e.GetMultipleFiles().FirstOrDefault();

        if (image is not null)
        {
            var fileContent = new StreamContent(image.OpenReadStream(maxAllowedSize: maxFileSize));

            ArchivoComandoDTO archivo = new()
            {
                Nombre = $"J{JRVId}P{PapeletaId}.jpg",
                Contenido = Convert.ToBase64String(await fileContent.ReadAsByteArrayAsync()),
                Tamano = (int)image.Size,
            };

            HttpResponseMessage response = await this.Http.PostAsJsonAsync("api/archivos", archivo);
            var result = await response.Content.ReadFromJsonAsync<RespuestaDTO>();

            if (result != null)
            {
                switch (result.Estado)
                {
                    case true:
                        MostrarAlerta(MensajesNotificacion.MENSAJE_IMAGEN_GUARDADA, Severity.Success);
                        Imagen = result.Mensaje;
                        break;
                    case false:
                        MostrarAlerta(result.Mensaje, Severity.Error);
                        break;
                }
            }
            else
            {
                MostrarAlerta(MensajesError.MENSAJE_ERROR_INESPERADO, Severity.Error);
            }
        }
        else
        {
            MostrarAlerta(MensajesAlerta.MENSAJE_IMAGEN_PROBLEMAS, Severity.Warning);
        }

        subiendo = false;
    }

    public async Task RegistrarActa()
    {
        if (Imagen == string.Empty)
        {
            MostrarAlerta(MensajesAlerta.MENSAJE_IMAGEN_NO_SELECCIONADA, Severity.Warning);
            return;
        }

        procesando = true;

        List<DetalleActaComandoDTO> DetallesActa = new List<DetalleActaComandoDTO>();

        foreach (var candidato in Candidatos)
        {
            DetallesActa.Add(new DetalleActaComandoDTO(candidato.Id, candidato.Votos));
        }

        var acta = new ActaComandoDTO
        (
            JRVId,
            PapeletaId,
            CantidadVotaciones,
            VotosBlancos,
            VotosNulos,
            FirmaPresidente,
            FirmaSecretario,
            Imagen,
            DetallesActa
        );

        HttpResponseMessage response = await this.Http.PostAsJsonAsync("api/actas", acta);
        var result = await response.Content.ReadFromJsonAsync<RespuestaDTO>();

        if (result != null)
        {
            switch (result.Estado)
            {
                case true:
                    MostrarAlerta(result.Mensaje, Severity.Success);
                    NavigationManager.NavigateTo($"/observador/papeletas/{JRVId}");
                    break;
                case false:
                    MostrarAlerta(result.Mensaje, Severity.Error);
                    break;
            }
        }
        else
        {
            MostrarAlerta(MensajesError.MENSAJE_ERROR_INESPERADO, Severity.Error);
        }

        procesando = false;
    }

    public void MostrarAlerta(string mensaje, Severity tipo) => Snackbar.Add(mensaje, tipo);

    public void Regresar()
    {
        NavigationManager.NavigateTo($"/observador/papeletas/{JRVId}");
    }

    protected override async Task OnInitializedAsync()
    {
        var result = await Http.GetFromJsonAsync<List<CandidatoDTO>>($"api/candidatos/{PapeletaId}");
        if (result is not null)
        {
            this.Candidatos = result;
            this.Dignidad = Candidatos.First().PapeletaDignidad;
        }

        this.JRV = await this.Http.GetFromJsonAsync<JRVDTO>($"api/jrvs/uno/{JRVId}");
        if (JRV is not null)
        {
            this.CantidadVotantes = JRV.CantidadVotantes;
            this.JRVNombreCompleto = $"{JRV.Numero} - {JRV.Genero}";
        }
    }
}