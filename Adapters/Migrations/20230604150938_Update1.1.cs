using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidadoes_Enderecos_EnderecoId",
                table: "Cidadoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Enderecos_EnderecoId",
                table: "Servidores");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Servidores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidadoes_Enderecos_EnderecoId",
                table: "Cidadoes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Enderecos_EnderecoId",
                table: "Servidores",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidadoes_Enderecos_EnderecoId",
                table: "Cidadoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Enderecos_EnderecoId",
                table: "Servidores");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Servidores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cidadoes_Enderecos_EnderecoId",
                table: "Cidadoes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Enderecos_EnderecoId",
                table: "Servidores",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
