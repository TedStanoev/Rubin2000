using Rubin2000.Models;
using Rubin2000.Models.Enums;
using Rubin2000.Services.ForAppointments.Models;
using System;
using System.Collections.Generic;

namespace Rubin2000.Services.ForAppointments
{
    public interface IAppointmentService
    {
        IEnumerable<UserAppointmentServiceModel> GetUserAppointments(string userId);

        IEnumerable<AppointmentScheduleServiceModel> GetAppointmentsByScheduleId(string scheduleId);

        void CreateAppointment(string scheduleId, string procedureName, string clientName, string creatorId,
                                string description, DateTime date, DateTime time);

        void ApproveAppointment(string appointmentId);

        void DeclineAppointment(string appointmentId, string appointmentDescription);

        void SetDeletedToUser(string appointmentId, string userId);

        void CheckForExpired();

        AppointmentEditServiceModel GetAppointmentForEdit(string id);

        AppointmentInfoServiceModel GetAppointmentInfo(string id);

        void ChangeAppointmentStatus(string appointmentId, AppointmentStatus status);

        void EditAppointment(string appointmentId, string clientName, string description, DateTime date, DateTime time);

        bool BelongsToUser(string userId, string appointmentId);

        bool AppointmentExists(string id);

        void DeleteAppointment(string id);
    }
}
