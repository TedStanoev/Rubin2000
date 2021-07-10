using Rubin2000.Models;
using System.Collections.Generic;

namespace Rubin2000.Services.ForEmployees
{
    public interface IEmployeeService
    {
        Employee GetEmployeeById(string id);

        Employee GetEmployeeByScheduleId(string scheduleId);

        IEnumerable<Employee> GetEmployees();

        IEnumerable<Employee> GetEmployeesWithOccupation();

        IEnumerable<Employee> GetEmployeesByProcedure(string procedureName);
    }
}
