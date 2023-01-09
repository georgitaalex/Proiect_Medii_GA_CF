using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB.Migrations
{
    public partial class CategorieSport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Sport");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Sport",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Durata",
                table: "Sport",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieSport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieSport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieSport_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieSport_Sport_SportID",
                        column: x => x.SportID,
                        principalTable: "Sport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieSport_CategorieID",
                table: "CategorieSport",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieSport_SportID",
                table: "CategorieSport",
                column: "SportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieSport");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Sport",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Durata",
                table: "Sport",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Sport",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
