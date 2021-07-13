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
using Rubin2000.Services.ForProcedures;
using Rubin2000.Global;
using System.Globalization;
using Rubin2000.Services.ForSchedules;

namespace Rubin2000.Web.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly IEmployeeService employeeService;
        private readonly IProcedureService procedureService;
        private readonly IScheduleService scheduleService;
        private readonly UserManager<AppUser> userManager;

        public AppointmentsController(IAppointmentService appointmentService, UserManager<AppUser> userManager, IEmployeeService employeeService, IProcedureService procedureService, IScheduleService scheduleService)
        {
            this.appointmentService = appointmentService;
            this.userManager = userManager;
            this.employeeService = employeeService;
            this.procedureService = procedureService;
            this.scheduleService = scheduleService;
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

        [Authorize]
        public IActionResult MakeAppointment(string id)
        {

            var appointmentViewModel = new AppointmentInputViewModel
            {
                ProcedureName = procedureService.GetProcedure(id).Name,
                Employees = employeeService
                    .GetEmployeesByProcedure(id)
                    .ToList()
            };

            return View(appointmentViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult MakeAppointment(AppointmentInputViewModel appointment, string id)
        {
            if (!procedureService.ProcedureExists(id))
            {
                this.ModelState.AddModelError(nameof(appointment.ProcedureName), ErrorConstants.InvalidProcedure);
            }

            if (!DateTime.TryParseExact(appointment.Date, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime appointmentDate))
            {
                this.ModelState.AddModelError(nameof(appointment.Date), ErrorConstants.InvalidDate);
            }

            if (appointmentDate.Date < DateTime.UtcNow)
            {
                this.ModelState.AddModelError(nameof(appointment.Date), ErrorConstants.InvalidDatePassed);
            }

            if (!DateTime.TryParseExact(appointment.Time, "HH:mm", null, DateTimeStyles.None, out DateTime appointmentTime))
            {
                this.ModelState.AddModelError(nameof(appointment.Time), ErrorConstants.InvalidTime);
            }

            if (appointmentTime.TimeOfDay < DateAndTimeConstants.DefaultStartingHours 
                || appointmentTime.TimeOfDay > DateAndTimeConstants.DefaultEndingHours)
            {
                this.ModelState.AddModelError(nameof(appointment.Time), ErrorConstants.InvalidTime);
            }

            if (!employeeService.EmployeeExists(appointment.EmployeeId)
                || !employeeService.EmployeeCanDoProcedure(appointment.EmployeeId, id))
            {
                this.ModelState.AddModelError(nameof(appointment.EmployeeId), ErrorConstants.InvalidEmployee);
            }

            if (!this.ModelState.IsValid)
            {
                appointment.Employees = employeeService
                    .GetEmployeesByProcedure(id)
                    .ToList();

                return View(appointment);
            }

            var procedure = procedureService.GetProcedure(id);

            var employeeSchedule = scheduleService
                .GetEmployeeScheduleByEmployeeId(appointment.EmployeeId);

            appointmentService.CreateAppointment(employeeSchedule, procedure, 
                this.userManager.GetUserAsync(this.User).Result, appointment.Description, appointmentDate, appointmentTime);

            return Redirect("/Appointments/MyAppointments");
        }

        public IActionResult Approve(string id)
        {
            var appointment = appointmentService.GetAppointment(id);

            var status = AppointmentStatus.Approved;

            appointmentService.ChangeAppointmentStatus(appointment, status);

            return Redirect($"/Appointments/MyAppointments");
        }

    }
}
