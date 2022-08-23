using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacion.Migrations
{
    public partial class thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadVotantesJRV",
                table: "Acta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadVotantesJRV",
                table: "Acta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
