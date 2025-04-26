using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen_Futbol_peruano.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Cumpleaños = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Posicion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Jugadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Asociaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JugadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Asociaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Asociaciones_t_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "t_Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_Asociaciones_t_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "t_Jugadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_Asociaciones_EquipoId",
                table: "t_Asociaciones",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Asociaciones_JugadorId_EquipoId",
                table: "t_Asociaciones",
                columns: new[] { "JugadorId", "EquipoId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_Asociaciones");

            migrationBuilder.DropTable(
                name: "t_Equipos");

            migrationBuilder.DropTable(
                name: "t_Jugadores");
        }
    }
}
