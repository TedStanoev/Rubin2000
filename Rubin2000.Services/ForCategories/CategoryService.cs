using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using Rubin2000.Services.ForCategories.Models;
using Rubin2000.Services.ForProcedures.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Services.ForCategories
{
    public class CategoryService : ICategoryService
    {
        private readonly Rubin2000DbContext data;

        public CategoryService(Rubin2000DbContext data)
            => this.data = data;

        public IEnumerable<CategoryWithProceduresServiceModel> GetAllCategoriesWithProcedures()
            => this.data.ProcedureCategories
                .Select(c => new CategoryWithProceduresServiceModel
                {
                    Name = c.Name,
                    Occupation = c.Procedures.FirstOrDefault().Occupation.Name,
                    Procedures = c.Procedures
                        .Where(p => p.CategoryId == c.Id)
                        .Select(p => new ProcedureServiceModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            CategoryName = c.Name,
                            OccupationName = p.Occupation.Name,
                            DiscountPercentage = p.PercantageDiscount ?? 0,
                            Price = p.Price
                        })
                        .OrderBy(p => p.Name)
                        .ToList()
                })
                .OrderBy(c => c.Occupation)
                .ToList();

    }
}
