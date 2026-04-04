using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnumsAsInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_employee_vehicle_trip_VehicleTripId",
                table: "vehicle_trip_employee");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_stop_vehicle_trip_VehicleTripId",
                table: "vehicle_trip_stop");

            // Converte cada coluna de enum apenas se ainda for do tipo text (idempotente)
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    -- vehicle_trip.Status (VehicleTripStatus): Completed=1, InProgress=2, AwaitingDriver=3
                    IF (SELECT data_type FROM information_schema.columns WHERE table_name='vehicle_trip' AND column_name='Status') = 'text' THEN
                        ALTER TABLE vehicle_trip ALTER COLUMN ""Status"" DROP DEFAULT;
                        ALTER TABLE vehicle_trip ALTER COLUMN ""Status"" DROP NOT NULL;
                        ALTER TABLE vehicle_trip ALTER COLUMN ""Status"" TYPE integer USING CASE ""Status""
                            WHEN 'Completed' THEN 1 WHEN 'InProgress' THEN 2 WHEN 'AwaitingDriver' THEN 3 ELSE 1 END;
                        ALTER TABLE vehicle_trip ALTER COLUMN ""Status"" SET NOT NULL;
                    END IF;

                    -- vehicle_model.Type (VehicleType): Truck=1, Van=2, Car=3, Pickup=4
                    IF (SELECT data_type FROM information_schema.columns WHERE table_name='vehicle_model' AND column_name='Type') = 'text' THEN
                        ALTER TABLE vehicle_model ALTER COLUMN ""Type"" DROP DEFAULT;
                        ALTER TABLE vehicle_model ALTER COLUMN ""Type"" DROP NOT NULL;
                        ALTER TABLE vehicle_model ALTER COLUMN ""Type"" TYPE integer USING CASE ""Type""
                            WHEN 'Truck' THEN 1 WHEN 'Van' THEN 2 WHEN 'Car' THEN 3 WHEN 'Pickup' THEN 4 ELSE 1 END;
                        ALTER TABLE vehicle_model ALTER COLUMN ""Type"" SET NOT NULL;
                    END IF;

                    -- vehicle_model.FuelType (FuelType): Diesel=1, Gasoline=2, Ethanol=3, Flex=4
                    IF (SELECT data_type FROM information_schema.columns WHERE table_name='vehicle_model' AND column_name='FuelType') = 'text' THEN
                        ALTER TABLE vehicle_model ALTER COLUMN ""FuelType"" DROP DEFAULT;
                        ALTER TABLE vehicle_model ALTER COLUMN ""FuelType"" DROP NOT NULL;
                        ALTER TABLE vehicle_model ALTER COLUMN ""FuelType"" TYPE integer USING CASE ""FuelType""
                            WHEN 'Diesel' THEN 1 WHEN 'Gasoline' THEN 2 WHEN 'Ethanol' THEN 3 WHEN 'Flex' THEN 4 ELSE 1 END;
                        ALTER TABLE vehicle_model ALTER COLUMN ""FuelType"" SET NOT NULL;
                    END IF;

                    -- vehicle.VehicleCondition (VehicleCondition): New=1, Used=2, PreOwned=3, CertifiedPreOwned=4
                    IF (SELECT data_type FROM information_schema.columns WHERE table_name='vehicle' AND column_name='VehicleCondition') = 'text' THEN
                        ALTER TABLE vehicle ALTER COLUMN ""VehicleCondition"" DROP DEFAULT;
                        ALTER TABLE vehicle ALTER COLUMN ""VehicleCondition"" DROP NOT NULL;
                        ALTER TABLE vehicle ALTER COLUMN ""VehicleCondition"" TYPE integer USING CASE ""VehicleCondition""
                            WHEN 'New' THEN 1 WHEN 'Used' THEN 2 WHEN 'PreOwned' THEN 3 WHEN 'CertifiedPreOwned' THEN 4 ELSE 1 END;
                        ALTER TABLE vehicle ALTER COLUMN ""VehicleCondition"" SET NOT NULL;
                    END IF;

                    -- vehicle.Status (VehicleStatus): InUse=1, Available=2
                    IF (SELECT data_type FROM information_schema.columns WHERE table_name='vehicle' AND column_name='Status') = 'text' THEN
                        ALTER TABLE vehicle ALTER COLUMN ""Status"" DROP DEFAULT;
                        ALTER TABLE vehicle ALTER COLUMN ""Status"" DROP NOT NULL;
                        ALTER TABLE vehicle ALTER COLUMN ""Status"" TYPE integer USING CASE ""Status""
                            WHEN 'InUse' THEN 1 WHEN 'Available' THEN 2 ELSE 1 END;
                        ALTER TABLE vehicle ALTER COLUMN ""Status"" SET NOT NULL;
                    END IF;

                    -- housing_room.HousingRoomType (HousingRoomType): Bedroom=1, Apartment=2, Other=3
                    IF (SELECT data_type FROM information_schema.columns WHERE table_name='housing_room' AND column_name='HousingRoomType') = 'text' THEN
                        ALTER TABLE housing_room ALTER COLUMN ""HousingRoomType"" DROP DEFAULT;
                        ALTER TABLE housing_room ALTER COLUMN ""HousingRoomType"" DROP NOT NULL;
                        ALTER TABLE housing_room ALTER COLUMN ""HousingRoomType"" TYPE integer USING CASE ""HousingRoomType""
                            WHEN 'Bedroom' THEN 1 WHEN 'Apartment' THEN 2 WHEN 'Other' THEN 3 ELSE 1 END;
                        ALTER TABLE housing_room ALTER COLUMN ""HousingRoomType"" SET NOT NULL;
                    END IF;

                    -- housing.Status (HousingStatus): Available=1, Full=2
                    IF (SELECT data_type FROM information_schema.columns WHERE table_name='housing' AND column_name='Status') = 'text' THEN
                        ALTER TABLE housing ALTER COLUMN ""Status"" DROP DEFAULT;
                        ALTER TABLE housing ALTER COLUMN ""Status"" DROP NOT NULL;
                        ALTER TABLE housing ALTER COLUMN ""Status"" TYPE integer USING CASE ""Status""
                            WHEN 'Available' THEN 1 WHEN 'Full' THEN 2 ELSE 1 END;
                        ALTER TABLE housing ALTER COLUMN ""Status"" SET NOT NULL;
                    END IF;

                    -- employee.Status (EmployeeStatus): Active=1, OnVacation=2, Dismissed=3
                    IF (SELECT data_type FROM information_schema.columns WHERE table_name='employee' AND column_name='Status') = 'text' THEN
                        ALTER TABLE employee ALTER COLUMN ""Status"" DROP DEFAULT;
                        ALTER TABLE employee ALTER COLUMN ""Status"" DROP NOT NULL;
                        ALTER TABLE employee ALTER COLUMN ""Status"" TYPE integer USING CASE ""Status""
                            WHEN 'Active' THEN 1 WHEN 'OnVacation' THEN 2 WHEN 'Dismissed' THEN 3 ELSE 1 END;
                        ALTER TABLE employee ALTER COLUMN ""Status"" SET NOT NULL;
                    END IF;
                END $$;");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_employee_vehicle_trip_VehicleTripId",
                table: "vehicle_trip_employee",
                column: "VehicleTripId",
                principalTable: "vehicle_trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_stop_vehicle_trip_VehicleTripId",
                table: "vehicle_trip_stop",
                column: "VehicleTripId",
                principalTable: "vehicle_trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_employee_vehicle_trip_VehicleTripId",
                table: "vehicle_trip_employee");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_trip_stop_vehicle_trip_VehicleTripId",
                table: "vehicle_trip_stop");

            migrationBuilder.Sql(@"ALTER TABLE vehicle_trip ALTER COLUMN ""Status"" TYPE text USING ""Status""::text;");
            migrationBuilder.Sql(@"ALTER TABLE vehicle_model ALTER COLUMN ""Type"" TYPE text USING ""Type""::text;");
            migrationBuilder.Sql(@"ALTER TABLE vehicle_model ALTER COLUMN ""FuelType"" TYPE text USING ""FuelType""::text;");
            migrationBuilder.Sql(@"ALTER TABLE vehicle ALTER COLUMN ""VehicleCondition"" TYPE text USING ""VehicleCondition""::text;");
            migrationBuilder.Sql(@"ALTER TABLE vehicle ALTER COLUMN ""Status"" TYPE text USING ""Status""::text;");
            migrationBuilder.Sql(@"ALTER TABLE housing_room ALTER COLUMN ""HousingRoomType"" TYPE text USING ""HousingRoomType""::text;");
            migrationBuilder.Sql(@"ALTER TABLE housing ALTER COLUMN ""Status"" TYPE text USING ""Status""::text;");
            migrationBuilder.Sql(@"ALTER TABLE employee ALTER COLUMN ""Status"" TYPE text USING ""Status""::text;");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_employee_vehicle_trip_VehicleTripId",
                table: "vehicle_trip_employee",
                column: "VehicleTripId",
                principalTable: "vehicle_trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_trip_stop_vehicle_trip_VehicleTripId",
                table: "vehicle_trip_stop",
                column: "VehicleTripId",
                principalTable: "vehicle_trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
