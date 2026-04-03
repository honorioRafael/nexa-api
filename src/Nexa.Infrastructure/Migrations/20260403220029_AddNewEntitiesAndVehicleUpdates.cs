using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntitiesAndVehicleUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_vehicle_allocation_VehicleAllocationId",
                table: "vehicle_trip");

            migrationBuilder.DropTable(
                name: "vehicle_allocation");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "vehicle_trip");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "vehicle_trip");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "housing");

            migrationBuilder.RenameColumn(
                name: "VehicleAllocationId",
                table: "vehicle_trip",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_trip_VehicleAllocationId",
                table: "vehicle_trip",
                newName: "IX_vehicle_trip_VehicleId");

            migrationBuilder.AddColumn<int>(
                name: "CurrentOcupation",
                table: "vehicle_trip",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "vehicle_trip",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DestinationAddressId",
                table: "vehicle_trip",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DriverId",
                table: "vehicle_trip",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OriginAddressId",
                table: "vehicle_trip",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastReviewDate",
                table: "vehicle_maintenance",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LastReviewMileage",
                table: "vehicle_maintenance",
                type: "numeric(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginCountry",
                table: "vehicle",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleCondition",
                table: "vehicle",
                type: "text",
                nullable: false,
                defaultValue: "New");

            migrationBuilder.AddColumn<long>(
                name: "HousingRoomId",
                table: "housing_allocation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AddressId",
                table: "housing",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "UseHousingRoom",
                table: "housing",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Street = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Complement = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Neighborhood = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "housing_room",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HousingId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    HousingRoomType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_housing_room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_housing_room_housing_HousingId",
                        column: x => x.HousingId,
                        principalTable: "housing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_trip_employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleTripId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_trip_employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicle_trip_employee_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vehicle_trip_employee_vehicle_trip_VehicleTripId",
                        column: x => x.VehicleTripId,
                        principalTable: "vehicle_trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_trip_stop",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleTripId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    QueuePosition = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_trip_stop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicle_trip_stop_address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vehicle_trip_stop_vehicle_trip_VehicleTripId",
                        column: x => x.VehicleTripId,
                        principalTable: "vehicle_trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_trip_DestinationAddressId",
                table: "vehicle_trip",
                column: "DestinationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_trip_DriverId",
                table: "vehicle_trip",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_trip_OriginAddressId",
                table: "vehicle_trip",
                column: "OriginAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_housing_allocation_HousingRoomId",
                table: "housing_allocation",
                column: "HousingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_housing_AddressId",
                table: "housing",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_housing_room_HousingId",
                table: "housing_room",
                column: "HousingId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_trip_employee_EmployeeId",
                table: "vehicle_trip_employee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_trip_employee_VehicleTripId",
                table: "vehicle_trip_employee",
                column: "VehicleTripId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_trip_stop_AddressId",
                table: "vehicle_trip_stop",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_trip_stop_VehicleTripId",
                table: "vehicle_trip_stop",
                column: "VehicleTripId");

            migrationBuilder.AddForeignKey(
                name: "FK_housing_address_AddressId",
                table: "housing",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_housing_allocation_housing_room_HousingRoomId",
                table: "housing_allocation",
                column: "HousingRoomId",
                principalTable: "housing_room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_address_DestinationAddressId",
                table: "vehicle_trip",
                column: "DestinationAddressId",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_address_OriginAddressId",
                table: "vehicle_trip",
                column: "OriginAddressId",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_driver_DriverId",
                table: "vehicle_trip",
                column: "DriverId",
                principalTable: "driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_vehicle_VehicleId",
                table: "vehicle_trip",
                column: "VehicleId",
                principalTable: "vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_housing_address_AddressId",
                table: "housing");

            migrationBuilder.DropForeignKey(
                name: "FK_housing_allocation_housing_room_HousingRoomId",
                table: "housing_allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_address_DestinationAddressId",
                table: "vehicle_trip");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_address_OriginAddressId",
                table: "vehicle_trip");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_driver_DriverId",
                table: "vehicle_trip");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_vehicle_VehicleId",
                table: "vehicle_trip");

            migrationBuilder.DropTable(
                name: "housing_room");

            migrationBuilder.DropTable(
                name: "vehicle_trip_employee");

            migrationBuilder.DropTable(
                name: "vehicle_trip_stop");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_trip_DestinationAddressId",
                table: "vehicle_trip");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_trip_DriverId",
                table: "vehicle_trip");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_trip_OriginAddressId",
                table: "vehicle_trip");

            migrationBuilder.DropIndex(
                name: "IX_housing_allocation_HousingRoomId",
                table: "housing_allocation");

            migrationBuilder.DropIndex(
                name: "IX_housing_AddressId",
                table: "housing");

            migrationBuilder.DropColumn(
                name: "CurrentOcupation",
                table: "vehicle_trip");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "vehicle_trip");

            migrationBuilder.DropColumn(
                name: "DestinationAddressId",
                table: "vehicle_trip");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "vehicle_trip");

            migrationBuilder.DropColumn(
                name: "OriginAddressId",
                table: "vehicle_trip");

            migrationBuilder.DropColumn(
                name: "LastReviewDate",
                table: "vehicle_maintenance");

            migrationBuilder.DropColumn(
                name: "LastReviewMileage",
                table: "vehicle_maintenance");

            migrationBuilder.DropColumn(
                name: "OriginCountry",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleCondition",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "HousingRoomId",
                table: "housing_allocation");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "housing");

            migrationBuilder.DropColumn(
                name: "UseHousingRoom",
                table: "housing");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "vehicle_trip",
                newName: "VehicleAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_trip_VehicleId",
                table: "vehicle_trip",
                newName: "IX_vehicle_trip_VehicleAllocationId");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "vehicle_trip",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "vehicle_trip",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "housing",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "vehicle_allocation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_allocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicle_allocation_driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vehicle_allocation_vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_allocation_DriverId",
                table: "vehicle_allocation",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_allocation_VehicleId",
                table: "vehicle_allocation",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_vehicle_allocation_VehicleAllocationId",
                table: "vehicle_trip",
                column: "VehicleAllocationId",
                principalTable: "vehicle_allocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
