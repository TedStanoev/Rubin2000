using Microsoft.AspNetCore.Mvc;
using Rubin2000.Services.ForCategories;
using Rubin2000.Services.ForProcedures;
using Rubin2000.Web.Models.Categories;
using Rubin2000.Web.Models.Procedures;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Web.Controllers
{
    public class PricesController : Controller
    {
        private IProcedureService procedureService;
        private ICategoryService categoryService;

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
                    Name = category.Name
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
                    }
                }

                categoryViewModelList.Add(categoryViewModel);
            }

            return View(categoryViewModelList);
        }

        public IActionResult Hair()
        {
            var hairProcedures = procedureService.GetHairProcedures();

            var hairProceduresViewModel = hairProcedures
                .Select(p => new ProcedureListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    DiscountPercentage = p.PercantageDiscount ?? 0,
                    CategoryName = p.Category.Name,
                    OccupationName = p.Occupation.Name
                })
                .ToList();

            return View(hairProceduresViewModel);
        }

        public IActionResult Nails()
        {
            var nailsProcedures = procedureService.GetNailsProcedures();

            var nailsProceduresViewModel = nailsProcedures
                .Select(p => new ProcedureListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    DiscountPercentage = p.PercantageDiscount ?? 0,
                    CategoryName = p.Category.Name,
                    OccupationName = p.Occupation.Name
                })
                .ToList();

            return View(nailsProceduresViewModel);
        }
    }
}
