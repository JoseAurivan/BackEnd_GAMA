using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingOnDeletes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Secretarias_SecretariaId",
                table: "Servidores");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CPF",
                table: "Users",
                column: "CPF",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Secretarias_SecretariaId",
                table: "Servidores",
                column: "SecretariaId",
                principalTable: "Secretarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Secretarias_SecretariaId",
                table: "Servidores");

            migrationBuilder.DropIndex(
                name: "IX_Users_CPF",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Secretarias_SecretariaId",
                table: "Servidores",
                column: "SecretariaId",
                principalTable: "Secretarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
