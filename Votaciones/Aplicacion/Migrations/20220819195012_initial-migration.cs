using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacion.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadVotantesJRV = table.Column<int>(type: "int", nullable: false),
                    CantidadVotaciones = table.Column<int>(type: "int", nullable: false),
                    VotosBlancos = table.Column<int>(type: "int", nullable: false),
                    VotosNulos = table.Column<int>(type: "int", nullable: false),
                    FirmaPresidente = table.Column<bool>(type: "bit", nullable: false),
                    FirmaSecretario = table.Column<bool>(type: "bit", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acta");
        }
    }
}
