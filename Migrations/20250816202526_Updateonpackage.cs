using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class Updateonpackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PackageId",
                table: "Bookings",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Packages_PackageId",
                table: "Bookings",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Packages_PackageId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PackageId",
                table: "Bookings");
        }
    }
}
