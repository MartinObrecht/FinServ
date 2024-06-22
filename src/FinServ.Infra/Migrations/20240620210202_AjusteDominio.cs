using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosFinanceiros_ContasInvestimento_ContaInvestimentoId",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropIndex(
                name: "IX_ProdutosFinanceiros_ContaInvestimentoId",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropColumn(
                name: "ContaInvestimentoId",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropColumn(
                name: "DataInvestimento",
                table: "ProdutosFinanceiros");

            migrationBuilder.DropColumn(
                name: "ValorInvestido",
                table: "ProdutosFinanceiros");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ProdutosFinanceiros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CarteiraInvestimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteiraInvestimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarteiraInvestimento_ContasInvestimento_ContaId",
                        column: x => x.ContaId,
                        principalTable: "ContasInvestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ativo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorCompra = table.Column<double>(type: "double(18,2)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoFinanceiroId = table.Column<int>(type: "int", nullable: false),
                    CarteiraInvestimentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivoFinanceiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtivoFinanceiro_CarteiraInvestimento_CarteiraInvestimentoId",
                        column: x => x.CarteiraInvestimentoId,
                        principalTable: "CarteiraInvestimento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AtivoFinanceiro_ProdutosFinanceiros_ProdutoFinanceiroId",
                        column: x => x.ProdutoFinanceiroId,
                        principalTable: "ProdutosFinanceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtivoFinanceiro_CarteiraInvestimentoId",
                table: "Ativo",
                column: "CarteiraInvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtivoFinanceiro_ProdutoFinanceiroId",
                table: "Ativo",
                column: "ProdutoFinanceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraInvestimento_ContaId",
                table: "CarteiraInvestimento",
                column: "ContaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ativo");

            migrationBuilder.DropTable(
                name: "CarteiraInvestimento");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ProdutosFinanceiros");

            migrationBuilder.AddColumn<int>(
                name: "ContaInvestimentoId",
                table: "ProdutosFinanceiros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInvestimento",
                table: "ProdutosFinanceiros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "ValorInvestido",
                table: "ProdutosFinanceiros",
                type: "double(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFinanceiros_ContaInvestimentoId",
                table: "ProdutosFinanceiros",
                column: "ContaInvestimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosFinanceiros_ContasInvestimento_ContaInvestimentoId",
                table: "ProdutosFinanceiros",
                column: "ContaInvestimentoId",
                principalTable: "ContasInvestimento",
                principalColumn: "Id");
        }
    }
}
