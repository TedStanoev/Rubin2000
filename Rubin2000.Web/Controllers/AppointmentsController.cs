using System;
using Microsoft.AspNetCore.Mvc;
using Rubin2000.Services.ForAppointments;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Rubin2000.Web.Models.Appointments;
using Rubin2000.Services.ForEmployees;
using Rubin2000.Services.ForProcedures;
using Rubin2000.Global;
using System.Globalization;
using Rubin2000.Services.ForSchedules;
using Rubin2000.Services.ForClients;

using Rubin2000.Services.ForAppointments.Models;

namespace Rubin2000.Web.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly IEmployeeService employeeService;
        private readonly IProcedureService procedureService;
        private readonly IScheduleService scheduleService;
        private readonly IUserService userService;

        public AppointmentsController(IAppointmentService appointmentService, IEmployeeService employeeService, IProcedureService procedureService, IScheduleService scheduleService, IUserService userService)
        {
            this.appointmentService = appointmentService;
            this.employeeService = employeeService;
            this.procedureService = procedureService;
            this.scheduleService = scheduleService;
            this.userService = userService;
        }

        public IActionResult MyAppointments()
        {
            appointmentService.CheckForExpired();
            var userAppointments = appointmentService.GetUserAppointments(this.userService.GetUserId(this.User));

            return View(userAppointments);
        }

        public IActionResult Info(string id)
        {
            var userId = this.userService.GetUserId(this.User);

            if (!this.appointmentService.BelongsToUser(userId, id) && !this.userService.IsAdministrator(this.User))
            {
                return Unauthorized();
            }

            var appointmentInfoModel = this.appointmentService.GetAppointmentInfo(id);

            return View(appointmentInfoModel);
        }

        public IActionResult MakeAppointment(string id)
        {
            var appointmentViewModel = new AppointmentInputViewModel
            {
                ProcedureName = procedureService.GetProcedureName(id),
                Employees = employeeService
                    .GetEmployeesForSelect(id)
                    .ToList()
            };

            return View(appointmentViewModel);
        }

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

            if (appointmentDate.Date < DateTime.UtcNow.Date)
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

            if (appointmentDate == DateTime.UtcNow.Date && appointmentTime.TimeOfDay <= DateTime.Now.TimeOfDay)
            {
                this.ModelState.AddModelError(nameof(appointment.Time), ErrorConstants.InvalidTimePassed);
            }

            if (!employeeService.EmployeeExists(appointment.EmployeeId)
                || !employeeService.EmployeeCanDoProcedure(appointment.EmployeeId, id))
            {
                this.ModelState.AddModelError(nameof(appointment.EmployeeId), ErrorConstants.InvalidEmployee);
            }

            if (!this.ModelState.IsValid)
            {
                appointment.Employees = employeeService
                    .GetEmployeesForSelect(id)
                    .ToList();

                return View(appointment);
            }

            var employeeScheduleId = scheduleService
                .GetScheduleIdByEmployeeId(appointment.EmployeeId);

            appointmentService.CreateAppointment(employeeScheduleId, id,
                appointment.ClientName, this.userService.GetUserId(this.User), appointment.Description, appointmentDate, appointmentTime);

            return Redirect("/Appointments/MyAppointments");
        }

        public IActionResult ClientDecline(string id)
        {


            return View(new DeclineAppointmentViewModel { Id = id});
        }

        [HttpPost]
        public IActionResult ClientDecline(DeclineAppointmentViewModel appointmentModel)
        {
            appointmentService.DeclineAppointment(appointmentModel.Id, appointmentModel.Description);

            return Redirect($"/Appointments/MyAppointments");
        }

        public IActionResult EmployeeDecline(string id)
        {
            var userId = this.userService.GetUserId(this.User);

            if (!this.appointmentService.BelongsToUser(userId, id))
            {
                return Unauthorized();
            }

            return View(new DeclineAppointmentViewModel { Id = id });
        }

        [HttpPost]
        public IActionResult EmployeeDecline(DeclineAppointmentViewModel appointmentModel)
        {
            var userId = this.userService.GetUserId(this.User);

            if (!this.appointmentService.BelongsToUser(userId, appointmentModel.Id))
            {
                return Unauthorized();
            }

            appointmentService.DeclineAppointment(appointmentModel.Id, appointmentModel.Description);

            var scheduleId = scheduleService.GetScheduleIdByAppointmentId(appointmentModel.Id);

            return Redirect($"/Schedules/EmployeeSchedule/{scheduleId}");
        }

        public IActionResult Edit(string id)
        {
            var userId = this.userService.GetUserId(this.User);

            if (!this.appointmentService.BelongsToUser(userId, id) && !this.userService.IsAdministrator(this.User))
            {
                return Unauthorized();
            }

            var appointment = this.appointmentService.GetAppointmentForEdit(id);

            if (DateTime.Parse(appointment.Date).Date < DateTime.UtcNow.Date)
            {
                return Forbid();
            }

            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(AppointmentEditServiceModel appointment, string id)
        {
            var userId = this.userService.GetUserId(this.User);

            if (!this.appointmentService.BelongsToUser(userId, id) && !this.userService.IsAdministrator(this.User))
            {
                return Unauthorized();
            }

            if (!procedureService.ProcedureExists(appointment.ProcedureId))
            {
                this.ModelState.AddModelError(nameof(appointment.ProcedureName), ErrorConstants.InvalidProcedure);
            }

            if (!DateTime.TryParseExact(appointment.Date, "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime appointmentDate))
            {
                this.ModelState.AddModelError(nameof(appointment.Date), ErrorConstants.InvalidDate);
            }

            if (appointmentDate.Date < DateTime.UtcNow.Date)
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

            if (appointmentDate == DateTime.UtcNow.Date && appointmentTime.TimeOfDay <= DateTime.Now.TimeOfDay)
            {
                this.ModelState.AddModelError(nameof(appointment.Time), ErrorConstants.InvalidTimePassed);
            }

            if (!employeeService.EmployeeExists(appointment.EmployeeId)
                || !employeeService.EmployeeCanDoProcedure(appointment.EmployeeId, appointment.ProcedureId))
            {
                this.ModelState.AddModelError(nameof(appointment.EmployeeId), ErrorConstants.InvalidEmployee);
            }

            if (!this.ModelState.IsValid)
            {
                appointment.Employees = this.employeeService.GetEmployeesForSelect(appointment.ProcedureId);
                return View(appointment);
            }

            this.appointmentService.EditAppointment(id, appointment.ClientName, 
                            appointment.Description, appointmentDate, appointmentTime);

            return Redirect("/Appointments/MyAppointments");
        }

        public IActionResult UserDelete(string id)
        {
            var userId = this.userService.GetUserId(this.User);

            if (!this.appointmentService.BelongsToUser(userId, id)) 
            {
                return Unauthorized();
            }

            appointmentService.SetDeletedToUser(id, userId);

            return Redirect("/Appointments/MyAppointments");
        }

    }
}
