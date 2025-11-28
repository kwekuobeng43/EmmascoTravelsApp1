using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/image1/packageimg5.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/image1/packageimg10.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/image1/packageimg4.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/image1/packageimg11.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/image1/packageimg6.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/image1/package.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/image1/packageimg3.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/image1/packageimg1.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/image1/packageimg2.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/image1/packageimg.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/image1/packageimg1.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "/image1/packageimg2.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/image1/packageimg.jpg");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "/image1/packageimg1.jpg");
        }
    }
}
