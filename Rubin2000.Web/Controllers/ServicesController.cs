using Microsoft.AspNetCore.Mvc;
using Rubin2000.Services.ForOccupations;

namespace Rubin2000.Web.Controllers
{
    public class ServicesController : Controller
    {
        private IOccupationService occupationService;

        public ServicesController(IOccupationService occupationService)
        {
            this.occupationService = occupationService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
