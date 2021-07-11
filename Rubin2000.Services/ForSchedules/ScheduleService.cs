using Microsoft.EntityFrameworkCore;
using Rubin2000.Data;
using Rubin2000.Models;
using System.Linq;

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

        public Schedule GetEmployeeScheduleWithAppointments(string scheduleId)
            => this.data.Schedules
                .Include(s => s.Appointments)
                .Where(s => s.Id == scheduleId)
                .FirstOrDefault();
    }
}
