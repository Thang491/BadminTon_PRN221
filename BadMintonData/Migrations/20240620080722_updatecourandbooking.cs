using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadMintonData.Migrations
{
    public partial class updatecourandbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Court",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BadmintonNet",
                table: "Court",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descrip",
                table: "Court",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Court",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seats",
                table: "Court",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Court",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Booking",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Booking",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Booking",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Booking",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Booking",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "BadmintonNet",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "Descrip",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Booking");
        }
    }
}
