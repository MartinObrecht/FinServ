using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDominioV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtivoFinanceiro_CarteiraInvestimento_CarteiraInvestimentoId",
                table: "AtivoFinanceiro");

            migrationBuilder.DropForeignKey(
                name: "FK_AtivoFinanceiro_ProdutosFinanceiros_ProdutoFinanceiroId",
                table: "AtivoFinanceiro");

            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraInvestimento_ContasInvestimento_ContaId",
                table: "CarteiraInvestimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarteiraInvestimento",
                table: "CarteiraInvestimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtivoFinanceiro",
                table: "AtivoFinanceiro");

            migrationBuilder.RenameTable(
                name: "CarteiraInvestimento",
                newName: "CarteirasInvestimento");

            migrationBuilder.RenameTable(
                name: "AtivoFinanceiro",
                newName: "AtivosFinanceiros");

            migrationBuilder.RenameIndex(
                name: "IX_CarteiraInvestimento_ContaId",
                table: "CarteirasInvestimento",
                newName: "IX_CarteirasInvestimento_ContaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtivoFinanceiro_ProdutoFinanceiroId",
                table: "AtivosFinanceiros",
                newName: "IX_AtivosFinanceiros_ProdutoFinanceiroId");

            migrationBuilder.RenameIndex(
                name: "IX_AtivoFinanceiro_CarteiraInvestimentoId",
                table: "AtivosFinanceiros",
                newName: "IX_AtivosFinanceiros_CarteiraInvestimentoId");

            migrationBuilder.AddColumn<int>(
                name: "CodigoProdutoFinanceiro",
                table: "TiposProdutoFinanceiro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoProdutoId",
                table: "ProdutosFinanceiros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarteirasInvestimento",
                table: "CarteirasInvestimento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtivosFinanceiros",
                table: "AtivosFinanceiros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtivosFinanceiros_CarteirasInvestimento_CarteiraInvestimentoId",
                table: "AtivosFinanceiros",
                column: "CarteiraInvestimentoId",
                principalTable: "CarteirasInvestimento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtivosFinanceiros_ProdutosFinanceiros_ProdutoFinanceiroId",
                table: "AtivosFinanceiros",
                column: "ProdutoFinanceiroId",
                principalTable: "ProdutosFinanceiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarteirasInvestimento_ContasInvestimento_ContaId",
                table: "CarteirasInvestimento",
                column: "ContaId",
                principalTable: "ContasInvestimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtivosFinanceiros_CarteirasInvestimento_CarteiraInvestimentoId",
                table: "AtivosFinanceiros");

            migrationBuilder.DropForeignKey(
                name: "FK_AtivosFinanceiros_ProdutosFinanceiros_ProdutoFinanceiroId",
                table: "AtivosFinanceiros");

            migrationBuilder.DropForeignKey(
                name: "FK_CarteirasInvestimento_ContasInvestimento_ContaId",
                table: "CarteirasInvestimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarteirasInvestimento",
                table: "CarteirasInvestimento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtivosFinanceiros",
                table: "AtivosFinanceiros");

            migrationBuilder.DropColumn(
                name: "CodigoProdutoFinanceiro",
                table: "TiposProdutoFinanceiro");

            migrationBuilder.DropColumn(
                name: "TipoProdutoId",
                table: "ProdutosFinanceiros");

            migrationBuilder.RenameTable(
                name: "CarteirasInvestimento",
                newName: "CarteiraInvestimento");

            migrationBuilder.RenameTable(
                name: "AtivosFinanceiros",
                newName: "AtivoFinanceiro");

            migrationBuilder.RenameIndex(
                name: "IX_CarteirasInvestimento_ContaId",
                table: "CarteiraInvestimento",
                newName: "IX_CarteiraInvestimento_ContaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtivosFinanceiros_ProdutoFinanceiroId",
                table: "AtivoFinanceiro",
                newName: "IX_AtivoFinanceiro_ProdutoFinanceiroId");

            migrationBuilder.RenameIndex(
                name: "IX_AtivosFinanceiros_CarteiraInvestimentoId",
                table: "AtivoFinanceiro",
                newName: "IX_AtivoFinanceiro_CarteiraInvestimentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarteiraInvestimento",
                table: "CarteiraInvestimento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtivoFinanceiro",
                table: "AtivoFinanceiro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtivoFinanceiro_CarteiraInvestimento_CarteiraInvestimentoId",
                table: "AtivoFinanceiro",
                column: "CarteiraInvestimentoId",
                principalTable: "CarteiraInvestimento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtivoFinanceiro_ProdutosFinanceiros_ProdutoFinanceiroId",
                table: "AtivoFinanceiro",
                column: "ProdutoFinanceiroId",
                principalTable: "ProdutosFinanceiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraInvestimento_ContasInvestimento_ContaId",
                table: "CarteiraInvestimento",
                column: "ContaId",
                principalTable: "ContasInvestimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
