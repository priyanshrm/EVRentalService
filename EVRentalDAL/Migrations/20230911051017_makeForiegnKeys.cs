using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVRentalDAL.Migrations
{
    public partial class makeForiegnKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EVvehicleId",
                table: "booking",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_booking_EVvehicleId",
                table: "booking",
                column: "EVvehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_userId",
                table: "booking",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_ev_EVvehicleId",
                table: "booking",
                column: "EVvehicleId",
                principalTable: "ev",
                principalColumn: "vehicleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_booking_user_userId",
                table: "booking",
                column: "userId",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_ev_EVvehicleId",
                table: "booking");

            migrationBuilder.DropForeignKey(
                name: "FK_booking_user_userId",
                table: "booking");

            migrationBuilder.DropIndex(
                name: "IX_booking_EVvehicleId",
                table: "booking");

            migrationBuilder.DropIndex(
                name: "IX_booking_userId",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "EVvehicleId",
                table: "booking");
        }
    }
}
