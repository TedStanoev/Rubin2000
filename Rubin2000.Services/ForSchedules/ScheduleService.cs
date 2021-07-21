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

        public Schedule GetEmployeeScheduleByEmployeeId(string employeeId)
            => this.data.Schedules
                .Where(s => s.EmployeeId == employeeId)
                .FirstOrDefault();

        public IEnumerable<EmployeeScheduleAppointmentServiceModel> GetEmployeeScheduleWithAppointments(string scheduleId)
        {
            var appointmentsInSchedule = this.data.Schedules
                .Where(s => s.Id == scheduleId)
                .Select(s => new
                {
                    Appointments = s.Appointments
                        .Where(a => a.DateAndTime.Date == DateTime.UtcNow.Date)
                        .OrderBy(a => (int)a.Status)
                        .ThenBy(a => a.DateAndTime)
                        .Select(a => new
                        {
                            AppointmentId = a.Id,
                            ProcedureName = a.Procedure.Name,
                            Date = a.DateAndTime.Date.ToString(DateViewFormat),
                            Time = a.DateAndTime.ToString(TimeViewFormat),
                            CreatorId = a.CreatorId,
                            CreatorName = a.Creator.FirstName,
                            ClientName = a.ClientName,
                            Status = a.Status.ToString()
                        })
                        .ToList()
                })
                .FirstOrDefault();

            return appointmentsInSchedule.Appointments
                    .Select(a => new EmployeeScheduleAppointmentServiceModel
                    {
                        AppointmentId = a.AppointmentId,
                        ProcedureName = a.ProcedureName,
                        Date = a.Date,
                        Time = a.Time,
                        ClientName = a.ClientName,
                        CreatorId = a.CreatorId,
                        CreatorName = a.CreatorName,
                        Status = a.Status
                    })
                    .ToList();
        }
    }
}
