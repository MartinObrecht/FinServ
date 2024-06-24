using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_tabela_ativo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorAtual",
                table: "Ativos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorAtual",
                table: "Ativos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
