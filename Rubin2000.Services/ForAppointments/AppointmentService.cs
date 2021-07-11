using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Services.ForAppointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly Rubin2000DbContext data;

        public AppointmentService(Rubin2000DbContext data)
            => this.data = data;

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
                Status = Models.Enums.AppointmentStatus.Pending
            };

            this.data.Appointments.Add(appointment);

            this.data.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllAppointments()
            => this.data.Appointments
                .ToList();

        public IEnumerable<Appointment> GetUserAppointments(string userId)
            => this.data.Appointments
                .Include(a => a.Procedure)
                .Include(a => a.Schedule)
                .ThenInclude(s => s.Employee)
                .Where(a => a.ClientId == userId)
                .ToList();
    }
}
