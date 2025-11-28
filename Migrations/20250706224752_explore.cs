using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class explore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Beautiful exploration and extraodinary people to meet and connect, vibe, believe and trust us with you little step");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Beautiful explotation and extraodinary people to meet and connect, vibe, believe and trust us with you little step");
        }
    }
}
