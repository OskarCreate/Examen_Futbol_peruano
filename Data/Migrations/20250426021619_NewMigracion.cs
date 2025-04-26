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
            migrationBuilder.DropColumn(
                name: "Cumpleaños",
                table: "t_Jugadores");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "t_Jugadores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "t_Jugadores");

            migrationBuilder.AddColumn<DateTime>(
                name: "Cumpleaños",
                table: "t_Jugadores",
                type: "TEXT",
                nullable: true);
        }
    }
}
