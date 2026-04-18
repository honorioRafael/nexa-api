using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameCurrentOcupationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentOcupation",
                table: "vehicle_trip",
                newName: "CurrentOccupation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentOccupation",
                table: "vehicle_trip",
                newName: "CurrentOcupation");
        }
    }
}
