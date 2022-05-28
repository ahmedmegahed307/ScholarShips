using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Update104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserInterestedPosting",
                newName: "UserInterestedPostings");

            migrationBuilder.AddColumn<bool>(
                name: "ISFunded",
                table: "UserInterestedPostings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserInterestedPostings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserInterestedPostings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quota",
                table: "UserInterestedPostings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "UserInterestedPostings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "UserInterestedPostings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UniversityName",
                table: "UserInterestedPostings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserInterestedPostings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISFunded",
                table: "UserInterestedPostings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserInterestedPostings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserInterestedPostings");

            migrationBuilder.DropColumn(
                name: "Quota",
                table: "UserInterestedPostings");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "UserInterestedPostings");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "UserInterestedPostings");

            migrationBuilder.DropColumn(
                name: "UniversityName",
                table: "UserInterestedPostings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserInterestedPostings");

            migrationBuilder.RenameTable(
                name: "UserInterestedPostings",
                newName: "UserInterestedPosting");
        }
    }
}
