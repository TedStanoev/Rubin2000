using Rubin2000.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForCategories
{
    public interface ICategoryService
    {
        IEnumerable<ProcedureCategory> GetAllProcedureCategories();
    }
}
