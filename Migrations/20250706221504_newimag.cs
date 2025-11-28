using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class newimag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Package for Tokyo. This is a nice package to fit your journey, book and get started with our team", 1700m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Customized Itenaries that you would match your prference", "Personal Trip", -1200m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Rich blend of historical landmarks, cultural experiences, and scenic landscapes", "/image1/UK.jpg", "United Kingdom", 4100m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Inquire in Barbados's breeze, culture, customs", "Barbados", 3000m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Habibi come to Dubai, get the best experience in Dubai", "Dubai", 1800m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Beautiful explotation and extraodinary people to meet and connect vibe", "Bern", 1070m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Explore Cairo with us", "Egypt", 2200m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Get a best of Mumbai with Emmasco Team, the coastals, cultures etc path with us to superb adventures", "India", 800m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Looking for family?? no worries we're here for you, look our awesome customized itenaries to enjoy lifetime moments with your family", "Family Trip (Customized)", 1900m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Enjoy our amazing full packages we offer to suit your needs", "Full Package", 2000m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Get to know more about Finland and get to the history of their customs and values", "/image1/FINLANDO.jpg", "Finland", 500m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Unforgettable memories, explore the beauty of Switzerland ", "/image1/packaGE201.jpg", "Switzerland", 6500m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Enjoy the breathtaking and the best moments in Melbourne", "/image1/broaustra.jpg", "Australia", 1500m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "A trip to explore the coastal and the excitement in Ontario, Canada", "/image1/canada0000.jpg", "Canada", 1000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Package for Tokyo. This is a nice package to fit your journey ", 100m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "This is package 2", "Package 2", 200m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Package for Tokyo", "/image1/packageimg.jpg", "Tokyo", 100m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "This is package 2", "Package 2", 200m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "This is package 3", "Package 3", 300m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Package for Tokyo", "Tokyo", 100m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "This is package 2", "Package 2", 200m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "This is package 3", "Package 3", 300m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Package for Tokyo", "Tokyo", 100m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "This is package 2", "Package 2", 200m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "This is package 3", "/image1/packageimg2.jpg", "Package 3", 300m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "Package for Tokyo", "/image1/packageimg.jpg", "Tokyo", 100m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "This is package 2", "/image1/packageimg1.jpg", "Package 2", 200m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "This is package 3", "/image1/packageimg2.jpg", "Package 3", 300m });
        }
    }
}
