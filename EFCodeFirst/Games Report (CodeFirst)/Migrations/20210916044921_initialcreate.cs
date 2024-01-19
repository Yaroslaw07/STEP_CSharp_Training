using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Games_Report__CodeFirst_.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Style = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameInfos",
                columns: new[] { "Id", "Creator", "ReleaseDate", "Style", "Title" },
                values: new object[] { -1, "PCF", new DateTime(2021, 9, 16, 7, 49, 20, 693, DateTimeKind.Local).AddTicks(4860), "RPG", "12" });

            migrationBuilder.InsertData(
                table: "GameInfos",
                columns: new[] { "Id", "Creator", "ReleaseDate", "Style", "Title" },
                values: new object[] { -2, "Bioware", new DateTime(2021, 9, 16, 7, 49, 20, 695, DateTimeKind.Local).AddTicks(4154), "Shooter", "1676" });

            migrationBuilder.InsertData(
                table: "GameInfos",
                columns: new[] { "Id", "Creator", "ReleaseDate", "Style", "Title" },
                values: new object[] { -3, "P56", new DateTime(2021, 9, 16, 7, 49, 20, 695, DateTimeKind.Local).AddTicks(4218), "R12", "121" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameInfos");
        }
    }
}
