using Rubin2000.Models;
using Rubin2000.Services.ForEmployees.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForEmployees
{
    public interface IEmployeeService
    {
        bool EmployeeExists(string id);

        IEnumerable<EmployeeSelectServiceModel> GetEmployeesForSelect(string procedureId);

        IEnumerable<EmployeeServiceModel> GetAllEmployeesWithSchedule();

        bool EmployeeCanDoProcedure(string employeeId, string procedureId);

        string GetEmployeeNameByScheduleId(string scheduleId);
    }
}
