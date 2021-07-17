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
            var appointment = appointmentService.GetAppointment(id);
            var client = userService.GetUserById(appointment.ClientId);
            var procedure = procedureService.GetProcedure(appointment.ProcedureId);
            var employee = employeeService.GetEmployeeByScheduleId(appointment.ScheduleId);
            var occupation = occupationService.GetEmployeeOccupation(employee.Id);

            var appointmentViewModel = new AppointmentInfoViewModel
            {
                Date = appointment.DateAndTime.Date.ToString(DateViewFormat),
                Time = appointment.DateAndTime.ToString(TimeViewFormat),
                Description = appointment.Description,
                ProcedureName = procedure.Name,
                EmployeeName = employee.Name,
                EmployeeOccupation = occupation.Name,
                Price = procedure.Price.ToString() + " BGN",
                ProcedureTime = procedure.Duration.ToString(),
                ClientFirstName = client.FirstName,
                ClientLastName = client.LastName,
                ClientGender = client.Gender.ToString(),
                ClientPhoneNumber = client.PhoneNumber
            };

            return View(appointmentViewModel);
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

            var procedure = procedureService.GetProcedure(id);

            var employeeSchedule = scheduleService
                .GetEmployeeScheduleByEmployeeId(appointment.EmployeeId);

            appointmentService.CreateAppointment(employeeSchedule, procedure, 
                this.userManager.GetUserAsync(this.User).Result, appointment.Description, appointmentDate, appointmentTime);

            return Redirect("/Appointments/MyAppointments");
        }

        public IActionResult Decline(string id)
        {
            var appointment = appointmentService.GetAppointment(id);

            var status = AppointmentStatus.Declined;

            appointmentService.ChangeAppointmentStatus(appointment, status);

            return Redirect($"/Appointments/MyAppointments");
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
