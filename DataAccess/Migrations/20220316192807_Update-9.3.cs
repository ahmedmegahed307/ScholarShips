using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Update93 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EmailConfirmeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmailConfirmeds_UserId",
                table: "EmailConfirmeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailConfirmeds_Users_UserId",
                table: "EmailConfirmeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailConfirmeds_Users_UserId",
                table: "EmailConfirmeds");

            migrationBuilder.DropIndex(
                name: "IX_EmailConfirmeds_UserId",
                table: "EmailConfirmeds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmailConfirmeds");
        }
    }
}
