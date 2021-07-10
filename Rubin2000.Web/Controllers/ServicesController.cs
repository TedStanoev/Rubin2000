using Microsoft.AspNetCore.Mvc;
using Rubin2000.Services.ForCategories;
using Rubin2000.Services.ForOccupations;
using Rubin2000.Services.ForProcedures;
using Rubin2000.Web.Models.Procedures;
using System.Linq;

namespace Rubin2000.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IProcedureService procedureService;

        public ServicesController(IProcedureService procedureService)
        {
            this.procedureService = procedureService;
        }

        public IActionResult Index()
        {
            return View();
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
