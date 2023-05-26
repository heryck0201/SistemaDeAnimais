using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeAnimais.Migrations
{
    public partial class AtualizandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "PetModelId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Raca",
                table: "Pets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Porte",
                table: "Pets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Pets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetModelId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Usuarios",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Raca",
                table: "Pets",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Porte",
                table: "Pets",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Pets",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Cor",
                table: "Pets",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
