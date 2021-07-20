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

        public void CreateAppointment(string scheduleId, string procedureId, string clientName, string creatorId, string description, DateTime date, DateTime time)
        {
            var dateAndTime = date + time.TimeOfDay;

            var appointment = new Appointment
            {
                ClientName = clientName,
                Description = description,
                DateAndTime = dateAndTime,
                ProcedureId = procedureId,
                ScheduleId = scheduleId,
                CreatorId = creatorId,
                Status = AppointmentStatus.Pending
            };

            this.data.Appointments.Add(appointment);

            this.data.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllAppointments()
            => this.data.Appointments
                .ToList();

        public Appointment GetAppointment(string id)
            => this.data.Appointments
                .Where(a => a.Id == id)
                .FirstOrDefault();

        public AppointmentInfoServiceModel GetAppointmentInfo(string id)
        {
            var appointment = this.GetAppointment(id);
            var user = (AppUser)this.data.Users.FirstOrDefault(u => u.Id == appointment.CreatorId);
            var procedure = this.data.Procedures.FirstOrDefault(p => p.Id == appointment.ProcedureId);
            var employee = this.data.Employees.FirstOrDefault(p => p.ScheduleId == appointment.ScheduleId);
            var occupationName = this.data.Occupations.FirstOrDefault(o => o.Id == employee.OccupationId).Name;

            return new AppointmentInfoServiceModel
            {
                Date = appointment.DateAndTime.Date.ToString(DateViewFormat),
                Time = appointment.DateAndTime.ToString(TimeViewFormat),
                Status = appointment.Status.ToString(),
                Description = appointment.Description,
                ProcedureName = procedure.Name,
                EmployeeName = employee.Name,
                EmployeeOccupation = occupationName,
                ScheduleId = employee.ScheduleId,
                Price = procedure.Price.ToString() + " BGN",
                ProcedureTime = procedure.Duration.ToString().Replace('_', ' '),
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                ClientPhoneNumber = user.PhoneNumber,
                ClientName = appointment.ClientName,
            };
        }

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
                            ClientName = a.ClientName,
                            CreatorId = a.CreatorId,
                            Status = Enum.GetName(a.Status)
                        })
                        .ToList();

        public IEnumerable<Appointment> GetUserAppointments(string userId)
            => this.data.Appointments
                .Include(a => a.Procedure)
                .Include(a => a.Schedule)
                .ThenInclude(s => s.Employee)
                .Where(a => a.CreatorId == userId)
                .ToList();

        public void SetDeletedToUser(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
