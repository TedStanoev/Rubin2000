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

        IEnumerable<UserAppointmentServiceModel> GetUserAppointments(string userId);

        IEnumerable<AppointmentScheduleServiceModel> GetAppointmentsByScheduleId(string scheduleId);

        void CreateAppointment(string scheduleId, string procedureName, string clientName, string creatorId,
                                string description, DateTime date, DateTime time);

        void DeclineAppointment(string appointmentId, string appointmentDescription);

        void CheckForExpired();

        Appointment GetAppointment(string id);

        AppointmentEditServiceModel GetAppointmentForEdit(string id);

        AppointmentInfoServiceModel GetAppointmentInfo(string id);

        void SetDeletedToUser(string appointmentId, string userId);

        void ChangeAppointmentStatus(Appointment appointment, AppointmentStatus status);

        void ChangeDescription(Appointment appointment, string description);

        void EditAppointment(string appointmentId, string clientName, string description, DateTime date, DateTime time);

        bool BelongsToUser(string userId, string appointmentId);
    }
}
