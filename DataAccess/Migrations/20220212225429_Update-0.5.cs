using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Update05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CvId",
                table: "Applies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applies_CvId",
                table: "Applies",
                column: "CvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applies_CVs_CvId",
                table: "Applies",
                column: "CvId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applies_CVs_CvId",
                table: "Applies");

            migrationBuilder.DropIndex(
                name: "IX_Applies_CvId",
                table: "Applies");

            migrationBuilder.DropColumn(
                name: "CvId",
                table: "Applies");
        }
    }
}
