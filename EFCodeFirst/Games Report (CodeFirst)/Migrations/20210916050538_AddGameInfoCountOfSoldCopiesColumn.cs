using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Games_Report__CodeFirst_.Migrations
{
    public partial class AddGameInfoCountOfSoldCopiesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfSoldCopies",
                table: "GameInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -3,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 8, 5, 38, 200, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -2,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 8, 5, 38, 200, DateTimeKind.Local).AddTicks(2902));

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -1,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 8, 5, 38, 198, DateTimeKind.Local).AddTicks(4940));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfSoldCopies",
                table: "GameInfos");

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -3,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 7, 50, 22, 388, DateTimeKind.Local).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -2,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 7, 50, 22, 388, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "GameInfos",
                keyColumn: "Id",
                keyValue: -1,
                column: "ReleaseDate",
                value: new DateTime(2021, 9, 16, 7, 50, 22, 386, DateTimeKind.Local).AddTicks(6917));
        }
    }
}
