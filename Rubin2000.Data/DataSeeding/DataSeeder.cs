using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rubin2000.Models;
using Rubin2000.Models.Enums;
using System;

namespace Rubin2000.Data.DataSeeding
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder builder)
        {
            SeedOccupations(builder);
            SeedProcedureCategories(builder);
            SeedProcedures(builder);
            SeedEmployees(builder);
            SeedSchedules(builder);
        }

        public static void SeedUsers(ModelBuilder builder, IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<AppUser>>();
        }

        private static void SeedEmployees(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasData(
                    new Employee
                    {
                        Id = "0caaa666-41f5-4f73-93b1-8c8cce3c60d3",
                        Name = "Albena",
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        ScheduleId = "2ef564a7-a15a-4b17-8407-9bc37a9ae985"
                    },
                    new Employee
                    {
                        Id = "ba190cb1-6a32-4884-a7bc-3d86e597d5c5",
                        Name = "Eli",
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        ScheduleId = "70561545-f07c-4e18-a255-fe4fff6e9e19"
                    });
        }

        private static void SeedSchedules(ModelBuilder builder)
        {
            builder.Entity<Schedule>()
                .HasData(
                    new Schedule
                    {
                        Id = "2ef564a7-a15a-4b17-8407-9bc37a9ae985",
                        StartsAt = new DateTime(2021, 4, 17, 10, 0, 0),
                        EndsAt = new DateTime(2021, 4, 17, 19, 0, 0),
                        EmployeeId = "0caaa666-41f5-4f73-93b1-8c8cce3c60d3"
                    },
                    new Schedule
                    {
                        Id = "70561545-f07c-4e18-a255-fe4fff6e9e19",
                        StartsAt = new DateTime(2021, 4, 17, 10, 0, 0),
                        EndsAt = new DateTime(2021, 4, 17, 19, 0, 0),
                        EmployeeId = "ba190cb1-6a32-4884-a7bc-3d86e597d5c5"
                    });
        }

        private static void SeedOccupations(ModelBuilder builder)
        {
            builder.Entity<Occupation>()
                .HasData(
                    new Occupation { Id = "6c064f87-4735-445c-8cf0-6b0e74482d96", Name = "HairStyler" },
                    new Occupation { Id = "28451ba3-d888-4762-a085-c2c0a6a241e0", Name = "Manicurist" });
        }

        private static void SeedProcedureCategories(ModelBuilder builder)
        {
            builder.Entity<ProcedureCategory>()
                .HasData(
                    new ProcedureCategory { Id = "24ccefef-e726-4ecd-88d1-94b7832a9223", Name = "Haircut" },
                    new ProcedureCategory { Id = "c8f647e6-4fa7-450c-a919-8d0e10fccaa4", Name = "Formal Hairstyles" },
                    new ProcedureCategory { Id = "a39dc7ca-6365-4647-bdab-db4d18b7dcca", Name = "Blow Dry with styling products" },
                    new ProcedureCategory { Id = "9f7669e3-e781-4f2a-a3b4-105ddd492a81", Name = "Hair Color" },
                    new ProcedureCategory { Id = "222287f0-7c00-47cf-8a69-bc95fecd8bd6", Name = "Manicure" },
                    new ProcedureCategory { Id = "e4119485-ebfe-4781-8c41-839865596ce4", Name = "Pedicure" });
        }

        private static void SeedProcedures(ModelBuilder builder)
        {
            builder.Entity<Procedure>()
                .HasData(
                    new Procedure
                    {
                        Id = "a1c889f7-0373-4cd0-ad68-11ccb61789ca",
                        Name = "Gentlemen's Haircut",
                        Duration = Duration.One_Hour,
                        Price = 10,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223"
                    },
                    new Procedure
                    {
                        Id = "0e4696c8-5fbb-40fb-a107-91c2c847aa22",
                        Name = "Short and Long Hair",
                        Duration = Duration.One_Hour,
                        Price = 17,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "a39dc7ca-6365-4647-bdab-db4d18b7dcca"
                    },
                    new Procedure
                    {
                        Id = "510aeb22-67ce-4e93-909c-472a9acd5dc3",
                        Name = "Wedding Hairstyle",
                        Duration = Duration.Two_Hours,
                        Price = 60,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "c8f647e6-4fa7-450c-a919-8d0e10fccaa4"
                    },
                    new Procedure
                    {
                        Id = "9a4f6f72-1d9d-4a48-9687-a268b7585ec5",
                        Name = "Short hair color with client's dye",
                        Duration = Duration.Two_Hours,
                        Price = 14,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "9f7669e3-e781-4f2a-a3b4-105ddd492a81"
                    },
                    new Procedure
                    {
                        Id = "be072ef4-c95c-4756-8f5e-c3787b425e09",
                        Name = "Gel Manicure with BlueSky",
                        Duration = Duration.One_Hour,
                        Price = 25,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "222287f0-7c00-47cf-8a69-bc95fecd8bd6"
                    },
                    new Procedure
                    {
                        Id = "2aed528d-ad6c-4831-89c5-e972c2947095",
                        Name = "Gel Pedicure with BlueSky",
                        Duration = Duration.One_Hour,
                        Price = 37,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "e4119485-ebfe-4781-8c41-839865596ce4"
                    },
                    new Procedure
                    {
                        Id = "82517ee7-ee22-452f-88c8-4f4dd4f4ba21",
                        Name = "Ladies' Haircut",
                        Duration = Duration.One_Hour,
                        Price = 12,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223"
                    });
        }
    }
}
