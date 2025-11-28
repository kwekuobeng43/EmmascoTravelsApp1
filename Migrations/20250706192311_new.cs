using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Package for Tokyo. This is a nice package to fit your journey ", "/image1/packageimg.jpg", "Tokyo", 100m },
                    { 2, "This is package 2", "/image1/packageimg1.jpg", "Package 2", 200m },
                    { 3, "This is package 3", "/image1/packageimg2.jpg", "Package 3", 300m },
                    { 4, "Package for Tokyo", "/image1/packageimg.jpg", "Tokyo", 100m },
                    { 5, "This is package 2", "/image1/packageimg1.jpg", "Package 2", 200m },
                    { 6, "This is package 3", "/image1/packageimg2.jpg", "Package 3", 300m },
                    { 7, "Package for Tokyo", "/image1/packageimg.jpg", "Tokyo", 100m },
                    { 8, "This is package 2", "/image1/packageimg1.jpg", "Package 2", 200m },
                    { 9, "This is package 3", "/image1/packageimg2.jpg", "Package 3", 300m },
                    { 10, "Package for Tokyo", "/image1/packageimg.jpg", "Tokyo", 100m },
                    { 11, "This is package 2", "/image1/packageimg1.jpg", "Package 2", 200m },
                    { 12, "This is package 3", "/image1/packageimg2.jpg", "Package 3", 300m },
                    { 13, "Package for Tokyo", "/image1/packageimg.jpg", "Tokyo", 100m },
                    { 14, "This is package 2", "/image1/packageimg1.jpg", "Package 2", 200m },
                    { 15, "This is package 3", "/image1/packageimg2.jpg", "Package 3", 300m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
