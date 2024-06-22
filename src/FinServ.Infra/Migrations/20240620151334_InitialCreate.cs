using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposProdutoFinanceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProdutoFinanceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasInvestimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestidorId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<double>(type: "double(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasInvestimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasInvestimento_Investidores_InvestidorId",
                        column: x => x.InvestidorId,
                        principalTable: "Investidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosFinanceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    ValorInvestido = table.Column<double>(type: "double(18,2)", nullable: false),
                    TaxaJurosMes = table.Column<double>(type: "double(18,2)", nullable: false),
                    DataInvestimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaInvestimentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosFinanceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosFinanceiros_ContasInvestimento_ContaInvestimentoId",
                        column: x => x.ContaInvestimentoId,
                        principalTable: "ContasInvestimento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdutosFinanceiros_TiposProdutoFinanceiro_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TiposProdutoFinanceiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasInvestimento_InvestidorId",
                table: "ContasInvestimento",
                column: "InvestidorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFinanceiros_ContaInvestimentoId",
                table: "ProdutosFinanceiros",
                column: "ContaInvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFinanceiros_TipoId",
                table: "ProdutosFinanceiros",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosFinanceiros");

            migrationBuilder.DropTable(
                name: "ContasInvestimento");

            migrationBuilder.DropTable(
                name: "TiposProdutoFinanceiro");

            migrationBuilder.DropTable(
                name: "Investidores");
        }
    }
}
