using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Update101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInterestedPosting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    PostingTypeId = table.Column<int>(type: "int", nullable: false),
                    ImagePathId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CvId = table.Column<int>(type: "int", nullable: false),
                    CvId2 = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvPathName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvPathName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVPath2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyCount = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<long>(type: "bigint", nullable: false),
                    Quota = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISFunded = table.Column<bool>(type: "bit", nullable: false),
                    FundingFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    PostingImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisciplineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
