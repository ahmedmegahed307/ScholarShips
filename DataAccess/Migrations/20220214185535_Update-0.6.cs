using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Update06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postings_Disciplines_DiciplineId",
                table: "Postings");

            migrationBuilder.RenameColumn(
                name: "DiciplineId",
                table: "Postings",
                newName: "DisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Postings_DiciplineId",
                table: "Postings",
                newName: "IX_Postings_DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postings_Disciplines_DisciplineId",
                table: "Postings",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postings_Disciplines_DisciplineId",
                table: "Postings");

            migrationBuilder.RenameColumn(
                name: "DisciplineId",
                table: "Postings",
                newName: "DiciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Postings_DisciplineId",
                table: "Postings",
                newName: "IX_Postings_DiciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postings_Disciplines_DiciplineId",
                table: "Postings",
                column: "DiciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
