using Rubin2000.Web.Models.Procedures;
using System.Collections.Generic;

namespace Rubin2000.Web.Models.Categories
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.Procedures = new List<ProcedureListViewModel>();
        }

        public string Name { get; set; }

        public string OccupationName { get; set; }

        public ICollection<ProcedureListViewModel> Procedures { get; set; }
    }
}
