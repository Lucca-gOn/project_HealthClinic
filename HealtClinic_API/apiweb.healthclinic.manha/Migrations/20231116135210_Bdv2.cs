using System;
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
            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Clinica_IdClinica",
                table: "Medico");

            migrationBuilder.DropIndex(
                name: "IX_Medico_IdClinica",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "IdClinica",
                table: "Medico");

            migrationBuilder.AlterColumn<string>(
                name: "CaminhoImagem",
                table: "Usuario",
                type: "VARCHAR(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CaminhoImagem",
                table: "Usuario",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");

            migrationBuilder.AddColumn<Guid>(
                name: "IdClinica",
                table: "Medico",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdClinica",
                table: "Medico",
                column: "IdClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Clinica_IdClinica",
                table: "Medico",
                column: "IdClinica",
                principalTable: "Clinica",
                principalColumn: "IdClinica",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
