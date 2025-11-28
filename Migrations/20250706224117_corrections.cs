using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class corrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Get the best of Mumbai with Emmasco Team, the coastals, cultures, and superb adventures");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Get to know more about Finland and get to the history of their customs, values and landscapes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Get a best of Mumbai with Emmasco Team, the coastals, cultures etc path with us to superb adventures");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Get to know more about Finland and get to the history of their customs, values and landscapes with our team ");
        }
    }
}
