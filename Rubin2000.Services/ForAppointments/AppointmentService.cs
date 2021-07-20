using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using Rubin2000.Models.Enums;
using Rubin2000.Services.ForAppointments.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using static Rubin2000.Global.GeneralConstants;

namespace Rubin2000.Services.ForAppointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly Rubin2000DbContext data;

        public AppointmentService(Rubin2000DbContext data)
            => this.data = data;

        public void ChangeAppointmentStatus(Appointment appointment, AppointmentStatus status)
        {
            this.data.Appointments.Remove(appointment);

            this.data.SaveChanges();

            appointment.Status = status;

            this.data.Appointments.Add(appointment);

            this.data.SaveChanges();
        }

        public void ChangeDescription(Appointment appointment, string description)
        {
            this.data.Appointments.Remove(appointment);

            this.data.SaveChanges();

            appointment.Description = description;

            this.data.Appointments.Add(appointment);

            this.data.SaveChanges();
        }

        public void CreateAppointment(Schedule schedule, Procedure procedure, AppUser client, string description, DateTime date, DateTime time)
        {
            var dateAndTime = date + time.TimeOfDay;

            var appointment = new Appointment
            {
                Description = description,
                DateAndTime = dateAndTime,
                ProcedureId = procedure.Id,
                ScheduleId = schedule.Id,
                ClientId = client.Id,
                Status = AppointmentStatus.Pending
            };

            this.data.Appointments.Add(appointment);

            this.data.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllAppointments()
            => this.data.Appointments
                .ToList();

        public IEnumerable<AppointmentScheduleListServiceModel> GetAllAppointmentsForEmployeeSchedule()
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointment(string id)
            => this.data.Appointments
                .Where(a => a.Id == id)
                .FirstOrDefault();

        public IEnumerable<ScheduleAppointmentServiceModel> GetAppointmentsByScheduleId(string scheduleId)
            => this.data.Schedules
                    .Include(s => s.Appointments)
                    .ThenInclude(a => a.Procedure)
                    .Where(s => s.Id == scheduleId)
                    .Select(a => new
                    {
                        a.Appointments
                    })
                    .FirstOrDefault()
                        .Appointments
                        .OrderBy(a => (int)a.Status)
                        .ThenBy(a => a.DateAndTime)
                        .Select(a => new ScheduleAppointmentServiceModel
                        {
                            AppointmentId = a.Id,
                            ProcedureName = a.Procedure.Name,
                            Date = a.DateAndTime.Date.ToString(DateViewFormat),
                            Time = a.DateAndTime.ToString(TimeViewFormat),
                            ClientId = a.ClientId,
                            Status = Enum.GetName(a.Status)
                        })
                        .ToList();

        public IEnumerable<Appointment> GetUserAppointments(string userId)
            => this.data.Appointments
                .Include(a => a.Procedure)
                .Include(a => a.Schedule)
                .ThenInclude(s => s.Employee)
                .Where(a => a.ClientId == userId)
                .ToList();

        public void SetDeletedToUser(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
