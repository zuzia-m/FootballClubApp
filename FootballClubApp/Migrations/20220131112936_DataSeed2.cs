using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballClubApp.Migrations
{
    public partial class DataSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Opponents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Competition",
                value: 4);

            migrationBuilder.InsertData(
                table: "Opponents",
                columns: new[] { "Id", "Competition", "TeamName" },
                values: new object[] { 4, 1, "Athletic Bilbao" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FirstName", "IsCaptain", "LastName", "Number", "Position" },
                values: new object[] { 6, "Nico", false, "Gonzalez", "14", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Opponents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Opponents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Competition",
                value: 3);
        }
    }
}