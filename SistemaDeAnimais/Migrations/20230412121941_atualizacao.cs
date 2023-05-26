using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeAnimais.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Usuarios_UsuarioId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetModelId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Usuarios_UsuarioId",
                table: "Pets",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Usuarios_UsuarioId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetModelId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Usuarios_UsuarioId",
                table: "Pets",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
