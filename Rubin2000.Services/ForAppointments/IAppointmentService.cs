using Rubin2000.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForAppointments
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllAppointments();

        IEnumerable<Appointment> GetUserAppointments(string userId);
    }
}
