using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiweb.healthclinic.manha.Migrations
{
    /// <inheritdoc />
    public partial class Bdv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Paciente_RG",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "RG",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Paciente",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "Paciente",
                type: "VARCHAR(12)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Paciente",
                type: "VARCHAR(30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_RG",
                table: "Paciente",
                column: "RG",
                unique: true,
                filter: "[RG] IS NOT NULL");
        }
    }
}
