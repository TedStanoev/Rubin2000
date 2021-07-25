using Rubin2000.Services.ForProcedures.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForCategories.Models
{
    public class CategoryWithProceduresServiceModel
    {
        public string Name { get; set; }

        public string Occupation { get; set; }

        public IEnumerable<ProcedureServiceModel> Procedures { get; set; }
    }
}
