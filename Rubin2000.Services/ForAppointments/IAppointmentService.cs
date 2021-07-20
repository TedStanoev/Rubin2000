using Rubin2000.Models;
using Rubin2000.Models.Enums;
using Rubin2000.Services.ForAppointments.Models;
using System;
using System.Collections.Generic;

namespace Rubin2000.Services.ForAppointments
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllAppointments();

        IEnumerable<Appointment> GetUserAppointments(string userId);

        IEnumerable<ScheduleAppointmentServiceModel> GetAppointmentsByScheduleId(string scheduleId);

        void CreateAppointment(Schedule schedule, Procedure procedure, AppUser client,
                                string description, DateTime date, DateTime time);

        Appointment GetAppointment(string id);

        void SetDeletedToUser(Appointment appointment);

        void ChangeAppointmentStatus(Appointment appointment, AppointmentStatus status);

        void ChangeDescription(Appointment appointment, string description);

        IEnumerable<AppointmentScheduleListServiceModel> GetAllAppointmentsForEmployeeSchedule();

        //void EditAppointment(Appointment appointment, Schedule schedule, Procedure procedure, AppUser client,
        //string description, DateTime date, DateTime time);
    }
}
