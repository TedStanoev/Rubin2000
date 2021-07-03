using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubin2000.Data.Migrations
{
    public partial class AddProcdeureCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Procedures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProcedureCategory",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_CategoryId",
                table: "Procedures",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_ProcedureCategory_CategoryId",
                table: "Procedures",
                column: "CategoryId",
                principalTable: "ProcedureCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_ProcedureCategory_CategoryId",
                table: "Procedures");

            migrationBuilder.DropTable(
                name: "ProcedureCategory");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_CategoryId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Procedures");
        }
    }
}
