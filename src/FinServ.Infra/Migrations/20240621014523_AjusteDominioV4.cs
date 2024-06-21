﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDominioV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosFinanceiros_TiposProdutoFinanceiro_TipoId",
                table: "ProdutosFinanceiros");

            migrationBuilder.RenameColumn(
                name: "TipoId",
                table: "ProdutosFinanceiros",
                newName: "TipoProdutoFinanceiroId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosFinanceiros_TipoId",
                table: "ProdutosFinanceiros",
                newName: "IX_ProdutosFinanceiros_TipoProdutoFinanceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosFinanceiros_TiposProdutoFinanceiro_TipoProdutoFinanceiroId",
                table: "ProdutosFinanceiros",
                column: "TipoProdutoFinanceiroId",
                principalTable: "TiposProdutoFinanceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosFinanceiros_TiposProdutoFinanceiro_TipoProdutoFinanceiroId",
                table: "ProdutosFinanceiros");

            migrationBuilder.RenameColumn(
                name: "TipoProdutoFinanceiroId",
                table: "ProdutosFinanceiros",
                newName: "TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosFinanceiros_TipoProdutoFinanceiroId",
                table: "ProdutosFinanceiros",
                newName: "IX_ProdutosFinanceiros_TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosFinanceiros_TiposProdutoFinanceiro_TipoId",
                table: "ProdutosFinanceiros",
                column: "TipoId",
                principalTable: "TiposProdutoFinanceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
