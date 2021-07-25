using Microsoft.AspNetCore.Mvc;
using Rubin2000.Services.ForProcedures;
using Rubin2000.Web.Models.Procedures;
using System.Linq;

namespace Rubin2000.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IProcedureService procedureService;

        public ServicesController(IProcedureService procedureService) 
            => this.procedureService = procedureService;

        public IActionResult Index() => View();


        public IActionResult Hair()
        {
            var hairProcedures = procedureService.GetHairProcedures();

            return View(hairProcedures);
        }

        public IActionResult Nails()
        {
            var nailsProcedures = procedureService.GetNailsProcedures();

            return View(nailsProcedures);
        }

    }
}
