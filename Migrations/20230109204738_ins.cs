using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB.Migrations
{
    public partial class ins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_1_Instructor_1_InstructorID",
                table: "Instructor_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Sport_Instructor_1_InstructorID",
                table: "Sport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor_1",
                table: "Instructor_1");

            migrationBuilder.RenameTable(
                name: "Instructor_1",
                newName: "Instructor");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_1_InstructorID",
                table: "Instructor",
                newName: "IX_Instructor_InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Instructor_InstructorID",
                table: "Instructor",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sport_Instructor_InstructorID",
                table: "Sport",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Instructor_InstructorID",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Sport_Instructor_InstructorID",
                table: "Sport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructor_1");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_InstructorID",
                table: "Instructor_1",
                newName: "IX_Instructor_1_InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor_1",
                table: "Instructor_1",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_1_Instructor_1_InstructorID",
                table: "Instructor_1",
                column: "InstructorID",
                principalTable: "Instructor_1",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sport_Instructor_1_InstructorID",
                table: "Sport",
                column: "InstructorID",
                principalTable: "Instructor_1",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
