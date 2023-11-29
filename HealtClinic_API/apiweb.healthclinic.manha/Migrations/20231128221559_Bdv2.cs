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
            migrationBuilder.AlterColumn<string>(
                name: "DescricaoProntuario",
                table: "Prontuario",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DescricaoProntuario",
                table: "Prontuario",
                type: "VARCHAR(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);
        }
    }
}
