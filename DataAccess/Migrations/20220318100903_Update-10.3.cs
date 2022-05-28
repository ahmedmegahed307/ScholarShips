using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Update103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInterestedPosting",
                columns: table => new
                {
                    Budget = table.Column<long>(type: "bigint", nullable: false),
                    FundingFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    DisciplineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterestedPosting");
        }
    }
}
