using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class linecorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Inquire in Barbados's breeze, exceptional cultures, customs to see more, feel more, and know around the world.");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Beautiful explotation and extraodinary people to meet and connect, vibe, believe and trust us with you little step");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Explore Cairo with us to feels life's beauty, wonderful landscapes and their authentic city vibe they give");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Get to know more about Finland and get to the history of their customs, values and landscapes with our team ");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Unforgettable memories you will get, explore the beauty of Switzerland and hikings etc book with us to see");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Get to know more about Finland and get to the history of their customs and values");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Unforgettable memories, explore the beauty of Switzerland ");
        }
    }
}
