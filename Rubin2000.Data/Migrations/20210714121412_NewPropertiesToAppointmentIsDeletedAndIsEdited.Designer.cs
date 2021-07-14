﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rubin2000.Data;

namespace Rubin2000.Data.Migrations
{
    [DbContext(typeof(Rubin2000DbContext))]
    [Migration("20210714121412_NewPropertiesToAppointmentIsDeletedAndIsEdited")]
    partial class NewPropertiesToAppointmentIsDeletedAndIsEdited
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Rubin2000.Models.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<bool>("IsDeletedToUser")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit");

                    b.Property<string>("ProcedureId")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ScheduleId")
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Rubin2000.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("OccupationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ScheduleId")
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("OccupationId");

                    b.HasIndex("ScheduleId")
                        .IsUnique()
                        .HasFilter("[ScheduleId] IS NOT NULL");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = "0caaa666-41f5-4f73-93b1-8c8cce3c60d3",
                            Name = "Albena",
                            OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                            ScheduleId = "2ef564a7-a15a-4b17-8407-9bc37a9ae985"
                        },
                        new
                        {
                            Id = "ba190cb1-6a32-4884-a7bc-3d86e597d5c5",
                            Name = "Eli",
                            OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                            ScheduleId = "70561545-f07c-4e18-a255-fe4fff6e9e19"
                        });
                });

            modelBuilder.Entity("Rubin2000.Models.Occupation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Occupations");

                    b.HasData(
                        new
                        {
                            Id = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                            Name = "HairStyler"
                        },
                        new
                        {
                            Id = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                            Name = "Manicurist"
                        });
                });

            modelBuilder.Entity("Rubin2000.Models.Procedure", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("OccupationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal?>("PercantageDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OccupationId");

                    b.ToTable("Procedures");

                    b.HasData(
                        new
                        {
                            Id = "a1c889f7-0373-4cd0-ad68-11ccb61789ca",
                            CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223",
                            Duration = 1,
                            Name = "Gentlemen's Haircut",
                            OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                            Price = 10m
                        },
                        new
                        {
                            Id = "0e4696c8-5fbb-40fb-a107-91c2c847aa22",
                            CategoryId = "a39dc7ca-6365-4647-bdab-db4d18b7dcca",
                            Duration = 1,
                            Name = "Short and Long Hair",
                            OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                            Price = 17m
                        },
                        new
                        {
                            Id = "510aeb22-67ce-4e93-909c-472a9acd5dc3",
                            CategoryId = "c8f647e6-4fa7-450c-a919-8d0e10fccaa4",
                            Duration = 2,
                            Name = "Wedding Hairstyle",
                            OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                            Price = 60m
                        },
                        new
                        {
                            Id = "9a4f6f72-1d9d-4a48-9687-a268b7585ec5",
                            CategoryId = "9f7669e3-e781-4f2a-a3b4-105ddd492a81",
                            Duration = 2,
                            Name = "Short hair color with client's dye",
                            OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                            Price = 14m
                        },
                        new
                        {
                            Id = "be072ef4-c95c-4756-8f5e-c3787b425e09",
                            CategoryId = "222287f0-7c00-47cf-8a69-bc95fecd8bd6",
                            Duration = 1,
                            Name = "Gel Manicure with BlueSky",
                            OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                            Price = 25m
                        },
                        new
                        {
                            Id = "2aed528d-ad6c-4831-89c5-e972c2947095",
                            CategoryId = "e4119485-ebfe-4781-8c41-839865596ce4",
                            Duration = 1,
                            Name = "Gel Pedicure with BlueSky",
                            OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                            Price = 37m
                        },
                        new
                        {
                            Id = "82517ee7-ee22-452f-88c8-4f4dd4f4ba21",
                            CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223",
                            Duration = 1,
                            Name = "Ladies' Haircut",
                            OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                            Price = 12m
                        });
                });

            modelBuilder.Entity("Rubin2000.Models.ProcedureCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProcedureCategories");

                    b.HasData(
                        new
                        {
                            Id = "24ccefef-e726-4ecd-88d1-94b7832a9223",
                            Name = "Haircut"
                        },
                        new
                        {
                            Id = "c8f647e6-4fa7-450c-a919-8d0e10fccaa4",
                            Name = "Formal Hairstyles"
                        },
                        new
                        {
                            Id = "a39dc7ca-6365-4647-bdab-db4d18b7dcca",
                            Name = "Blow Dry with styling products"
                        },
                        new
                        {
                            Id = "9f7669e3-e781-4f2a-a3b4-105ddd492a81",
                            Name = "Hair Color"
                        },
                        new
                        {
                            Id = "222287f0-7c00-47cf-8a69-bc95fecd8bd6",
                            Name = "Manicure"
                        },
                        new
                        {
                            Id = "e4119485-ebfe-4781-8c41-839865596ce4",
                            Name = "Pedicure"
                        });
                });

            modelBuilder.Entity("Rubin2000.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal?>("PercantageDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Rubin2000.Models.Schedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndsAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartsAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = "2ef564a7-a15a-4b17-8407-9bc37a9ae985",
                            EmployeeId = "0caaa666-41f5-4f73-93b1-8c8cce3c60d3",
                            EndsAt = new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            StartsAt = new DateTime(2021, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = "70561545-f07c-4e18-a255-fe4fff6e9e19",
                            EmployeeId = "ba190cb1-6a32-4884-a7bc-3d86e597d5c5",
                            EndsAt = new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            StartsAt = new DateTime(2021, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Rubin2000.Models.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rubin2000.Models.Appointment", b =>
                {
                    b.HasOne("Rubin2000.Models.AppUser", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rubin2000.Models.Procedure", "Procedure")
                        .WithMany("Appointments")
                        .HasForeignKey("ProcedureId");

                    b.HasOne("Rubin2000.Models.Schedule", "Schedule")
                        .WithMany("Appointments")
                        .HasForeignKey("ScheduleId");
                });

            modelBuilder.Entity("Rubin2000.Models.Employee", b =>
                {
                    b.HasOne("Rubin2000.Models.Occupation", "Occupation")
                        .WithMany("Employees")
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rubin2000.Models.Schedule", "Schedule")
                        .WithOne("Employee")
                        .HasForeignKey("Rubin2000.Models.Employee", "ScheduleId");
                });

            modelBuilder.Entity("Rubin2000.Models.Procedure", b =>
                {
                    b.HasOne("Rubin2000.Models.ProcedureCategory", "Category")
                        .WithMany("Procedures")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Rubin2000.Models.Occupation", "Occupation")
                        .WithMany("Procedures")
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
