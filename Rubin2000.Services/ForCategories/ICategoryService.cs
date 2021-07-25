using Rubin2000.Models;
using Rubin2000.Services.ForCategories.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForCategories
{
    public interface ICategoryService
    {
        IEnumerable<CategoryWithProceduresServiceModel> GetAllCategoriesWithProcedures();
    }
}
