using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddPackageDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accommodation",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Activities",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meals",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transport",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Transport" },
                values: new object[] { "4-Star Hotel", "Tokyo Tower, Shibuya Crossing, Mt. Fuji Tour", "Japan", "7 Days, 6 Nights", "Breakfast Included", "Flight + Bullet Train" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Transport" },
                values: new object[] { "Customizable", "Custom itinerary, Personalized tours", "Worldwide", "Flexible", "Optional", "Flexible Options" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Name", "Transport" },
                values: new object[] { "3-Star Hotel", "Great Wall, Forbidden City, Shanghai Tour", "China", "8 Days, 7 Nights", "Breakfast + Lunch", "Beijing", "Flight + High-speed Train" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Name", "Transport" },
                values: new object[] { "4-Star Hotel", "London Eye, Buckingham Palace, Stonehenge", "United Kingdom", "10 Days, 9 Nights", "Breakfast", "London", "Flight + Train" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Name", "Transport" },
                values: new object[] { "Resort", "Beaches, Island Tour, Snorkeling", "Barbados", "6 Days, 5 Nights", "All Inclusive", "Bridgetown", "Flight + Local Transport" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Transport" },
                values: new object[] { "Luxury Hotel", "Burj Khalifa, Desert Safari, Shopping Tour", "UAE", "5 Days, 4 Nights", "Breakfast + Dinner", "Flight + Private Car" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Transport" },
                values: new object[] { "3-Star Hotel", "City Tour, Old Town, Zytglogge Clock Tower", "Switzerland", "4 Days, 3 Nights", "Breakfast", "Flight + Train" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Name", "Transport" },
                values: new object[] { "4-Star Hotel", "Pyramids of Giza, Nile Cruise, Egyptian Museum", "Egypt", "7 Days, 6 Nights", "Breakfast + Dinner", "Cairo", "Flight + Local Bus" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Accommodation", "Activities", "Country", "Description", "Duration", "Meals", "Name", "Transport" },
                values: new object[] { "3-Star Hotel", "Gateway of India, Taj Mahal, Bollywood Tour", "India", "Get the best of New Delhi, Mumbai with Emmasco Team, the coastals, cultures, and superb adventures", "6 Days, 5 Nights", "Breakfast + Lunch", "New Delhi", "Flight + Train" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Transport" },
                values: new object[] { "Family Suites / Villas", "Theme Parks, Family Adventures, Museums", "Worldwide", "Flexible", "Customizable", "Flight + Private Van" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Transport" },
                values: new object[] { "Shared Apartments / Hotels", "Nightlife, Beaches, Hiking", "Various Destinations", "5 Days, 4 Nights", "Breakfast + Drinks", "Flight + Local Bus" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Name", "Transport" },
                values: new object[] { "3-Star Hotel", "Northern Lights, Helsinki Tour, Snow Activities", "Finland", "5 Days, 4 Nights", "Breakfast", "Helsinki", "Flight + Train" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Accommodation", "Activities", "Country", "Description", "Duration", "ImageUrl", "Meals", "Name", "Transport" },
                values: new object[] { "Luxury Hotel", "Alps Hiking, Lake Alpsee, Rhine Valley Tour", "Germany", "Unforgettable memories you will get, explore the beauty of Berlin and hikings etc book with us to see", "8 Days, 7 Nights", "/image1/germanyapp.jpg", "Breakfast + Dinner", "Berlin", "Flight + Train" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Name", "Transport" },
                values: new object[] { "4-Star Hotel", "Sydney Opera House, Great Barrier Reef, Melbourne Tour", "Australia", "7 Days, 6 Nights", "Breakfast", "Canberra", "Flight + Car Rental" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Accommodation", "Activities", "Country", "Duration", "Meals", "Name", "Transport" },
                values: new object[] { "3-Star Hotel", "Niagara Falls, Toronto CN Tower, National Parks", "Canada", "6 Days, 5 Nights", "Breakfast", "Toronto", "Flight + Train" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Activities",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Meals",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "Packages");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "China");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "United Kingdom");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Barbados");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Egypt");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Get the best of Mumbai with Emmasco Team, the coastals, cultures, and superb adventures", "India" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Finland");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Unforgettable memories you will get, explore the beauty of Switzerland and hikings etc book with us to see", "/image1/packaGE201.jpg", "Switzerland" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Australia");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Canada");
        }
    }
}
