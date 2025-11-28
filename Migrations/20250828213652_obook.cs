using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmmascoTravelsApp1.Migrations
{
    /// <inheritdoc />
    public partial class obook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Bookings",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Bookings",
                newName: "CustomerEmail");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Bookings",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "Bookings",
                newName: "Nationality");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
