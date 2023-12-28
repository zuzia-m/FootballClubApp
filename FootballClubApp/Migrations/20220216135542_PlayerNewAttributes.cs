using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballClubApp.Migrations
{
    public partial class PlayerNewAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Opponents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Opponents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Opponents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Opponents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<DateTime>(
                name: "ContractTo",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "MarketValue",
                table: "Players",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "WeeklyWage",
                table: "Players",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractTo",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MarketValue",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "WeeklyWage",
                table: "Players");

            migrationBuilder.InsertData(
                table: "Opponents",
                columns: new[] { "Id", "Competition", "TeamName" },
                values: new object[,]
                {
                    { 1, 1, "Real Madrid" },
                    { 2, 1, "Atletico Madrid" },
                    { 3, 4, "SSC Napoli" },
                    { 4, 1, "Athletic Bilbao" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FirstName", "IsCaptain", "LastName", "Number", "Position" },
                values: new object[,]
                {
                    { 1, "Ansu", false, "Fati", "10", 4 },
                    { 2, "Gerard", false, "Piqué", "3", 2 },
                    { 3, "Marc-André", false, "ter Stegen", "1", 1 },
                    { 4, "Pablo", false, "Gavi", "30", 3 },
                    { 5, "Sergio", true, "Busquets", "5", 3 },
                    { 6, "Nico", false, "Gonzalez", "14", 3 }
                });
        }
    }
}
