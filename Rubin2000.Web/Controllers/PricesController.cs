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
        private readonly ICategoryService categoryService;

        public PricesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categoriesWithProcedures = categoryService.GetAllCategoriesWithProcedures();

            return View(categoriesWithProcedures);
        }
    }
}
