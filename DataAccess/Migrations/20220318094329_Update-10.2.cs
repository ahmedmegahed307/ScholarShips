using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Update102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterestedPosting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInterestedPosting",
                columns: table => new
                {
                    ApplyCount = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<long>(type: "bigint", nullable: false),
                    CVPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVPath2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvId = table.Column<int>(type: "int", nullable: false),
                    CvId2 = table.Column<int>(type: "int", nullable: false),
                    CvPathName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvPathName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    DisciplineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FundingFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    ISFunded = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ImagePathId = table.Column<int>(type: "int", nullable: false),
                    PostingImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostingTypeId = table.Column<int>(type: "int", nullable: false),
                    Quota = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    TitleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    İmage4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
