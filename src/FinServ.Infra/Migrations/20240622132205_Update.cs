using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtivosFinanceiros");

            migrationBuilder.DropTable(
                name: "ProdutosFinanceiros");

            migrationBuilder.DropTable(
                name: "TiposProdutoFinanceiro");

            migrationBuilder.AlterColumn<double>(
                name: "Saldo",
                table: "ContasInvestimento",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(18,2)");

            migrationBuilder.CreateTable(
                name: "TiposProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxaJurosMes = table.Column<double>(type: "float", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_TiposProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TiposProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorCompra = table.Column<double>(type: "float", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    CarteiraInvestimentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ativos_CarteirasInvestimento_CarteiraInvestimentoId",
                        column: x => x.CarteiraInvestimentoId,
                        principalTable: "CarteirasInvestimento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ativos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_CarteiraInvestimentoId",
                table: "Ativos",
                column: "CarteiraInvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_ProdutoId",
                table: "Ativos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TipoProdutoId",
                table: "Produtos",
                column: "TipoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProduto_CodigoProduto",
                table: "TiposProduto",
                column: "CodigoProduto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "TiposProduto");

            migrationBuilder.AlterColumn<double>(
                name: "Saldo",
                table: "ContasInvestimento",
                type: "double(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "TiposProdutoFinanceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProduto = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProdutoFinanceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosFinanceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxaJurosMes = table.Column<double>(type: "double(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosFinanceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosFinanceiros_TiposProdutoFinanceiro_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TiposProdutoFinanceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtivosFinanceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoFinanceiroId = table.Column<int>(type: "int", nullable: false),
                    CarteiraInvestimentoId = table.Column<int>(type: "int", nullable: true),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorCompra = table.Column<double>(type: "double(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivosFinanceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtivosFinanceiros_CarteirasInvestimento_CarteiraInvestimentoId",
                        column: x => x.CarteiraInvestimentoId,
                        principalTable: "CarteirasInvestimento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AtivosFinanceiros_ProdutosFinanceiros_ProdutoFinanceiroId",
                        column: x => x.ProdutoFinanceiroId,
                        principalTable: "ProdutosFinanceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtivosFinanceiros_CarteiraInvestimentoId",
                table: "AtivosFinanceiros",
                column: "CarteiraInvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtivosFinanceiros_ProdutoFinanceiroId",
                table: "AtivosFinanceiros",
                column: "ProdutoFinanceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFinanceiros_TipoProdutoId",
                table: "ProdutosFinanceiros",
                column: "TipoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposProdutoFinanceiro_CodigoProduto",
                table: "TiposProdutoFinanceiro",
                column: "CodigoProduto",
                unique: true);
        }
    }
}
