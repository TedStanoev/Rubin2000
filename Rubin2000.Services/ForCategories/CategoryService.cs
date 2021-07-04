using Rubin2000.Data;
using Rubin2000.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Services.ForCategories
{
    public class CategoryService : ICategoryService
    {
        private readonly Rubin2000DbContext data;

        public CategoryService(Rubin2000DbContext data)
        {
            this.data = data;
        }

        public IEnumerable<ProcedureCategory> GetAllProcedureCategories()
            => this.data.ProcedureCategories
                .ToList();
    }
}
