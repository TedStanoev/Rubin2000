using Rubin2000.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForEmployees
{
    public interface IEmployeeService
    {
        bool EmployeeExists(string id);

        Employee GetEmployeeById(string id);

        Employee GetEmployeeByScheduleId(string scheduleId);

        IEnumerable<Employee> GetEmployees();

        IEnumerable<Employee> GetEmployeesWithOccupation();

        IEnumerable<Employee> GetEmployeesByProcedure(string procedureId);

        bool EmployeeCanDoProcedure(string employeeId, string procedureId);
    }
}
