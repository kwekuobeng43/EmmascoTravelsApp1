using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class friendsupda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "China's diverse landscapes include stunning forests, ranging from ancient tropical rainforests to towering mountain forests.", "China", 2300m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Enjoy our amazing friendship packages that suit your needs of personalization", "Friendship Travel" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "This is package 3", "Package 3", 300m });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Enjoy our amazing full packages we offer to suit your needs", "Full Package" });
        }
    }
}
