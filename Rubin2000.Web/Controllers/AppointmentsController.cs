using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Rubin2000.Services.ForAppointments;
using Rubin2000.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Rubin2000.Web.Models.Appointments;
using Rubin2000.Models.Enums;
using Rubin2000.Services.ForEmployees;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rubin2000.Web.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly IEmployeeService employeeService;
        private readonly UserManager<AppUser> userManager;

        public AppointmentsController(IAppointmentService appointmentService, UserManager<AppUser> userManager, IEmployeeService employeeService)
        {
            this.appointmentService = appointmentService;
            this.userManager = userManager;
            this.employeeService = employeeService;
        }

        public IActionResult MyAppointments()
        {
            var userAppointments = appointmentService.GetUserAppointments(this.userManager.GetUserId(this.User));

            var userAppointmentsViewModel = userAppointments
                .Select(a => new AppointmentClientViewModel
                {
                    ProcedureName = a.Procedure.Name,
                    Date = a.DateAndTime.ToShortDateString(),
                    Time = a.DateAndTime.ToShortTimeString(),
                    Status = Enum.GetName<AppointmentStatus>(a.Status)
                })
                .ToList();

            return View(userAppointmentsViewModel);
        }

        public IActionResult MakeAppointment(string id)
        {

            var appointmentViewModel = new AppointmentInputViewModel
            {
                ProcedureName = id,
                Employees = employeeService.GetEmployeesByProcedure(id)
                    .Select(e => new SelectListItem 
                    {
                        Text = e.Name,
                        Value = e.Id
                    })
                    .ToList()
            };

            return View(appointmentViewModel);
        }

        [HttpPost]
        public IActionResult MakeAppointment(AppointmentInputViewModel model)
        {
            return Redirect("/Appointments/MyAppointments");
        }
    }
}
