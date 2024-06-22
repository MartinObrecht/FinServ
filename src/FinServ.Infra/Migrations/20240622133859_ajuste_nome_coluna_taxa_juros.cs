using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_nome_coluna_taxa_juros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxaJurosMes",
                table: "Produtos",
                newName: "TaxaJurosMensal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxaJurosMensal",
                table: "Produtos",
                newName: "TaxaJurosMes");
        }
    }
}
