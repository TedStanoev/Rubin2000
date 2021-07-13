using Microsoft.AspNetCore.Mvc;
using Rubin2000.Services.ForCategories;
using Rubin2000.Services.ForProcedures;
using Rubin2000.Web.Models.Categories;
using Rubin2000.Web.Models.Procedures;
using Rubin2000.Global;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Web.Controllers
{
    public class PricesController : Controller
    {
        private readonly IProcedureService procedureService;
        private readonly ICategoryService categoryService;

        public PricesController(IProcedureService procedureService, ICategoryService categoryService)
        {
            this.procedureService = procedureService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var allProcedures = procedureService.GetAllProcedures();
            var allProcedureCategories = categoryService.GetAllProcedureCategories();

            var categoryViewModelList = new List<CategoryViewModel>();

            foreach (var category in allProcedureCategories)
            {
                var categoryViewModel = new CategoryViewModel
                {
                    Name = category.Name,
                    OccupationName = OccupationConstants.HairStyler
                };

                foreach (var procedure in allProcedures)
                {
                    if (procedure.Category.Name == category.Name)
                    {
                        categoryViewModel.Procedures.Add(new ProcedureListViewModel
                        {
                            Id = procedure.Id,
                            Name = procedure.Name,
                            Price = procedure.Price,
                            DiscountPercentage = procedure.PercantageDiscount ?? 0,
                            CategoryName = procedure.Category.Name,
                            OccupationName = procedure.Occupation.Name
                        });

                        categoryViewModel.OccupationName = procedure.Occupation.Name;
                    }
                }

                categoryViewModelList.Add(categoryViewModel);
            }

            categoryViewModelList = categoryViewModelList
                .OrderBy(c => c.OccupationName)
                .ToList();

            return View(categoryViewModelList);
        }
    }
}
