using Rubin2000.Data;
using Rubin2000.Global;
using System.Collections.Generic;
using System.Linq;
using Rubin2000.Services.ForProcedures.Models;

namespace Rubin2000.Services.ForProcedures
{
    public class ProcedureService : IProcedureService
    {
        private readonly Rubin2000DbContext data;

        public ProcedureService(Rubin2000DbContext data) 
            => this.data = data;

        public IEnumerable<ProcedureListServiceModel> GetHairProcedures()
            => this.data.Procedures
                .Where(p => p.Occupation.Name.ToLower() == OccupationConstants.HairStyler)
                .Select(p => new ProcedureListServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    DiscountPercentage = p.PercantageDiscount ?? 0,
                    CategoryName = p.Category.Name
                })
                .OrderBy(p => p.CategoryName)
                .ThenBy(p => p.Name)
                .ToList();

        public IEnumerable<ProcedureListServiceModel> GetNailsProcedures()
            => this.data.Procedures
                .Where(p => p.Occupation.Name.ToLower() == OccupationConstants.Manicurist)
                .Select(p => new ProcedureListServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    DiscountPercentage = p.PercantageDiscount ?? 0,
                    CategoryName = p.Category.Name
                })
                .OrderBy(p => p.CategoryName)
                .ThenBy(p => p.Name)
                .ToList();

        public string GetPrcedureCategoryName(string id)
            => this.data.Procedures
                .Where(p => p.Id == id)
                .Select(p => p.Category)
                .FirstOrDefault()
                .Name;

        public string GetProcedureName(string id)
            => this.data.Procedures
                .Where(p => p.Id == id)
                .FirstOrDefault()
                .Name;

        public bool ProcedureExists(string id)
            => this.data.Procedures
                .Any(p => p.Id == id);
    }
}
