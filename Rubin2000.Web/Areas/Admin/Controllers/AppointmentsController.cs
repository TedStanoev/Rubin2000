using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rubin2000.Services.ForAppointments;
using Rubin2000.Services.ForClients;
using Rubin2000.Services.ForSchedules;
using Rubin2000.Web.Areas.Admin.Models.Appointments;

using static Rubin2000.Global.WebConstants;

namespace Rubin2000.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    [Area(AdminArea)]
    public class AppointmentsController : Controller
    {
        private readonly IUserService userService;
        private readonly IAppointmentService appointmentService;
        private readonly IScheduleService scheduleService;

        public AppointmentsController(IUserService userService, IAppointmentService appointmentService, IScheduleService scheduleService)
        {
            this.userService = userService;
            this.appointmentService = appointmentService;
            this.scheduleService = scheduleService;
        }

        public IActionResult Info(string id)
        {
            if (!this.userService.IsAdministrator(this.User))
            {
                return Unauthorized();
            }

            var appointmentInfoModel = this.appointmentService.GetAppointmentInfo(id);

            return View(appointmentInfoModel);
        }

        public IActionResult EmployeeDecline(string id)
        {
            return View(new DeclineAppointmentViewModel { Id = id });
        }

        [HttpPost]
        public IActionResult EmployeeDecline(DeclineAppointmentViewModel appointmentModel)
        {
            appointmentService.DeclineAppointment(appointmentModel.Id, appointmentModel.Description);

            var scheduleId = scheduleService.GetScheduleIdByAppointmentId(appointmentModel.Id);

            return Redirect($"/Admin/Schedules/EmployeeSchedule/{scheduleId}");
        }
    }
}
