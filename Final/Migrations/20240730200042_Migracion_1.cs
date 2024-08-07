using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica_Final.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Soldados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    InicioActividades = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Escuadrones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Escuadrones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escuadrones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuadrones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escuadrones_Tipo_Escuadrones_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "Tipo_Escuadrones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoladosXEscuadrones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEscuadron = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSoldado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Actividad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoladosXEscuadrones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoladosXEscuadrones_Escuadrones_IdEscuadron",
                        column: x => x.IdEscuadron,
                        principalTable: "Escuadrones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoladosXEscuadrones_Soldados_IdSoldado",
                        column: x => x.IdSoldado,
                        principalTable: "Soldados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Escuadrones_IdTipo",
                table: "Escuadrones",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_SoladosXEscuadrones_IdEscuadron",
                table: "SoladosXEscuadrones",
                column: "IdEscuadron");

            migrationBuilder.CreateIndex(
                name: "IX_SoladosXEscuadrones_IdSoldado",
                table: "SoladosXEscuadrones",
                column: "IdSoldado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoladosXEscuadrones");

            migrationBuilder.DropTable(
                name: "Escuadrones");

            migrationBuilder.DropTable(
                name: "Soldados");

            migrationBuilder.DropTable(
                name: "Tipo_Escuadrones");
        }
    }
}
