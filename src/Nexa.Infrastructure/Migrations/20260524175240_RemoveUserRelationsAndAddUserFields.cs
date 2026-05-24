using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserRelationsAndAddUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_driver_user_UserId",
                table: "driver");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_user_UserId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_UserId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_driver_UserId",
                table: "driver");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "driver");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "user",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "user",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPasswordChange",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "user",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "user",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "user");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "user");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "user");

            migrationBuilder.DropColumn(
                name: "LastPasswordChange",
                table: "user");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "user");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "employee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "driver",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_employee_UserId",
                table: "employee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_driver_UserId",
                table: "driver",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_driver_user_UserId",
                table: "driver",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_user_UserId",
                table: "employee",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
