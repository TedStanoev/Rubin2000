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
            var employeeName = this.employeeService.GetEmployeeByScheduleId(id).Name;
            var appointments = this.scheduleService.GetEmployeeScheduleWithAppointments(id);

            this.ViewBag.EmployeeName = employeeName;
            this.ViewBag.ScheduleId = id;

            return View(appointments);
        }

        public IActionResult All(string id)
        {
            var employeeName = this.employeeService.GetEmployeeByScheduleId(id).Name;
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
    }
}
