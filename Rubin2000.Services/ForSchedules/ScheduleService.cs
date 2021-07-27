using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using Rubin2000.Services.ForSchedules.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using static Rubin2000.Global.GeneralConstants;

namespace Rubin2000.Services.ForSchedules
{
    public class ScheduleService : IScheduleService
    {
        private readonly Rubin2000DbContext data;

        public ScheduleService(Rubin2000DbContext data)
        {
            this.data = data;
        }

        private Schedule GetEmployeeScheduleByEmployeeId(string employeeId)
            => this.data.Schedules
                .Where(s => s.EmployeeId == employeeId)
                .FirstOrDefault();

        public string GetScheduleIdByEmployeeId(string employeeId)
            => this.GetEmployeeScheduleByEmployeeId(employeeId).Id;

        public string GetScheduleIdByAppointmentId(string appointmentId)
            => this.data.Appointments.FirstOrDefault(a => a.Id == appointmentId).ScheduleId;

        public IEnumerable<EmployeeScheduleAppointmentServiceModel> GetEmployeeScheduleWithAppointments(string scheduleId)
            => this.data.Appointments
                .Where(a => a.ScheduleId == scheduleId)
                .OrderBy(a => (int)a.Status)
                .ThenBy(a => a.DateAndTime)
                .Select(a => new EmployeeScheduleAppointmentServiceModel
                {
                    AppointmentId = a.Id,
                    ProcedureName = a.Procedure.Name,
                    Date = a.DateAndTime.Date.ToString(DateViewFormat),
                    Time = a.DateAndTime.ToString(TimeViewFormat),
                    CreatorId = a.CreatorId,
                    CreatorName = a.Creator.FirstName,
                    ClientName = a.ClientName,
                    Status = a.Status.ToString(),
                })
                .ToList();

        public IEnumerable<EmployeeScheduleAppointmentServiceModel> GetEmployeeScheduleForToday(string scheduleId)
            => this.data.Appointments
                .Where(a => a.ScheduleId == scheduleId
                    && a.DateAndTime.Date == DateTime.UtcNow.Date)
                .OrderBy(a => (int)a.Status)
                .ThenBy(a => a.DateAndTime)
                .Select(a => new EmployeeScheduleAppointmentServiceModel
                {
                    AppointmentId = a.Id,
                    ProcedureName = a.Procedure.Name,
                    Date = a.DateAndTime.Date.ToString(DateViewFormat),
                    Time = a.DateAndTime.ToString(TimeViewFormat),
                    CreatorId = a.CreatorId,
                    CreatorName = a.Creator.FirstName,
                    ClientName = a.ClientName,
                    Status = a.Status.ToString(),
                })
                .ToList();
    }
}
