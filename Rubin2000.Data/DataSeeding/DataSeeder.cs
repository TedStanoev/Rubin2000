using Microsoft.EntityFrameworkCore;
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
                    },
                    new Employee 
                    {
                        Id = "02059b6a-05d6-484f-98a4-aeffd4046e7f",
                        Name = "Gabriela",
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        ScheduleId = "fdfbd9ba-b3ac-48d1-a48a-bb8952dfb586"
                    },
                    new Employee 
                    {
                        Id = "d89f0d03-d479-4a63-80f0-d1698567ea31",
                        Name = "Yoana",
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        ScheduleId = "a9cfc612-2c3d-4037-872b-801f80952608"
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
                        Id = "fdfbd9ba-b3ac-48d1-a48a-bb8952dfb586",
                        StartsAt = new DateTime(2021, 4, 17, 10, 0, 0),
                        EndsAt = new DateTime(2021, 4, 17, 19, 0, 0),
                        EmployeeId = "02059b6a-05d6-484f-98a4-aeffd4046e7f"
                    },
                    new Schedule
                    {
                        Id = "a9cfc612-2c3d-4037-872b-801f80952608",
                        StartsAt = new DateTime(2021, 4, 17, 10, 0, 0),
                        EndsAt = new DateTime(2021, 4, 17, 19, 0, 0),
                        EmployeeId = "d89f0d03-d479-4a63-80f0-d1698567ea31"
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
                        Id = "8e6278d4-e5b9-431e-82d2-b2062d8ee978",
                        Name = "Gentlemen's Haircut with Hair Clipper only",
                        Duration = Duration.One_Hour,
                        Price = 8,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223"
                    },
                    new Procedure
                    {
                        Id = "1da5bc63-5c9d-4ad9-9222-804a094a782a",
                        Name = "Children's Haircut",
                        Duration = Duration.One_Hour,
                        Price = 7,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223"
                    },
                    new Procedure
                    {
                        Id = "4f8e0b47-696b-446a-821b-00907a67eabd",
                        Name = "Hair Wash",
                        Duration = Duration.One_Hour,
                        Price = 3,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223"
                    },
                    new Procedure
                    {
                        Id = "0e4696c8-5fbb-40fb-a107-91c2c847aa22",
                        Name = "Short and Medium Hair Blow",
                        Duration = Duration.One_Hour,
                        Price = 17,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "a39dc7ca-6365-4647-bdab-db4d18b7dcca"
                    },
                    new Procedure
                    {
                        Id = "c1fda323-c923-4385-8df5-2e31a27182e1",
                        Name = "Long Hair Blow",
                        Duration = Duration.Two_Hours,
                        Price = 21,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "a39dc7ca-6365-4647-bdab-db4d18b7dcca"
                    },
                    new Procedure
                    {
                        Id = "8367fa94-c90f-4eaf-bf13-19a6d91ba3e2",
                        Name = "Longer Hair Blow",
                        Duration = Duration.Two_Hours,
                        Price = 27,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "a39dc7ca-6365-4647-bdab-db4d18b7dcca"
                    },
                    new Procedure
                    {
                        Id = "510aeb22-67ce-4e93-909c-472a9acd5dc3",
                        Name = "Wedding Hairstyle",
                        Duration = Duration.Three_Hours,
                        Price = 60,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "c8f647e6-4fa7-450c-a919-8d0e10fccaa4"
                    },
                    new Procedure
                    {
                        Id = "934b8db8-7390-4ffd-aedb-0da8e16b2dcf",
                        Name = "Graduation Hairstyle",
                        Duration = Duration.Three_Hours,
                        Price = 60,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "c8f647e6-4fa7-450c-a919-8d0e10fccaa4"
                    },
                    new Procedure
                    {
                        Id = "9a4f6f72-1d9d-4a48-9687-a268b7585ec5",
                        Name = "Short Hair Color with Client's Dye",
                        Duration = Duration.Two_Hours,
                        Price = 14,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "9f7669e3-e781-4f2a-a3b4-105ddd492a81"
                    },
                    new Procedure
                    {
                        Id = "75a1d938-1108-4421-b92b-a5fc1dacaced",
                        Name = "Medium Hair Color with Client's Dye",
                        Duration = Duration.Two_Hours,
                        Price = 17,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "9f7669e3-e781-4f2a-a3b4-105ddd492a81"
                    },
                    new Procedure
                    {
                        Id = "136d4911-845e-4746-91c2-52b26dfd814d",
                        Name = "Long Hair Color with Client's Dye",
                        Duration = Duration.Two_Hours,
                        Price = 19,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "9f7669e3-e781-4f2a-a3b4-105ddd492a81"
                    },
                    new Procedure
                    {
                        Id = "9d3ff389-76b4-4f50-baf2-6c2f111cfd59",
                        Name = "Hair Color with Salon's Dye",
                        Duration = Duration.Two_Hours,
                        Price = 34,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "9f7669e3-e781-4f2a-a3b4-105ddd492a81"
                    },
                    new Procedure
                    {
                        Id = "34452ab8-e0c3-4d1b-9b2c-a2a373ac64c7",
                        Name = "Root Color",
                        Duration = Duration.One_Hour,
                        Price = 19,
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
                        Id = "248924a8-020e-461f-bb4a-7542bc7ac602",
                        Name = "Classic Manicure",
                        Duration = Duration.One_Hour,
                        Price = 15,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "222287f0-7c00-47cf-8a69-bc95fecd8bd6"
                    },
                    new Procedure
                    {
                        Id = "0abf387d-7945-4366-a8c3-a06d5ccabaf8",
                        Name = "Gentleman's Manicure",
                        Duration = Duration.One_Hour,
                        Price = 12,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "222287f0-7c00-47cf-8a69-bc95fecd8bd6"
                    },
                    new Procedure
                    {
                        Id = "93b53419-1652-4e03-aa10-2139f263e455",
                        Name = "Nail Fixing",
                        Duration = Duration.One_Hour,
                        Price = 3,
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
                        Id = "186d70a7-2155-4141-85e8-8efa9c1776e6",
                        Name = "Classic Gel Pedicure",
                        Duration = Duration.One_Hour,
                        Price = 33,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "e4119485-ebfe-4781-8c41-839865596ce4"
                    },
                    new Procedure
                    {
                        Id = "76d88f50-edd4-4be1-bc6e-8b41348d1aab",
                        Name = "Nail Polish with Dry Bits of Skin Removal",
                        Duration = Duration.One_Hour,
                        Price = 28,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "e4119485-ebfe-4781-8c41-839865596ce4"
                    },
                    new Procedure
                    {
                        Id = "1c160230-1a44-4a1c-a89b-2d3429a20284",
                        Name = "Nail Polish with Gel Removal",
                        Duration = Duration.One_Hour,
                        Price = 15,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "e4119485-ebfe-4781-8c41-839865596ce4"
                    },
                    new Procedure
                    {
                        Id = "af9eed06-a94b-47fd-86f3-d821ba4bd074",
                        Name = "Nail Polish with Gel Removal and Dry Bits of Skin Removal",
                        Duration = Duration.One_Hour,
                        Price = 20,
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
