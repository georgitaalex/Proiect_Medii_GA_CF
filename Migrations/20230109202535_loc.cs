using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB.Migrations
{
    public partial class loc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locatie",
                table: "Sport");

            migrationBuilder.AddColumn<int>(
                name: "LocatieID",
                table: "Sport",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "Instructor_1",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locatie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeSala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sport_LocatieID",
                table: "Sport",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_1_InstructorID",
                table: "Instructor_1",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_1_Instructor_1_InstructorID",
                table: "Instructor_1",
                column: "InstructorID",
                principalTable: "Instructor_1",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sport_Locatie_LocatieID",
                table: "Sport",
                column: "LocatieID",
                principalTable: "Locatie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_1_Instructor_1_InstructorID",
                table: "Instructor_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Sport_Locatie_LocatieID",
                table: "Sport");

            migrationBuilder.DropTable(
                name: "Locatie");

            migrationBuilder.DropIndex(
                name: "IX_Sport_LocatieID",
                table: "Sport");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_1_InstructorID",
                table: "Instructor_1");

            migrationBuilder.DropColumn(
                name: "LocatieID",
                table: "Sport");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Instructor_1");

            migrationBuilder.AddColumn<string>(
                name: "Locatie",
                table: "Sport",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
