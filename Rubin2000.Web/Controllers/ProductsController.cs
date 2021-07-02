using Microsoft.AspNetCore.Mvc;

namespace Rubin2000.Web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
