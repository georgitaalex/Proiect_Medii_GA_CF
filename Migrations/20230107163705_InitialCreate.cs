using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeSport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durata = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sport");
        }
    }
}
