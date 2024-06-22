using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadMintonData.Migrations
{
    public partial class updatesixatributed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Court",
                columns: table => new
                {
                    CourtID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourtName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Court", x => x.CourtID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "CourtSlots",
                columns: table => new
                {
                    SlotID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourtID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlotStartTime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SlotEndTime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SlotPrice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourtSlo__0A124A4F7BDA49D5", x => x.SlotID);
                    table.ForeignKey(
                        name: "FK__CourtSlot__Court__5165187F",
                        column: x => x.CourtID,
                        principalTable: "Court",
                        principalColumn: "CourtID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourtID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlotID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BookingDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK__Bookings__CourtI__619B8048",
                        column: x => x.CourtID,
                        principalTable: "Court",
                        principalColumn: "CourtID");
                    table.ForeignKey(
                        name: "FK__Bookings__Custom__60A75C0F",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Bookings__SlotID__628FA481",
                        column: x => x.SlotID,
                        principalTable: "CourtSlots",
                        principalColumn: "SlotID");
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                columns: table => new
                {
                    BookingDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SlotID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourtID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => x.BookingDetailID);
                    table.ForeignKey(
                        name: "FK_BookingDetail_Booking",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID");
                    table.ForeignKey(
                        name: "FK_BookingDetail_CourtSlots",
                        column: x => x.SlotID,
                        principalTable: "CourtSlots",
                        principalColumn: "SlotID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CourtID",
                table: "Booking",
                column: "CourtID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerID",
                table: "Booking",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SlotID",
                table: "Booking",
                column: "SlotID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_BookingID",
                table: "BookingDetail",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_SlotID",
                table: "BookingDetail",
                column: "SlotID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtSlots_CourtID",
                table: "CourtSlots",
                column: "CourtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetail");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CourtSlots");

            migrationBuilder.DropTable(
                name: "Court");
        }
    }
}
