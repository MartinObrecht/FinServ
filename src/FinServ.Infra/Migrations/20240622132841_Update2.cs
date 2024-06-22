using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinServ.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativos_CarteirasInvestimento_CarteiraInvestimentoId",
                table: "Ativos");

            migrationBuilder.DropTable(
                name: "CarteirasInvestimento");

            migrationBuilder.DropTable(
                name: "ContasInvestimento");

            migrationBuilder.RenameColumn(
                name: "CarteiraInvestimentoId",
                table: "Ativos",
                newName: "CarteiraId");

            migrationBuilder.RenameIndex(
                name: "IX_Ativos_CarteiraInvestimentoId",
                table: "Ativos",
                newName: "IX_Ativos_CarteiraId");

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestidorId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Investidores_InvestidorId",
                        column: x => x.InvestidorId,
                        principalTable: "Investidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carteiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    AtivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carteiras_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteiras_ContaId",
                table: "Carteiras",
                column: "ContaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_InvestidorId",
                table: "Contas",
                column: "InvestidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ativos_Carteiras_CarteiraId",
                table: "Ativos",
                column: "CarteiraId",
                principalTable: "Carteiras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativos_Carteiras_CarteiraId",
                table: "Ativos");

            migrationBuilder.DropTable(
                name: "Carteiras");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.RenameColumn(
                name: "CarteiraId",
                table: "Ativos",
                newName: "CarteiraInvestimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ativos_CarteiraId",
                table: "Ativos",
                newName: "IX_Ativos_CarteiraInvestimentoId");

            migrationBuilder.CreateTable(
                name: "ContasInvestimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestidorId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false)
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
                name: "CarteirasInvestimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    AtivoFinanceiroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteirasInvestimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarteirasInvestimento_ContasInvestimento_ContaId",
                        column: x => x.ContaId,
                        principalTable: "ContasInvestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarteirasInvestimento_ContaId",
                table: "CarteirasInvestimento",
                column: "ContaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContasInvestimento_InvestidorId",
                table: "ContasInvestimento",
                column: "InvestidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ativos_CarteirasInvestimento_CarteiraInvestimentoId",
                table: "Ativos",
                column: "CarteiraInvestimentoId",
                principalTable: "CarteirasInvestimento",
                principalColumn: "Id");
        }
    }
}
