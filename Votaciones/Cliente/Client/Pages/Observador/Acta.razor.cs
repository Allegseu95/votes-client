﻿using Cliente.Shared.Escrutinio;
using Cliente.Shared.Mensajes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Net.Http.Json;
using System.Text.Json;
using static MudBlazor.CategoryTypes;
using static MudBlazor.Colors;

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


    IList<IBrowserFile> files = new List<IBrowserFile>();
    private bool procesando = false;

    public async Task UploadFiles(InputFileChangeEventArgs e)
    {
        foreach (var file in e.GetMultipleFiles())
        {
            files.Add(file);
        }

        var image = files.FirstOrDefault();

        if (image != null)
        {
            var ms = new MemoryStream();
            var content = new MultipartFormDataContent
            {
                {new ByteArrayContent( ms.GetBuffer()), "\"upload\"", image.Name }
            };

            HttpResponseMessage response = await this.Http.PostAsync("api/upload", content);            
            var result = await response.Content.ReadAsStringAsync();

            if (result == "true")
            {
                this.Imagen = "Url demo de evidencia";
                MostrarAlerta("Imagen guardada correctamente!", Severity.Info);
            }
            
            if (result == "false")
            {                
                MostrarAlerta("La imagen no se subio correctamente!", Severity.Error);

            }
        }
    }

    public async Task RegistrarActa()
    {
        procesando = true;

        List<DetalleActaComandoDTO> DetalleActas = new List<DetalleActaComandoDTO>();

        foreach (var candidato in Candidatos)
        {
            DetalleActas.Add(new DetalleActaComandoDTO(candidato.Id, candidato.Votos));
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
            DetalleActas
        );

        HttpResponseMessage response = await this.Http.PostAsJsonAsync("api/actas", acta);
        var result = await response.Content.ReadAsStringAsync();

        switch (result)
        {
            case "true":
                MostrarAlerta(MensajesNotificacion.MENSAJE_ACTA_REGISTRADA, Severity.Success);
                NavigationManager.NavigateTo($"/observador/papeletas/{JRVId}");
                break;
            case "false":
                MostrarAlerta(MensajesError.MENSAJE_ERROR_INESPERADO, Severity.Error);
                break;
            default:
                int code = (int)response.StatusCode;
                if (code == 404)
                {
                    MostrarAlerta(MensajesError.MENSAJE_ERROR_VALIDACION_ACTA, Severity.Error);
                }
                else
                {
                    MostrarAlerta(MensajesError.MENSAJE_ERROR_INESPERADO, Severity.Error);
                }
                break;
        }

        procesando = false;
    }

    public void MostrarAlerta(string mensaje, Severity tipo) => Snackbar.Add(mensaje, tipo);

    protected override async Task OnInitializedAsync()
    {
        this.Candidatos = await this.Http.GetFromJsonAsync<List<CandidatoDTO>>($"api/candidatos/{PapeletaId}");
        this.Dignidad = Candidatos.Any() ? Candidatos.FirstOrDefault().PapeletaDignidad : "No Registrada";
        this.JRV = await this.Http.GetFromJsonAsync<JRVDTO>($"api/jrvs/uno/{JRVId}");
        this.CantidadVotantes = JRV.CantidadVotantes;
        this.JRVNombreCompleto = $"{JRV.Numero} - {JRV.Genero}";
    }
}