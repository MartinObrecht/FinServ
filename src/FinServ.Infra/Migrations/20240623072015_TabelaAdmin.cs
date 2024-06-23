using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TabelaAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoAcesso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Email_CodigoAcesso",
                table: "Administradores",
                columns: new[] { "Email", "CodigoAcesso" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");
        }
    }
}
