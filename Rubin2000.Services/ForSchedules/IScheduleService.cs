using Rubin2000.Models;

namespace Rubin2000.Services.ForSchedules
{
    public interface IScheduleService
    {
        Schedule GetEmployeeScheduleWithAppointments(string scheduleId);
    }
}
