using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rsAPIElevador.Migrations
{
    /// <inheritdoc />
    public partial class _23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Libro",
                table: "EV_Obra",
                newName: "IdCons");

            migrationBuilder.RenameColumn(
                name: "FechaLibro",
                table: "EV_Obra",
                newName: "FechaCons");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "EV_Obra",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAdm",
                table: "EV_Obra",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expediente",
                table: "EV_Maquina",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLib",
                table: "EV_Maquina",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Libro",
                table: "EV_Maquina",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAdm",
                table: "EV_Obra");

            migrationBuilder.DropColumn(
                name: "Expediente",
                table: "EV_Maquina");

            migrationBuilder.DropColumn(
                name: "FechaLib",
                table: "EV_Maquina");

            migrationBuilder.DropColumn(
                name: "Libro",
                table: "EV_Maquina");

            migrationBuilder.RenameColumn(
                name: "IdCons",
                table: "EV_Obra",
                newName: "Libro");

            migrationBuilder.RenameColumn(
                name: "FechaCons",
                table: "EV_Obra",
                newName: "FechaLibro");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "EV_Obra",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
