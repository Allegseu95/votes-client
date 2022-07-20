using MudBlazor;

namespace Cliente.Client.Shared;

public partial class MainLayout
{
    private readonly MudTheme temarsonalizado = new()
    {
        Palette = new Palette
        {
            Primary = Colors.DeepPurple.Default,
            Secondary = Colors.Amber.Accent4,
            AppbarBackground = Colors.DeepPurple.Default
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