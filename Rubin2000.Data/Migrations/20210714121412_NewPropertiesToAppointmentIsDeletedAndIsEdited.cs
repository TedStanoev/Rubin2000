using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubin2000.Data.Migrations
{
    public partial class NewPropertiesToAppointmentIsDeletedAndIsEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeletedToUser",
                table: "Appointments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEdited",
                table: "Appointments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeletedToUser",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsEdited",
                table: "Appointments");
        }
    }
}
