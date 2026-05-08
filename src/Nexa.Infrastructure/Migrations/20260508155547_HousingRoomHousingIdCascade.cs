using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HousingRoomHousingIdCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_housing_room_housing_HousingId",
                table: "housing_room");

            migrationBuilder.AddForeignKey(
                name: "FK_housing_room_housing_HousingId",
                table: "housing_room",
                column: "HousingId",
                principalTable: "housing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_housing_room_housing_HousingId",
                table: "housing_room");

            migrationBuilder.AddForeignKey(
                name: "FK_housing_room_housing_HousingId",
                table: "housing_room",
                column: "HousingId",
                principalTable: "housing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
