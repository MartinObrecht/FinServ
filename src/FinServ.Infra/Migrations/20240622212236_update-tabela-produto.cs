using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class updatetabelaproduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Produtos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Produtos");
        }
    }
}
