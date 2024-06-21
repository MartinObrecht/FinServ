using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDominioV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TiposProdutoFinanceiro_CodigoProdutoFinanceiro",
                table: "TiposProdutoFinanceiro",
                column: "CodigoProdutoFinanceiro",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TiposProdutoFinanceiro_CodigoProdutoFinanceiro",
                table: "TiposProdutoFinanceiro");
        }
    }
}
