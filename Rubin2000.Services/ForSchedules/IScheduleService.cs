using Rubin2000.Models;
using Rubin2000.Services.ForSchedules.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForSchedules
{
    public interface IScheduleService
    {
        IEnumerable<EmployeeScheduleAppointmentServiceModel> GetEmployeeScheduleWithAppointments(string scheduleId);

        IEnumerable<EmployeeScheduleAppointmentServiceModel> GetEmployeeScheduleForToday(string scheduleId);

        string GetScheduleIdByEmployeeId(string employeeId);

        string GetScheduleIdByAppointmentId(string appointmentId);
    }
}
