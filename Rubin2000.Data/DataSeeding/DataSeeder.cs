﻿using Microsoft.EntityFrameworkCore;
using Rubin2000.Models;
using Rubin2000.Models.Enums;

namespace Rubin2000.Data.DataSeeding
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder builder)
        {
            SeedOccupations(builder);
            SeedProcedureCategories(builder);
            SeedProcedures(builder);
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
                        Duration = Duration.OneHour,
                        Price = 10,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223"
                    },
                    new Procedure
                    {
                        Id = "0e4696c8-5fbb-40fb-a107-91c2c847aa22",
                        Name = "Short and Long Hair",
                        Duration = Duration.OneHour,
                        Price = 17,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "a39dc7ca-6365-4647-bdab-db4d18b7dcca"
                    },
                    new Procedure
                    {
                        Id = "510aeb22-67ce-4e93-909c-472a9acd5dc3",
                        Name = "Wedding Hairstyle",
                        Duration = Duration.TwoHours,
                        Price = 60,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "c8f647e6-4fa7-450c-a919-8d0e10fccaa4"
                    },
                    new Procedure
                    {
                        Id = "9a4f6f72-1d9d-4a48-9687-a268b7585ec5",
                        Name = "Short hair color with client's dye",
                        Duration = Duration.TwoHours,
                        Price = 14,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "9f7669e3-e781-4f2a-a3b4-105ddd492a81"
                    },
                    new Procedure
                    {
                        Id = "be072ef4-c95c-4756-8f5e-c3787b425e09",
                        Name = "Gel Manicure with BlueSky",
                        Duration = Duration.OneHour,
                        Price = 25,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "222287f0-7c00-47cf-8a69-bc95fecd8bd6"
                    },
                    new Procedure
                    {
                        Id = "2aed528d-ad6c-4831-89c5-e972c2947095",
                        Name = "Gel Pedicure with BlueSky",
                        Duration = Duration.OneHour,
                        Price = 37,
                        PercantageDiscount = null,
                        OccupationId = "28451ba3-d888-4762-a085-c2c0a6a241e0",
                        CategoryId = "e4119485-ebfe-4781-8c41-839865596ce4"
                    },
                    new Procedure
                    {
                        Id = "82517ee7-ee22-452f-88c8-4f4dd4f4ba21",
                        Name = "Ladies' Haircut",
                        Duration = Duration.OneHour,
                        Price = 12,
                        PercantageDiscount = null,
                        OccupationId = "6c064f87-4735-445c-8cf0-6b0e74482d96",
                        CategoryId = "24ccefef-e726-4ecd-88d1-94b7832a9223"
                    });
        }
    }
}
