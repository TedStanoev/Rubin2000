using Microsoft.AspNetCore.Mvc;
using Rubin2000.Services.ForProcedures;
using Rubin2000.Web.Models.Procedures;
using System.Linq;

namespace Rubin2000.Web.Controllers
{
    public class PricesController : Controller
    {
        private IProcedureService procedureService;

        public PricesController(IProcedureService procedureService)
        {
            this.procedureService = procedureService;
        }

        public IActionResult Index()
        {
            var allProcedures = procedureService.GetAllProcedures();

            var allProceduresViewModel = allProcedures
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

            return View(allProceduresViewModel);
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
