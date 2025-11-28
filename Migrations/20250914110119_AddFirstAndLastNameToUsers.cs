using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstAndLastNameToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "ProfilePicture", "Role", "Username" },
                values: new object[] { 1, "System Address", "admin@example.com", "System", "Administrator", "$2a$11$kO9r5BVOcBPtou9FlmZw/uRPNSXovzk/Vth9rnMflnDrrEic/3lPS", "0000000000", null, "Admin", "admin" });
        }
    }
}
