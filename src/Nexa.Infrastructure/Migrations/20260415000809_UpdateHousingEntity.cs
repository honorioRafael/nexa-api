using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHousingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "housing");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "housing");

            // Rename Status -> HousingStatus (preserving existing data)
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "housing",
                newName: "HousingStatus");

            // Add new HousingType column
            migrationBuilder.AddColumn<int>(
                name: "HousingType",
                table: "housing",
                type: "integer",
                nullable: false,
                defaultValue: 3); // Mixed as default
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HousingType",
                table: "housing");

            migrationBuilder.RenameColumn(
                name: "HousingStatus",
                table: "housing",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "housing",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "housing",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
