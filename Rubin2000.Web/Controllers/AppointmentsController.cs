using Microsoft.AspNetCore.Mvc;

namespace Rubin2000.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult MyAppointments()
        {
            return View();
        }
    }
}
