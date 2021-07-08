using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubin2000.Data.Migrations
{
    public partial class AddEmployeesAndSchedulesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Schedules_ScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "OccupationId", "ScheduleId" },
                values: new object[] { "0caaa666-41f5-4f73-93b1-8c8cce3c60d3", "Albena", "6c064f87-4735-445c-8cf0-6b0e74482d96", null });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Description", "EmployeeId", "EndsAt", "StartsAt" },
                values: new object[] { "2ef564a7-a15a-4b17-8407-9bc37a9ae985", null, "0caaa666-41f5-4f73-93b1-8c8cce3c60d3", new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees",
                column: "ScheduleId",
                unique: true,
                filter: "[ScheduleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Schedules_ScheduleId",
                table: "Employees",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Schedules_ScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "0caaa666-41f5-4f73-93b1-8c8cce3c60d3");

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: "2ef564a7-a15a-4b17-8407-9bc37a9ae985");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleId",
                table: "Employees",
                type: "nvarchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Schedules_ScheduleId",
                table: "Employees",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
