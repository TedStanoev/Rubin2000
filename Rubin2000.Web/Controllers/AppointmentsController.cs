using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Rubin2000.Services.ForAppointments;
using Rubin2000.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Rubin2000.Web.Models.Appointments;
using Rubin2000.Models.Enums;

namespace Rubin2000.Web.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly UserManager<AppUser> userManager;

        public AppointmentsController(IAppointmentService appointmentService, UserManager<AppUser> userManager)
        {
            this.appointmentService = appointmentService;
            this.userManager = userManager;
        }

        public IActionResult MyAppointments()
        {
            var userAppointments = appointmentService.GetUserAppointments(this.userManager.GetUserId(this.User));

            var userAppointmentsViewModel = userAppointments
                .Select(a => new AppointmentListViewModel
                {
                    ProcedureName = a.Procedure.Name,
                    Date = a.DateAndTime.ToShortDateString(),
                    Time = a.DateAndTime.ToShortTimeString(),
                    Status = Enum.GetName<AppointmentStatus>(a.Status)
                })
                .ToList();

            return View(userAppointmentsViewModel);
        }
    }
}
