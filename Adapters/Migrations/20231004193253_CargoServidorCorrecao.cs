using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CargoServidorCorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores");

            migrationBuilder.DropIndex(
                name: "IX_Servidores_CargoId",
                table: "Servidores");

            migrationBuilder.AlterColumn<int>(
                name: "AtendidoPorId",
                table: "Solicitacoes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Servidores_CargoId",
                table: "Servidores",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores");

            migrationBuilder.DropIndex(
                name: "IX_Servidores_CargoId",
                table: "Servidores");

            migrationBuilder.AlterColumn<int>(
                name: "AtendidoPorId",
                table: "Solicitacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servidores_CargoId",
                table: "Servidores",
                column: "CargoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
