using MudBlazor;

namespace Cliente.Client.Shared;

public partial class MainLayout
{
    private readonly MudTheme temaPersonalizado = new()
    {
        Palette = new Palette
        {
            Primary = Colors.Teal.Darken2,
            Secondary = Colors.Teal.Lighten2,
            AppbarBackground = Colors.Teal.Darken2,
            Error = Colors.Red.Default
        }

        //LayoutProperties = new LayoutProperties()
        //{
        //    DrawerWidthLeft = "260px",
        //    DrawerWidthRight = "300px"
        //}
    };

    private bool drawerAbierto = true;

    private void AlternarDrawer() => this.drawerAbierto = !this.drawerAbierto;
}