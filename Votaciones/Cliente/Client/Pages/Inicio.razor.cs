using Cliente.Shared;
using Cliente.Shared.Escrutinio;
using System.Net.Http.Json;

namespace Cliente.Client.Pages;

public partial class Inicio
{
    private bool drawerAbierto = false;

    private void AlternarDrawer() => this.drawerAbierto = !this.drawerAbierto;
}