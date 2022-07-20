namespace Cliente.Client.Shared;

public partial class NavMenu
{
    private bool colapsarNavMenu = true;

    private string? NavMenuCssClass => this.colapsarNavMenu ? "collapse" : null;

    private void AlternarNavMenu() => this.colapsarNavMenu = !this.colapsarNavMenu;
}