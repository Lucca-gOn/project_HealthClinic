using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiweb.healthclinic.manha.Migrations
{
    /// <inheritdoc />
    public partial class Bd9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Usuario",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoProntuario",
                table: "Prontuario",
                type: "VARCHAR(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Usuario",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoProntuario",
                table: "Prontuario",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");
        }
    }
}
