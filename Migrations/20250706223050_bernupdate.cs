using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class bernupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 2080m);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Inquire in Barbados's breeze, culture, customs to see more and feel more.");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Beautiful explotation and extraodinary people to meet and connect, vibe, believe and trust");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Explore Cairo with us and feels life's beauty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: -1200m);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Inquire in Barbados's breeze, culture, customs");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Beautiful explotation and extraodinary people to meet and connect vibe");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Explore Cairo with us");
        }
    }
}
