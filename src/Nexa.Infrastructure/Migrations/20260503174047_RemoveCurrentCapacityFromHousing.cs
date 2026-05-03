using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCurrentCapacityFromHousing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCapacity",
                table: "housing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentCapacity",
                table: "housing",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
