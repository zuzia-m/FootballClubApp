using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballClubApp.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Opponents",
                columns: new[] { "Id", "Competition", "TeamName" },
                values: new object[,]
                {
                    { 1, 1, "Real Madrid" },
                    { 2, 1, "Atletico Madrid" },
                    { 3, 3, "SSC Napoli" }
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
                    { 5, "Sergio", true, "Busquets", "5", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}