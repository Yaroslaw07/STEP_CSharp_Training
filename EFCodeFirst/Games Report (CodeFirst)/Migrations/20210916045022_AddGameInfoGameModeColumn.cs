using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Games_Report__CodeFirst_.Migrations
{
    public partial class AddGameInfoGameModeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameMode",
                table: "GameInfos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "GameMode", "ReleaseDate" },
                values: new object[] { "single", new DateTime(2021, 9, 16, 7, 50, 22, 388, DateTimeKind.Local).AddTicks(5263) });

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "GameMode", "ReleaseDate" },
                values: new object[] { "single", new DateTime(2021, 9, 16, 7, 50, 22, 388, DateTimeKind.Local).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "GameMode", "ReleaseDate" },
                values: new object[] { "single", new DateTime(2021, 9, 16, 7, 50, 22, 386, DateTimeKind.Local).AddTicks(6917) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameMode",
                table: "GameInfos");

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -3,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 7, 49, 20, 695, DateTimeKind.Local).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -2,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 7, 49, 20, 695, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -1,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 7, 49, 20, 693, DateTimeKind.Local).AddTicks(4860));
        }
    }
}
