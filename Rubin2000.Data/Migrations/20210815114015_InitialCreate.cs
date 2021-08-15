using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rubin2000.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    Gender = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureCategories",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    StartsAt = table.Column<DateTime>(nullable: false),
                    EndsAt = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PercantageDiscount = table.Column<decimal>(nullable: true),
                    OccupationId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedures_ProcedureCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProcedureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    OccupationId = table.Column<string>(nullable: false),
                    ScheduleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 40, nullable: false),
                    DateAndTime = table.Column<DateTime>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsDeletedToUser = table.Column<bool>(nullable: false),
                    IsEdited = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    ScheduleId = table.Column<string>(nullable: true),
                    ProcedureId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "6c064f87-4735-445c-8cf0-6b0e74482d96", "HairStyler" },
                    { "28451ba3-d888-4762-a085-c2c0a6a241e0", "Manicurist" }
                });

            migrationBuilder.InsertData(
                table: "ProcedureCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "24ccefef-e726-4ecd-88d1-94b7832a9223", "Haircut" },
                    { "c8f647e6-4fa7-450c-a919-8d0e10fccaa4", "Formal Hairstyles" },
                    { "a39dc7ca-6365-4647-bdab-db4d18b7dcca", "Blow Dry with styling products" },
                    { "9f7669e3-e781-4f2a-a3b4-105ddd492a81", "Hair Color" },
                    { "222287f0-7c00-47cf-8a69-bc95fecd8bd6", "Manicure" },
                    { "e4119485-ebfe-4781-8c41-839865596ce4", "Pedicure" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Description", "EmployeeId", "EndsAt", "StartsAt" },
                values: new object[,]
                {
                    { "2ef564a7-a15a-4b17-8407-9bc37a9ae985", null, "0caaa666-41f5-4f73-93b1-8c8cce3c60d3", new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "fdfbd9ba-b3ac-48d1-a48a-bb8952dfb586", null, "02059b6a-05d6-484f-98a4-aeffd4046e7f", new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "a9cfc612-2c3d-4037-872b-801f80952608", null, "d89f0d03-d479-4a63-80f0-d1698567ea31", new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "70561545-f07c-4e18-a255-fe4fff6e9e19", null, "ba190cb1-6a32-4884-a7bc-3d86e597d5c5", new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "OccupationId", "ScheduleId" },
                values: new object[,]
                {
                    { "ba190cb1-6a32-4884-a7bc-3d86e597d5c5", "Eli", "28451ba3-d888-4762-a085-c2c0a6a241e0", "70561545-f07c-4e18-a255-fe4fff6e9e19" },
                    { "02059b6a-05d6-484f-98a4-aeffd4046e7f", "Gabriela", "6c064f87-4735-445c-8cf0-6b0e74482d96", "fdfbd9ba-b3ac-48d1-a48a-bb8952dfb586" },
                    { "0caaa666-41f5-4f73-93b1-8c8cce3c60d3", "Albena", "6c064f87-4735-445c-8cf0-6b0e74482d96", "2ef564a7-a15a-4b17-8407-9bc37a9ae985" },
                    { "d89f0d03-d479-4a63-80f0-d1698567ea31", "Yoana", "28451ba3-d888-4762-a085-c2c0a6a241e0", "a9cfc612-2c3d-4037-872b-801f80952608" }
                });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "CategoryId", "Duration", "Name", "OccupationId", "PercantageDiscount", "Price" },
                values: new object[,]
                {
                    { "af9eed06-a94b-47fd-86f3-d821ba4bd074", "e4119485-ebfe-4781-8c41-839865596ce4", 1, "Nail Polish with Gel Removal and Dry Bits of Skin Removal", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 20m },
                    { "1c160230-1a44-4a1c-a89b-2d3429a20284", "e4119485-ebfe-4781-8c41-839865596ce4", 1, "Nail Polish with Gel Removal", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 15m },
                    { "76d88f50-edd4-4be1-bc6e-8b41348d1aab", "e4119485-ebfe-4781-8c41-839865596ce4", 1, "Nail Polish with Dry Bits of Skin Removal", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 28m },
                    { "186d70a7-2155-4141-85e8-8efa9c1776e6", "e4119485-ebfe-4781-8c41-839865596ce4", 1, "Classic Gel Pedicure", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 33m },
                    { "2aed528d-ad6c-4831-89c5-e972c2947095", "e4119485-ebfe-4781-8c41-839865596ce4", 1, "Gel Pedicure with BlueSky", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 37m },
                    { "93b53419-1652-4e03-aa10-2139f263e455", "222287f0-7c00-47cf-8a69-bc95fecd8bd6", 1, "Nail Fixing", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 3m },
                    { "0abf387d-7945-4366-a8c3-a06d5ccabaf8", "222287f0-7c00-47cf-8a69-bc95fecd8bd6", 1, "Gentleman's Manicure", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 12m },
                    { "248924a8-020e-461f-bb4a-7542bc7ac602", "222287f0-7c00-47cf-8a69-bc95fecd8bd6", 1, "Classic Manicure", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 15m },
                    { "be072ef4-c95c-4756-8f5e-c3787b425e09", "222287f0-7c00-47cf-8a69-bc95fecd8bd6", 1, "Gel Manicure with BlueSky", "28451ba3-d888-4762-a085-c2c0a6a241e0", null, 25m },
                    { "34452ab8-e0c3-4d1b-9b2c-a2a373ac64c7", "9f7669e3-e781-4f2a-a3b4-105ddd492a81", 1, "Root Color", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 19m },
                    { "9d3ff389-76b4-4f50-baf2-6c2f111cfd59", "9f7669e3-e781-4f2a-a3b4-105ddd492a81", 2, "Hair Color with Salon's Dye", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 34m },
                    { "75a1d938-1108-4421-b92b-a5fc1dacaced", "9f7669e3-e781-4f2a-a3b4-105ddd492a81", 2, "Medium Hair Color with Client's Dye", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 17m },
                    { "9a4f6f72-1d9d-4a48-9687-a268b7585ec5", "9f7669e3-e781-4f2a-a3b4-105ddd492a81", 2, "Short Hair Color with Client's Dye", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 14m },
                    { "8367fa94-c90f-4eaf-bf13-19a6d91ba3e2", "a39dc7ca-6365-4647-bdab-db4d18b7dcca", 2, "Longer Hair Blow", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 27m },
                    { "c1fda323-c923-4385-8df5-2e31a27182e1", "a39dc7ca-6365-4647-bdab-db4d18b7dcca", 2, "Long Hair Blow", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 21m },
                    { "0e4696c8-5fbb-40fb-a107-91c2c847aa22", "a39dc7ca-6365-4647-bdab-db4d18b7dcca", 1, "Short and Medium Hair Blow", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 17m },
                    { "934b8db8-7390-4ffd-aedb-0da8e16b2dcf", "c8f647e6-4fa7-450c-a919-8d0e10fccaa4", 3, "Graduation Hairstyle", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 60m },
                    { "510aeb22-67ce-4e93-909c-472a9acd5dc3", "c8f647e6-4fa7-450c-a919-8d0e10fccaa4", 3, "Wedding Hairstyle", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 60m },
                    { "82517ee7-ee22-452f-88c8-4f4dd4f4ba21", "24ccefef-e726-4ecd-88d1-94b7832a9223", 1, "Ladies' Haircut", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 12m },
                    { "4f8e0b47-696b-446a-821b-00907a67eabd", "24ccefef-e726-4ecd-88d1-94b7832a9223", 1, "Hair Wash", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 3m },
                    { "1da5bc63-5c9d-4ad9-9222-804a094a782a", "24ccefef-e726-4ecd-88d1-94b7832a9223", 1, "Children's Haircut", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 7m },
                    { "8e6278d4-e5b9-431e-82d2-b2062d8ee978", "24ccefef-e726-4ecd-88d1-94b7832a9223", 1, "Gentlemen's Haircut with Hair Clipper only", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 8m },
                    { "136d4911-845e-4746-91c2-52b26dfd814d", "9f7669e3-e781-4f2a-a3b4-105ddd492a81", 2, "Long Hair Color with Client's Dye", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 19m },
                    { "a1c889f7-0373-4cd0-ad68-11ccb61789ca", "24ccefef-e726-4ecd-88d1-94b7832a9223", 1, "Gentlemen's Haircut", "6c064f87-4735-445c-8cf0-6b0e74482d96", null, 10m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CreatorId",
                table: "Appointments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProcedureId",
                table: "Appointments",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ScheduleId",
                table: "Appointments",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OccupationId",
                table: "Employees",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees",
                column: "ScheduleId",
                unique: true,
                filter: "[ScheduleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_CategoryId",
                table: "Procedures",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_OccupationId",
                table: "Procedures",
                column: "OccupationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "ProcedureCategories");

            migrationBuilder.DropTable(
                name: "Occupations");
        }
    }
}
