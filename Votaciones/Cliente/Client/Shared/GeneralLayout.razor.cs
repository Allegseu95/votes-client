using MudBlazor;
namespace Cliente.Client.Shared;

public partial class GeneralLayout
{
    private readonly MudTheme temaPersonalizado = new()
    {
        Palette = new Palette
        {
            Primary = Colors.Teal.Darken2,
            Secondary = Colors.Grey.Lighten4,
            AppbarBackground = Colors.Teal.Darken2,
            Error = Colors.Red.Default,
        }
    };
}
