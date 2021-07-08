using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubin2000.Data.Migrations
{
    public partial class AddManicuristWithSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "0caaa666-41f5-4f73-93b1-8c8cce3c60d3",
                column: "ScheduleId",
                value: "2ef564a7-a15a-4b17-8407-9bc37a9ae985");

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Description", "EmployeeId", "EndsAt", "StartsAt" },
                values: new object[] { "70561545-f07c-4e18-a255-fe4fff6e9e19", null, "ba190cb1-6a32-4884-a7bc-3d86e597d5c5", new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "OccupationId", "ScheduleId" },
                values: new object[] { "ba190cb1-6a32-4884-a7bc-3d86e597d5c5", "Eli", "28451ba3-d888-4762-a085-c2c0a6a241e0", "70561545-f07c-4e18-a255-fe4fff6e9e19" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "ba190cb1-6a32-4884-a7bc-3d86e597d5c5");

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: "70561545-f07c-4e18-a255-fe4fff6e9e19");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "0caaa666-41f5-4f73-93b1-8c8cce3c60d3",
                column: "ScheduleId",
                value: null);
        }
    }
}
