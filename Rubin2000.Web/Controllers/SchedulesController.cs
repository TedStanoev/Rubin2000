using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rubin2000.Global;
using Rubin2000.Models.Enums;
using Rubin2000.Services.ForAppointments;
using Rubin2000.Services.ForClients;
using Rubin2000.Services.ForEmployees;
using Rubin2000.Services.ForProcedures;
using Rubin2000.Services.ForSchedules;
using Rubin2000.Web.Models.Appointments;
using Rubin2000.Web.Models.Employees;

using static Rubin2000.Global.GeneralConstants;

namespace Rubin2000.Web.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IProcedureService procedureService;
        private readonly IUserService userService;
        private readonly IScheduleService scheduleService;
        private readonly IAppointmentService appointmentService;

        public SchedulesController(IEmployeeService employeeService, IProcedureService procedureService, IUserService userService, IScheduleService scheduleService, IAppointmentService appointmentService)
        {
            this.employeeService = employeeService;
            this.procedureService = procedureService;
            this.userService = userService;
            this.scheduleService = scheduleService;
            this.appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var employeesViewModel = employeeService
                .GetEmployeesWithOccupation()
                .Select(e => new EmployeeScheduleViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    ScheduleId = e.ScheduleId,
                    Occupation = e.Occupation.Name
                });

            return View(employeesViewModel);
        }

        public IActionResult EmployeeSchedule(string id)
        {
            var employeeName = employeeService.GetEmployeeByScheduleId(id).Name;

            var schedule = scheduleService
                .GetEmployeeScheduleWithAppointments(id)
                .Appointments
                .Where(a => a.DateAndTime.Date == DateTime.UtcNow.Date)
                .OrderBy(a => (int)a.Status)
                .ThenBy(a => a.DateAndTime)
                    .Select(a => new AppointmentScheduleViewModel
                    {
                        AppointmentId = a.Id,
                        ProcedureName = procedureService.GetProcedure(a.ProcedureId).Name,
                        Date = a.DateAndTime.Date.ToString(DateViewFormat),
                        Time = a.DateAndTime.ToString(TimeViewFormat),
                        ClientId = a.ClientId,
                        ClientName = userService.GetUserById(a.ClientId).FirstName,
                        Status = Enum.GetName(a.Status)
                    })
                    .ToList();

            this.ViewBag.EmployeeName = employeeName;
            this.ViewBag.ScheduleId = id;

            return View(schedule);
        }

        public IActionResult All(string id)
        {
            var employeeName = employeeService.GetEmployeeByScheduleId(id).Name;
            var appointments = this.appointmentService.GetAppointmentsByScheduleId(id);

            this.ViewBag.EmployeeName = employeeName;
            this.ViewBag.ScheduleId = id;

            return View(appointments);
        }

        public IActionResult Approve(string id)
        {
            var appointment = appointmentService.GetAppointment(id);

            var status = AppointmentStatus.Approved;

            appointmentService.ChangeAppointmentStatus(appointment, status);

            var scheduleId = appointment.ScheduleId;

            return Redirect($"/Schedules/EmployeeSchedule/{scheduleId}");
        }

        public IActionResult Edit(string id)
        {
            var appointment = appointmentService.GetAppointment(id);

            var appointmentViewModel = new AppointmentInputViewModel
            {
                ProcedureName = procedureService.GetProcedure(appointment.ProcedureId).Name,
                Date = appointment.DateAndTime.Date.ToString("yyyy-MM-dd"),
                Time = appointment.DateAndTime.TimeOfDay.ToString(),
                Description = appointment.Description,
                Employees = employeeService.GetEmployeesByProcedure(appointment.ProcedureId).ToList()
            };

            return View(appointmentViewModel);
        }

        [HttpPut]
        public IActionResult Edit(AppointmentInputViewModel appointment, string id)
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
                View(appointment);
            }

            return Redirect($"/Schedules/EmployeeSchedule/{appointment}");
        }
    }
}
