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
using Rubin2000.Services.ForClients;
using Rubin2000.Services.ForOccupations;

using static Rubin2000.Global.GeneralConstants;

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
        private readonly IOccupationService occupationService;
        private readonly UserManager<AppUser> userManager;

        public AppointmentsController(IAppointmentService appointmentService, UserManager<AppUser> userManager, IEmployeeService employeeService, IProcedureService procedureService, IScheduleService scheduleService, IUserService userService, IOccupationService occupationService)
        {
            this.appointmentService = appointmentService;
            this.userManager = userManager;
            this.employeeService = employeeService;
            this.procedureService = procedureService;
            this.scheduleService = scheduleService;
            this.userService = userService;
            this.occupationService = occupationService;
        }

        public IActionResult MyAppointments()
        {
            var userAppointments = appointmentService.GetUserAppointments(this.userManager.GetUserId(this.User));

            var userAppointmentsViewModel = userAppointments
                .OrderByDescending(a => a.DateAndTime)
                .Select(a => new AppointmentClientViewModel
                {
                    ProcedureName = a.Procedure.Name,
                    AppointmentId = a.Id,
                    Date = a.DateAndTime.ToString(DateViewFormat),
                    Time = a.DateAndTime.ToShortTimeString(),
                    Status = Enum.GetName<AppointmentStatus>(a.Status)
                })
                .ToList();

            return View(userAppointmentsViewModel);
        }

        public IActionResult Info(string id)
        {
            var appointmentInfoModel = this.appointmentService.GetAppointmentInfo(id);

            return View(new AppointmentInfoViewModel 
            { 
                ClientName = appointmentInfoModel.ClientName,
                Date = appointmentInfoModel.Date,
                Time = appointmentInfoModel.Time,
                Status = appointmentInfoModel.Status,
                UserFirstName = appointmentInfoModel.UserFirstName,
                UserLastName = appointmentInfoModel.UserLastName,
                ClientPhoneNumber = appointmentInfoModel.ClientPhoneNumber,
                Description = appointmentInfoModel.Description,
                ProcedureName = appointmentInfoModel.ProcedureName,
                ProcedureTime = appointmentInfoModel.ProcedureTime,
                Price = appointmentInfoModel.Price,
                EmployeeName = appointmentInfoModel.EmployeeName,
                EmployeeOccupation = appointmentInfoModel.EmployeeOccupation,
                ScheduleId = appointmentInfoModel.ScheduleId
            });
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

            var employeeScheduleId = scheduleService
                .GetEmployeeScheduleByEmployeeId(appointment.EmployeeId).Id;

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
            var appointment = appointmentService.GetAppointment(appointmentModel.Id);

            var status = AppointmentStatus.Declined;

            appointmentService.ChangeAppointmentStatus(appointment, status);

            if (!string.IsNullOrWhiteSpace(appointmentModel.Description))
            {
                appointmentService.ChangeDescription(appointment, appointmentModel.Description);
            }

            return Redirect($"/Appointments/MyAppointments");
        }

        public IActionResult EmployeeDecline(string id)
        {
            return View(new DeclineAppointmentViewModel { Id = id });
        }

        [HttpPost]
        public IActionResult EmployeeDecline(DeclineAppointmentViewModel appointmentModel)
        {
            var appointment = appointmentService.GetAppointment(appointmentModel.Id);

            var status = AppointmentStatus.Declined;

            appointmentService.ChangeAppointmentStatus(appointment, status);

            if (!string.IsNullOrWhiteSpace(appointmentModel.Description))
            {
                appointmentService.ChangeDescription(appointment, appointmentModel.Description);
            }

            var scheduleId = appointment.ScheduleId;

            return Redirect($"/Schedules/EmployeeSchedule/{scheduleId}");
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
