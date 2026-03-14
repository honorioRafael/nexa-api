using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Users_UserId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Vehicles_VehicleId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Housings_HousingId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_HousingAllocations_Employees_EmployeeId",
                table: "HousingAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_HousingAllocations_Housings_HousingId",
                table: "HousingAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleAllocations_Drivers_DriverId",
                table: "VehicleAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleAllocations_Vehicles_VehicleId",
                table: "VehicleAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleMaintenances_Vehicles_VehicleId",
                table: "VehicleMaintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleTrips_VehicleAllocations_VehicleAllocationId",
                table: "VehicleTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleTrips",
                table: "VehicleTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleModels",
                table: "VehicleModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleMaintenances",
                table: "VehicleMaintenances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleAllocations",
                table: "VehicleAllocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Housings",
                table: "Housings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HousingAllocations",
                table: "HousingAllocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.RenameTable(
                name: "VehicleTrips",
                newName: "vehicle_trip");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "vehicle");

            migrationBuilder.RenameTable(
                name: "VehicleModels",
                newName: "vehicle_model");

            migrationBuilder.RenameTable(
                name: "VehicleMaintenances",
                newName: "vehicle_maintenance");

            migrationBuilder.RenameTable(
                name: "VehicleAllocations",
                newName: "vehicle_allocation");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Housings",
                newName: "housing");

            migrationBuilder.RenameTable(
                name: "HousingAllocations",
                newName: "housing_allocation");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employee");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "driver");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleTrips_VehicleAllocationId",
                table: "vehicle_trip",
                newName: "IX_vehicle_trip_VehicleAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "vehicle",
                newName: "IX_vehicle_VehicleModelId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleMaintenances_VehicleId",
                table: "vehicle_maintenance",
                newName: "IX_vehicle_maintenance_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleAllocations_VehicleId",
                table: "vehicle_allocation",
                newName: "IX_vehicle_allocation_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleAllocations_DriverId",
                table: "vehicle_allocation",
                newName: "IX_vehicle_allocation_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_HousingAllocations_HousingId",
                table: "housing_allocation",
                newName: "IX_housing_allocation_HousingId");

            migrationBuilder.RenameIndex(
                name: "IX_HousingAllocations_EmployeeId",
                table: "housing_allocation",
                newName: "IX_housing_allocation_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "employee",
                newName: "IX_employee_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_HousingId",
                table: "employee",
                newName: "IX_employee_HousingId");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_VehicleId",
                table: "driver",
                newName: "IX_driver_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_UserId",
                table: "driver",
                newName: "IX_driver_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicle_trip",
                table: "vehicle_trip",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicle",
                table: "vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicle_model",
                table: "vehicle_model",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicle_maintenance",
                table: "vehicle_maintenance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicle_allocation",
                table: "vehicle_allocation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_housing",
                table: "housing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_housing_allocation",
                table: "housing_allocation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee",
                table: "employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_driver",
                table: "driver",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_driver_user_UserId",
                table: "driver",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_driver_vehicle_VehicleId",
                table: "driver",
                column: "VehicleId",
                principalTable: "vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_housing_HousingId",
                table: "employee",
                column: "HousingId",
                principalTable: "housing",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_user_UserId",
                table: "employee",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_housing_allocation_employee_EmployeeId",
                table: "housing_allocation",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_housing_allocation_housing_HousingId",
                table: "housing_allocation",
                column: "HousingId",
                principalTable: "housing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_vehicle_model_VehicleModelId",
                table: "vehicle",
                column: "VehicleModelId",
                principalTable: "vehicle_model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_allocation_driver_DriverId",
                table: "vehicle_allocation",
                column: "DriverId",
                principalTable: "driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_allocation_vehicle_VehicleId",
                table: "vehicle_allocation",
                column: "VehicleId",
                principalTable: "vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_maintenance_vehicle_VehicleId",
                table: "vehicle_maintenance",
                column: "VehicleId",
                principalTable: "vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_vehicle_allocation_VehicleAllocationId",
                table: "vehicle_trip",
                column: "VehicleAllocationId",
                principalTable: "vehicle_allocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_driver_user_UserId",
                table: "driver");

            migrationBuilder.DropForeignKey(
                name: "FK_driver_vehicle_VehicleId",
                table: "driver");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_housing_HousingId",
                table: "employee");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_user_UserId",
                table: "employee");

            migrationBuilder.DropForeignKey(
                name: "FK_housing_allocation_employee_EmployeeId",
                table: "housing_allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_housing_allocation_housing_HousingId",
                table: "housing_allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_vehicle_model_VehicleModelId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_allocation_driver_DriverId",
                table: "vehicle_allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_allocation_vehicle_VehicleId",
                table: "vehicle_allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_maintenance_vehicle_VehicleId",
                table: "vehicle_maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_vehicle_allocation_VehicleAllocationId",
                table: "vehicle_trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicle_trip",
                table: "vehicle_trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicle_model",
                table: "vehicle_model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicle_maintenance",
                table: "vehicle_maintenance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicle_allocation",
                table: "vehicle_allocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicle",
                table: "vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_housing_allocation",
                table: "housing_allocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_housing",
                table: "housing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee",
                table: "employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_driver",
                table: "driver");

            migrationBuilder.RenameTable(
                name: "vehicle_trip",
                newName: "VehicleTrips");

            migrationBuilder.RenameTable(
                name: "vehicle_model",
                newName: "VehicleModels");

            migrationBuilder.RenameTable(
                name: "vehicle_maintenance",
                newName: "VehicleMaintenances");

            migrationBuilder.RenameTable(
                name: "vehicle_allocation",
                newName: "VehicleAllocations");

            migrationBuilder.RenameTable(
                name: "vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "housing_allocation",
                newName: "HousingAllocations");

            migrationBuilder.RenameTable(
                name: "housing",
                newName: "Housings");

            migrationBuilder.RenameTable(
                name: "employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "driver",
                newName: "Drivers");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_trip_VehicleAllocationId",
                table: "VehicleTrips",
                newName: "IX_VehicleTrips_VehicleAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_maintenance_VehicleId",
                table: "VehicleMaintenances",
                newName: "IX_VehicleMaintenances_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_allocation_VehicleId",
                table: "VehicleAllocations",
                newName: "IX_VehicleAllocations_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_allocation_DriverId",
                table: "VehicleAllocations",
                newName: "IX_VehicleAllocations_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_VehicleModelId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleModelId");

            migrationBuilder.RenameIndex(
                name: "IX_housing_allocation_HousingId",
                table: "HousingAllocations",
                newName: "IX_HousingAllocations_HousingId");

            migrationBuilder.RenameIndex(
                name: "IX_housing_allocation_EmployeeId",
                table: "HousingAllocations",
                newName: "IX_HousingAllocations_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_employee_UserId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_employee_HousingId",
                table: "Employees",
                newName: "IX_Employees_HousingId");

            migrationBuilder.RenameIndex(
                name: "IX_driver_VehicleId",
                table: "Drivers",
                newName: "IX_Drivers_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_driver_UserId",
                table: "Drivers",
                newName: "IX_Drivers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleTrips",
                table: "VehicleTrips",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleModels",
                table: "VehicleModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleMaintenances",
                table: "VehicleMaintenances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleAllocations",
                table: "VehicleAllocations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HousingAllocations",
                table: "HousingAllocations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Housings",
                table: "Housings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Users_UserId",
                table: "Drivers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Vehicles_VehicleId",
                table: "Drivers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Housings_HousingId",
                table: "Employees",
                column: "HousingId",
                principalTable: "Housings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HousingAllocations_Employees_EmployeeId",
                table: "HousingAllocations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HousingAllocations_Housings_HousingId",
                table: "HousingAllocations",
                column: "HousingId",
                principalTable: "Housings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleAllocations_Drivers_DriverId",
                table: "VehicleAllocations",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleAllocations_Vehicles_VehicleId",
                table: "VehicleAllocations",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleMaintenances_Vehicles_VehicleId",
                table: "VehicleMaintenances",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleTrips_VehicleAllocations_VehicleAllocationId",
                table: "VehicleTrips",
                column: "VehicleAllocationId",
                principalTable: "VehicleAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
