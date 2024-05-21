using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rsAPIElevador.Migrations
{
    /// <inheritdoc />
    public partial class veintitres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EV_Obra_EV_Administracion_IdAdministacion",
                table: "EV_Obra");

            migrationBuilder.DropColumn(
                name: "Expediente",
                table: "EV_Maquina");

            migrationBuilder.RenameColumn(
                name: "IdAdministacion",
                table: "EV_Obra",
                newName: "IdAdministracion");

            migrationBuilder.RenameIndex(
                name: "IX_EV_Obra_IdAdministacion",
                table: "EV_Obra",
                newName: "IX_EV_Obra_IdAdministracion");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EV_Obra",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "EV_Obra",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EV_Obra_EV_Administracion_IdAdministracion",
                table: "EV_Obra",
                column: "IdAdministracion",
                principalTable: "EV_Administracion",
                principalColumn: "IdAdministracion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EV_Obra_EV_Administracion_IdAdministracion",
                table: "EV_Obra");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "EV_Obra");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "EV_Obra");

            migrationBuilder.RenameColumn(
                name: "IdAdministracion",
                table: "EV_Obra",
                newName: "IdAdministacion");

            migrationBuilder.RenameIndex(
                name: "IX_EV_Obra_IdAdministracion",
                table: "EV_Obra",
                newName: "IX_EV_Obra_IdAdministacion");

            migrationBuilder.AddColumn<string>(
                name: "Expediente",
                table: "EV_Maquina",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EV_Obra_EV_Administracion_IdAdministacion",
                table: "EV_Obra",
                column: "IdAdministacion",
                principalTable: "EV_Administracion",
                principalColumn: "IdAdministracion");
        }
    }
}
