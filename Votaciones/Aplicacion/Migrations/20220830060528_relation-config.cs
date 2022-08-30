using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacion.Migrations
{
    public partial class relationconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observador",
                table: "Actas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Actas",
                newName: "ActaId");

            migrationBuilder.AlterColumn<string>(
                name: "Imagen",
                table: "Actas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Actas",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Creado",
                table: "Actas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Actas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JRVId",
                table: "Actas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modificado",
                table: "Actas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPor",
                table: "Actas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PapeletaId",
                table: "Actas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JRVs",
                columns: table => new
                {
                    JRVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DireccionRecinto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Recinto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZonaElectoral = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Parroquia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoParroquia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Canton = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Circunscripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JRVs", x => x.JRVId);
                });

            migrationBuilder.CreateTable(
                name: "Papeletas",
                columns: table => new
                {
                    PapeletaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Dignidad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaEleccion = table.Column<DateTime>(type: "date", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papeletas", x => x.PapeletaId);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PapeletaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    OrganizacionPolitica = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.CandidatoId);
                    table.ForeignKey(
                        name: "FK_CandidatosPapeletas",
                        column: x => x.PapeletaId,
                        principalTable: "Papeletas",
                        principalColumn: "PapeletaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JRVs_Papeletas",
                columns: table => new
                {
                    JRVId = table.Column<int>(type: "int", nullable: false),
                    PapeletaId = table.Column<int>(type: "int", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JRVs_Papeletas", x => new { x.JRVId, x.PapeletaId });
                    table.ForeignKey(
                        name: "FK_JRVs_PapeletasJRVs",
                        column: x => x.JRVId,
                        principalTable: "JRVs",
                        principalColumn: "JRVId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JRVs_PapeletasPapeletas",
                        column: x => x.PapeletaId,
                        principalTable: "Papeletas",
                        principalColumn: "PapeletaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalles_Acta",
                columns: table => new
                {
                    ActaId = table.Column<int>(type: "int", nullable: false),
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    CantidadVotos = table.Column<int>(type: "int", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalles_Acta", x => new { x.ActaId, x.CandidatoId });
                    table.ForeignKey(
                        name: "FK_DetallesActasActas",
                        column: x => x.ActaId,
                        principalTable: "Actas",
                        principalColumn: "ActaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesActasCandidatos",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "CandidatoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actas_JRVId_PapeletaId",
                table: "Actas",
                columns: new[] { "JRVId", "PapeletaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_PapeletaId",
                table: "Candidatos",
                column: "PapeletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_Acta_CandidatoId",
                table: "Detalles_Acta",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_JRVs_Papeletas_PapeletaId",
                table: "JRVs_Papeletas",
                column: "PapeletaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActasJRVs_Papeletas",
                table: "Actas",
                columns: new[] { "JRVId", "PapeletaId" },
                principalTable: "JRVs_Papeletas",
                principalColumns: new[] { "JRVId", "PapeletaId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActasJRVs_Papeletas",
                table: "Actas");

            migrationBuilder.DropTable(
                name: "Detalles_Acta");

            migrationBuilder.DropTable(
                name: "JRVs_Papeletas");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "JRVs");

            migrationBuilder.DropTable(
                name: "Papeletas");

            migrationBuilder.DropIndex(
                name: "IX_Actas_JRVId_PapeletaId",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "Creado",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "JRVId",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "Modificado",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "ModificadoPor",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "PapeletaId",
                table: "Actas");

            migrationBuilder.RenameColumn(
                name: "ActaId",
                table: "Actas",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Imagen",
                table: "Actas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "Observador",
                table: "Actas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
