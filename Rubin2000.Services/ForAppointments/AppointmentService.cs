using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rubin2000.Services.ForAppointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly Rubin2000DbContext data;

        public AppointmentService(Rubin2000DbContext data)
            => this.data = data;

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
