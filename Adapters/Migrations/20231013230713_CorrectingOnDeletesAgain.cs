using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingOnDeletesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Solicitacoes_SolicitacaoId",
                table: "Chamados");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacoes_Cidadoes_AutorId",
                table: "Reclamacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacoes_Secretarias_DestinoId",
                table: "Reclamacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_Secretarias_SecretariaId",
                table: "Solicitacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_Servidores_AtendidoPorId",
                table: "Solicitacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_Users_SolicitadoPorId",
                table: "Solicitacoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Solicitacoes_SolicitacaoId",
                table: "Chamados",
                column: "SolicitacaoId",
                principalTable: "Solicitacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacoes_Cidadoes_AutorId",
                table: "Reclamacoes",
                column: "AutorId",
                principalTable: "Cidadoes",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacoes_Secretarias_DestinoId",
                table: "Reclamacoes",
                column: "DestinoId",
                principalTable: "Secretarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_Secretarias_SecretariaId",
                table: "Solicitacoes",
                column: "SecretariaId",
                principalTable: "Secretarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_Servidores_AtendidoPorId",
                table: "Solicitacoes",
                column: "AtendidoPorId",
                principalTable: "Servidores",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_Users_SolicitadoPorId",
                table: "Solicitacoes",
                column: "SolicitadoPorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Solicitacoes_SolicitacaoId",
                table: "Chamados");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacoes_Cidadoes_AutorId",
                table: "Reclamacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamacoes_Secretarias_DestinoId",
                table: "Reclamacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_Secretarias_SecretariaId",
                table: "Solicitacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_Servidores_AtendidoPorId",
                table: "Solicitacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacoes_Users_SolicitadoPorId",
                table: "Solicitacoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Solicitacoes_SolicitacaoId",
                table: "Chamados",
                column: "SolicitacaoId",
                principalTable: "Solicitacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacoes_Cidadoes_AutorId",
                table: "Reclamacoes",
                column: "AutorId",
                principalTable: "Cidadoes",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamacoes_Secretarias_DestinoId",
                table: "Reclamacoes",
                column: "DestinoId",
                principalTable: "Secretarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Cargos_CargoId",
                table: "Servidores",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_Secretarias_SecretariaId",
                table: "Solicitacoes",
                column: "SecretariaId",
                principalTable: "Secretarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_Servidores_AtendidoPorId",
                table: "Solicitacoes",
                column: "AtendidoPorId",
                principalTable: "Servidores",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacoes_Users_SolicitadoPorId",
                table: "Solicitacoes",
                column: "SolicitadoPorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
