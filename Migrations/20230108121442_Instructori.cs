using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB.Migrations
{
    public partial class Instructori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instructor",
                table: "Sport");

            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "Sport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instructor_1",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varsta = table.Column<int>(type: "int", nullable: false),
                    Experienta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor_1", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sport_InstructorID",
                table: "Sport",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sport_Instructor_1_InstructorID",
                table: "Sport",
                column: "InstructorID",
                principalTable: "Instructor_1",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sport_Instructor_1_InstructorID",
                table: "Sport");

            migrationBuilder.DropTable(
                name: "Instructor_1");

            migrationBuilder.DropIndex(
                name: "IX_Sport_InstructorID",
                table: "Sport");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Sport");

            migrationBuilder.AddColumn<string>(
                name: "Instructor",
                table: "Sport",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
